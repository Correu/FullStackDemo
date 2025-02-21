using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackDemo.Server.Models
{
    [Table("userTypes")]
    public class UserTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string typeName { get; set; }
    }

    public class UserTypesContext : DbContext
    {
        public UserTypesContext(DbContextOptions<UserTypesContext> options)
            : base(options)
        {
        }

        public DbSet<UserTypes> UserTypes { get; set; } = null!;
    }
}
