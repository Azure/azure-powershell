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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorObject", SupportsShouldProcess = true), OutputType(typeof(PSConnectionMonitor))]
    public class NetworkWatcherConnectionMonitortObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The test group.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorTestGroupObject> TestGroup { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource ID of workspace.")]
        [ValidateNotNullOrEmpty]
        public List<PSNetworkWatcherConnectionMonitorOutputObject> Output { get; set; }


        public override void Execute()
        {
            base.Execute();

            Validate();

            PSConnectionMonitor connectionMonitor = new PSConnectionMonitor()
            {
                TestGroup = this.TestGroup,
                Output = this.Output
            };

            WriteObject(connectionMonitor);
        }

        public bool Validate()
        {
            if (this.TestGroup == null && this.Output == null)
            {
                throw new ArgumentException("No Parameter is provided");
            }

            return true;
        }
    }
}
