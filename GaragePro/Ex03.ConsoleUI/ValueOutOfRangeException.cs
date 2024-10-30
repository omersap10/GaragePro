
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; }
        public float MaxValue { get; }

        public ValueOutOfRangeException(float minValue, float maxValue)
            : base($"Value is out of range. Valid range: {minValue} to {maxValue}.")
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
