using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemMananger
{
    public class ItemFactory
    {
        private static ItemFactory Instance = new ItemFactory();
        private static int Counter=0;

      

        public int Next()
        {
            return Interlocked.Increment(ref Counter);
        }

        public Item  CreateItem()
        {
            return new Item(Next());
        }


        public static ItemFactory GetInstance()
        {
            return Instance;
        }
    }
}
