using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<bool>> observers;
        private IObserver<bool> observer;

        public Unsubscriber(List<IObserver<bool>> observers, IObserver<bool> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}
