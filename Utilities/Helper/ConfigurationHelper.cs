using Burak.Application.Inveon.Utilities.ConfigModels;
using Burak.Application.Inveon.Utilities.Constants;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Utilities.Helper
{
    public class ConfigurationHelper
    {
        public static DataStorage GetDataStorage(IConfiguration configuration)
        {
            var dataStorageList = configuration.GetSection(AppConstants.DataStorageSection).Get<DataStorageSection>();

            if (dataStorageList == null)
            {
                throw new ApplicationException($"{nameof(DataStorageSection)} is null");
            }

            if (!Enum.IsDefined(typeof(DataStorageTypes), dataStorageList.SelectedDataStorageType))
            {
                throw new ApplicationException($"{dataStorageList.SelectedDataStorageType} is not defined data storage type");
            }

            DataStorage dataStorage = dataStorageList.DataStorageCollection.FirstOrDefault(storage => storage.DataStorageType == dataStorageList.SelectedDataStorageType);

            if (dataStorage == null)
            {
                throw new ApplicationException($"DataStorageList does not contains {dataStorageList.SelectedDataStorageType}");
            }

            return dataStorage;
        }
    }
}
