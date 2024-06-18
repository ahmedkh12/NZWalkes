using System.ComponentModel.DataAnnotations;

namespace NZWalkes.API.Models
{
    public class WalkDifficulty
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
    }
}
