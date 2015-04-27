using System;
using Creuna.Dashboard.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace Creuna.Dashboard.Repositories
{
    public class AzureTableDataPointStore : IDataPointStore
    {
        private readonly CloudTable _table;

        public AzureTableDataPointStore(CloudTable table)
        {
            _table = table;
        }

        public void StoreDataPoint<T>(DataPoint<T> dataPoint)
        {
            _table.Execute(TableOperation.Insert(dataPoint));
        }

        public void IncrementDailyCounter(string key, DateTime date)
        {
            var rowKey = date.ToUniversalTime().ToString("yyyy-MM-dd");
            var retrieveOperation = TableOperation.Retrieve<DataPoint<long>>(key, rowKey);
            var retrievedResult = _table.Execute(retrieveOperation);
            var counter = retrievedResult.Result as DataPoint<long>;
            if (counter == null)
                StoreDataPoint(new DataPoint<long>
                {
                    PartitionKey = key,
                    RowKey = rowKey,
                    Value = 1
                });
            else
            {
                counter.Value = counter.Value + 1;
                TableOperation updateOperation = TableOperation.Replace(counter);
                _table.Execute(updateOperation);
            }
        }
    }
}