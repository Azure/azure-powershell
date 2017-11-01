using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public abstract class CreateInfo
    {
        public abstract IEnumerable<CreateInfo> Dependencies { get; }

        public abstract Task CreateAsync(Context context);
    }
}
