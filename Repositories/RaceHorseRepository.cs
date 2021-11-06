using HorseRacingBettingAPI.Data;
using HorseRacingBettingAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Repositories
{
    public class RaceHorseRepository
    {
        private readonly DataContext _context;

        public RaceHorseRepository(DataContext context)
        {
            _context = context;
        }

        internal async Task<List<RaceHorseModel>> GetAllAsync()
        {
            return await _context.RaceHorses.Include(d => d.RaceBettors).ToListAsync();
        }

        public async Task<RaceHorseModel> GetById(int id)
        {
            return await _context.RaceHorses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(RaceHorseModel horse)
        {
            _context.Add(horse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RaceHorseModel horse)
        {
            _context.Remove(horse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RaceHorseModel horse)
        {
            _context.Update(horse);
            await _context.SaveChangesAsync();
        }
    }
}
