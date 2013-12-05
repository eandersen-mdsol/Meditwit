using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediTwit.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Twit> Twits { get; set; }

    }
}