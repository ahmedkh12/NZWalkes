using Microsoft.EntityFrameworkCore;
using NZWalkes.API.data;
using NZWalkes.API.Models;

namespace NZWalkes.API.Repositers
{
    public class WalksRpositery : IWalksRpositery
    {
        private readonly ApplicationDbContext _context;

        public WalksRpositery(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Walk> Create(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> Delete(Guid id)
        {
            var walk = await _context.Walks.FindAsync(id);
             _context.Walks.Remove(walk);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _context.Walks.Include("Region").Include("WalkDifficulty").ToListAsync();
        }

        public async Task<Walk?> GetByID(Guid? id)
        {
            var walk = await _context.Walks.FindAsync(id);
            return walk;
        }

        public async Task<Walk> Update(Guid id, Walk walk)
        {
            var oldwalk = await _context.Walks.FindAsync(id);

            oldwalk.Name = walk.Name;
            oldwalk.WalkDifficultyId = walk.WalkDifficultyId;
            oldwalk.RegionId = walk.RegionId;   

            return oldwalk;
        }
    }
}
