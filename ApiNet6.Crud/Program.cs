namespace ApiNet6.Crud
{
    public class Program
    {

        public static void Main(string[] args)
        {
            


            var host = CreateHostBuilder(args).Build();
            CreateIfNotExists(host);

            //MigrateAysnc(host);
            host.Run();
        }

        //private static async Task MigrateAysnc(IHost host)
        //{
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        var loogerFactory = services.GetRequiredService<ILoggerFactory>();
        //        try
        //        {
        //            var context = services.GetRequiredService<StoreDbContext>();
        //            await context.Database.MigrateAsync();
        //            context.Database.EnsureCreated();
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = loogerFactory.CreateLogger<Program>();
        //            logger.LogError(ex, "Migrations Error");
        //        }
        //    }
        //}


        private static void CreateIfNotExists(IHost host)
        {

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                });
    }

}