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
            if (resourceTypeFieldList.Length == 1)
            {
                topLevelResourceType = resourceTypeFieldList[0];
            }
            else // resourceType is like {providerNameSpace}/{topLevelResource}/[{subLevelResource}] at least two fields
            {
                topLevelResourceType = string.Format("{0}/{1}", resourceTypeFieldList[0], resourceTypeFieldList[1]);
            }

            return topLevelResourceType;
        }
    }
}
