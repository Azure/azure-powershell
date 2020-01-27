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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorTestGroupObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorTestGroupObject))]
    public class NetworkWatcherConnectionMonitorTestGroupObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the connection monitor test group.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of test configurations.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestConfigurationObject> TestConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of source endpoints.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorEndpointObject> Source { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "List of destination endpoints.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorEndpointObject> Destination { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Flag indicating whether test group is disabled.")]
        public SwitchParameter Disable { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSNetworkWatcherConnectionMonitorTestGroupObject testGroup = new PSNetworkWatcherConnectionMonitorTestGroupObject()
            {
                Name = this.Name,
                Disable = this.Disable.IsPresent,
                TestConfigurations = this.TestConfiguration,
                Sources = this.Source,
                Destinations = this.Destination
            };

            this.ValidateTestGroup(testGroup);

            WriteObject(testGroup);
        }
    }
}
