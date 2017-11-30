using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies
{
    internal sealed class MessageLoop
    {
        readonly ConcurrentQueue<Task> _Tasks = new ConcurrentQueue<Task>();

        public async Task<T> Invoke<T>(Func<T> func)
        {
            var task = new Task<T>(func);
            _Tasks.Enqueue(task);
            while (!task.IsCompleted)
            {
                await Task.Yield();
            }
            return task.Result;
        }

        public void BeginInvoke(Action action)
            => _Tasks.Enqueue(new Task(action));

        public void Wait(Task task)
        {
            while (!task.IsCompleted)
            {
                HandleActions();
                Thread.Yield();
            }
            HandleActions();
        }

        void HandleActions()
        {
            Task task;
            while (_Tasks.TryDequeue(out task))
            {
                task.RunSynchronously();
            }
        }
    }
}
