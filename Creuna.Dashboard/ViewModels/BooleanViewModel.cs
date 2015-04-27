using System;

namespace Creuna.Dashboard.ViewModels
{
    public class BooleanViewModel : DataPointViewModel
    {
        public BooleanViewModel(string key, DateTime dateTime, bool value)
            : base(key, dateTime)
        {
            Value = value;
        }

        public bool Value { get; private set; }
    }
}