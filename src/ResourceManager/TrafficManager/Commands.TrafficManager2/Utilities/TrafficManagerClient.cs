﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.TrafficManager.Utilities
{
    using Common.Authentication.Abstractions;
    using Management.TrafficManager;
    using Management.TrafficManager.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class TrafficManagerClient
    {
        public const string ProfileResourceLocation = "global";

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public TrafficManagerClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateClient<TrafficManagerManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public TrafficManagerClient(ITrafficManagerManagementClient client)
        {
            this.TrafficManagerManagementClient = client;
        }

        public ITrafficManagerManagementClient TrafficManagerManagementClient { get; set; }

        public TrafficManagerProfile CreateTrafficManagerProfile(string resourceGroupName, string profileName, string profileStatus, string trafficRoutingMethod, string relativeDnsName, uint ttl, string monitorProtocol, uint monitorPort, string monitorPath, Hashtable tag)
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
                            ProfileStatus = profileStatus,
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
                        },
                        Tags = TagsConversionHelper.CreateTagDictionary(tag, validate: true),
                    }
                });

            return TrafficManagerClient.GetPowershellTrafficManagerProfile(resourceGroupName, profileName, response.Profile);
        }

        public TrafficManagerEndpoint CreateTrafficManagerEndpoint(string resourceGroupName, string profileName, string endpointType, string endpointName, string targetResourceId, string target, string endpointStatus, uint? weight, uint? priority, string endpointLocation, uint? minChildEndpoints, IList<string> geoMapping)
        {
            EndpointCreateOrUpdateResponse response = this.TrafficManagerManagementClient.Endpoints.CreateOrUpdate(
                resourceGroupName,
                profileName,
                endpointType,
                endpointName,
                new EndpointCreateOrUpdateParameters
                {
                    Endpoint = new Endpoint
                    {
                        Name = endpointName,
                        Type = TrafficManagerEndpoint.ToSDKEndpointType(endpointType),
                        Properties = new EndpointProperties
                        {
                            EndpointLocation = endpointLocation,
                            EndpointStatus = endpointStatus,
                            GeoMapping = geoMapping,
                            MinChildEndpoints = minChildEndpoints,
                            Priority = priority,
                            Target = target,
                            TargetResourceId = targetResourceId,
                            Weight = weight,
                        }
                    }
                });

            return TrafficManagerClient.GetPowershellTrafficManagerEndpoint(response.Endpoint.Id, resourceGroupName, profileName, endpointType, endpointName, response.Endpoint.Properties);
        }

        public TrafficManagerProfile GetTrafficManagerProfile(string resourceGroupName, string profileName)
        {
            ProfileGetResponse response = this.TrafficManagerManagementClient.Profiles.Get(resourceGroupName, profileName);

            return TrafficManagerClient.GetPowershellTrafficManagerProfile(resourceGroupName, profileName, response.Profile);
        }

        public TrafficManagerEndpoint GetTrafficManagerEndpoint(string resourceGroupName, string profileName, string endpointType, string endpointName)
        {
            EndpointGetResponse response = this.TrafficManagerManagementClient.Endpoints.Get(resourceGroupName, profileName, endpointType, endpointName);

            return TrafficManagerClient.GetPowershellTrafficManagerEndpoint(
                response.Endpoint.Id,
                resourceGroupName,
                profileName,
                endpointType,
                endpointName,
                response.Endpoint.Properties);
        }

        public TrafficManagerProfile[] ListTrafficManagerProfiles(string resourceGroupName = null)
        {
            ProfileListResponse response =
                resourceGroupName == null ?
                this.TrafficManagerManagementClient.Profiles.ListAll() :
                this.TrafficManagerManagementClient.Profiles.ListAllInResourceGroup(resourceGroupName);

            return response.Profiles.Select(profile => TrafficManagerClient.GetPowershellTrafficManagerProfile(
                resourceGroupName ?? TrafficManagerClient.ExtractResourceGroupFromId(profile.Id),
                profile.Name,
                profile)).ToArray();
        }

        public TrafficManagerProfile SetTrafficManagerProfile(TrafficManagerProfile profile)
        {
            var parameters = new ProfileCreateOrUpdateParameters
            {
                Profile = profile.ToSDKProfile()
            };

            ProfileCreateOrUpdateResponse response = this.TrafficManagerManagementClient.Profiles.CreateOrUpdate(
                profile.ResourceGroupName,
                profile.Name,
                parameters
                );

            return TrafficManagerClient.GetPowershellTrafficManagerProfile(profile.ResourceGroupName, profile.Name, response.Profile);
        }

        public TrafficManagerEndpoint SetTrafficManagerEndpoint(TrafficManagerEndpoint endpoint)
        {
            var parameters = new EndpointCreateOrUpdateParameters
            {
                Endpoint = endpoint.ToSDKEndpoint()
            };

            EndpointCreateOrUpdateResponse response = this.TrafficManagerManagementClient.Endpoints.CreateOrUpdate(
                endpoint.ResourceGroupName,
                endpoint.ProfileName,
                endpoint.Type,
                endpoint.Name,
                parameters);

            return TrafficManagerClient.GetPowershellTrafficManagerEndpoint(
                endpoint.Id,
                endpoint.ResourceGroupName,
                endpoint.ProfileName,
                endpoint.Type,
                endpoint.Name,
                response.Endpoint.Properties);
        }

        public bool DeleteTrafficManagerProfile(TrafficManagerProfile profile)
        {
            AzureOperationResponse response = this.TrafficManagerManagementClient.Profiles.Delete(profile.ResourceGroupName, profile.Name);

            return response.StatusCode.Equals(HttpStatusCode.OK);
        }

        public bool DeleteTrafficManagerEndpoint(TrafficManagerEndpoint trafficManagerEndpoint)
        {
            AzureOperationResponse response = this.TrafficManagerManagementClient.Endpoints.Delete(
                trafficManagerEndpoint.ResourceGroupName,
                trafficManagerEndpoint.ProfileName,
                trafficManagerEndpoint.Type,
                trafficManagerEndpoint.Name);

            return response.StatusCode.Equals(HttpStatusCode.OK);
        }

        public bool EnableDisableTrafficManagerProfile(TrafficManagerProfile profile, bool shouldEnableProfileStatus)
        {
            profile.ProfileStatus = shouldEnableProfileStatus ? Constants.StatusEnabled : Constants.StatusDisabled;

            Profile sdkProfile = profile.ToSDKProfile();
            sdkProfile.Properties.DnsConfig = null;
            sdkProfile.Properties.Endpoints = null;
            sdkProfile.Properties.TrafficRoutingMethod = null;
            sdkProfile.Properties.MonitorConfig = null;

            var parameters = new ProfileUpdateParameters
            {
                Profile = sdkProfile
            };

            AzureOperationResponse response = this.TrafficManagerManagementClient.Profiles.Update(profile.ResourceGroupName, profile.Name, parameters);

            return response.StatusCode.Equals(HttpStatusCode.OK);
        }

        public bool EnableDisableTrafficManagerEndpoint(TrafficManagerEndpoint endpoint, bool shouldEnableEndpointStatus)
        {
            endpoint.EndpointStatus = shouldEnableEndpointStatus ? Constants.StatusEnabled : Constants.StatusDisabled;

            Endpoint sdkEndpoint = endpoint.ToSDKEndpointForPatch();
            sdkEndpoint.Properties.EndpointStatus = endpoint.EndpointStatus;

            var parameters = new EndpointUpdateParameters
            {
                Endpoint = sdkEndpoint
            };

            AzureOperationResponse response = this.TrafficManagerManagementClient.Endpoints.Update(
                endpoint.ResourceGroupName,
                endpoint.ProfileName,
                endpoint.Type,
                endpoint.Name,
                parameters);

            return response.StatusCode.Equals(HttpStatusCode.Created);
        }

        private static TrafficManagerProfile GetPowershellTrafficManagerProfile(string resourceGroupName, string profileName, Profile mamlProfile)
        {
            var profile = new TrafficManagerProfile
            {
                Id = mamlProfile.Id,
                Name = profileName,
                ResourceGroupName = resourceGroupName,
                ProfileStatus = mamlProfile.Properties.ProfileStatus,
                RelativeDnsName = mamlProfile.Properties.DnsConfig.RelativeName,
                Ttl = mamlProfile.Properties.DnsConfig.Ttl,
                TrafficRoutingMethod = mamlProfile.Properties.TrafficRoutingMethod,
                MonitorProtocol = mamlProfile.Properties.MonitorConfig.Protocol,
                MonitorPort = mamlProfile.Properties.MonitorConfig.Port,
                MonitorPath = mamlProfile.Properties.MonitorConfig.Path
            };

            if (mamlProfile.Properties.Endpoints != null)
            {
                profile.Endpoints = new List<TrafficManagerEndpoint>();

                foreach (Endpoint endpoint in mamlProfile.Properties.Endpoints)
                {
                    profile.Endpoints.Add(
                        GetPowershellTrafficManagerEndpoint(
                            endpoint.Id,
                            resourceGroupName,
                            profileName,
                            endpoint.Type,
                            endpoint.Name, 
                            endpoint.Properties));
                }
            }

            return profile;
        }

        private static string ExtractResourceGroupFromId(string id)
        {
            return id.Split('/')[4];
        }

        private static TrafficManagerEndpoint GetPowershellTrafficManagerEndpoint(string id, string resourceGroupName, string profileName, string endpointType, string endpointName, EndpointProperties mamlEndpointProperties)
        {
            return new TrafficManagerEndpoint
            {
                Id = id,
                ResourceGroupName = resourceGroupName,
                ProfileName = profileName,
                Name = endpointName,
                Type = endpointType,

                EndpointStatus = mamlEndpointProperties.EndpointStatus,
                EndpointMonitorStatus = mamlEndpointProperties.EndpointMonitorStatus,
                GeoMapping = mamlEndpointProperties.GeoMapping != null ? mamlEndpointProperties.GeoMapping.ToList() : null,
                Location = mamlEndpointProperties.EndpointLocation,
                MinChildEndpoints = mamlEndpointProperties.MinChildEndpoints,
                Priority = mamlEndpointProperties.Priority,
                Target = mamlEndpointProperties.Target,
                TargetResourceId = mamlEndpointProperties.TargetResourceId,
                Weight = mamlEndpointProperties.Weight,
            };
        }
    }
}
