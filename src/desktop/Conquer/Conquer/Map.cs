using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer
{
    internal class Map
    {


        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public Square[,] Squares { get; set; }

        public Map(int MaxX, int MaxY) 
        {
            this.MaxX = MaxX;
            this.MaxY = MaxY;
            this.Squares = new Square[MaxX, MaxY];

            for(int x = 0; x < MaxX; x++)
            {
                for (int y = 0; y < MaxY; y++)
                {
                    this.Squares[x,y] = new Square(30);
                }
            }
        }


    }
}
