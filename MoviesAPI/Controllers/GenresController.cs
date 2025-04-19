using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTOs;
using MoviesAPI.Servcies;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenersService _genersService;

        public GenresController(IGenersService genersService)
        {
            _genersService = genersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var gernres = await _genersService.GetAll();
            return Ok(gernres);


        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateGenreDto dto)
        {
            var genre = new Genre { Name = dto.Name };
            _genersService.Add(genre);

            return Ok(genre);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] CreateGenreDto dto)
        {
            var genre = await _genersService.GetByID(id);
            if(genre == null)
            {
                return NotFound($"No Genre With Found ID : {id}");
            }
            _genersService.Update(genre);
            return Ok(genre);



        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var genre = await _genersService.GetByID(id);
            if (genre == null)
            {
                return NotFound($"No Genre With Found ID : {id}");
            }
            _genersService.Delete(genre);
            return Ok(genre);


        }
    }

}