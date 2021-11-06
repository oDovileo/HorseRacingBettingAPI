using HorseRacingBettingAPI.Dtos;
using HorseRacingBettingAPI.Entities;
using HorseRacingBettingAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Services
{
    public class RaceHorseService
    {
        private RaceHorseRepository _horseRepository;

        public RaceHorseService(RaceHorseRepository horseRepository)
        {
            _horseRepository = horseRepository;
        }
        public async Task<List<RaceHorseModel>> GetAllAsync()
        {
            return await _horseRepository.GetAllAsync();
        }

        public async Task<RaceHorseModel> GetByIdAsync(int id)
        {
            var company = await _horseRepository.GetById(id);
            if (company == null)
            {
                throw new ArgumentException("Race horse not found");
            }
            return company;
        }

        public async Task DeleteAsync(int id)
        {
            var dish = await GetByIdAsync(id);
            await _horseRepository.DeleteAsync(dish);
        }

        public async Task CreateAsync(CreateHorseDto createHorseDto)
        {
            var entity = new RaceHorseModel
            {
                
                Name = createHorseDto.Name,
                Runs = createHorseDto.Runs,
                Wins = createHorseDto.Wins,
                About = createHorseDto.About

            };

            await _horseRepository.CreateAsync(entity);
        }

        internal Task UpdateAsync(object updatehorseDto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateHorseDto updateHorseDto)
        {
            RaceHorseModel entity = new RaceHorseModel
            {
                Id = updateHorseDto.Id,
                Name = updateHorseDto.Name,
                Runs = updateHorseDto.Runs,
                Wins = updateHorseDto.Wins,
                About = updateHorseDto.About
            };

            await _horseRepository.UpdateAsync(entity);

        }

    }
}
