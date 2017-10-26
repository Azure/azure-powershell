using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public abstract class Parameters
    {
        public string Name { get; }

        public static IEnumerable<Parameters> NoDependencies
            => Enumerable.Empty<Parameters>();

        public abstract IEnumerable<Parameters> Dependencies { get; }

        public Parameters(string name)
        {
            Name = name;
        }
    }

    public abstract class Parameters<T> : Parameters
    {

        public Parameters(string name) : base(name)
        {
        }
    }
}
