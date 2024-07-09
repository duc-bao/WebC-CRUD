using Microsoft.EntityFrameworkCore;
using WebC_CRUD.Data;
using WebC_CRUD.Model.Entity;

namespace WebC_CRUD.Repository
{
    public class SQLRegionRepository : IRepository
    {   
        private readonly ApplicationDbContext dbContext;
        public SQLRegionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;    
        }

        public async Task<Region> CreateRegion(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegion(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null) {
                return null;
            }
            dbContext.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionById(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateRegion(Guid id, Region region)
        {
            var existsRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existsRegion == null) { 
            return null;
            }
            existsRegion.Name = region.Name;
            existsRegion.RegionImageUrl = region.RegionImageUrl;
            existsRegion.Code = region.Code;
            await dbContext.SaveChangesAsync();
            return existsRegion;
        }
    }
}
