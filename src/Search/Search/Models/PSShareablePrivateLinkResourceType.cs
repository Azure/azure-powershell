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

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSShareablePrivateLinkResourceType
    {
        [Ps1Xml(Label = "Shareable Private link resource name", Target = ViewControl.List, Position = 0)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Shareable Private link resource description", Target = ViewControl.List, Position = 1)]
        public string Description { get; private set; }

        [Ps1Xml(Label = "Shareable Private link resource type", Target = ViewControl.List, Position = 2)]
        public string Type { get; private set; }

        [Ps1Xml(Label = "Shareable Private link resource group id", Target = ViewControl.List, Position = 3)]
        public string GroupId { get; private set; }

        public static explicit operator PSShareablePrivateLinkResourceType(ShareablePrivateLinkResourceType v)
        {
            return new PSShareablePrivateLinkResourceType()
            {
                Name = v.Name,
                Description = v.Properties.Description,
                Type = v.Properties.Type,
                GroupId = v.Properties.GroupId
            };
        }

        public static explicit operator ShareablePrivateLinkResourceType(PSShareablePrivateLinkResourceType v)
        {
            return new ShareablePrivateLinkResourceType(
                name: v.Name,
                properties: new ShareablePrivateLinkResourceProperties(
                    type: v.Type,
                    groupId: v.GroupId,
                    description: v.Description));
        }
    }
}