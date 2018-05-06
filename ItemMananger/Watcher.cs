using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemMananger
{
    public class Watcher
    {
        private ItemManager ItemManager;
        private CancellationToken CancellationToken;

        public Watcher(ItemManager itemManager, CancellationToken cancellationToken)
        {
            this.ItemManager = new ItemManager();
            this.CancellationToken = cancellationToken;
        }



        public void PrintCount()
        {
            while (!CancellationToken.IsCancellationRequested)
            {
                Console.SetCursorPosition(1, 1);
                Console.WriteLine(ItemManager.Count());
               
                Task.Delay(TimeSpan.FromMilliseconds(1000));
            }
           ;
        }
    }
}
