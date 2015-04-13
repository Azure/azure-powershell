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

namespace Microsoft.Azure.Commands.TrafficManager.Utilities
{
    using Microsoft.Azure.Commands.TrafficManager.Models;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.Azure.Management.TrafficManager;
    using Microsoft.Azure.Management.TrafficManager.Models;

    public class TrafficManagerClient 
    {
        public const string ProfileResourceLocation = "global";

        public TrafficManagerClient(AzureProfile profile)
            : this(AzureSession.ClientFactory.CreateClient<TrafficManagerManagementClient>(profile, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public TrafficManagerClient(ITrafficManagerManagementClient client)
        {
            this.TrafficManagerManagementClient = client;
        }

        public ITrafficManagerManagementClient TrafficManagerManagementClient { get; set; }

        public TrafficManagerProfile CreateTrafficManagerProfile(string resourceGroupName, string profileName, string trafficRoutingMethod, string relativeDnsName, uint ttl, string monitorProtocol, uint monitorPort, string monitorPath)
        {
            ProfileCreateResponse response = this.TrafficManagerManagementClient.Profiles.Create(
                resourceGroupName, 
                profileName,
                new ProfileCreateParameters
                {
                    Profile = new Profile
                    {
                        Name = profileName,
                        Location = TrafficManagerClient.ProfileResourceLocation,
                        Properties = new ProfileProperties
                        {
                            TrafficRoutingMethod = trafficRoutingMethod,
                            DnsConfig = new DnsConfig
                            {
                                RelativeName = relativeDnsName,
                                Ttl = ttl
                            },
                            MonitorConfig = new MonitorConfig
                            {
                                Protocol = monitorProtocol,
                                Port = monitorPort,
                                Path = monitorPath
                            }
                        }
                    }
                });

            return TrafficManagerClient.GetPowershellTrafficManagerProfile(resourceGroupName, profileName, response.Profile.Properties);
        }

        private static TrafficManagerProfile GetPowershellTrafficManagerProfile(string resourceGroupName, string profileName, ProfileProperties mamlProfileProperties)
        {
            return new TrafficManagerProfile
            {
                Name = profileName,
                ResourceGroupName = resourceGroupName,
                RelativeDnsName = mamlProfileProperties.DnsConfig.RelativeName,
                Ttl = mamlProfileProperties.DnsConfig.Ttl,
                TrafficRoutingMethod = mamlProfileProperties.TrafficRoutingMethod,
                MonitorProtocol = mamlProfileProperties.MonitorConfig.Protocol,
                MonitorPort = mamlProfileProperties.MonitorConfig.Port,
                MonitorPath = mamlProfileProperties.MonitorConfig.Path
            };
        }
    }
}
