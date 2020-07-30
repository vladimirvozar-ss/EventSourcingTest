using System;

namespace Domain.Infrastructure
{
    public interface ISkiPassLookupService
    {
        bool SkiPassNameExists(string skiPassName);
        bool CanBeSetAsDefault(Guid skiPassId);
    }

    public class FixedSkiPassLookupService : ISkiPassLookupService
    {
        public bool SkiPassNameExists(string skiPassName)
        {
            // assuming that SkiPass with name "Standard" already exists
            // calling external service here, to check if there exists already SkiPass with the "Standard" name
            if (skiPassName.Equals("Standard"))
            {
                return true;
            }

            return false;
        }

        public bool CanBeSetAsDefault(Guid skiPassId)
        {
            // validate if this SkiPass can be set to be default
            return true;
        }
    }
}
