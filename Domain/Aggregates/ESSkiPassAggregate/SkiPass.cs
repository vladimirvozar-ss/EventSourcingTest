using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using static Domain.Aggregates.ESSkiPassAggregate.Events;

namespace Domain.Aggregates.ESSkiPassAggregate
{
    public class SkiPass : AggregateRoot<SkiPassId>
    {
        public SkiPassName Name { get; private set; }
        public SkiPassDefault IsDefault { get; private set; }
        public List<Facility> Facilities { get; private set; }

        public SkiPass(SkiPassId id, SkiPassName skiPassName, SkiPassDefault defaultSkiPass)
        {
            Facilities = new List<Facility>();
            Apply(new SkiPassCreated
            {
                Id = id,
                Name = skiPassName
            });
        }

        public void UpdateName(SkiPassName skiPassName)
        {
            Apply(new SkiPassNameChanged
            {
                Id = Id,
                Name = skiPassName
            });
        }

        public void UpdateDefault(SkiPassDefault skiPassDefault)
        {
            Apply(new UpdatedDefault
            {
                Id = Id,
                IsDefault = skiPassDefault
            });
        }

        public void AddFacility(FacilityName facilityName)
        {
            Apply(new FacilityAddedToSkiPass
            {
                SkiPassId = Id,
                FacilityId = new Guid(), // externally generated 
                Name = facilityName
            });
        }

        protected override void When(object @event)
        {
            Facility facility;

            switch (@event)
            {
                case SkiPassCreated e:
                    Id = new SkiPassId(e.Id);
                    Name = new SkiPassName(e.Name);
                    Facilities = new List<Facility>();
                    break;
                case SkiPassNameChanged e:
                    Name = new SkiPassName(e.Name);
                    break;
                case UpdatedDefault e:
                    IsDefault = new SkiPassDefault(e.IsDefault);
                    break;

                // facility
                case FacilityAddedToSkiPass e:
                    facility = new Facility(Apply);
                    ApplyToEntity(facility, e);
                    Facilities.Add(facility);
                    break;
                case FacilityNameChanged e:
                    facility = FindFacility(new FacilityId(e.FacilityId));
                    ApplyToEntity(facility, @event);
                    break;
            }
        }

        private Facility FindFacility(FacilityId id)
        {
            return Facilities.FirstOrDefault(x => x.Id == id);
        }

        protected override void EnsureValidState()
        {
            var valid = (Id != null) && !string.IsNullOrEmpty(Name);

            if (!valid)
                throw new DomainExceptions.InvalidEntityState(this, $"Post-checks failed");
        }
    }
}
