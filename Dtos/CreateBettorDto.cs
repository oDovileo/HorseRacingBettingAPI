using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Dtos
{
    public class CreateBettorDto
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Bet { get; set; }
        public int? HorseId { get; set; }
    }
}
