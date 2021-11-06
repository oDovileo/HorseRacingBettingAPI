using HorseRacingBettingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Dtos
{
    public class UpdateHorseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Runs { get; set; }
        public int Wins { get; set; }
        public string About { get; set; }
       
    }
}
