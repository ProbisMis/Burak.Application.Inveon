using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Burak.Application.Inveon.Data;
using Burak.Application.Inveon.Utilities.Constants;
using Burak.Application.Inveon.Utilities.Helper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace Burak.Application.Inveon
{
    public class Program
    {
        private static string appSettingsFile = "./appsettings.json";

        public static void Main(string[] args)
        {
            Logger logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            try
            {
                var config = new ConfigurationBuilder()
                                            .AddJsonFile(appSettingsFile, optional: false)
                                            .Build();

                logger.Info($"{AppConstants.SolutionName}.Api trigger migration");
                RunMigration(config);

                logger.Info($"{AppConstants.SolutionName}.Api is starting");
                var webHost = BuildWebHost(args, config);

                webHost.Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex);
            }
            finally
            {
                logger.Info($"{AppConstants.SolutionName}.Api is shutting down");
                LogManager.Shutdown();
            }
        }

        private static void RunMigration(IConfigurationRoot config)
        {
            var dataStorage = ConfigurationHelper.GetDataStorage(config);
            var dbMigrationEngine = new DbMigrationEngine();
            //dbMigrationEngine.MigrateDown(DataStorageTypes.SqlServer, dataStorage.ConnectionString, 1);
            dbMigrationEngine.MigrateUp(dataStorage);
        }

        private static IWebHost BuildWebHost(string[] args, IConfiguration c)
        {
            var urls = c.GetSection("AspNetCoreUrls").Get<string[]>();

            return WebHost.CreateDefaultBuilder(args)
                          .UseStartup<Startup>()
                          .ConfigureAppConfiguration((hostingContext, config) =>
                          {
                              config.SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile(appSettingsFile, false);
                          })
                          .UseUrls(urls)
                          .UseNLog()
                          .Build();
        }
    }
}

