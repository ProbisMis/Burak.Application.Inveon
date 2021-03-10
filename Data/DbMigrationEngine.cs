using Burak.Application.Inveon.Utilities.ConfigModels;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Data
{
    public class DbMigrationEngine
    {
        public void MigrateUp(DataStorage dataStorage)
        {
            IServiceProvider serviceProvider = CreateServices(dataStorage.DataStorageType, dataStorage.ConnectionString);

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetService<IMigrationRunner>();

                runner.MigrateUp();
            }
        }

        public void MigrateDown(DataStorageTypes dbOptions, string connectionStrings, long toVersion)
        {
            IServiceProvider serviceProvider = CreateServices(dbOptions, connectionStrings);

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                runner.MigrateDown(toVersion);
            }
        }

        private IServiceProvider CreateServices(DataStorageTypes dbOptions, string dbConnectionString)
        {
            switch (dbOptions)
            {
                case DataStorageTypes.SqlServer:
                    return new ServiceCollection()
                        .AddFluentMigratorCore()
                        .ConfigureRunner(rb => rb
                            .AddSqlServer()
                            .WithGlobalConnectionString(dbConnectionString)
                            .ScanIn(typeof(DbMigrationEngine).Assembly).For.Migrations())
                        .AddLogging(lb => lb.AddFluentMigratorConsole())
                        .BuildServiceProvider(false);
                case DataStorageTypes.MySQL:
                    return new ServiceCollection()
                        .AddFluentMigratorCore()
                        .ConfigureRunner(rb => rb
                            .AddMySql5()
                            .WithGlobalConnectionString(dbConnectionString)
                            .ScanIn(typeof(DbMigrationEngine).Assembly).For.Migrations())
                        .AddLogging(lb => lb.AddFluentMigratorConsole())
                        .BuildServiceProvider(false);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dbOptions), dbOptions, null);
            }
        }
    }
}
