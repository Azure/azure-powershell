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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections;
using ResourceManagement = Microsoft.Azure.Management.Internal.Resources.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultIdentityItem
    {
        public PSKeyVaultIdentityItem()
        {

        }
        public PSKeyVaultIdentityItem(ResourceManagement.GenericResource resource)
        {
            ResourceIdentifier identifier = new ResourceIdentifier(resource.Id);
            VaultName = identifier.ResourceName;
            ResourceId = resource.Id;
            ResourceGroupName = identifier.ResourceGroupName;
            Location = resource.Location;
            Tags = TagsConversionHelper.CreateTagHashtable(resource.Tags);
        }
        public string ResourceId { get; protected set; }

        public string VaultName { get; protected set; }

        public string ResourceGroupName { get; protected set; }

        public string Location { get; protected set; }

        public Hashtable Tags { get; protected set; }

        public string TagsTable
        {
            get { return ResourcesExtensions.ConstructTagsTable(Tags); }
        }

    }
}
