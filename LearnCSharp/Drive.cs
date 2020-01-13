using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame
{
    class Drive
    {
        private int yards;
        private string runOrPass;
        public int RushYards { get; set; }
        public int PassYards { get; set; }
        public int TotalYards { get; set; }


        public Drive()
        {
            RushYards = 0;
            PassYards = 0;
            TotalYards = 0;
            //add the yard marker to assist with punts and kicks
        }
        
        public int RunBall(Player player)  //eventually split this into a plays class with pass, punt, kick.
        {
            //int yards;
            Random rnd = new Random();
            yards = rnd.Next(-1, 11);
            RushYards += yards;
            TotalYards += yards;
            player.TotYards += yards;
            return yards;
        }

        public int PassBall(Player player)
        {
            //int yards;
            Random rnd = new Random();
            yards = rnd.Next(2, 7);  //need to weigh this and add chance of drops
            PassYards += yards;
            TotalYards += yards;
            player.TotYards += yards;
            return yards;
        }

        // add punt and kick

        public bool Sequence(Player player)
        {
            int down = 1;
            int downYards = 0; //yards per the current set of 3 downs (punt on 4th)
            
            int toGo;

            while (this.TotalYards < 80 && (down % 4 != 0))  // the drive -> make this into a method
            {
                //int yards;

                //pass or run 50-50 chance
                Random rnd = new Random();
                if (rnd.Next(0, 2) > 0)
                {
                    yards = this.PassBall(player);
                    runOrPass = "pass for";
                }
                else
                {
                    yards = this.RunBall(player);
                    runOrPass = "run of";
                }

                downYards += yards;
                toGo = 10 - downYards;

                if (toGo <= 0)  // move the chains
                {
                    Console.WriteLine($"After a {player.First} {player.Last} {runOrPass} {yards} yards on down {down}, the {player.Team} move the chains.");
                    down = 1;
                    downYards = 0;
                }
                else  // next down
                {
                    Console.WriteLine($"After a {player.First} {player.Last} {runOrPass} {yards} yards on down {down}, the {player.Team} need {toGo} yards for a 1st Down.");
                    down++;
                }

                System.Threading.Thread.Sleep(1000);
            }

            if (this.TotalYards > 80)
            {
                Console.WriteLine($"Touchdown {player.Last}! A drive for {this.TotalYards} yards was topped off with a {runOrPass} {this.yards} yards.\n");
                return true;
            }
            else
            {
                Console.WriteLine($"Turnover on downs. A drive for {this.TotalYards} yards was stopped on a {runOrPass} {this.yards} yards.\n");
                return false;
            }
        }
    }
}
