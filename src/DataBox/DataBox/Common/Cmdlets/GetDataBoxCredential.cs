using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Threading;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxCredential" , DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(IEnumerable<UnencryptedCredentials>))]
    public class GetDataBoxCredential : AzureDataBoxCmdletBase
    {

        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet )]
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

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals("GetByResourceIdParameterSet"))
            {
                this.ResourceGroupName = ResourceIdHandler.GetResourceGroupName(ResourceId);
                this.Name = ResourceIdHandler.GetResourceName(ResourceId);
            }

            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            IEnumerable<UnencryptedCredentials> result = DataBoxManagementClient.Jobs.ListCredentials(ResourceGroupName, Name);
            WriteObject(result);
        }
    }
}
