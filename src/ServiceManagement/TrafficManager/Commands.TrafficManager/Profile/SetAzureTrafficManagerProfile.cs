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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.TrafficManager.Models;
using Microsoft.WindowsAzure.Commands.TrafficManager.Utilities;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Profile
{
    [Cmdlet(VerbsCommon.Set, "AzureTrafficManagerProfile"), OutputType(typeof(IProfileWithDefinition))]
    public class SetAzureTrafficManagerProfile : TrafficManagerConfigurationBaseCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateSet("Performance", "Failover", "RoundRobin", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancingMethod { get; set; }

        [Parameter(Mandatory = false)]
        public int? MonitorPort { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateSet("Http", "Https", IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string MonitorProtocol { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string MonitorRelativePath { get; set; }

        [Parameter(Mandatory = false)]
        public int? Ttl { get; set; }

        public override void ExecuteCmdlet()
        {
            ProfileWithDefinition profile = TrafficManagerProfile.GetInstance();

            if (string.IsNullOrEmpty(Name))
            {
                this.Name = profile.Name;
            }

            if (!profile.Name.Equals(Name))
            {
                throw new Exception(Resources.SetTrafficManagerProfileAmbiguous);
            }

            DefinitionCreateParameters updatedDefinitionAsParam =
                TrafficManagerClient.InstantiateTrafficManagerDefinition(
                LoadBalancingMethod ?? profile.LoadBalancingMethod.ToString(),
                MonitorPort.HasValue ? MonitorPort.Value : profile.MonitorPort,
                MonitorProtocol ?? profile.MonitorProtocol.ToString(),
                MonitorRelativePath ?? profile.MonitorRelativePath,
                Ttl.HasValue ? Ttl.Value : profile.TimeToLiveInSeconds,
                profile.Endpoints);

            ProfileWithDefinition newDefinition =
                TrafficManagerClient.AssignDefinitionToProfile(Name, updatedDefinitionAsParam);

            WriteObject(newDefinition);
        }
    }
}
