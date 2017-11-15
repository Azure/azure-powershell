using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public sealed class NestedResourcePolicy<Config, ParentConfig> : IResourcePolicy
    {
        public Func<string, IEnumerable<string>> GetId { get; }

        public Func<ParentConfig, string, Config> Get { get; }

        public Action<ParentConfig, string, Config> Set { get; }

        public NestedResourcePolicy(
            Func<string, IEnumerable<string>> getId,
            Func<ParentConfig, string, Config> get,
            Action<ParentConfig, string, Config> set)
        {
            GetId = getId;
            Get = get;
            Set = set;
        }
    }

    public static class NestedResourcePolicy
    {
        public static NestedResourcePolicy<Config, ParentConfig> Create<Config, ParentConfig>(
            string header,
            Func<ParentConfig, string, Config> get,
            Action<ParentConfig, string, Config> set)
            where Config : class
            where ParentConfig : class
            => new NestedResourcePolicy<Config, ParentConfig>(
                name => new[] { header, name},
                get,
                set);
    }
}
