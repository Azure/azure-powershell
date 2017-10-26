using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public abstract class Parameters
    {
        public static IEnumerable<Parameters> NoDependencies
            => Enumerable.Empty<Parameters>();

        public string Name { get; }

        public IEnumerable<Parameters> Dependencies { get; }

        protected Parameters(string name, IEnumerable<Parameters> dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }
    }

    public abstract class Parameters<T> : Parameters
    {
        protected Parameters(string name, IEnumerable<Parameters> parameters) 
            : base(name, parameters)
        {
        }

        public abstract Task<T> GetAsync(GetContext context);
    }
}
