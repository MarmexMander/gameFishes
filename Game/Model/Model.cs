using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
 

namespace Game
{
    class Model
    {
        class TestSmallFish : IFish
        {
            public int Size { get; private set; }
            public int MaxCount { get; private set; }
            public int Count { get; set; }
            public Image Sprite { get; private set; }
            TestSmallFish()
            {
                this.Sprite.Source = Controller.BitmapToImageSource(Properties.Resources.SmallFish);
                Size = 1;
                MaxCount = 2;
                Count = 0;
            }

            public void Die()
            {
                Console.WriteLine("I don't DIE!!");

 

            }

            public void Attach(IObserver observer)
            {

 

            }

            public void Detach(IObserver observer)
            {
                 
            }

            public void Notify()
            {

 

            }
        }
        
    }
}