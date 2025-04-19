


namespace MoviesAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Genre> genres { get; set; }
        public DbSet<Movie> movies { get; set; }

    }

}
