using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public sealed class ResourceGroupParameters : Parameters
    {
        public override IEnumerable<Parameters> Dependencies 
            => NoDependencies;

        public ResourceGroupParameters(string name) : base(name)
        {
        }
    }
}
