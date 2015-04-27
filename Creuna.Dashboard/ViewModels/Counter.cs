using System;

namespace Creuna.Dashboard.ViewModels
{
    public sealed class CounterViewModel : DataPointViewModel
    {
        public CounterViewModel(string key, DateTime dateTime, long value) : base(key, dateTime)
        {
            Value = value;
        }

        public long Value { get; private set; }
    }
}