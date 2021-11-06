using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRacingBettingAPI.Entities
{
    public class RaceHorseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Runs { get; set; }
        public int Wins { get; set; }
        public string About { get; set; }
        public List<RaceBettorModel> RaceBettors { get; set; }
    }
}
