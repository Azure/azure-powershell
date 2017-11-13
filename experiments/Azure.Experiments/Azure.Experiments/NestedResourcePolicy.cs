using System;

namespace Microsoft.Azure.Experiments
{
    public sealed class NestedResourcePolicy<Config, ParentConfig> : IResourcePolicy
    {
        public Func<ParentConfig, Config> Get { get; }

        public Action<ParentConfig, Config> Set { get; }

        public NestedResourcePolicy(
            Func<ParentConfig, Config> get, Action<ParentConfig, Config> set)
        {
            Get = get;
            Set = set;
        }
    }
}
