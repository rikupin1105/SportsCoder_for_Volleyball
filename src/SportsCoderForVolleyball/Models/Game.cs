using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCoderForVolleyball.Models
{
    internal class Game
    {
        public List<Set> Sets = new List<Set>();
    }
    public class Set
    {
        public int ATeamPoint { get; set; }
        public int BTeamPoint { get; set; }

        public int ATeamTimeOut { get; set; }
        public int BTeamTimeOut { get; set; }

        public int ATeamAttackPoint { get; set; }
        public int BTeamAttackPoint { get; set; }

        public int ATeamBlockPoint { get; set; }
        public int BTeamBlockPoint { get; set; }

        public int ATeamServePoint { get; set; }
        public int BTeamServePoint { get; set; }

        public int ATeamServeError { get; set; }
        public int BTeamServeError { get; set; }

        public int ATeamError { get; set; }
        public int BTeamError { get; set; }
    }
}
