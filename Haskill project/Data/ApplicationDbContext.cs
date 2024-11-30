using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Haskill_project.Models;

namespace Haskill_project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Haskill_project.Models.Month> Month { get; set; } = default!;
        public DbSet<Haskill_project.Models.Category> Category { get; set; } = default!;
        public DbSet<Haskill_project.Models.Food> Food { get; set; } = default!;
        public DbSet<Haskill_project.Models.Price> Price { get; set; } = default!;
        public DbSet<Haskill_project.Models.Product> Product { get; set; } = default!;
    }
}
