using System;

namespace Domain.Aggregates.ESSkiPassAggregate
{
    public static class Events
    {
        public class SkiPassCreated
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class SkiPassNameChanged
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class UpdatedDefault
        {
            public Guid Id { get; set; }
            public bool IsDefault { get; set; }
        }

        public class FacilityAddedToSkiPass
        {
            public Guid SkiPassId { get; set; }
            public Guid FacilityId { get; set; }
            public string Name { get; set; }
        }

        public class FacilityNameChanged
        {
            public Guid SkiPassId { get; set; }
            public Guid FacilityId { get; set; }
            public string Name { get; set; }
        }
    }
}
