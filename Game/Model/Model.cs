using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game
{
   public class Model
    {
        public class SmallFish : IFish
        {
            private List<IObserver> _observers = new List<IObserver>();
            public int Size { get; private set; }
            public int MaxCount { get; private set; }
            public int Count { get; set; }
            public Image Sprite { get; private set; } 
            public SmallFish()
            {
                Sprite = new Image();
                this.Sprite.Source = Controller.BitmapToImageSource(Properties.Resources.SmallFish1);
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
                this._observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                this._observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }
        }

        public class MiddleFish : IFish
        {
            private List<IObserver> _observers = new List<IObserver>();
            public int Size { get; private set; }
            public int MaxCount { get; private set; }
            public int Count { get; set; }
            public Image Sprite { get; private set; }
            public MiddleFish()
            {
                Sprite = new Image();
                this.Sprite.Source = Controller.BitmapToImageSource(Properties.Resources.MiddleFish1);
                Size = 2;
                MaxCount = 2;
                Count = 0;
            }
            public void Die()
            {
                Console.WriteLine("I don't DIE!!");

            }

            public void Attach(IObserver observer)
            {
                this._observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                this._observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }
        }

        public class BigFish : IFish
        {
            private List<IObserver> _observers = new List<IObserver>();
            public int Size { get; private set; }
            public int MaxCount { get; private set; }
            public int Count { get; set; }
            public Image Sprite { get; private set; }
            public BigFish()
            {
                Sprite = new Image();
                this.Sprite.Source = Controller.BitmapToImageSource(Properties.Resources.BigFish1);
                Size = 3;
                MaxCount = 2;
                Count = 0;
            }
            public void Die()
            {
                Console.WriteLine("I don't DIE!!");

            }

            public void Attach(IObserver observer)
            {
                this._observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                this._observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }
        }

        public class Fild : IField
        {
            public List<List<IFish>> Field { get; private set; }
            public Fild(int x, int y)
            {
                Field = new List<List<IFish>>();
                for(int i = 0; i < x; i++)
                {
                    Field.Add(new List<IFish>());
                    for(int j = 0; j < y; j++)
                    {
                        Field[i].Add(null);
                    }
                }
            }
 
            public IFish pullColumn(int collumn)
            {
                IFish fish = Field[collumn].Last();
                Field[collumn].Remove(fish);
                return fish;
            }

            public void pushBackColumn(int collumn, IFish fish)
            {                
                Field[collumn].Insert(0,fish);
                if (Field[collumn].Last() != null)
                    Controller.GameOver();
                Field[collumn].Remove(Field[collumn].Last());
            }

            public void pudhColumn(int collumn, IFish fish)
            {
                Field[collumn].Add(fish); 
            }

            

            public void Update(IObservable subject)
            {

            }
        }
    }




}