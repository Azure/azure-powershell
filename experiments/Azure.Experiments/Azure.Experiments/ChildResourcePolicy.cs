using System;

namespace Microsoft.Azure.Experiments
{
    public static class ChildResourcePolicy
    {
        public static ChildResourcePolicy<Info, ParentInfo> Create<Info, ParentInfo>(
            Func<ParentInfo, string, Info> get,
            Action<ParentInfo, Info> set)
            where Info : class
            where ParentInfo : class
            => new ChildResourcePolicy<Info, ParentInfo>(get, set);
    }

    public sealed class ChildResourcePolicy<Info, ParentInfo>
        where Info : class
        where ParentInfo : class
    {
        public Func<ParentInfo, string, Info> Get { get; }
        
        public Action<ParentInfo, Info> Set { get; }

        public ChildResourcePolicy(
            Func<ParentInfo, string, Info> get, Action<ParentInfo, Info> set)
        {
            Get = get;
            Set = set;
        }
    }
}
