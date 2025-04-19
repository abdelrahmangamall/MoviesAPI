namespace MoviesAPI.Servcies
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetAllMovies(byte genreid=0);
        Task<Movie> GetMovieById(int id);
        /*Task<IEnumerable<Movie>> GetMovieByGenreId(byte id);
        Task<Movie> ValidateMovie(byte id);*/
        Task<Movie> AddMovie(Movie movie);
        //Task<Movie> UpdateById(int id);
        Movie UpdateMovie(Movie movie);
        Movie DeleteMovie(Movie movie);




    }
}
