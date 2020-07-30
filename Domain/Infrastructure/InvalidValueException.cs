using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(Type type, string message)
            : base($"Value of {type.Name} {message}")
        {
        }
    }
}
