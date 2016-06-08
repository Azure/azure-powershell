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

using System.Collections.Generic;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Models
{
    /// <summary>
    /// Class that will be exposed to PowerShell to interact with profiles
    /// This class will be piped between cmdlets.
    /// Note that some definition properties are missing because they are not configurable yet
    /// and would be as read-only. These properties are not exposed in the portal either:
    /// - MonitorExpectedStatusCode
    /// - MonitorVerb
    /// - MonitorIntervalInSeconds
    /// - MonitorTimeOutInSeconds
    /// - MonitorToleratedNumberOfFailures
    /// </summary>
    public class ProfileWithDefinition : SimpleProfile, IProfileWithDefinition
    {
        private Definition definition { get; set; }
        private IList<TrafficManagerEndpoint> endpoints { get; set; }

        public int TimeToLiveInSeconds
        {
            get { return this.definition.DnsOptions.TimeToLiveInSeconds; }
            set { this.definition.DnsOptions.TimeToLiveInSeconds = value; }
        }

        public string MonitorRelativePath
        {
            get { return this.definition.Monitors[0].HttpOptions.RelativePath; }
            set { this.definition.Monitors[0].HttpOptions.RelativePath = value; }
        }

        public int MonitorPort
        {
            get { return this.definition.Monitors[0].Port; }
            set { this.definition.Monitors[0].Port = value; }
        }

        public DefinitionMonitorProtocol MonitorProtocol
        {
            get { return this.definition.Monitors[0].Protocol; }
            set { this.definition.Monitors[0].Protocol = value; }
        }

        public LoadBalancingMethod LoadBalancingMethod
        {
            get { return this.definition.Policy.LoadBalancingMethod; }
            set { this.definition.Policy.LoadBalancingMethod = value; }
        }

        public IList<TrafficManagerEndpoint> Endpoints
        {
            get
            {
                if (this.endpoints == null)
                {
                    this.endpoints = new List<TrafficManagerEndpoint>();

                    foreach (DefinitionEndpointResponse endpointReponse in this.definition.Policy.Endpoints)
                    {
                        TrafficManagerEndpoint endpoint = new TrafficManagerEndpoint();
                        endpoint.DomainName = endpointReponse.DomainName;
                        endpoint.Location = endpointReponse.Location;
                        endpoint.Type = endpointReponse.Type;
                        endpoint.Status = endpointReponse.Status;
                        endpoint.Weight = endpointReponse.Weight;
                        endpoint.MinChildEndpoints = endpointReponse.MinChildEndpoints;
                        endpoint.MonitorStatus = endpointReponse.MonitorStatus;

                        this.endpoints.Add(endpoint);
                    }
                }
                return this.endpoints;
            }

            set
            {
                this.endpoints = value;
            }
        }

        public DefinitionPolicyMonitorStatus MonitorStatus
        {
            get { return this.definition.Policy.MonitorStatus; }
            set { this.definition.Policy.MonitorStatus = value; }
        }

        public ProfileWithDefinition GetInstance()
        {
            return this;
        }

        public ProfileWithDefinition(Management.TrafficManager.Models.Profile profile, Definition definition) : base(profile)
        {
            this.endpoints = null;
            this.definition = definition;
        }

        public ProfileWithDefinition() : base(new Management.TrafficManager.Models.Profile())
        {
            this.endpoints = null;
            this.definition = new Definition()
            {
                Policy = new DefinitionPolicyResponse()
            };
            DefinitionMonitor monitor = new DefinitionMonitor()
            {
                HttpOptions = new DefinitionMonitorHTTPOptions(),
            };
            this.definition.Monitors.Add(monitor);
            this.definition.DnsOptions = new DefinitionDnsOptions();
        }
    }
}
