using Domain.Infrastructure;
using System;

namespace Domain.Aggregates.ESSkiPassAggregate
{
    public class SkiPassId : Value<SkiPassId>
    {
        public Guid Value { get; }

        public SkiPassId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "SkiPass id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(SkiPassId self) => self.Value;

        public static implicit operator SkiPassId(string value)
            => new SkiPassId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
