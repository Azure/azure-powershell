using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    public static class ResourceTypeUtility
    {
        public static string GetTopLevelResourceType(string resourceType)
        {
            if (resourceType == null)
            {
                return null;
            }
            string[] resourceTypeFieldList = resourceType.Split('/');
            string topLevelResourceType;
            // resourceType is like {topLevelResource}/[{subLevelResource}]
            topLevelResourceType = resourceTypeFieldList[0];

            return topLevelResourceType;
        }

        public static string GetTopLevelResourceTypeWithProvider(string resourceType)
        {
            if (resourceType == null)
            {
                return null;
            }
            string[] resourceTypeFieldList = resourceType.Split('/');
            string topLevelResourceType;
            // resourceType is like {provider}/{topLevelResource}/[{subLevelResource}]
            topLevelResourceType = resourceTypeFieldList[1];

            return topLevelResourceType;
        }
    }
}
