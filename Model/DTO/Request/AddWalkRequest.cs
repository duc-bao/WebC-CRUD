using WebC_CRUD.Model.Domain;
using WebC_CRUD.Model.Entity;

namespace WebC_CRUD.Model.DTO.Request
{
    public class AddWalkRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficulityId { get; set; }
        public Guid RegionId { get; set; }
        // navigation property

    }
}
