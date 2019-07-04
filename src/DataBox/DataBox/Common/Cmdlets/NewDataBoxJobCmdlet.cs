using System;
using System.Collections.Generic;
using System.Management.Automation;
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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob"), OutputType(typeof(String))]
    public class NewDataBoxJob : AzureDataBoxCmdletBase
    {


        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Job Resource Object")]
        [ValidateNotNullOrEmpty]
        public JobResource JobResource { get; set; }


        public override void ExecuteCmdlet()
        {
            JobResource newJobResource = JobsOperationsExtensions.Create(
                            DataBoxManagementClient.Jobs,
                            ResourceGroupName,
                            Name,
                            JobResource);

            WriteObject(newJobResource);
        }


    }


}
