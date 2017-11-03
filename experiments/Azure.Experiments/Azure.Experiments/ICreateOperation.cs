using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public interface ICreateOperation
    {
        IEnumerable<ICreateOperation> Dependencies { get; }

        Task<object> Create(Context context);
    }

    public sealed class CreateOperation<I> : ICreateOperation
    {
        public IEnumerable<ICreateOperation> Dependencies { get; }

        public async Task<object> Create(Context context) => await CreateFunc(context);

        public CreateOperation(
            IEnumerable<ICreateOperation> dependencies, Func<Context, Task<I>> createFunc)
        {
            Dependencies = dependencies;
            CreateFunc = createFunc;
        }

        private Func<Context, Task<I>> CreateFunc { get; }
    }
}
