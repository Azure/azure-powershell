using Newtonsoft.Json;
using System;
using System.Linq;

namespace Microsoft.Azure.Commands.DevTestLabs
{
    internal static class Extensions
    {
        internal static T DuckType<T>(this object target)
        {
            if (target == null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(target));
        }
    }
}
