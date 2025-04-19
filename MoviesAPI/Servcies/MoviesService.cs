using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Servcies
{
    public class MoviesService : IMoviesService

    {
        private readonly ApplicationDbContext _dbContext;
        public MoviesService(ApplicationDbContext dbContext) {
            _dbContext= dbContext;
        }
      

        public Movie DeleteMovie(Movie movie)
        {
            _dbContext.Remove(movie);
            _dbContext.SaveChanges();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies(byte genreid=0)
        {

            return await _dbContext.movies
                 .Where(m=>m.GenreId==genreid || genreid==0)
                .OrderByDescending(m => m.Rate)
                .Include(g => g.genre)
                .ToListAsync();
        }

        public async  Task<Movie> GetMovieById(int id)
        {
            return await _dbContext.movies.Include(g => g.genre).SingleOrDefaultAsync(m => m.Id == id);
        }

        public Movie UpdateMovie(Movie movie)
        {
            _dbContext.Update(movie);
            _dbContext.SaveChanges();
            return movie;

        }

       public async Task<Movie> AddMovie(Movie movie)
        {
             await _dbContext.movies.AddAsync(movie);
            _dbContext.SaveChanges();
            return movie;
        }
    }
}
