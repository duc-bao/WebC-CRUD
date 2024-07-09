namespace WebC_CRUD.Model.DTO.Request
{
    public class AddRegionRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
