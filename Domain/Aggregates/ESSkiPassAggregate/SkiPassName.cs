using Domain.Infrastructure;
using System;

namespace Domain.Aggregates.ESSkiPassAggregate
{
    public class SkiPassName : Value<SkiPassName>
    {
        public string Value { get; }

        internal SkiPassName(string value) => Value = value;

        public static implicit operator string(SkiPassName self) => self.Value;

        public SkiPassName(string skiPassName, ISkiPassLookupService skiPassLookup)
        {
            // check for null value
            if (string.IsNullOrEmpty(skiPassName))
            {
                throw new ArgumentNullException(nameof(skiPassName), "SkiPass Name must be specified");
            }

            // validate "name"
            if (skiPassName.Length > 100)
            {
                throw new ArgumentOutOfRangeException("SkiPass Name cannot be longer that 100 characters", nameof(skiPassName));
            }

            // domain service call, checking if given SkiPass name is already taken
            var skiPassNameExists = skiPassLookup.SkiPassNameExists(skiPassName);

            if (skiPassNameExists)
            {
                throw new ArgumentException($"SkiPass Name <{skiPassName}> already exists");
            }

            Value = skiPassName;
        }

        // Satisfy the serialization requirements 
        protected SkiPassName() { }
    }
}
