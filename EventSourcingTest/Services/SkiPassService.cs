using Domain.Aggregates.ESSkiPassAggregate;
using Domain.Infrastructure;
using EventSourcingTest.Infrastructure;
using System;
using System.Threading.Tasks;
using static EventSourcingTest.Contracts.SkiPasses;

namespace EventSourcingTest.Services
{
    public class SkiPassService : IApplicationService
    {
        private readonly ISkiPassLookupService _skiPassLookupService;
        private readonly IAggregateStore _store;
        private FixedSkiPassLookupService _fixedSkiPassLookupService;

        public SkiPassService(IAggregateStore store, ISkiPassLookupService skiPassLookupService)
        {
            _skiPassLookupService = skiPassLookupService;
            _store = store;
        }

        public SkiPassService(EsAggregateStore store, FixedSkiPassLookupService fixedSkiPassLookupService)
        {
            _store = store;
            _fixedSkiPassLookupService = fixedSkiPassLookupService;
        }

        public Task Handle(object command)
        {
            return command switch
            {
                V1.Create cmd =>
                    HandleCreate(cmd),

                _ => Task.CompletedTask
            };
        }

        private async Task HandleCreate(V1.Create cmd)
        {
            if (await _store.Exists<SkiPass, SkiPassId>(new SkiPassId(cmd.Id)))
            {
                throw new InvalidOperationException($"Entity with id {cmd.Id} already exists");
            }

            var skiPass = new SkiPass(
                new SkiPassId(cmd.Id),
                new SkiPassName(cmd.SkiPassName, _skiPassLookupService),
                new SkiPassDefault(true)
            );

            await _store.Save<SkiPass, SkiPassId>(skiPass);
        }
    }
}
