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
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureRmNetworkWatcherIPFlow", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSIPFlowVerifyResult))]

    public class TestAzureNetworkWatcherIPFlowCommand : NetworkWatcherBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The network watcher resource.",
             ParameterSetName = "SetByResource")]
        [ValidateNotNull]
        public PSNetworkWatcher NetworkWatcher { get; set; }

        [Alias("Name")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The name of network watcher.",
            ParameterSetName = "SetByName")]
        [ValidateNotNullOrEmpty]
        public string NetworkWatcherName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the network watcher resource group.",
            ParameterSetName = "SetByName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The target virtual machine ID.")]
        [ValidateNotNullOrEmpty]
        public string TargetVirtualMachineId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Direction.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Inbound", "Outbound", IgnoreCase = true)]
        public string Direction { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Protocol.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("TCP", "UDP", IgnoreCase = true)]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Remote IP Address.")]
        [ValidateNotNullOrEmpty]
        public string RemoteIPAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local IP Address.")]
        [ValidateNotNullOrEmpty]
        public string LocalIPAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local Port.")]
        [ValidateNotNullOrEmpty]
        public string LocalPort { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Remote port.")]
        public string RemotePort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Target network interface Id.")]
        [ValidateNotNullOrEmpty]
        public string TargetNetworkInterfaceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            MNM.VerificationIPFlowParameters flowParameters = new MNM.VerificationIPFlowParameters();

            flowParameters.Direction = this.Direction;
            flowParameters.LocalIPAddress = this.LocalIPAddress;
            flowParameters.LocalPort = this.LocalPort;
            flowParameters.Protocol = this.Protocol;
            flowParameters.RemoteIPAddress = this.RemoteIPAddress;
            flowParameters.RemotePort = this.RemotePort;
            flowParameters.TargetNicResourceId = this.TargetNetworkInterfaceId;
            flowParameters.TargetResourceId = this.TargetVirtualMachineId;

            MNM.VerificationIPFlowResult ipFlowVerify = new MNM.VerificationIPFlowResult();
            if (ParameterSetName.Contains("SetByResource"))
            {
                ipFlowVerify = this.NetworkWatcherClient.VerifyIPFlow(this.NetworkWatcher.ResourceGroupName, this.NetworkWatcher.Name, flowParameters);
            }
            else
            {
                ipFlowVerify = this.NetworkWatcherClient.VerifyIPFlow(this.ResourceGroupName, this.NetworkWatcherName, flowParameters);
            }

            PSIPFlowVerifyResult psIPFlowVerify = NetworkResourceManagerProfile.Mapper.Map<PSIPFlowVerifyResult>(ipFlowVerify);

            WriteObject(psIPFlowVerify);
        }
    }
}
