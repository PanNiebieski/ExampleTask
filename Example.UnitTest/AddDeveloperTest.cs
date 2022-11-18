using Example.Application.Contracts;
using Example.Application.CQRS.Developers.Command.AddDeveloper;
using Example.Application.CQRS.Developers.Command.UpdateDeveloper;
using Example.Infrastructure.Persistence.FakeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.UnitTest
{
    public class UpdateDeveloperTest
    {
        private readonly IDeveloperRepository _fakeRepo;

        public UpdateDeveloperTest()
        {
            _fakeRepo = new FakeDeveloperRepository();
        }

        [Fact]
        public async Task Handle_UpdateDeveloper_NewDataInThatDeveloper()
        {
            var handler = new UpdateDeveloperCommandHandler
                (_fakeRepo);

            var id = new Domain.DeveloperId(1);
            var before = (await _fakeRepo.GetByIdAsync(id));


            var command = new UpdateDeveloperCommand()
            {
                Developer = new Domain.Developer()
                {
                    Id = id,
                    Name = "A",
                    Status = Domain.DeveloperStatus.Rejected
                }
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var after = await _fakeRepo.GetByIdAsync((id)); ;

            Assert.NotSame(before.Name, after.Name);

        }
    }
}
