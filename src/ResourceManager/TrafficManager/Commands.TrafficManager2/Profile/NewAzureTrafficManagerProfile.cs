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



namespace Microsoft.Azure.Commands.TrafficManager
{
    using System.Collections;
    using System.Net;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.TrafficManager.Models;
    using Microsoft.Azure.Commands.TrafficManager.Utilities;
    using Microsoft.Rest.Azure;
    using ProjectResources = Microsoft.Azure.Commands.TrafficManager.Properties.Resources;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Collections.Generic;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "TrafficManagerProfile"), OutputType(typeof(TrafficManagerProfile))]
    public class NewAzureTrafficManagerProfile : TrafficManagerBaseCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The name of the profile.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group to which the profile belongs.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The status of the profile.")]
        [ValidateSet(Constants.StatusEnabled, Constants.StatusDisabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string ProfileStatus { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The relative name of the profile.")]
        [ValidateNotNullOrEmpty]
        public string RelativeDnsName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Ttl value of the DNS configurations.")]
        [ValidateNotNullOrEmpty]
        public uint Ttl { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The traffic routing method of the profile.")]
        [ValidateSet(Constants.Performance, Constants.Weighted, Constants.Priority, Constants.Geographic, Constants.Subnet, Constants.MultiValue, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string TrafficRoutingMethod { get; set; }

        [Alias("ProtocolForMonitor")]
        [Parameter(Mandatory = true, HelpMessage = "The protocol of the monitor.")]
        [ValidateSet(Constants.HTTP, Constants.HTTPS, Constants.TCP, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string MonitorProtocol { get; set; }

        [Alias("PortForMonitor")]
        [Parameter(Mandatory = true, HelpMessage = "The port of the monitor.")]
        [ValidateNotNullOrEmpty]
        public uint MonitorPort { get; set; }

        [Alias("PathForMonitor")]
        [Parameter(Mandatory = false, HelpMessage = "The path of the monitor.")]
        [ValidateNotNullOrEmpty]
        public string MonitorPath { get; set; }

        [Alias("IntervalInSecondsForMonitor")]
        [Parameter(Mandatory = false, HelpMessage = "The interval (in seconds) at which Traffic Manager will check the health of each endpoint in this profile. The default is 30.")]
        [ValidateNotNullOrEmpty]
        public int? MonitorIntervalInSeconds { get; set; }

        [Alias("TimeoutInSecondsForMonitor")]
        [Parameter(Mandatory = false, HelpMessage = "The time (in seconds) that Traffic Manager allows endpoints in this profile to respond to the health check. The default is 10.")]
        [ValidateNotNullOrEmpty]
        public int? MonitorTimeoutInSeconds { get; set; }

        [Alias("ToleratedNumberOfFailuresForMonitor")]
        [Parameter(Mandatory = false, HelpMessage = "The number of consecutive failed health checks that Traffic Manager tolerates before declaring an endpoint in this profile Degraded after the next consecutive failed health check. The default is 3.")]
        [ValidateNotNullOrEmpty]
        public int? MonitorToleratedNumberOfFailures { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The maximum number of answers returned for profiles with a MultiValue routing method.")]
        public long? MaxReturn { get; set; }

        [Alias("Tags")]
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of custom header name and value pairs for probe requests.")]
        [ValidateCount(1, 8)]
        public List<TrafficManagerCustomHeader> CustomHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of expected HTTP status code ranges for probe requests.")]
        [ValidateCount(1, 8)]
        public List<TrafficManagerExpectedStatusCodeRange> ExpectedStatusCodeRange { get; set; }

        public override void ExecuteCmdlet()
        {
            // We are not supporting etags yet, NewAzureTrafficManagerProfile should not overwrite any existing profile.
            // Since our create operation is implemented using PUT, it will overwrite by default.
            // Therefore, we need to check whether the Profile exists before we actually try to create it.
            try
            {
                this.TrafficManagerClient.GetTrafficManagerProfile(this.ResourceGroupName, this.Name);

                throw new PSArgumentException(string.Format(ProjectResources.Error_CreateExistingProfile, this.Name, this.ResourceGroupName));
            }
            catch (CloudException exception)
            {
                if (exception.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    TrafficManagerProfile profile = this.TrafficManagerClient.CreateTrafficManagerProfile(
                    this.ResourceGroupName,
                    this.Name,
                    this.ProfileStatus,
                    this.TrafficRoutingMethod,
                    this.RelativeDnsName,
                    this.Ttl,
                    this.MonitorProtocol,
                    this.MonitorPort,
                    this.MonitorPath,
                    this.MonitorIntervalInSeconds,
                    this.MonitorTimeoutInSeconds,
                    this.MonitorToleratedNumberOfFailures,
                    this.MaxReturn,
                    this.Tag,
                    this.CustomHeader,
                    this.ExpectedStatusCodeRange);

                    this.WriteVerbose(ProjectResources.Success);
                    this.WriteObject(profile);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
