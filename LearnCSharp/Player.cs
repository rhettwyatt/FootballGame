using System;
using System.Collections.Generic;
using System.Text;

namespace FootballGame
{
    class Player
    {
        public string Team { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Num { get; set; }
        public int TotYards { get; set; }

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
    }
}
