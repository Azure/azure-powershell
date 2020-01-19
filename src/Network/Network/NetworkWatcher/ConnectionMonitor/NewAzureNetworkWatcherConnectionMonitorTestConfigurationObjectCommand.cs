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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorTestConfigurationObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorTestConfigurationObject))]
    public class NetworkWatcherConnectionMonitorTestConfigurationObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The test configuration name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("TestFrequency")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The test frequency in seconds.")]
        [ValidateNotNullOrEmpty]
        public Int32 TestFrequencySec { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The protocol configuration.")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorProtocolConfiguration ProtocolConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The percentage of failed check.")]
        [ValidateNotNullOrEmpty]
        public Int32? SuccessThresholdChecksFailedPercent { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The round trip time in millisecond.")]
        [ValidateNotNullOrEmpty]
        public Int32? SuccessThresholdRoundTripTimeMs { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The preferred IP version.")]
        [ValidateNotNullOrEmpty]
        public string PreferredIPVersion { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            uint TestConfigCounter = 1;

            PSNetworkWatcherConnectionMonitorTestConfigurationObject testConfiguration = new PSNetworkWatcherConnectionMonitorTestConfigurationObject()
            {
                Name = string.IsNullOrEmpty(this.Name) ? "TestConfig" + TestConfigCounter.ToString() : this.Name,
                TestFrequencySec = this.TestFrequencySec,
                PreferredIPVersion = this.PreferredIPVersion,
                SuccessThreshold = new PSConnectionMonitorSuccessThreshold()
                {
                    ChecksFailedPercent = this.SuccessThresholdChecksFailedPercent,
                    RoundTripTimeMs = this.SuccessThresholdRoundTripTimeMs

                }
            };

           if (this.ProtocolConfiguration.GetType() == typeof(PSConnectionMonitorTcpConfiguration))
            {
                testConfiguration.TcpConfiguration = (PSConnectionMonitorTcpConfiguration)this.ProtocolConfiguration;
                testConfiguration.Protocol = "TCP";
            }
            else if (this.ProtocolConfiguration.GetType() == typeof(PSConnectionMonitorHttpConfiguration))
            {
                testConfiguration.HttpConfiguration = (PSConnectionMonitorHttpConfiguration)this.ProtocolConfiguration;
                testConfiguration.Protocol = "HTTP";
            }
            else
            {
                testConfiguration.IcmpConfiguration = (PSConnectionMonitorIcmpConfiguration)this.ProtocolConfiguration;
                testConfiguration.Protocol = "ICMP";
            }

            WriteObject(testConfiguration);
   }

    public bool Validate()
        {
            if (this.ProtocolConfiguration.GetType() != typeof(PSConnectionMonitorTcpConfiguration) &&
                this.ProtocolConfiguration.GetType() != typeof(PSConnectionMonitorHttpConfiguration) &&
                this.ProtocolConfiguration.GetType() != typeof(PSConnectionMonitorIcmpConfiguration))
            {
                throw new ArgumentException("Protocol configuration is not supported.");
            }

            if (this.TestFrequencySec == 0)
            {
                throw new ArgumentException("Test frequency can not be zero.");
            }

            if (this.PreferredIPVersion != null & String.Compare(this.PreferredIPVersion, NetworkBaseCmdlet.IPv4, true) != 0 &&
                String.Compare(this.PreferredIPVersion, NetworkBaseCmdlet.IPv6, true) != 0)
            {
                throw new ArgumentException("IP version is undefined.");
            }

            return true;
        }
    }
}
