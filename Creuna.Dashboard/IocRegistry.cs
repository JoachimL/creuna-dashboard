using System.Configuration;
using Creuna.Dashboard.Repositories;
using Microsoft.WindowsAzure.Storage;
using StructureMap.Configuration.DSL;

namespace Creuna.Dashboard
{
    class IocRegistry : Registry
    {
        public IocRegistry()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("datapoints");
            table.CreateIfNotExists();

            For<IDataPointStore>().Singleton().Use(() => new AzureTableDataPointStore(table));
        }
    }
}
