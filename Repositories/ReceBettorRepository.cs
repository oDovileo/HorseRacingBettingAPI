using HorseRacingBettingAPI.Data;
using HorseRacingBettingAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Repositories
{
    public class ReceBettorRepository
    {
        private readonly DataContext _context;

        public ReceBettorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<RaceBettorModel>> GetAsync()
        {
            return await _context.RaceBettors.ToListAsync();
        }

        public async Task<RaceBettorModel> GetByIdAsync(int id)
        {
            return await _context.RaceBettors.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task AddAsync(RaceBettorModel bettor)
        {
            _context.Add(bettor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RaceBettorModel bettor)
        {
            _context.Remove(bettor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RaceBettorModel bettor)
        {
            _context.Update(bettor);
            await _context.SaveChangesAsync();
        }
    }
}
