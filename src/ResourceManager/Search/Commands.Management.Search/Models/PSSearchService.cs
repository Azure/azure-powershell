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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSSearchService
    {
        [Ps1Xml(Label = "Resource Group Name", Target = ViewControl.List, Position = 0)]
        public string ResourceGroupName { get; private set; }

        [Ps1Xml(Label = "Service Name", Target = ViewControl.List, Position = 1)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Location", Target = ViewControl.List, Position = 2)]
        public string Location { get; private set; }

        [Ps1Xml(Label = "Sku", Target = ViewControl.List, Position = 3)]
        public PSSkuName? Sku { get; private set; }

        [Ps1Xml(Label = "Replica Count", Target = ViewControl.List, Position = 4)]
        public int? ReplicaCount { get; private set; }

        [Ps1Xml(Label = "Partition Count", Target = ViewControl.List, Position = 5)]
        public int? PartitionCount { get; private set; }

        [Ps1Xml(Label = "Hosting Mode", Target = ViewControl.List, Position = 6)]
        public PSHostingMode? HostingMode { get; private set; }

        [Ps1Xml(Label = "Resource Id", Target = ViewControl.List, Position = 7)]
        public string Id { get; private set; }

        public IDictionary<string, string> Tags { get; set; }

        public PSSearchService(Azure.Management.Search.Models.SearchService searchService)
        {
            ResourceGroupName = new ResourceIdentifier(searchService.Id).ResourceGroupName;
            Name = searchService.Name;
            Id = searchService.Id;
            Location = searchService.Location;

            if (searchService.Sku != null && searchService.Sku.Name != null)
            {
                Sku = (PSSkuName)searchService.Sku.Name;
            }

            ReplicaCount = searchService.ReplicaCount;
            PartitionCount = searchService.PartitionCount;

            if (searchService.HostingMode != null)
            {
                HostingMode = (PSHostingMode)searchService.HostingMode;
            }

            Tags = searchService.Tags;
        }

        public static PSSearchService Create(Azure.Management.Search.Models.SearchService searchService)
        {
            return new PSSearchService(searchService);
        }
    }
}
