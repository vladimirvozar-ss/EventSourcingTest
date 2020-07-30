using Domain.Infrastructure;
using System;

namespace Domain.Aggregates.ESSkiPassAggregate
{
    public class SkiPassDefault : Value<SkiPassDefault>
    {
        public bool Value { get; }

        public SkiPassDefault(bool value) => Value = value;

        public static implicit operator bool(SkiPassDefault isDefault) =>
            isDefault.Value;

        private static void CheckValidityToSetAsDefault(SkiPassId skiPassId, ISkiPassLookupService skiPassLookup)
        {
            // calling external domain service, checking if this SkiPass can be set to default
            // rule: there should always be one default SkiPass
            var canBeSetAsDefault = skiPassLookup.CanBeSetAsDefault(skiPassId);

            if (!canBeSetAsDefault)
            {
                throw new ArgumentException($"Cannot set this SkiPass as default");
            }
        }
    }
}
