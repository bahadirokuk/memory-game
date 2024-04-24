using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.point = 0;
        }
        public Player(string name,int point)
        {
            this.Name = name;
            this.point = point;
        }
        public int point { get; set; }
        public string Name { get; set; }
        
    }
}
