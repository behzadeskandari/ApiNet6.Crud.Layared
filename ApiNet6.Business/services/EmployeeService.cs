using ApiNet6.Common.Dtos.Employee;
using ApiNet6.Common.Interfaces;
using ApiNet6.Common.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiNet6.Business.services
{
    public class EmployeeService : IEmployeeService
    {

        public IMapper Mapper { get; }
        public IGenericRepository<Employee> EmployeeRepository { get; }
        public IGenericRepository<Job> JobRepository { get; }
        public IGenericRepository<Address> AddressRepository { get; }

        public EmployeeService(IMapper mapper, IGenericRepository<Employee> employeeRepository,IGenericRepository<Job> jobRepository,IGenericRepository<Address> addressRepository)
        {
            Mapper = mapper;
            EmployeeRepository = employeeRepository;
            JobRepository = jobRepository;
            AddressRepository = addressRepository;
        }

        public async Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate)
        {
            var address = await AddressRepository.GetByIdAsync(employeeCreate.AddressId);
            var job = await JobRepository.GetByIdAsync(employeeCreate.JobId);
            
            var entity = Mapper.Map<Employee>(employeeCreate);
            entity.job = job;
            entity.Address = address;
            
            await EmployeeRepository.InsertAsync(entity);
            await EmployeeRepository.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteEmployeeAsync(EmployeeDelete employeeDelete)
        {
            var entity = await EmployeeRepository.GetByIdAsync(employeeDelete.id);
            EmployeeRepository.Delete(entity);
            await EmployeeRepository.SaveChangesAsync();
        }

        public async Task<EmployeeDetails> GetEmployeeAsync(int id)
        {
            var entity = await EmployeeRepository
                .GetByIdAsync(id, 
                (employee) => employee.Address, 
                (employee)=> employee.job,
                (employee) => employee.Teams);

            return Mapper.Map<EmployeeDetails>(entity);
        }

        public async Task<List<EmployeeList>> GetEmployeesAsync(EmployeeFilter employeeFilter)
        {
            Expression<Func<Employee, bool>> firstNameFilter = (employee) => employeeFilter.FirstName == null ? true :
            employee.FirstName.StartsWith(employeeFilter.FirstName);

            Expression<Func<Employee, bool>> lastNameFilter = (employee) => employeeFilter.LastName == null ? true :
           employee.LastName.StartsWith(employeeFilter.LastName);

            Expression<Func<Employee, bool>> jobFilter = (employee) => employeeFilter.Job == null ? true :
           employee.job.Name.StartsWith(employeeFilter.Job);

            Expression<Func<Employee, bool>> teamFilter = (employee) => employeeFilter.Team == null ? true :
           employee.Teams.Any(x => x.Name.StartsWith(employeeFilter.Team));

            var enteties = await EmployeeRepository.GetFilteredAysnc(new Expression<Func<Employee, bool>>[]
            {
                firstNameFilter, lastNameFilter, jobFilter,teamFilter
            }, employeeFilter.Skip,employeeFilter.Take,
                (employee) => employee.Address,
                (employee) => employee.job,
                (employee) => employee.Teams);

            return Mapper.Map<List<EmployeeList>>(enteties);
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate)
        {
            var address = await AddressRepository.GetByIdAsync(employeeUpdate.AddressId);
            var job = await JobRepository.GetByIdAsync(employeeUpdate.JobId);

            var entity = Mapper.Map<Employee>(employeeUpdate);

            entity.job = job;
            entity.Address = address;

            EmployeeRepository.Update(entity);
            await EmployeeRepository.SaveChangesAsync();

        }
    }
}
