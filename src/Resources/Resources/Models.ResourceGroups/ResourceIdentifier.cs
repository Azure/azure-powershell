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
using AuthorizationResourceIdentity = Microsoft.Azure.ResourceIdentity;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;
using ResourcesResourceIdentity = Microsoft.Azure.ResourceIdentity;

namespace Microsoft.Azure.Management.Internal.Resources.Utilities.Models
{
    static public class ResourceIdentifierExtention
    {
        static public AuthorizationResourceIdentity ToResourceIdentity(this ResourceIdentifier resourceIdentifier)
        {
            AuthorizationResourceIdentity identity = null;

            if (!string.IsNullOrEmpty(resourceIdentifier.ResourceType) && resourceIdentifier.ResourceType.IndexOf('/') > 0)
            {
                identity = new AuthorizationResourceIdentity
                {
                    ResourceName = resourceIdentifier.ResourceName,
                    ParentResourcePath = resourceIdentifier.ParentResource,
                    ResourceProviderNamespace = ResourceIdentifier.GetProviderFromResourceType(resourceIdentifier.ResourceType),
                    ResourceType = ResourceIdentifier.GetTypeFromResourceType(resourceIdentifier.ResourceType)
                };
            }

            return identity;
        }

        static public ResourcesResourceIdentity ToResourceIdentity(this ResourceIdentifier resourceIdentifier, string apiVersion)
        {
            if (string.IsNullOrEmpty(resourceIdentifier.ResourceType))
            {
                throw new ArgumentNullException("ResourceType");
            }
            if (resourceIdentifier.ResourceType.IndexOf('/') < 0)
            {
                throw new ArgumentException(ProjectResources.ResourceTypeFormat, "ResourceType");
            }

            ResourcesResourceIdentity identity = new ResourcesResourceIdentity
            {
                ResourceName = resourceIdentifier.ResourceName,
                ParentResourcePath = resourceIdentifier.ParentResource,
                ResourceProviderNamespace = ResourceIdentifier.GetProviderFromResourceType(resourceIdentifier.ResourceType),
                ResourceType = ResourceIdentifier.GetTypeFromResourceType(resourceIdentifier.ResourceType),
                ResourceProviderApiVersion = apiVersion
            };

            return identity;
        }
    }
}
