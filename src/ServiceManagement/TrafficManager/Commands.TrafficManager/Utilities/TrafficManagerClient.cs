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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.TrafficManager.Models;
using Microsoft.WindowsAzure.Management.TrafficManager;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure;
using Hyak.Common;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Utilities
{
    public class TrafficManagerClient : ITrafficManagerClient
    {
        public TrafficManagerManagementClient Client { get; internal set; }

        public TrafficManagerClient(AzureSMProfile profile, AzureSubscription subscription)
        {
            this.Client = AzureSession.ClientFactory.CreateClient<TrafficManagerManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        public TrafficManagerClient(TrafficManagerManagementClient client)
        {
            this.Client = client;
        }

        public ProfileWithDefinition NewAzureTrafficManagerProfile(
            string profileName,
            string domainName,
            string loadBalancingMethod,
            int monitorPort,
            string monitorProtocol,
            string monitorRelativePath,
            int ttl)
        {
            // Create the profile
            this.CreateTrafficManagerProfile(profileName, domainName);

            // Create the definition
            DefinitionCreateParameters definitionParameter = this.InstantiateTrafficManagerDefinition(
                loadBalancingMethod,
                monitorPort,
                monitorProtocol,
                monitorRelativePath,
                ttl,
                // not adding any endpoints at this time
                new List<TrafficManagerEndpoint>());

            this.CreateTrafficManagerDefinition(profileName, definitionParameter);

            return this.GetTrafficManagerProfileWithDefinition(profileName);
        }

        public ProfileWithDefinition AssignDefinitionToProfile(string profileName, DefinitionCreateParameters definitionParameter)
        {
            this.Client.Definitions.Create(profileName, definitionParameter);
            return this.GetTrafficManagerProfileWithDefinition(profileName);
        }

        public void RemoveTrafficManagerProfile(string profileName)
        {
            AzureOperationResponse resp = this.Client.Profiles.Delete(profileName);
        }

        public ProfileWithDefinition GetTrafficManagerProfileWithDefinition(string profileName)
        {
            Management.TrafficManager.Models.Profile profile = this.GetProfile(profileName).Profile;
            Definition definition = null;
            try
            {
                definition = this.GetDefinition(profileName).Definition;

            }
            catch (CloudException)
            {
                
            }
            return new ProfileWithDefinition(profile, definition);
        }

        public DefinitionCreateParameters InstantiateTrafficManagerDefinition(
            string loadBalancingMethod,
            int monitorPort,
            string monitorProtocol,
            string monitorRelativePath,
            int ttl,
            IList<TrafficManagerEndpoint> endpoints)
        {
            // Create the definition
            var definitionParameter = new DefinitionCreateParameters();
            var dnsOptions = new DefinitionDnsOptions();
            var monitor = new DefinitionMonitor();
            var policyParameter = new DefinitionPolicyCreateParameters();
            var monitorHttpOption = new DefinitionMonitorHTTPOptions();

            dnsOptions.TimeToLiveInSeconds = ttl;

            monitorHttpOption.RelativePath = monitorRelativePath;
            monitorHttpOption.Verb = Constants.monitorHttpOptionVerb;
            monitorHttpOption.ExpectedStatusCode = Constants.monitorHttpOptionExpectedStatusCode;

            monitor.Protocol =
                (DefinitionMonitorProtocol)Enum.Parse(typeof(DefinitionMonitorProtocol), monitorProtocol);
            monitor.IntervalInSeconds = Constants.monitorIntervalInSeconds;
            monitor.TimeoutInSeconds = Constants.monitorTimeoutInSeconds;
            monitor.ToleratedNumberOfFailures = Constants.monitorToleratedNumberOfFailures;
            monitor.Port = monitorPort;
            policyParameter.LoadBalancingMethod =
                (LoadBalancingMethod)Enum.Parse(typeof(LoadBalancingMethod), loadBalancingMethod);

            policyParameter.Endpoints = new List<DefinitionEndpointCreateParameters>();
            foreach (TrafficManagerEndpoint endpoint in endpoints)
            {
                var endpointParam = new DefinitionEndpointCreateParameters
                    {
                        DomainName = endpoint.DomainName,
                        Location = endpoint.Location,
                        Status = endpoint.Status,
                        Type = endpoint.Type,
                        Weight = endpoint.Weight,
                        MinChildEndpoints = endpoint.MinChildEndpoints
                    };

                policyParameter.Endpoints.Add(endpointParam);
            }

            definitionParameter.DnsOptions = dnsOptions;
            definitionParameter.Policy = policyParameter;
            definitionParameter.Monitors.Add(monitor);
            monitor.HttpOptions = monitorHttpOption;

            return definitionParameter;
        }

        public DefinitionCreateParameters InstantiateTrafficManagerDefinition(Definition definition)
        {
            var definitionCreateParams = new DefinitionCreateParameters();

            var endpoints = new List<DefinitionEndpointCreateParameters>();
            foreach (DefinitionEndpointResponse endpointReponse in definition.Policy.Endpoints)
            {
                var endpoint = new DefinitionEndpointCreateParameters
                    {
                        DomainName = endpointReponse.DomainName,
                        Location = endpointReponse.Location,
                        Type = endpointReponse.Type,
                        Status = endpointReponse.Status,
                        Weight = endpointReponse.Weight,
                        MinChildEndpoints = endpointReponse.MinChildEndpoints
                    };

                endpoints.Add(endpoint);
            }

            definitionCreateParams.Policy = new DefinitionPolicyCreateParameters
            {
                Endpoints = endpoints,
                LoadBalancingMethod = definition.Policy.LoadBalancingMethod
            };

            definitionCreateParams.DnsOptions = definition.DnsOptions;
            definitionCreateParams.Monitors = definition.Monitors;

            return definitionCreateParams;
        }

        public void UpdateProfileStatus(string profileName, ProfileDefinitionStatus targetStatus)
        {
            ProfileDefinitionStatus currentStatus = this.GetStatus(profileName);
            if (currentStatus != targetStatus)
            {
                this.Client.Profiles.Update(profileName, targetStatus, 1);
            }
        }

        public ProfileDefinitionStatus GetStatus(string profileName)
        {
            return this.Client.Profiles.Get(profileName).Profile.Status;
        }

        public void CreateTrafficManagerProfile(string profileName, string domainName)
        {
            this.Client.Profiles.Create(profileName, domainName);
        }

        public void CreateTrafficManagerDefinition(string profileName, DefinitionCreateParameters parameters)
        {
            this.Client.Definitions.Create(profileName, parameters);
        }

        public ProfileGetResponse GetProfile(string profileName)
        {
            return this.Client.Profiles.Get(profileName);
        }

        public DefinitionGetResponse GetDefinition(string profileName)
        {
            return this.Client.Definitions.Get(profileName);
        }

        public IEnumerable<SimpleProfile> ListProfiles()
        {
            IList<Management.TrafficManager.Models.Profile> respProfiles = this.Client.Profiles.List().Profiles;

            IEnumerable<SimpleProfile> resultProfiles =
                respProfiles.Select(respProfile => new SimpleProfile(respProfile));

            return resultProfiles;
        }

        public bool TestDomainAvailability(string domainName)
        {
            return this.Client.Profiles.CheckDnsPrefixAvailability(domainName).Result;
        }
    }
}
