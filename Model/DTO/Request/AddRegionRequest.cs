using System.ComponentModel.DataAnnotations;

namespace WebC_CRUD.Model.DTO.Request
{
    public class AddRegionRequest
    {
        [Required]
        [MinLength(1, ErrorMessage = "Code has to be minium of 3 character")]
        public string Code { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Code has to be maxium of 20 character")]
        public string Name { get; set; }
           
        public string? RegionImageUrl { get; set; }
    }
}
