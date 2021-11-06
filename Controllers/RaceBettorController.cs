using HorseRacingBettingAPI.Dtos;
using HorseRacingBettingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceBettorController : ControllerBase
    {
        private readonly RaceBettorService _raceBettorService;

        public RaceBettorController(RaceBettorService raceBettorService)
        {
            _raceBettorService = raceBettorService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _raceBettorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var bettor = await _raceBettorService.GetByIdAsync(id);
            if (bettor == null)
            {
                return NotFound();
            }
            return Ok(bettor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBettorDto bettor)
        {

            return Ok(await _raceBettorService.AddAsync(bettor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _raceBettorService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBettorDto bettor)
        {
            await _raceBettorService.UpdateAsync(bettor);
            return NoContent();
        }
    }
}
