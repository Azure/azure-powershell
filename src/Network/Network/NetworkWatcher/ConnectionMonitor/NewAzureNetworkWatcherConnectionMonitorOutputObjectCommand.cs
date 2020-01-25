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
using Microsoft.Azure.Management.Network.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorOutputObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorOutputObject))]
    public class NetworkWatcherConnectionMonitorOutputObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Connection monitor output destination type. Currently, only \"Workspace\" is supported.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Workspace")]
        public string OutputType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Log analytics workspace resource ID.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSNetworkWatcherConnectionMonitorOutputObject output = new PSNetworkWatcherConnectionMonitorOutputObject()
            {
                 Type = string.IsNullOrEmpty(this.OutputType) ? "Workspace" : this.OutputType,
                 WorkspaceSettings = new PSConnectionMonitorWorkspaceSettings()
                 {
                     WorkspaceResourceId = WorkspaceResourceId
                 }
             };

            this.ValidateOutput(output);

            WriteObject(output);
        }
    }
}
