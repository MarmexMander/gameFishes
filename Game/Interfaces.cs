using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface Fish
    {
        int Size { get; }
        int Count { get; set; }
        int MaxCount { get; }
        void Die();
    }
}
