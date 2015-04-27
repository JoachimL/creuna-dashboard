using Creuna.Dashboard.Entities;

namespace Creuna.Dashboard.Repositories
{
    public interface IDataPointStore
    {
        void StoreDataPoint<T>(DataPoint<T> dataPoint);

        void IncrementCounter(string key);
    }
}
