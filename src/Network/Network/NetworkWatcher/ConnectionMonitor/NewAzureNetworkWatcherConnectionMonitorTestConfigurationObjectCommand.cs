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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorTestConfigurationObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorTestConfigurationObject))]
    public class NetworkWatcherConnectionMonitorTestConfigurationObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the connection monitor test configuration.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("TestFrequency")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The frequency of test evaluation, in seconds.")]
        [ValidateNotNullOrEmpty]
        public int TestFrequencySec { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The parameters used to perform test evaluation over some protocol.")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorProtocolConfiguration ProtocolConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The maximum percentage of failed checks permitted for a test to evaluate as successful.")]
        [ValidateNotNullOrEmpty]
        public int? SuccessThresholdChecksFailedPercent { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The maximum round-trip time in milliseconds permitted for a test to evaluate as successful.")]
        [ValidateNotNullOrEmpty]
        public int? SuccessThresholdRoundTripTimeMs { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The preferred IP version to use in test evaluation. The connection monitor may choose to use a different version depending on other parameters.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("IPv4", "IPv6")]
        public string PreferredIPVersion { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfiguration = new PSNetworkWatcherConnectionMonitorTestConfigurationObject()
            {
                Name = this.Name,
                TestFrequencySec = this.TestFrequencySec,
                PreferredIPVersion = this.PreferredIPVersion,
                SuccessThreshold = GetSuccessThreshold(),
                ProtocolConfiguration = this.ProtocolConfiguration
            };

            this.ValidateTestConfiguration(testConfiguration);

            WriteObject(testConfiguration);
        }

        private PSNetworkWatcherConnectionMonitorSuccessThreshold GetSuccessThreshold()
        {
            if (this.SuccessThresholdChecksFailedPercent == null && this.SuccessThresholdRoundTripTimeMs == null)
            {
                return null;
            }

            return new PSNetworkWatcherConnectionMonitorSuccessThreshold()
            {
                ChecksFailedPercent = this.SuccessThresholdChecksFailedPercent,
                RoundTripTimeMs = this.SuccessThresholdRoundTripTimeMs
            };
        }
    }
}
