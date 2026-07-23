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
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectBlock", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public class RemoveAzureInterconnectBlock : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Compute/interconnectBlocks", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PSInterconnectBlock object to delete.")]
        [ValidateNotNullOrEmpty]
        public PSInterconnectBlock InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Skip confirmation prompt.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string name;

                switch (this.ParameterSetName)
                {
                    case InputObjectParameterSet:
                        resourceGroupName = GetResourceGroupName(this.InputObject.Id);
                        name = this.InputObject.Name;
                        break;
                    default:
                        resourceGroupName = this.ResourceGroupName;
                        name = this.Name;
                        break;
                }

                if (ShouldProcess(name, VerbsCommon.Remove)
                    && (this.Force.IsPresent ||
                        this.ShouldContinue(Properties.Resources.ResourceRemovalConfirmation,
                                            "Remove-AzInterconnectBlock operation")))
                {
                    var result = InterconnectBlocksClient.DeleteWithHttpMessagesAsync(resourceGroupName, name).GetAwaiter().GetResult();

                    PSOperationStatusResponse output = new PSOperationStatusResponse
                    {
                        StartTime = this.StartTime,
                        EndTime = DateTime.Now
                    };

                    if (result != null && result.Request != null && result.Request.RequestUri != null)
                    {
                        output.Name = GetOperationIdFromUrlString(result.Request.RequestUri.ToString());
                    }

                    WriteObject(output);
                }
            });
        }
    }
}
