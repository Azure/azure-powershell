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


using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkVirtualApplianceBootDiagnostics", DefaultParameterSetName = ResourceNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSNetworkVirtualApplianceBootDiagnosticsOperationStatusResponse))]
    public class GetNetworkVirtualApplianceBootDiagnosticsCommand : NetworkVirtualApplianceBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualApplianceName", "NvaName", "NetworkVirtualApplianceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Network Virtual Appliance name.")]
        [ResourceNameCompleter("Microsoft.Network/networkVirtualAppliances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Network Virtual Appliance instance id to retrieve boot diagnostics for")]
        public int InstanceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage blob (eg. txt file) sas url into which serial console logs for requested VM instance is copied")]
        public SecureString SerialConsoleStorageSasUrl { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Storage blob (eg. png file) sas url into which console screen shot for requested VM instance is copied")]
        public SecureString ConsoleScreenshotStorageSasUrl { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           ParameterSetName = ResourceIdParameterSet,
           HelpMessage = "The resource Id.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess("Retrieving boot diagnostics for given NVA instance", "WARNING: If NVA is in an updating or deleting state, boot diagnostics retrieval may fail. You could try again later if the NVA still exists.", String.Format($"Retrieving boot diagnostics for NVA: {this.Name}")))
            {
                base.Execute();
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = GetResourceGroup(this.ResourceId);
                    this.Name = GetResourceName(this.ResourceId, "Microsoft.Network/networkVirtualAppliances");
                }

                if (!this.IsNetworkVirtualAppliancePresent(this.ResourceGroupName, this.Name))
                {
                    throw new ArgumentException(Properties.Resources.ResourceNotFound);
                }

                string resourceGroupName = this.ResourceGroupName;
                string nvaName = this.Name;
                int instanceId = this.InstanceId;

                PSNetworkVirtualApplianceBootDiagnosticsOperationStatusResponse output = new PSNetworkVirtualApplianceBootDiagnosticsOperationStatusResponse()
                {
                    Name = nvaName,
                    InstanceId = instanceId,
                    StartTime = DateTime.Now
                };

                var bootDiagParams = new NetworkVirtualApplianceBootDiagnosticParameters()
                {
                    InstanceId = instanceId,
                    SerialConsoleStorageSasUrl = this.SerialConsoleStorageSasUrl?.ConvertToString(),
                    ConsoleScreenshotStorageSasUrl = this.ConsoleScreenshotStorageSasUrl?.ConvertToString()
                };

                var result = this.NetworkVirtualAppliancesClient.GetBootDiagnosticLogsWithHttpMessagesAsync(resourceGroupName: this.ResourceGroupName, networkVirtualApplianceName: this.Name, request: bootDiagParams).GetAwaiter().GetResult();

                output.EndTime = DateTime.Now;

                if (result != null && result.Request != null && result.Request.RequestUri != null)
                {
                    output.OperationId = GetOperationIdFromUrlString(result.Request.RequestUri.ToString());
                }

                WriteObject(output);
            }
        }
    }
}
