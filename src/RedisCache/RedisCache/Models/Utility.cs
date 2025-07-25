using Microsoft.Azure.Commands.RedisCache.Properties;
using Microsoft.Azure.Management.RedisCache.Models;
using System;
using System.Collections.Generic;

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

        public static string GetResourceGroupNameFromRedisCacheId(string id)
        {
            //Id looks like this: "/subscriptions/<subscription id>/resourceGroups/<resource group name>/providers/Microsoft.Cache/Redis/<cache name>"
            string[] e = id.Split('/');
            if (e.Length != 9 || string.IsNullOrWhiteSpace(e[4]))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRedisCacheId, id));
            }
            return e[4];
        }

        public static string GetRedisCacheNameFromRedisCacheId(string id)
        {
            //Id looks like this: "/subscriptions/<subscription id>/resourceGroups/<resource group name>/providers/Microsoft.Cache/Redis/<cache name>"
            string[] e = id.Split('/');
            if (e.Length != 9 || string.IsNullOrWhiteSpace(e[8]))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRedisCacheId, id));
            }
            return e[8];
        }

        public static (string resourceGroupName, string cacheName, string childResource) GetDetailsFromRedisCacheChildResourceId(string id)
        {
            //Id looks like this: "/subscriptions/<subscription id>/resourceGroups/<resource group name>/providers/Microsoft.Cache/Redis/<cache name>/<operation group>/<name>"
            string[] e = id.Split('/');
            if (e.Length != 11 || string.IsNullOrWhiteSpace(e[4]) || string.IsNullOrWhiteSpace(e[8]) || string.IsNullOrWhiteSpace(e[10]))
            {
                throw new ArgumentException(string.Format(Resources.InvalidRedisCacheChildResourceId, id));
            }
            return (e[4], e[8], e[10]);
        }

        internal static ManagedServiceIdentity BuildManagedServiceIdentity(string identityType, string[] userAssignedIdentities)
        {
            if (!string.IsNullOrEmpty(identityType))
            {
                string managedIdentityType = ManagedServiceIdentityType.None;
                foreach (var field in typeof(ManagedServiceIdentityType).GetFields())
                {
                    if (field.FieldType == typeof(string) && field.IsPublic && field.IsLiteral)
                    {
                        if (string.Equals(identityType, field.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            managedIdentityType = (string)field.GetRawConstantValue();
                            break;
                        }
                    }
                }
                var identity = new ManagedServiceIdentity(
                    type: managedIdentityType
                    );
                if (userAssignedIdentities != null)
                {
                    identity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();
                    foreach (var userIdentity in userAssignedIdentities)
                    {
                        identity.UserAssignedIdentities[userIdentity.Trim()] = new UserAssignedIdentity();
                    }
                }
                return identity;
            }
            return null;
        }
    }
}
