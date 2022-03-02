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

using Microsoft.Azure.Management.ResourceManager.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Resources.Models.PrivateLinks
{
    /// <summary>
    /// Represents a Resource Management Private Link.
    /// </summary>
    public class PSResourceManagementPrivateLink
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public IList<string> PrivateEndpointConnections { get; private set; }

        public PSResourceManagementPrivateLink()
        {
        }

        public PSResourceManagementPrivateLink(ResourceManagementPrivateLink resourceManagementPrivateLink)
        {
            if (resourceManagementPrivateLink != null)
            {
                Id = resourceManagementPrivateLink.Id;
                Type = resourceManagementPrivateLink.Type;
                Name = resourceManagementPrivateLink.Name;
                Location = resourceManagementPrivateLink.Location;
                PrivateEndpointConnections = resourceManagementPrivateLink.Properties.PrivateEndpointConnections;
            }
        }
    }
}
