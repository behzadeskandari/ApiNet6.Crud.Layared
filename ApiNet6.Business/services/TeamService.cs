using ApiNet6.Common.Dtos.Team;
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
    public class TeamService : ITeamService
    {

        public IGenericRepository<Team> TeamRepository { get; }
        public IGenericRepository<Employee> EmployeeRepository { get; }
        public IMapper Mapper { get; }

        public TeamService(IGenericRepository<Team> teamRepository, IGenericRepository<Employee> employeeRepository,IMapper mapper)
        {
            TeamRepository = teamRepository;
            EmployeeRepository = employeeRepository;
            Mapper = mapper;
        }

        public async Task<int> CreateTeamAsync(TeamCreate teamCreate)
        {
            Expression<Func<Employee, bool>> employeeFilter = (employee) => teamCreate.Employee.Contains(employee.Id);
            var employee = await EmployeeRepository.GetFilteredAysnc(new[] { employeeFilter }, null, null);
            var entity = Mapper.Map<Team>(teamCreate);
            entity.Employees = employee;
            await TeamRepository.InsertAsync(entity);
            await TeamRepository.SaveChangesAsync();
            return entity.Id;

        }

        public async Task DeleteTeamAsync(TeamDelete teamDelete)
        {
            var entity = await TeamRepository.GetByIdAsync(teamDelete.Id);
            TeamRepository.Delete(entity); ;
            await TeamRepository.SaveChangesAsync();
        }

        public async Task<TeamGet> GetTeamAsync(int id)
        {
            var entity = await TeamRepository.GetByIdAsync(id, (team) => team.Employees);

            return Mapper.Map<TeamGet>(entity);
        }

        public async Task<List<TeamGet>> GetTeamsAsync()
        {

            var entities = await TeamRepository.GetAysnc(null, null, (team) => team.Employees);
            return Mapper.Map<List<TeamGet>>(entities);

        }

        public async Task UpdateTeamAsync(TeamUpdate teamUpdate)
        {
            Expression<Func<Employee, bool>> employeeFilter = (employee) => teamUpdate.Employees.Contains(employee.Id);
            var employee = await EmployeeRepository.GetFilteredAysnc(new[] { employeeFilter }, null, null);
            var existingEntity = await TeamRepository.GetByIdAsync(teamUpdate.Id, (team) => team.Employees);
            Mapper.Map(teamUpdate, existingEntity);
            existingEntity.Employees = employee;
            TeamRepository.Update(existingEntity);
            await TeamRepository.SaveChangesAsync();
        }


    }
}
