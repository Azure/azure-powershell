using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.StorageSync.Common.Extensions
{
    public static class ResourceIdentifierExtensions
    {
        /// <summary>
        /// Get the parent resource name starting from level 0, immediate parent
        /// </summary>
        /// <param name="resourceIdentifier"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static string GetParentResourceName(this ResourceIdentifier resourceIdentifier, string resourceType, int level = 0)
        {
            if (resourceIdentifier?.ParentResource == null)
            {
                return null;
            }

            string[] parentResourceTokens = resourceIdentifier.ParentResource.Split(new[] { '/' });

            if (parentResourceTokens.Length % 2 != 0)
            {
                throw new ArgumentException($"Invalid argument {nameof(resourceIdentifier.ParentResource)}", nameof(resourceIdentifier.ParentResource));
            }

            if (parentResourceTokens.Length < 2 * (level + 1))
            {
                throw new ArgumentException($"Invalid argument {nameof(level)}", nameof(level));
            }

            if(!String.Equals(resourceType, parentResourceTokens[parentResourceTokens.Length - 2 * (level + 1)],StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Invalid argument {nameof(resourceType)}", nameof(resourceType));
            }

            return parentResourceTokens[parentResourceTokens.Length - 2 * level - 1];
        }
    }
}
