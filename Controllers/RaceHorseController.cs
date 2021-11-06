using HorseRacingBettingAPI.Dtos;
using HorseRacingBettingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceHorseController : ControllerBase
    {

        private readonly RaceHorseService _horseService;
        private object createHorseDto;

        public RaceHorseController(RaceHorseService horseService)
        {
            _horseService = horseService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _horseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _horseService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHorseDto createHorseDto)
        {
            await _horseService.CreateAsync(createHorseDto);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHorseDto updateHorseDto)
        {
            await _horseService.UpdateAsync(updateHorseDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _horseService.DeleteAsync(id);
            return NoContent();
        }

    }
}
