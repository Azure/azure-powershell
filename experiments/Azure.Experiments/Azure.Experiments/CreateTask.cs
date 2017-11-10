using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public interface ICreateTask
    {
    }

    public sealed class CreateTask<Info> : ICreateTask
    {
        public IEnumerable<ICreateTask> Subtasks { get; }

        public CreateTask(IEnumerable<ICreateTask> subtasks)
        {
            Subtasks = subtasks;
        }
    }
}
