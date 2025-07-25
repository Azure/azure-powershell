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
    public class PSPrivateEndpoint
    {
        [Ps1Xml(Label = "Private Endpoint Id", Target = ViewControl.List, Position = 0)]
        public string Id { get; set; }

        public static implicit operator PrivateEndpointConnectionPropertiesPrivateEndpoint(PSPrivateEndpoint v)
        {
            return new PrivateEndpointConnectionPropertiesPrivateEndpoint(id: v.Id);
        }

        public static implicit operator PSPrivateEndpoint(PrivateEndpointConnectionPropertiesPrivateEndpoint v)
        {
            return new PSPrivateEndpoint()
            {
                Id = v.Id
            };
        }
    }
}