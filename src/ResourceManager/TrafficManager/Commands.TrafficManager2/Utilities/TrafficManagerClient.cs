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
    
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Commands.TrafficManager.Models;
    using Microsoft.Azure.Management.TrafficManager;
    using Microsoft.Azure.Management.TrafficManager.Models;

    public class TrafficManagerClient
    {
        public const string ProfileResourceLocation = "global";

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public TrafficManagerClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<TrafficManagerManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public TrafficManagerClient(ITrafficManagerManagementClient client)
        {
            this.TrafficManagerManagementClient = client;
        }

        public ITrafficManagerManagementClient TrafficManagerManagementClient { get; set; }

        public TrafficManagerProfile CreateTrafficManagerProfile(string resourceGroupName, string profileName, string profileStatus, string trafficRoutingMethod, string relativeDnsName, uint ttl, string monitorProtocol, uint monitorPort, string monitorPath, int? monitorInterval, int? monitorTimeout, int? monitorToleratedNumberOfFailures, Hashtable tag)
        {
            Profile response = this.TrafficManagerManagementClient.Profiles.CreateOrUpdate(
                resourceGroupName,
                profileName,
                new Profile(name: profileName, location: TrafficManagerClient.ProfileResourceLocation)
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
                        Path = monitorPath,
                        IntervalInSeconds = monitorInterval,
                        TimeoutInSeconds = monitorTimeout,
                        ToleratedNumberOfFailures = monitorToleratedNumberOfFailures,
                    },
                    Tags = TagsConversionHelper.CreateTagDictionary(tag, validate: true),
                });

            return Convert.ToTrafficManagerProfile(resourceGroupName, profileName, response);
        }

        public TrafficManagerEndpoint CreateTrafficManagerEndpoint(string resourceGroupName, string profileName, string endpointType, string endpointName, string targetResourceId, string target, string endpointStatus, uint? weight, uint? priority, string endpointLocation, uint? minChildEndpoints, IList<string> geoMapping)
        {
            Endpoint response = this.TrafficManagerManagementClient.Endpoints.CreateOrUpdate(
                resourceGroupName,
                profileName,
                endpointType,
                endpointName,
                new Endpoint(name: endpointName, type: TrafficManagerEndpoint.ToFullEndpointType(endpointType))
                {
                    EndpointLocation = endpointLocation,
                    EndpointStatus = endpointStatus,
                    GeoMapping = geoMapping,
                    MinChildEndpoints = minChildEndpoints,
                    Priority = priority,
                    Target = target,
                    TargetResourceId = targetResourceId,
                    Weight = weight,
                });

            return Convert.ToTrafficManagerEndpoint(response.Id, resourceGroupName, profileName, endpointType, endpointName, response);
        }

        public TrafficManagerProfile GetTrafficManagerProfile(string resourceGroupName, string profileName)
        {
            Profile response = this.TrafficManagerManagementClient.Profiles.Get(resourceGroupName, profileName);

            return Convert.ToTrafficManagerProfile(resourceGroupName, profileName, response);
        }

        public TrafficManagerEndpoint GetTrafficManagerEndpoint(string resourceGroupName, string profileName, string endpointType, string endpointName)
        {
            Endpoint response = this.TrafficManagerManagementClient.Endpoints.Get(resourceGroupName, profileName, endpointType, endpointName);

            return Convert.ToTrafficManagerEndpoint(
                response.Id,
                resourceGroupName,
                profileName,
                endpointType,
                endpointName,
                response);
        }

        public TrafficManagerProfile[] ListTrafficManagerProfiles(string resourceGroupName = null)
        {
            IEnumerable<Profile> response =
                resourceGroupName == null ?
                this.TrafficManagerManagementClient.Profiles.ListAll() :
                this.TrafficManagerManagementClient.Profiles.ListAllInResourceGroup(resourceGroupName);

            return response.Select(profile => Convert.ToTrafficManagerProfile(
                resourceGroupName ?? new TrafficManagerProfileResourceId(profile.Id).ResourceGroup,
                profile.Name,
                profile)).ToArray();
        }

        public TrafficManagerProfile SetTrafficManagerProfile(TrafficManagerProfile profile)
        {
            Profile profileToSet = Convert.ToSDKProfile(profile);

            Profile response = this.TrafficManagerManagementClient.Profiles.CreateOrUpdate(
                profile.ResourceGroupName,
                profile.Name,
                profileToSet
                );

            return Convert.ToTrafficManagerProfile(profile.ResourceGroupName, profile.Name, response);
        }

        public TrafficManagerEndpoint SetTrafficManagerEndpoint(TrafficManagerEndpoint endpoint)
        {
            Endpoint endpointToSet = Convert.ToSDKEndpoint(endpoint);

            Endpoint response = this.TrafficManagerManagementClient.Endpoints.CreateOrUpdate(
                endpoint.ResourceGroupName,
                endpoint.ProfileName,
                endpoint.Type,
                endpoint.Name,
                endpointToSet);

            return Convert.ToTrafficManagerEndpoint(
                endpoint.Id,
                endpoint.ResourceGroupName,
                endpoint.ProfileName,
                endpoint.Type,
                endpoint.Name,
                response);
        }

        public bool DeleteTrafficManagerProfile(string resourceGroupName, string profileName)
        {
            HttpStatusCode code = this.DeleteTrafficManagerProfileAsync(resourceGroupName, profileName).GetAwaiter().GetResult();

            return code == HttpStatusCode.OK;
        }

        public bool DeleteTrafficManagerEndpoint(string resourceGroupName, string profileName, string endpointType, string endpointName)
        {
            HttpStatusCode code = this.DeleteTrafficManagerEndpointAsync(resourceGroupName, profileName, endpointType, endpointName).GetAwaiter().GetResult();

            return code == HttpStatusCode.OK;
        }

        #region BUG#1226881 Traffic Manager does not return a response body to Delete operations

        private async System.Threading.Tasks.Task<HttpStatusCode> DeleteTrafficManagerProfileAsync(string resourceGroupName, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await this.TrafficManagerManagementClient.Profiles.DeleteWithHttpMessagesAsync(resourceGroupName, profileName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Response.StatusCode;
            }
        }

        private async System.Threading.Tasks.Task<HttpStatusCode> DeleteTrafficManagerEndpointAsync(string resourceGroupName, string profileName, string endpointType, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await this.TrafficManagerManagementClient.Endpoints.DeleteWithHttpMessagesAsync(resourceGroupName, profileName, endpointType, endpointName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Response.StatusCode;
            }
        }

        #endregion

        public bool EnableTrafficManagerProfile(string resourceGroup, string profileName)
        {
            return this.EnableDisableTrafficManagerProfile(resourceGroup, profileName, shouldEnableProfileStatus: true);
        }

        public bool DisableTrafficManagerProfile(string resourceGroup, string profileName)
        {
            return this.EnableDisableTrafficManagerProfile(resourceGroup, profileName, shouldEnableProfileStatus: false);
        }

        private bool EnableDisableTrafficManagerProfile(string resourceGroup, string profileName, bool shouldEnableProfileStatus)
        {
            var profile = new Profile(profileStatus: shouldEnableProfileStatus ? Constants.StatusEnabled : Constants.StatusDisabled);

            this.TrafficManagerManagementClient.Profiles.Update(resourceGroup, profileName, profile);

            return true;
        }

        public bool EnableTrafficManagerEndpoint(string resourceGroup, string profileName, string endpointType, string endpointName)
        {
            return this.EnableDisableTrafficManagerEndpoint(resourceGroup, profileName, endpointType, endpointName, shouldEnableEndpointStatus: true);
        }

        public bool DisableTrafficManagerEndpoint(string resourceGroup, string profileName, string endpointType, string endpointName)
        {
            return this.EnableDisableTrafficManagerEndpoint(resourceGroup, profileName, endpointType, endpointName, shouldEnableEndpointStatus: false);
        }

        private bool EnableDisableTrafficManagerEndpoint(string resourceGroup, string profileName, string endpointType, string endpointName, bool shouldEnableEndpointStatus)
        {
            var sdkEndpoint = new Endpoint(name: endpointName, type: TrafficManagerEndpoint.ToFullEndpointType(endpointType), endpointStatus: shouldEnableEndpointStatus ? Constants.StatusEnabled : Constants.StatusDisabled);

            this.TrafficManagerManagementClient.Endpoints.Update(resourceGroup, profileName, endpointType, endpointName, sdkEndpoint);

            return true;
        }
    }
}
