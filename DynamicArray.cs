using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3_2
{
    public class DynamicArray<T>: IDisposable, IEnumerable<T> where T:new()
    {
        #region fields
        private bool _Disposed = false;
        private T[] _Items;
       

        public T this[int index]
        {
            get
            {
                return _Items[index];
            }

            set
            {
                _Items[index] = value;
            }
        }
        #endregion fields

        #region constructors

        public DynamicArray(int x)
        {
            _Items = new T[x];
            

            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }
        
        public DynamicArray( IEnumerable<T> items)
        {
            
            _Items = items.ToArray();
            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");

        }
        #endregion constructors

        #region methods
        public void Resize(int x)
        {
            T[] newitems = _Items;
            int copythese = _Items.Length-1;
            if ((_Items.Length) > x)
            {
                Console.WriteLine("Losing data on resize");
                copythese = x;
            }
            _Items = new T[x];
            for (int i =copythese-1; i >= 0; --i) 
            {
                 _Items[i]= newitems[i];
            }


        }

        public IEnumerator<T> GetEnumerator()
        {
            return (_Items as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        public void Dispose()
        {
            Console.WriteLine($"Disposing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");            Dispose(true);            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }
            if (disposing)
            {
                _Items = null;
                //If unmanaged memory allocated, it would get cleared here
            }
            _Disposed = true;
            return;

        }
        ~DynamicArray()
        {
            Console.WriteLine($"Finalizing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }


        #endregion methods
    }
}
