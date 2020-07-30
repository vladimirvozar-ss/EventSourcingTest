using System.Threading.Tasks;

namespace Domain.Infrastructure
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}
