using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemMananger
{
   public class Item
    {
        public Item(int Nbr)
        {
            this.Nbr = Nbr;
        }

        public int Nbr { get; set; }
    }
}
