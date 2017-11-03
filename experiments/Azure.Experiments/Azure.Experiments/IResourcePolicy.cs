using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    interface IInfoMap
    {
        Info Get<Info>(IResourcePolicy<Info> info);
    }

    interface IResourcePolicy
    {
        IEnumerable<IResourcePolicy> Dependencies { get; }
    }

    interface IResourcePolicy<Info> : IResourcePolicy
    {
        string GetLocation(Info info);
        Task<Info> Get(Context context, IInfoMap infoMap, string name);
        Task<Info> CreateAsync(Context context, IInfoMap infoMap, Info info);
    }
}
