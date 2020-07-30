using Domain.Infrastructure;
using System;

namespace Domain.Aggregates.ESSkiPassAggregate
{
    public class FacilityName : Value<FacilityName>
    {
        public string Value { get; internal set; }

        public FacilityName(string name)
        {
            // check for null value
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Facility Name must be specified");
            }

            // validate "name"
            if (name.Length > 100)
            {
                throw new ArgumentOutOfRangeException("Facility Name cannot be longer that 100 characters", nameof(name));
            }

            Value = name;
        }

        public static implicit operator string(FacilityName self) => self.Value;
    }
}
