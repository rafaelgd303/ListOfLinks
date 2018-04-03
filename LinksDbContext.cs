using webdev.Models;
using Microsoft.EntityFrameworkCore;


namespace ListOfLinks
{
    public class LinkDbContext : DbContext
    {
        public LinkDbContext(DbContextOptions<LinkDbContext> options): base (options)
        {

        
        }
        public DbSet<Link> Links { get; set; } 
        
    }
}