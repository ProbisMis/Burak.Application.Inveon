using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Utilities.ConfigModels
{
    public class DataStorageSection
    {
        public List<DataStorage> DataStorageCollection { get; set; } = new List<DataStorage>();
        public DataStorageTypes SelectedDataStorageType { get; set; }
    }

    public class DataStorage
    {
        public DataStorageTypes DataStorageType { get; set; }
        public string DataStorageName { get; set; }
        public string ConnectionString { get; set; }
    }

    public enum DataStorageTypes
    {
        SqlServer = 1,
        MySQL = 2
    }
}
