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

namespace Microsoft.Azure.Commands.Scheduler.Cmdlets
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Scheduler.Properties;
    using Microsoft.Azure.Commands.Scheduler.Utilities;

    /// <summary>
    /// Deletes existing job collection.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSchedulerJobCollection", SupportsShouldProcess = true)]
    public class RemoveAzureSchedulerJobCollectionCommand : SchedulerBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The targeted resource group for job collection.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the job collection.")]
        [Alias("Name", "ResourceName")]
        [ValidateNotNullOrEmpty]
        public string JobCollectionName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If specified will write \"Success\" in case operation succeeds. This parameter is optional. Default value is false.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            this.ConfirmAction(
                processMessage: string.Format(Resources.RemoveJobCollectionResourceDescription, this.JobCollectionName),
                target: this.JobCollectionName,
                action: () =>
                {
                    this.SchedulerClient.DeleteJobCollections(this.ResourceGroupName, this.JobCollectionName);
                    
                    if (PassThru.IsPresent)
                    {
                        this.WriteObject(Resources.CompletedSuccessfully);
                    }

                }
            );
        }
    }
}
