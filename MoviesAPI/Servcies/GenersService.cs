using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Servcies
{
    public class GenersService : IGenersService
    {
        private readonly ApplicationDbContext _dbContext;

        public GenersService( ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public async Task<Genre> Add(Genre genre)
        {
            
            await _dbContext.genres.AddAsync(genre);
            _dbContext.SaveChanges();
            return genre;

        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            
            return await _dbContext.genres.OrderBy(c => c.Name).ToListAsync();

        }

        public async Task<Genre> GetByID(byte id)
        {

            return await  _dbContext.genres.SingleOrDefaultAsync(c => c.Id == id);
        }

       

       public Genre Delete(Genre genre)
        {
            _dbContext.genres.Remove(genre);
            _dbContext.SaveChanges();
            return genre;

        }

        public Genre Update(Genre genre)
        {
            _dbContext.genres.Update(genre);
            _dbContext.SaveChanges();
            return genre;

        }

        public async Task<bool> ValidateGenre(byte id)
        {
            return await _dbContext.genres.AnyAsync(g => g.Id == id);
        }
    }
}
