using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchAsyncAwait
{
    internal class MyConcurrentQueuePool<T> where T : class, new()
    {
        private ConcurrentQueue<T> _pool = new ConcurrentQueue<T>();

        public void Return()
        {
            if(_pool.Count > 0)
            {
                _pool.TryDequeue;
            }
            else
            {
                return new _pool;
            }
        }
        public void Rent()
        {
            _pool.Enqueue;
        }
    }
    internal class MySinglePool<T> where T : class, new()
    {
        private readonly T _value;
        public void Return()
        {
            //
        }
        public void Rent()
        {
            //
        }
    }
}
