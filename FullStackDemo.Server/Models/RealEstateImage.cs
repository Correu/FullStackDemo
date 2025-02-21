using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackDemo.Server.Models
{
    [Table("realEstateImage")]
    public class RealEstateImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public required string image { get; set; }
    }

    public class RealEstateImageContext : DbContext
    {
        public RealEstateImageContext(DbContextOptions<RealEstateImageContext> options)
            : base(options)
        {
        }

        public DbSet<RealEstateImage> RealEstateImage { get; set; } = null!;
    }
}
