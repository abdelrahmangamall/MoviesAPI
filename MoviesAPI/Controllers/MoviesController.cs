using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Servcies;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly IGenersService _genersService;
        private readonly IMapper _mapper;
        List<string> AllowExtenstion = new List<string> { ".jpg", ".png" };
        long MaxSizeAllowed = 1048576;
        public MoviesController( IMoviesService moviesService, IGenersService genersService, IMapper mapper)
        {
            _moviesService = moviesService;
            _genersService = genersService;
            _mapper = mapper;

        }
     
        [HttpGet]
        public async Task<IActionResult> GetAllMovie()
        {
            var movie = await _moviesService.GetAllMovies();
            //TODO: Map Movie To DTO
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movie); 
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieByID(int id)
        {
            var movie = await _moviesService.GetMovieById(id);
            if (movie == null)
            {
                return BadRequest($"No Movie Get By ID :{id}");
            }
            var dto = _mapper.Map<MovieDetailsDto>(movie);
            return Ok(dto);
        }
        [HttpGet("{genreid}")]//for get
        public async Task<IActionResult> GetGenreID(byte genreid)
        {
            var movie =await _moviesService.GetAllMovies(genreid);
            //TODO: Map Movie To DTO
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movie);

            return Ok(data);
        }
        
    

        [HttpPost]//for create
        public async Task <IActionResult> CreateMovieAsyc([FromForm]CreateMovieDto dto)
        {
          if(!AllowExtenstion.Contains(Path.GetExtension(dto.Poster.FileName).ToLower())) {
                return BadRequest("Only .png .jpg Are Allowed");

            }
          if(dto.Poster.Length> MaxSizeAllowed)
            {
                return BadRequest("Max Allowed Size 1MB ");
            }
            var validGenre = await _genersService.ValidateGenre(dto.GenreId);
            if (!validGenre)
            {
                return BadRequest("Invalid Genre ID");

            }


            var datastream =new MemoryStream();
            await dto.Poster.CopyToAsync(datastream);
            var movie = _mapper.Map<Movie>(dto);
            movie.Poster=datastream.ToArray();

            
            await _moviesService.AddMovie(movie);
            return Ok(movie);


        }

        [HttpPut("{id}")] //for Update
        public async Task<IActionResult> UpdateMovieAsync(int id,[FromForm]CreateMovieDto dto)
        {
            var movie = await _moviesService.GetMovieById(id);
            if (movie == null)
            {
                return BadRequest($"No Movie With found with ID :{id}");
            }
            var validGenre = await _genersService.ValidateGenre(dto.GenreId);
            if (!validGenre)
            {
                return BadRequest("Invalid Genre ID");

            }
          
            if(dto.Poster!=null)
            {
                if (!AllowExtenstion.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                {
                    return BadRequest("Only .png .jpg Are Allowed");

                }
                if (dto.Poster.Length > MaxSizeAllowed)
                {
                    return BadRequest("Max Allowed Size 1MB ");
                }
                var datastream = new MemoryStream();
                await dto.Poster.CopyToAsync(datastream);

                movie.Poster = datastream.ToArray();
            }
            movie.Title = dto.Title;
            movie.Year = dto.Year;
            movie.StoryLine = dto.StoryLine;
            movie.Rate = dto.Rate;
            movie.GenreId = dto.GenreId;

            _moviesService.UpdateMovie(movie);
            return Ok(movie);   




        }

        [HttpDelete("Id")]//for delete
        public async Task  <IActionResult> DeleteMovieAsync(int id)
        {
            var movie = await _moviesService.GetMovieById(id);
            if(movie == null) {
                return BadRequest($"No movie with ID {id}");
            }
            _moviesService.DeleteMovie(movie);
            return Ok(movie);

        }
        
    }
}
