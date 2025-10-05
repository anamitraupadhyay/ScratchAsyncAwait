using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;

namespace ScratchAsyncAwait
{
    internal class MyConcurrentQueuePool<T> where T : class, new()
    {
        private ConcurrentQueue<T> _pool = new ConcurrentQueue<T>();

        public object Rent()
        {
            if (_pool.TryDequeue(out var item)) return _pool;

            return new T();

        }
        public void Return(T item)
        {
            _pool.Enqueue(item);
        }
    }
    internal class MySinglePool<T> where T : class, new()
    {
        private T? _value;
        public void Return(T item)
        {
            _value ??= item;
        }
        public T Rent()
        {
            T? item = _value;
            if (item is null) return new T();
            else { item = null; return item; }
        }
    }
    class Mainclass {
        static void main(string[] args) {
            MyConcurrentQueuePool<StringBuilder> stringobject = new(); 
        }
    }
}
