using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame
{
    class Player
    {
        private int yards;
        public string Team { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Num { get; set; }
        public int TotYards { get; private set; }

        public Player(string team, string first, string last, int num)
        {
            Team = team;
            First = first;
            Last = last;
            Num = num;

            Console.WriteLine(this.ToString());
        }

        public Player()
        {
            Console.WriteLine("New Player");
            Console.Write("Team Name:");
            this.Team = Console.ReadLine();
            Console.Write("First Name:");
            this.First = Console.ReadLine();
            Console.Write("Last Name:");
            this.Last = Console.ReadLine();
            Console.Write("Number:");
            this.Num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"{this.First} {this.Last} is number {this.Num} on the {this.Team}";
        }

        public int RunBall()  //eventually split this into a plays class with pass, punt, kick.
        {
            Random rnd = new Random();
            yards = rnd.Next(-1, 11);
            TotYards += yards;
            return yards;
        }

        public bool Drive()
        {
            int down = 1;
            int downYards = 0; //yards per the current set of 3 downs (punt on 4th)
            while (this.TotYards < 80 && (down % 4 != 0))  // the drive -> make this into a method
            {
                int yards;
                int toGo;

                yards = this.RunBall();
                downYards += yards;
                toGo = 10 - downYards;

                if (toGo <= 0)  // move the chains
                {
                    Console.WriteLine($"After a {this.First} {this.Last} run of {yards} yards on down {down}, the {this.Team} move the chains.");
                    down = 1;
                    downYards = 0;
                }
                else  // next down
                {
                    Console.WriteLine($"After a {this.First} {this.Last} run of {yards} yards on down {down}, the {this.Team} need {toGo} yards for a 1st Down.");
                    down++;
                }

                System.Threading.Thread.Sleep(1000);
            }

            if (this.TotYards > 80)
            {
                Console.WriteLine($"Touchdown {this.Last}!");
                return true;
            }
            else
            {
                Console.WriteLine($"Turnover on downs");
                return false;
            }
        }
    }
}
