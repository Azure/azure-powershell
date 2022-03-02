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
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Resources.Models.PrivateLinks
{
    /// <summary>
    /// Represents a Resource Management Private Link Association.
    /// </summary>
    public class PSResourceManagementPrivateLinkAssociation
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public string Properties { get; private set; }

        public PSResourceManagementPrivateLinkAssociation()
        {
        }

        public PSResourceManagementPrivateLinkAssociation(PrivateLinkAssociation privateLinkAssociation)
        {
            if (privateLinkAssociation != null)
            {
                Id = privateLinkAssociation.Id;
                Type = privateLinkAssociation.Type;
                Name = privateLinkAssociation.Name;
                Properties = JsonConvert.SerializeObject(privateLinkAssociation.Properties);
            }
        }
    }
}
