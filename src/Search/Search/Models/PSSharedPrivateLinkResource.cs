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
    public class PSSharedPrivateLinkResource
    {
        public string Id { get; private set; }

        public string Type { get; private set; }

        public PSSharedPrivateLinkResourceStatus Status { get; private set; }

        [Ps1Xml(Label = "Name", Target = ViewControl.List, Position = 0)]
        public string Name { get; set; }

        [Ps1Xml(Label = "Group Id", Target = ViewControl.List, Position = 1)]
        public string GroupId { get; set; }

        [Ps1Xml(Label = "Private link resource id", Target = ViewControl.List, Position = 2)]
        public string PrivateLinkResourceId { get; set; }

        public PSSharedPrivateLinkResourceProvisioningState? ProvisioningState { get; private set; }

        [Ps1Xml(Label = "Request message", Target = ViewControl.List, Position = 3)]
        public string RequestMessage { get; set; }

        [Ps1Xml(Label = "Resource region", Target = ViewControl.List, Position = 4)]
        public string ResourceRegion { get; set; }

        public static explicit operator PSSharedPrivateLinkResource(SharedPrivateLinkResource v)
        {
            return new PSSharedPrivateLinkResource
            {
                Id = v.Id,
                Type = v.Type,
                Name = v.Name,
                GroupId = v.Properties.GroupId,
                PrivateLinkResourceId = v.Properties.PrivateLinkResourceId,
                ProvisioningState = (PSSharedPrivateLinkResourceProvisioningState?)v.Properties.ProvisioningState,
                RequestMessage = v.Properties.RequestMessage,
                ResourceRegion = v.Properties.ResourceRegion
            };
        }

        public static explicit operator SharedPrivateLinkResource(PSSharedPrivateLinkResource v)
        {
            return new SharedPrivateLinkResource(
                id: v.Id, 
                name: v.Name, 
                type: v.Type, 
                properties: new SharedPrivateLinkResourceProperties(
                    status: (SharedPrivateLinkResourceStatus?)v.Status, 
                    provisioningState: (SharedPrivateLinkResourceProvisioningState?)v.ProvisioningState)
                {
                    GroupId = v.GroupId,
                    PrivateLinkResourceId = v.PrivateLinkResourceId,
                    RequestMessage = v.RequestMessage,
                    ResourceRegion = v.ResourceRegion,
                });
        }
    }
}
