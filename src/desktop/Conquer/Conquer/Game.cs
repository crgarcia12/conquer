using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer
{
    internal class Game
    {
        public List<Player> Players { get; set; }
        public Player HumanPlayer { get; set; }
        public Map Map { get; set; }

        public Game(int X, int Y)
        {
            this.Players = new List<Player>();
            this.Map = new Map(X, Y);

            this.HumanPlayer = new Player();
            this.Players.Add(this.HumanPlayer);

            // Starting possition
            Map.Squares[3, 3].Player = HumanPlayer;
            Map.Squares[3, 3].SoldiersCount = 60;
        }

        internal void IncreasePlayersSoldiers()
        {
            for(int x = 0; x < Map.MaxX; x++)
            {
                for(int y = 0; y < Map.MaxY; y++)
                {
                    if (Map.Squares[x,y].Player != null)
                    {
                        Map.Squares[x, y].SoldiersCount ++;
                    }
                }
            }
        }
    }
}
