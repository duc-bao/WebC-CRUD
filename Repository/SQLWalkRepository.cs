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

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null
            ,string? sortBy = null, bool isAccending = true, int pageNumber = 1, int pageSize = 10
            )  
        {
            var walk =  applicationDbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase)) { 
                    walk = walk.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if(string.IsNullOrWhiteSpace(sortBy) == false){
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) { 
                walk = isAccending ? walk.OrderBy(x => x.Name) : walk.OrderByDescending(x =>x.Name);
                }else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walk = isAccending ? walk.OrderBy(x => x.LengthKm):walk.OrderByDescending(x => x.LengthKm);
                }
            }

            // Pagination
            var skipResult = (pageNumber - 1) *pageSize;
            return await walk.Skip(skipResult).Take(pageSize).ToListAsync();
            //return await applicationDbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
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
