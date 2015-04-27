using Microsoft.WindowsAzure.Storage.Table;

namespace Creuna.Dashboard.Entities
{
    public class DataPoint : TableEntity
    {
        public string Value { get; set; }
        public string OriginatingIp { get; set; }
    }
}