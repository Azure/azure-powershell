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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models;
using System.Management.Automation;
using Resource = Microsoft.Azure.PowerShell.Cmdlets.DataBox.Resources.Resource;


namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob", SupportsShouldProcess = true, DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(void))]
    public class StopDataBoxJob : AzureDataBoxCmdletBase
    {

        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";
        private const string GetByInputObjectParameterSet = "GetByInputObjectParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Reason For Cancellation")]
        [ValidateNotNullOrEmpty]
        public string Reason { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSDataBoxJob InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals(GetByResourceIdParameterSet))
            {
                this.ResourceGroupName = ResourceIdHandler.GetResourceGroupName(ResourceId);
                this.Name = ResourceIdHandler.GetResourceName(ResourceId);
            }

            if (this.ParameterSetName.Equals(GetByInputObjectParameterSet))
            {
                this.ResourceGroupName = InputObject.ResourceGroup;
                this.Name = InputObject.JobResource.Name;
            }


            // Initiate to cancel job
            if (ShouldProcess(this.Name, string.Format(Resource.CancellingDataboxJob + this.Name + Resource.InResourceGroup + this.ResourceGroupName)))
            {
                if(this.Force || ShouldContinue(Resource.CancellingDataboxJobWarning + this.Name, ""))
                {
                    JobsOperationsExtensions.Cancel(
                        DataBoxManagementClient.Jobs,
                        ResourceGroupName,
                        Name,
                        Reason);

                    if (PassThru)
                        WriteObject(true);
                }
                
            }


        }
    }
}
