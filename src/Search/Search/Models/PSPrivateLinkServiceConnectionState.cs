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
    public class PSPrivateLinkServiceConnectionState
    {
        [Ps1Xml(Label = "Private Link Service Connection Status", Target = ViewControl.List, Position = 0)]
        public PSPrivateLinkServiceConnectionStatus Status { get; private set; }

        [Ps1Xml(Label = "Private Link Service Connection Description", Target = ViewControl.List, Position = 1)]
        public string Description { get; private set; }

        [Ps1Xml(Label = "Private Link Service Connection Actions Required", Target = ViewControl.List, Position = 2)]
        public string ActionsRequired { get; private set; }

        public static explicit operator PSPrivateLinkServiceConnectionState(PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState v)
        {
            return new PSPrivateLinkServiceConnectionState()
            {
                Status = (PSPrivateLinkServiceConnectionStatus)v.Status,
                Description = v.Description,
                ActionsRequired = v.ActionsRequired
            };
        }

        public static explicit operator PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState(PSPrivateLinkServiceConnectionState v)
        {
            return new PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState(status: (PrivateLinkServiceConnectionStatus)v.Status, description: v.Description, actionsRequired: v.ActionsRequired);
        }
    }
}