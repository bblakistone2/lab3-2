using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab3_2
{
    public class Student: IDisposable
    {
        private bool _Disposed;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DynamicArray<int> Scores { get; set; }

        public Student(string lastName, string firstName, int numScores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = new DynamicArray<int>(numScores);
        }
        public override string ToString()
        {
            return $"{LastName,-25} {FirstName,-15} Number of Scores:{Scores.Count()}   Average:{Scores.Average():0.###}";
        }
        public void Dispose()
        {
            Console.WriteLine($"Disposing Student from thread {Thread.CurrentThread.ManagedThreadId}");            Dispose(true);            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }
            if (disposing)
            {
                Scores?.Dispose();
                //If unmanaged memory allocated, it would get cleared here
            }
            _Disposed = true;
            return;

        }
        ~Student()
        {
            Console.WriteLine($"Finalizing Student from thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
