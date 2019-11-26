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
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorTestGroupObject", SupportsShouldProcess = true, DefaultParameterSetName = "SetByName"), OutputType(typeof(PSConnectionMonitorResult))]
    public class NetworkWatcherConnectionMonitorTestGroupObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The test group name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of test configuration.")]
        [ValidateNotNullOrEmpty]
        public PSConnectionMonitorTestConfiguration[] TestConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of source endpoints.")]
        [ValidateNotNullOrEmpty]
        public PSConnectionMonitorEndpoint[] Source { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of destination endpoints.")]
        [ValidateNotNullOrEmpty]
        public PSConnectionMonitorEndpoint[] Destination { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The disable flag.")]
        public SwitchParameter Disable { get; set; }

        public override void Execute()
        {
            base.Execute();

            Validate();

            PSConnectionMonitorTestGroup testGroup = new PSConnectionMonitorTestGroup()
            {
                Name = this.Name,
                Disable = this.Disable? true:false,
                TestConfigurations = this.TestConfiguration,
                Sources = this.Source,
                Destinations = this.Destination              
            };

            WriteObject(testGroup);
        }

        public bool Validate()
        {
            
            if (!this.TestConfiguration.Any())
            {
                throw new ArgumentException("Test configuration is undefined.");
            }

            if (!this.Source.Any())
            {
                throw new ArgumentException("Source endpoint is undefined.");
            }

            if (!this.Destination.Any())
            {
                throw new ArgumentException("Destination endpoint is undefined.");
            }

            return true;
        }
    }
}
