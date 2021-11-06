using HorseRacingBettingAPI.Dtos;
using HorseRacingBettingAPI.Entities;
using HorseRacingBettingAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Services
{
    public class RaceBettorService
    {

        private ReceBettorRepository _bettorRepository;
        private RaceHorseRepository _horseRepository;
        public RaceBettorService(ReceBettorRepository raceBettorRepository, RaceHorseRepository horseRepository)
        {
            _bettorRepository = raceBettorRepository;
            _horseRepository = horseRepository;
        }
        public async Task<List<UpdateBettorDto>> GetAllAsync()
        {

            var employeeEntities = await _bettorRepository.GetAsync();
            var dtos = employeeEntities.Select(b => new UpdateBettorDto()
            {
                Id = b.Id,
                Name = b.Name,
                Surname =b.Surname,
                Bet = b.Bet,
                HorseId = b.HorseId


            });

            return dtos.ToList();
        }

        public async Task<RaceBettorModel> GetByIdAsync(int id)
        {
            return await _bettorRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(CreateBettorDto createBettorDto)
        {
            var entity = new RaceBettorModel()
            {
                Name = createBettorDto.Name,
                Surname = createBettorDto.Surname,
                Bet = createBettorDto.Bet,
                HorseId = createBettorDto.HorseId
            };


            if (createBettorDto.HorseId.HasValue)
            {
                var better = await _horseRepository.GetById(createBettorDto.HorseId.Value);
                if (better == null)
                {
                    throw new ArgumentException("Race bettor does not exist");
                }
            }

            await _bettorRepository.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var bettor = await GetByIdAsync(id);
            await _bettorRepository.DeleteAsync(bettor);
        }

        public async Task UpdateAsync(UpdateBettorDto updateBettorDto)
        {
            RaceBettorModel entity = new RaceBettorModel
            {   
                Id = updateBettorDto.Id,
                Name = updateBettorDto.Name,
                Surname = updateBettorDto.Surname,
                Bet = updateBettorDto.Bet,
                HorseId = updateBettorDto.HorseId


            };

            await _bettorRepository.UpdateAsync(entity);

        }
    }
}
