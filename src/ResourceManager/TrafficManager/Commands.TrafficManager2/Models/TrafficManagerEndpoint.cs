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

namespace Microsoft.Azure.Commands.TrafficManager.Models
{
    using Microsoft.Azure.Commands.TrafficManager.Utilities;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using System;

    public class TrafficManagerEndpoint
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProfileName { get; set; }

        public string ResourceGroupName { get; set; }

        public string Type { get; set; }

        public string TargetResourceId { get; set; }

        public string Target { get; set; }

        public string EndpointStatus { get; set; }

        public uint? Weight { get; set; }

        public uint? Priority { get; set; }

        public string Location { get; set; }

        public string EndpointMonitorStatus { get; set; }

        public uint? MinChildEndpoints { get; set; }

        public Endpoint ToSDKEndpoint()
        {
            return new Endpoint
            {
                Id = this.Id,
                Name = this.Name,
                Type = TrafficManagerEndpoint.ToSDKEndpointType(this.Type),
                Properties = new EndpointProperties
                {
                    Target = this.Target,
                    EndpointStatus = this.EndpointStatus,
                    Weight = this.Weight,
                    Priority = this.Priority,
                    EndpointLocation = this.Location,
                    TargetResourceId = this.TargetResourceId,
                    MinChildEndpoints = this.MinChildEndpoints,
                }
            };
        }

        public static string ToSDKEndpointType(string type)
        {
            return
                !type.StartsWith(Constants.ProfileType, StringComparison.OrdinalIgnoreCase) ?
                string.Format("{0}/{1}", Constants.ProfileType, type) :
                type;
        }
    }
}
