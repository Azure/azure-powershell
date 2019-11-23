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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorEndPointTestConfigurationObject", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSConnectionMonitorResult))]
    public class NetworkWatcherConnectionMonitorEndPointTestConfigurationObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Alias("TestConfigurationtName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The test configuration name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("TestFrequency")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The test frequency is seconds.")]
        [ValidateNotNullOrEmpty]
        public Int32 TestFrequencySec { get; set; }

        [Alias("FailedCheckPercentage")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The percentage of failed check.")]
        [ValidateNotNullOrEmpty]
        public Int32 ChecksFailedPercent { get; set; }

        [Alias("RoundTripTime")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The round trip time in millisecond.")]
        [ValidateNotNullOrEmpty]
        public Double RoundTripTimeMs { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The preferred IP version.")]
        [ValidateNotNullOrEmpty]
        public string PreferredIPVersion { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            // WriteObject(endPoint);
        }
    }
}
