using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    public static class ResourceTypeUtility
    {
        public static string GetTopLevelResourceType(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                return null;
            }
            string[] resourceTypeFieldList = resourceType.Split('/');
            // resourceType is like {topLevelResource}/[{subLevelResource}]
            return resourceTypeFieldList[0];
        }

        public static string GetTopLevelResourceTypeWithProvider(string resourceType)
        {
            if (string.IsNullOrEmpty(resourceType))
            {
                return null;
            }
            string[] resourceTypeFieldList = resourceType.Split('/');
            // resourceType is like {provider}/{topLevelResource}/[{subLevelResource}]
            if (resourceTypeFieldList.Length >= 1)
            {
                return resourceTypeFieldList[1];
            }
            else
            {
                return resourceType;
            }
        }
    }
}
