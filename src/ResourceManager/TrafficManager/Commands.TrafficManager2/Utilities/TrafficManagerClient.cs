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
    using System.Collections.Generic;
    using System.Net;
    using Microsoft.Azure.Commands.TrafficManager.Models;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Common.Authentication.Models;
    using Microsoft.Azure.Management.TrafficManager;
    using Microsoft.Azure.Management.TrafficManager.Models;
    using Endpoint = Microsoft.Azure.Management.TrafficManager.Models.Endpoint;

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
            ProfileCreateOrUpdateResponse response = this.TrafficManagerManagementClient.Profiles.CreateOrUpdate(
                resourceGroupName, 
                profileName,
                new ProfileCreateOrUpdateParameters
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

        public TrafficManagerProfile GetTrafficManagerProfile(string resourceGroupName, string profileName)
        {
            ProfileGetResponse response = this.TrafficManagerManagementClient.Profiles.Get(resourceGroupName, profileName);

            return TrafficManagerClient.GetPowershellTrafficManagerProfile(resourceGroupName, profileName, response.Profile.Properties);
        }

        public TrafficManagerProfile SetTrafficManagerProfile(TrafficManagerProfile profile)
        {
            var parameteres = new ProfileCreateOrUpdateParameters
            {
                Profile = profile.ToSDKProfile()
            };

            ProfileCreateOrUpdateResponse response = this.TrafficManagerManagementClient.Profiles.CreateOrUpdate(
                profile.ResourceGroupName,
                profile.Name, 
                parameteres
                );

            return TrafficManagerClient.GetPowershellTrafficManagerProfile(profile.ResourceGroupName, profile.Name, response.Profile.Properties);
        }

        public bool DeleteTrafficManagerProfile(TrafficManagerProfile profile)
        {
            AzureOperationResponse response = this.TrafficManagerManagementClient.Profiles.Delete(profile.ResourceGroupName, profile.Name);

            return response.StatusCode.Equals(HttpStatusCode.OK);
        }

        private static TrafficManagerProfile GetPowershellTrafficManagerProfile(string resourceGroupName, string profileName, ProfileProperties mamlProfileProperties)
        {
            var profile = new TrafficManagerProfile
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

            if (mamlProfileProperties.Endpoints != null)
            {
                profile.Endpoints = new List<Models.Endpoint>();

                foreach (Endpoint endpoint in mamlProfileProperties.Endpoints)
                {
                    profile.Endpoints.Add(new Models.Endpoint
                    {
                        Name = endpoint.Name,
                        Type = endpoint.Type,
                        Target = endpoint.Properties.Target,
                        EndpointStatus = endpoint.Properties.EndpointStatus,
                        Location = endpoint.Properties.EndpointLocation,
                        Priority = endpoint.Properties.Priority,
                        Weight = endpoint.Properties.Weight
                    });
                }
            }

            return profile;
        }
    }
}
