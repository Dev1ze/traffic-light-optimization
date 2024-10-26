using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Subscribers : IDisposable
    {
        public Subscribers(List<IObserver<bool>> observers, IObserver<bool> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        private readonly List<IObserver<bool>> observers;
        private readonly IObserver<bool> observer;
        public void Dispose()
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}
