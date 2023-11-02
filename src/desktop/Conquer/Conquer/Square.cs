using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquer
{
    internal class Square
    {
        public Player? Player { get; set; }
        public int SoldiersCount { get; set; }

        public Square(int SoldiersCount)
        {
            this.SoldiersCount = SoldiersCount;
        }
    }
}
