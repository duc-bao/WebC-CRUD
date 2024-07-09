using WebC_CRUD.Model.Entity;

namespace WebC_CRUD.Repository
{
    public interface IRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetRegionById(Guid id);
        Task<Region> CreateRegion(Region region);
        Task<Region?> UpdateRegion(Guid id,Region region);
        Task<Region?> DeleteRegion(Guid id);
    }
}
