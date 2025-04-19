namespace MoviesAPI.DTOs
{
    public class CreateGenreDto
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
