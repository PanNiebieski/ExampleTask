using Example.Domain;

namespace Example.Application.Contracts
{
    public interface IDeveloperRepository
    {
        Task<IReadOnlyList<Developer>> GetCollectionAsync();

        Task<Developer> GetByIdAsync(DeveloperId id);

        Task<DeveloperId> AddAsync(Developer Developer);

        Task UpdateAsync(Developer Developer);

        Task DeleteAsync(DeveloperId id);

        //

    }
}