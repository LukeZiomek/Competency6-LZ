using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Competency5.Data.DAL
{
    public class AssetsPageDAL
    {
        // Constructor
        private readonly ApplicationDbContext _context;
        public AssetsPageDAL(ApplicationDbContext context) 
        {
            _context = context;
        }

        // Get all
        public async Task<List<Asset>> GetAllAsync()
        {
            // Get all and return list sorted by name
            return await _context.Assets.OrderBy(o=>o.AssetName).ToListAsync();
        }

        // Get specific
        public async Task<Asset> GetSpecifcAsync(Guid id)
        {
            var retrivedAsset = await _context.Assets.Where(ast=>ast.ID == id).FirstOrDefaultAsync();
            return retrivedAsset;
        }

        // Add asset
        public async Task AddAsync(Asset newAsset)
        {
            _context.Assets.Add(newAsset);
            await _context.SaveChangesAsync();
        }

        // Update asset
        public async Task UpdateAsync(Asset updated)
        {
            _context.Assets.Update(updated);
            await _context.SaveChangesAsync();
        }

        // Delete asset
        public async Task RemoveAsync(Asset targetAsset)
        {
            _context.Assets.Remove(targetAsset);
            await _context.SaveChangesAsync();
        }
    }
}
