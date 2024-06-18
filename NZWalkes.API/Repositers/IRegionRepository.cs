using NZWalkes.API.Models;
using System.Drawing;

namespace NZWalkes.API.Repositers
{
    public interface IRegionRepository
    {
        Task<List<RegionModel>> GetAllAsync();

        Task<RegionModel?> GetByID(Guid? id);

        Task<RegionModel> Create (RegionModel regionModel);

        Task<RegionModel> Update(Guid id,RegionModel regionModel);

        Task<RegionModel> Delete(Guid id);
    }
}
