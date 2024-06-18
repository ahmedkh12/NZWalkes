using System.ComponentModel.DataAnnotations;

namespace NZWalkes.API.Models
{
    public class RegionModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string? RegionImageUrl { get; set; }
        

    }
}
