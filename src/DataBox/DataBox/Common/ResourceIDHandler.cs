using System;
using System.Resources;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Resource = Microsoft.Azure.PowerShell.Cmdlets.DataBox.Resources.Resource;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    public class ResourceIdHandler
    {
        public static string GetResourceGroupName(string resourceId)
        {
            var splits = resourceId.Split(new[] { '/' });
            for(int i = 0;i<splits.Length; i++)
            {
                if (splits[i].Equals("resourceGroups", StringComparison.CurrentCultureIgnoreCase))
                {
                    return splits[i + 1];
                }
            }
            throw new Exception(Resource.InvalidResourceId);
        }

        public static string GetResourceName(string resourceId)
        {
            var splits = resourceId.Split(new[] { '/' });
            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i].Equals("providers", StringComparison.CurrentCultureIgnoreCase))
                {
                    return splits[i + 3];
                }
            }
            throw new Exception(Resource.InvalidResourceId);
        }
    }
}
