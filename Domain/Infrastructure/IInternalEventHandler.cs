namespace Domain.Infrastructure
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}
