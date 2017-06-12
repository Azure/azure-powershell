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
    using System.Linq;

    using Microsoft.Azure.Commands.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager.Models;

    public static class Convert
    {
        public static TrafficManagerProfile ToTrafficManagerProfile(string resourceGroupName, string profileName, Profile sdkProfile)
        {
            var profile = new TrafficManagerProfile
            {
                Id = sdkProfile.Id,
                Name = profileName,
                ResourceGroupName = resourceGroupName,
                ProfileStatus = sdkProfile.ProfileStatus,
                RelativeDnsName = sdkProfile.DnsConfig.RelativeName,
                Ttl = (uint)sdkProfile.DnsConfig.Ttl,
                TrafficRoutingMethod = sdkProfile.TrafficRoutingMethod,
                MonitorProtocol = sdkProfile.MonitorConfig.Protocol,
                MonitorPort = (uint)sdkProfile.MonitorConfig.Port,
                MonitorPath = sdkProfile.MonitorConfig.Path,
                MonitorIntervalInSeconds = (int?)sdkProfile.MonitorConfig.IntervalInSeconds,
                MonitorTimeoutInSeconds = (int?)sdkProfile.MonitorConfig.TimeoutInSeconds,
                MonitorToleratedNumberOfFailures = (int?)sdkProfile.MonitorConfig.ToleratedNumberOfFailures,
            };

            if (sdkProfile.Endpoints != null)
            {
                profile.Endpoints = new List<TrafficManagerEndpoint>();

                foreach (Endpoint endpoint in sdkProfile.Endpoints)
                {
                    profile.Endpoints.Add(
                        Convert.ToTrafficManagerEndpoint(
                            endpoint.Id,
                            resourceGroupName,
                            profileName,
                            endpoint.Type,
                            endpoint.Name,
                            endpoint));
                }
            }

            return profile;
        }

        public static TrafficManagerEndpoint ToTrafficManagerEndpoint(string id, string resourceGroupName, string profileName, string endpointType, string endpointName, Endpoint sdkEndpoint)
        {
            return new TrafficManagerEndpoint
            {
                Id = id,
                ResourceGroupName = resourceGroupName,
                ProfileName = profileName,
                Name = endpointName,
                Type = TrafficManagerEndpoint.ToShortEndpointType(endpointType),

                EndpointStatus = sdkEndpoint.EndpointStatus,
                EndpointMonitorStatus = sdkEndpoint.EndpointMonitorStatus,
                GeoMapping = sdkEndpoint.GeoMapping != null ? sdkEndpoint.GeoMapping.ToList() : null,
                Location = sdkEndpoint.EndpointLocation,
                MinChildEndpoints = (uint?)sdkEndpoint.MinChildEndpoints,
                Priority = (uint?)sdkEndpoint.Priority,
                Target = sdkEndpoint.Target,
                TargetResourceId = sdkEndpoint.TargetResourceId,
                Weight = (uint?)sdkEndpoint.Weight,
            };
        }

        public static Profile ToSDKProfile(TrafficManagerProfile trafficManagerProfile)
        {
            var profile = new Profile(trafficManagerProfile.Id, trafficManagerProfile.Name, Constants.ProfileType, TrafficManagerClient.ProfileResourceLocation)
            {
                ProfileStatus = trafficManagerProfile.ProfileStatus,
                TrafficRoutingMethod = trafficManagerProfile.TrafficRoutingMethod,
                DnsConfig = new DnsConfig
                {
                    RelativeName = trafficManagerProfile.RelativeDnsName,
                    Ttl = trafficManagerProfile.Ttl
                },
                MonitorConfig = new MonitorConfig
                {
                    Protocol = trafficManagerProfile.MonitorProtocol,
                    Port = trafficManagerProfile.MonitorPort,
                    Path = trafficManagerProfile.MonitorPath,
                    IntervalInSeconds = trafficManagerProfile.MonitorIntervalInSeconds,
                    TimeoutInSeconds = trafficManagerProfile.MonitorTimeoutInSeconds,
                    ToleratedNumberOfFailures = trafficManagerProfile.MonitorToleratedNumberOfFailures,
                }
            };

            if (trafficManagerProfile.Endpoints != null && trafficManagerProfile.Endpoints.Any())
            {
                profile.Endpoints = trafficManagerProfile.Endpoints.Select(Convert.ToSDKEndpoint).ToList();
            }

            return profile;
        }
        
        public static Endpoint ToSDKEndpoint(TrafficManagerEndpoint trafficManagerEndpoint)
        {
            return new Endpoint
            {
                Id = trafficManagerEndpoint.Id,
                Name = trafficManagerEndpoint.Name,
                Type = TrafficManagerEndpoint.ToFullEndpointType(trafficManagerEndpoint.Type),
                EndpointLocation = trafficManagerEndpoint.Location,
                EndpointStatus = trafficManagerEndpoint.EndpointStatus,
                GeoMapping = trafficManagerEndpoint.GeoMapping,
                MinChildEndpoints = trafficManagerEndpoint.MinChildEndpoints,
                Priority = trafficManagerEndpoint.Priority,
                Target = trafficManagerEndpoint.Target,
                TargetResourceId = trafficManagerEndpoint.TargetResourceId,
                Weight = trafficManagerEndpoint.Weight,
            };
        }
    }
}