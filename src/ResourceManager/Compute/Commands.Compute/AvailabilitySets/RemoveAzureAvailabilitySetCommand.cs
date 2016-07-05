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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Remove, ProfileNouns.AvailabilitySet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class RemoveAzureAvailabilitySetCommand : AvailabilitySetBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "AvailabilitySetName")]
        [Parameter(
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The availability set name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Position = 2,
           HelpMessage = "To force the removal.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (this.ShouldProcess(Name, VerbsCommon.Remove) 
                    && (this.Force.IsPresent
                    || this.ShouldContinue(Properties.Resources.AvailabilitySetRemovalConfirmation, Properties.Resources.AvailabilitySetRemovalCaption)))
                {
                    var op = this.AvailabilitySetClient.DeleteWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.Name).GetAwaiter().GetResult();
                    var result = Mapper.Map<PSAzureOperationResponse>(op);
                    WriteObject(result);
                }
            });
        }
    }
}
