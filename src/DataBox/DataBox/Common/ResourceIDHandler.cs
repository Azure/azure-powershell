// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
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
