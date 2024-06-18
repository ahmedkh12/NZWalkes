using NZWalkes.API.Models;

namespace NZWalkes.API.Repositers
{
    public interface IWalksRpositery
    {
        Task<List<Walk>> GetAllAsync();

        Task<Walk?> GetByID(Guid? id);

        Task<Walk> Create(Walk walk);

        Task<Walk> Update(Guid id, Walk walk);

        Task<Walk> Delete(Guid id);
    }
}
