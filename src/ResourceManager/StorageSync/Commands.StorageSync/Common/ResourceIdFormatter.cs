using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    public static class ResourceIdFormatter
    {
        /// <summary>
        /// Constructs a resource Id
        /// </summary>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="resources">Key-value pairs, each one contains resource type and resource name</param>
        /// <returns>Return the resource Id</returns>
        public static string GenerateResourceId(
            Guid subscriptionId,
            string resourceGroupName,
            IList<KeyValuePair<string, string>> resources = null)
        {
            //Check.NotEquals(Guid.Empty, subscriptionId, $"{subscriptionId} should not be empty Guid");
            //resources is allowed to be null
            if (resources != null && resources.Count > 0)
            {
                //Check.NotNullOrEmpty(nameof(resourceGroupName), resourceGroupName);
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"/{StorageSyncConstants.SubscriptionTypeName}/{subscriptionId}");

            if (!string.IsNullOrEmpty(resourceGroupName))
            {
                sb.Append($"/{StorageSyncConstants.ResourceGroupTypeName}/{resourceGroupName}");

                if (resources != null && resources.Count > 0)
                {
                    sb.Append($"/{StorageSyncConstants.ProvidersTypeName}/{StorageSyncConstants.ResourceProvider}");
                    foreach (var resourcePair in resources)
                    {
                        sb.Append($"/{resourcePair.Key}/{resourcePair.Value}");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
