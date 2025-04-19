namespace MoviesAPI.Servcies
{
    public interface IGenersService
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> Add(Genre genre);
        Genre Update(Genre genre);
        Genre Delete(Genre genre);
        Task<Genre> GetByID(byte id);
        Task<bool> ValidateGenre(byte id);




    }
}
