using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame
{
    class RunningBack : Player
    {
        public RunningBack(string team, string first, string last, int num) : base(team, first, last, num)
        {

        }

        public override string ToString()
        {
            return $"{this.First} {this.Last}, #{this.Num}, is the running back for the {this.Team}";
        }
    }
}
