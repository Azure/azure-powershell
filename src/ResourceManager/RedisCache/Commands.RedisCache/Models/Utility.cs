using Microsoft.Azure.Commands.RedisCache.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RedisCache
{
    public class Utility
    {
        public static void ValidateResourceGroupAndResourceName(string resourceGroupName, string name)
        {
            if (resourceGroupName != null && resourceGroupName.Contains("/"))
            {
                throw new ArgumentException(Resources.InvalidResourceGroupName);
            }

            if (name != null && (name.Contains("/") || name.Contains(".")))
            {
                throw new ArgumentException(Resources.InvalidRedisCacheName);
            }
        }
    }
}
