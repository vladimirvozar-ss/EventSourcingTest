using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcingTest.Contracts
{
    public static class SkiPasses
    {
        public static class V1
        {
            public class Create
            {
                public Guid Id { get; set; }
                public string SkiPassName { get; set; }
            }

            public class UpdateName
            {
                public Guid Id { get; set; }
                public string SkiPassName { get; set; }
            }

            public class UpdateDefault
            {
                public Guid Id { get; set; }
                public bool IsDefault { get; set; }
            }
        }
    }
}
