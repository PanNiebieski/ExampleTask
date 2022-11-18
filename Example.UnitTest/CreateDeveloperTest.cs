using Example.Application.Contracts;
using Example.Application.CQRS.Developers.Command.AddDeveloper;
using Example.Infrastructure.Persistence.FakeRepository;
using Shouldly;

namespace Example.UnitTest
{
    public class CreateDeveloperTest
    {
        private readonly IDeveloperRepository _fakeRepo;

        public CreateDeveloperTest()
        {
            _fakeRepo = new FakeDeveloperRepository();
        }

        [Fact]
        public async Task Handle_ValidDeveloper_AddedToPostRepo()
        {
            var handler = new AddDeveloperCommandHandler
                (_fakeRepo);

            var alldevBeforeCount = (await _fakeRepo.GetCollectionAsync()).Count;

            var command = new AddDeveloperCommand()
            {
                Name = "Test",
                Status = Domain.DeveloperStatus.New
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allDev = await _fakeRepo.GetCollectionAsync();

            response.Success.ShouldBe(true);
            response.ValidationErrors.Count.ShouldBe(0);
            allDev.Count.ShouldBe(alldevBeforeCount + 1);
            response.Id.ShouldNotBeNull();
        }
    }
}