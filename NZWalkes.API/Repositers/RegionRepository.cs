using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalkes.API.data;
using NZWalkes.API.Models;

namespace NZWalkes.API.Repositers
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _context;

        public RegionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegionModel> Create(RegionModel regionModel)
        {
            await _context.AddAsync(regionModel);
            await _context.SaveChangesAsync();
            return regionModel;
        }

        public async Task<RegionModel> Delete(Guid id)
        {
            var regionDomain = await _context.Regions.FindAsync(id);

            _context.Regions.Remove(regionDomain);
            await _context.SaveChangesAsync();

            return regionDomain;
        }

        public async Task<List<RegionModel>> GetAllAsync()
        {
           return await _context.Regions.ToListAsync();
        }

        public async Task<RegionModel?> GetByID(Guid? id)
        {
          
                return await _context.Regions.FindAsync(id);
     
        }

        public async Task<RegionModel?> Update(Guid id, RegionModel regionModel)
        {
            var RegionDomainRecord = await _context.Regions.FindAsync(id);

            if (RegionDomainRecord == null)
            {
                return null;
            }
             
            RegionDomainRecord.Name = regionModel.Name;
            RegionDomainRecord.Code = regionModel.Code;
            RegionDomainRecord.RegionImageUrl   = regionModel.RegionImageUrl;
            await _context.SaveChangesAsync();
            return RegionDomainRecord;
        }
    }
}
