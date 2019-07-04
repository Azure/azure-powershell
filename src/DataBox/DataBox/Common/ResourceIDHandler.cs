using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    public class ResourceIdHandler
    {
        public static string GetResourceGroupName(string resourceId)
        {
            var splits = resourceId.Split(new[] { '/' });
            for(int i = 0;i<splits.Length; i++)
            {
                if (splits[i].Equals("resourceGroups"))
                {
                    return splits[i + 1];
                }
            }
            throw new Exception("Invalid Resource Id");
        }

        public static string GetResourceName(string resourceId)
        {
            var splits = resourceId.Split(new[] { '/' });
            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i].Equals("providers"))
                {
                    return splits[i + 3];
                }
            }
            throw new Exception("Invalid Resource Id");
        }
    }
}
