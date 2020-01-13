using System;

namespace FootballGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player s1 = new Player("Titans", "King", "Henry", 22);
            Player s2 = new Player("Cheifs", "Patrick", "Mahomes", 15);
            //Player s2 = new Player();  // user inputs a player

            while (true)  //first to score
            {
                if (s1.Drive())
                {
                    break;
                }
                else if (s2.Drive())
                {
                    break;
                }
            }

        }
    }
}