using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceValidation.util
{
    public class KeyValue<T>
    {
        public string KeyName { get; set; }

        public T value { get; set; }
    }
}
