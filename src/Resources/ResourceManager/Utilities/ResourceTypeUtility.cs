using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    public static class ResourceTypeUtility
    {
        public static string GetTopLevelResourceType(string resourceType)
        {
            string[] resourceTypeFieldList = resourceType.Split('/'); // resourceType is like {providerNameSpace}/{topLevelResource}/[{subLevelResource}] at least two fields
            string topLevelResourceType = string.Format("{0}/{1}", resourceTypeFieldList[0], resourceTypeFieldList[1]);

            return topLevelResourceType;
        }
    }
}
