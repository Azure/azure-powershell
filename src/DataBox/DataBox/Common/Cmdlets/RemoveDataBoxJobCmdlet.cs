using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Threading;
using Resource = Microsoft.Azure.PowerShell.Cmdlets.DataBox.Resources.Resource;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob", SupportsShouldProcess = true, DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(void))]
    public class RemoveDataBoxJob : AzureDataBoxCmdletBase
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

        [Parameter(Mandatory = true, ParameterSetName = GetByResourceIdParameterSet, ValueFromPipelineByPropertyName = true)]
        [Alias("Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSDataBoxJob InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru;

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



            // Initiate to delete job
            if (ShouldProcess(this.Name, string.Format(Resource.DeletingDataboxJob + this.Name + Resource.InResourceGroup + this.ResourceGroupName)))
            {
                JobsOperationsExtensions.Delete(
                    DataBoxManagementClient.Jobs,
                    ResourceGroupName,
                    Name);

                if (PassThru)
                    WriteObject(true);
            }

        }
    }
}
