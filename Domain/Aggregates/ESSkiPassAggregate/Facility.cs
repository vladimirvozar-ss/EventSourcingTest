using Domain.Infrastructure;
using System;

namespace Domain.Aggregates.ESSkiPassAggregate
{
    public class Facility : Entity<FacilityId>
    {
        public SkiPassId ParentId { get; private set; }
        public FacilityName Name { get; private set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.FacilityAddedToSkiPass e:
                    ParentId = new SkiPassId(e.SkiPassId);
                    Id = new FacilityId(e.FacilityId);
                    Name = new FacilityName(e.Name);
                    break;
                case Events.FacilityNameChanged e:
                    ParentId = new SkiPassId(e.SkiPassId);
                    Id = new FacilityId(e.FacilityId);
                    Name = new FacilityName(e.Name);
                    break;
            }
        }

        public Facility(Action<object> applier) : base(applier)
        {
        }
    }

    public class FacilityId : Value<FacilityId>
    {
        public Guid Value { get; }

        public FacilityId(Guid value) => Value = value;
    }
}
