using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game
{
    public interface IObserver
    {
        void Update(IObservable subject);
    }
    public interface IObservable
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }
    interface IFish : IObservable
    {
        int Size { get; }
        int Count { get; set; }
        int MaxCount { get; }
        void Die();
        Image Sprite { get; }
    }
     interface IField : IObserver
    {
        IFish pullColumn(int column);
        void pudhColumn(int column, IFish fish);
        List<List<IFish>> Field { get; }

    }
}
