using Example.Application.Contracts;
using Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infrastructure.Persistence.FakeRepository
{
    public class FakeDeveloperRepository : IDeveloperRepository
    {
        List<Developer> developers = new List<Developer>();

        public FakeDeveloperRepository()
        {
            developers.Add(new Developer() { Id = new DeveloperId(1), Name = "Cezary Walenciuk", Status = DeveloperStatus.Rejected });
            developers.Add(new Developer() { Id = new DeveloperId(2), Name = "Ada Stefa", Status = DeveloperStatus.Accepted });
            developers.Add(new Developer() { Id = new DeveloperId(3), Name = "Asasa EEE", Status = DeveloperStatus.New });
        }


        public async Task<DeveloperId> AddAsync(Developer Developer)
        {
            await Task.Delay(500);
            Developer.Id = new DeveloperId(developers.Count());
            developers.Add(Developer);

            return Developer.Id;
        }

        public async Task DeleteAsync(DeveloperId id)
        {
            await Task.Delay(500);
            var dev = developers.FirstOrDefault(ad => ad.Id.Value == id.Value);
            developers.Remove(dev);
        }

        public async Task<Developer> GetByIdAsync(DeveloperId id)
        {
            await Task.Delay(500);
            return developers.FirstOrDefault(ad => ad.Id.Value == id.Value);
        }

        public async Task<IReadOnlyList<Developer>> GetCollectionAsync()
        {
            await Task.Delay(500);
            return developers.ToList();
        }

        public async Task UpdateAsync(Developer Developer)
        {

            await Task.Delay(500);
            var dev = developers.FirstOrDefault(ad => ad.Id.Value == Developer.Id.Value);
            developers.Remove(dev);
            developers.Add(Developer);
        }
    }
}
