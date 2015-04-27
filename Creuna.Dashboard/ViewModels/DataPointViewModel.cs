using System;

namespace Creuna.Dashboard.ViewModels
{
    public abstract class DataPointViewModel
    {
        protected DataPointViewModel(string key, DateTime timestamp)
        {
            Key = key;
            Timestamp = timestamp;
        }

        public string Key { get; private set; }
        public DateTime Timestamp { get; set; }
    }
}