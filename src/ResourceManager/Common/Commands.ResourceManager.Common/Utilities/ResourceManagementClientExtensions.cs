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

using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Internal.Resources.Utilities
{
    public static class ResourceManagementClientExtensions
    {
        public static List<GenericResource> FilterResources(this IResourceManagementClient client, FilterResourcesOptions options)
        {
            List<GenericResource> resources = new List<GenericResource>();

            if (!string.IsNullOrEmpty(options.ResourceGroup) && !string.IsNullOrEmpty(options.Name))
            {
                resources.Add(client.Resources.Get(options.ResourceGroup, null, null, null, options.Name, null));
            }
            else
            {
                if (!string.IsNullOrEmpty(options.ResourceGroup))
                {
                    Rest.Azure.IPage<GenericResource> result = client.ResourceGroups.ListResources(options.ResourceGroup,
                        new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(r => r.ResourceType == options.ResourceType));

                    resources.AddRange(result);
                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = client.ResourceGroups.ListResourcesNext(result.NextPageLink);
                        resources.AddRange(result);
                    }
                }
                else
                {
                    Rest.Azure.IPage<GenericResource> result = client.Resources.List(
                        new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(r => r.ResourceType == options.ResourceType));

                    resources.AddRange(result);
                    while (!string.IsNullOrEmpty(result.NextPageLink))
                    {
                        result = client.Resources.ListNext(result.NextPageLink);
                        resources.AddRange(result);
                    }
                }
            }

            return resources;
        }
    }
}
