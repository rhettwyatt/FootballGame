using System;
using System.Collections.Generic;

namespace FootballGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player s1 = new Player("Titans", "King", "Henry", 22);
            Player s2 = new Player("Cheifs", "Patrick", "Mahomes", 15);
            //Player s2 = new Player();  // user inputs a player

            List<Drive> DrivesHome = new List<Drive>();
            List<Drive> DrivesAway = new List<Drive>();

            while (true)  //first to score
            {
                Drive dH = new Drive();
                DrivesHome.Add(dH);
                if (dH.Sequence(s1))
                {

                    break;
                }

                Drive dA = new Drive();
                DrivesAway.Add(dA);
                if (dA.Sequence(s2))
                {
                    break;
                }
            }

            Console.WriteLine($"\nDrives for the Home team: {DrivesHome.Count}");
            Console.WriteLine($"Drives for the Away team: {DrivesAway.Count}\n");
            
            int i = 1;
            foreach (Drive d in DrivesHome)
            {
                Console.WriteLine($"Drive {i} for the {s1.Team} produced {d.RushYards} rushing yards and {d.PassYards} passing yards.");
                i++;
            }

            i = 1;
            foreach (Drive d in DrivesAway)
            {
                Console.WriteLine($"Drive {i} for the {s2.Team} produced {d.RushYards} rushing yards and {d.PassYards} passing yards.");
                i++;
            }
        }
    }
}