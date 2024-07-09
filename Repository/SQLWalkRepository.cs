using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebC_CRUD.Data;
using WebC_CRUD.Model.DTO.Request;
using WebC_CRUD.Model.Entity;

namespace WebC_CRUD.Repository
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SQLWalkRepository(ApplicationDbContext applicationDbContext) {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
                await applicationDbContext.Walks.AddAsync(walk);
                await applicationDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteWalkByIdAsync(Guid id)
        {
            var existsWalk = await applicationDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existsWalk == null) {
                return null;
            }
             applicationDbContext.Remove(existsWalk);
            await applicationDbContext.SaveChangesAsync();
            return existsWalk;

        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await applicationDbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            var walk = await applicationDbContext.Walks
                .Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null) {
                return null;
            };
            return walk;
        }

        public async Task<Walk?> UpdateWalkAsync(Walk walk, Guid id)
        {
           var existsWalk = await applicationDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existsWalk == null) {
                return null;
            }
            existsWalk.Name = walk.Name;
            existsWalk.Description = walk.Description;
            existsWalk.LengthKm = walk.LengthKm;
            existsWalk.RegionId = walk.RegionId;
            existsWalk.DifficultyId = walk.DifficultyId;
            existsWalk.WalkImageUrl = walk.WalkImageUrl;
            await applicationDbContext.SaveChangesAsync();
            return existsWalk;
        }
    }
}
