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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSPrivateLinkResource
    {
        [Ps1Xml(Label = "Private link resource name", Target = ViewControl.List, Position = 0)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Private link resource id", Target = ViewControl.List, Position = 1)]
        public string Id { get; private set; }

        [Ps1Xml(Label = "Private link resource type", Target = ViewControl.List, Position = 2)]
        public string Type { get; private set; }

        [Ps1Xml(Label = "Private link resource group id", Target = ViewControl.List, Position = 3)]
        public string GroupId { get; private set; }

        [Ps1Xml(Label = "Private link resource required members", Target = ViewControl.List, Position = 4)]
        public string[] RequiredMembers { get; private set; }

        [Ps1Xml(Label = "Private link resource required zone names", Target = ViewControl.List, Position = 5)]
        public string[] RequiredZoneNames { get; private set; }

        [Ps1Xml(Label = "Shareable private link resource types", Target = ViewControl.List, Position = 6)]
        public PSShareablePrivateLinkResourceType[] ShareablePrivateLinkResourceTypes { get; private set; }

        public static explicit operator PSPrivateLinkResource(PrivateLinkResource v)
        {
            return new PSPrivateLinkResource()
            {
                Name = v.Name,
                Id = v.Id,
                Type = v.Type,
                GroupId = v.Properties.GroupId,
                RequiredMembers = v.Properties.RequiredMembers.ToArray(),
                RequiredZoneNames = v.Properties.RequiredZoneNames.ToArray(),
                ShareablePrivateLinkResourceTypes = 
                    v.Properties.ShareablePrivateLinkResourceTypes
                        .Select(type => (PSShareablePrivateLinkResourceType)type)
                        .ToArray()
            };
        }

        public static explicit operator PrivateLinkResource(PSPrivateLinkResource v)
        {
            return new PrivateLinkResource(
                id: v.Id,
                name: v.Name,
                type: v.Type,
                properties: new PrivateLinkResourceProperties(
                    groupId: v.GroupId,
                    requiredMembers: v.RequiredMembers,
                    requiredZoneNames: v.RequiredZoneNames,
                    shareablePrivateLinkResourceTypes:
                        v.ShareablePrivateLinkResourceTypes.Select(type => (ShareablePrivateLinkResourceType)type).ToList()));
        }
    }
}
