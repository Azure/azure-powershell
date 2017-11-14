using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public sealed class NestedResourcePolicy<Config, ParentConfig> : IResourcePolicy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<ParentConfig, Config> Get { get; }

        public Action<ParentConfig, Config> Set { get; }

        public NestedResourcePolicy(
            Func<string, IEnumerable<string>> getId,
            Func<ParentConfig, Config> get,
            Action<ParentConfig, Config> set)
        {
            GetId = getId;
            Get = get;
            Set = set;
        }
    }
}
