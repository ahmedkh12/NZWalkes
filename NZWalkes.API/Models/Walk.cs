using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace NZWalkes.API.Models
{
    public class Walk
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        // Navigation Properties
        public RegionModel Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
