
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiskEncryptionSetAssociatedResource")]
    [OutputType(typeof(String[]))]
    public partial class GetAzureDiskEncryptionSetAssociatedResource : ComputeAutomationBaseCmdlet
    {


        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias("Name")]
        public string DiskEncryptionSetName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = this.ResourceGroupName;
                string EncryptionSetName = this.DiskEncryptionSetName;

                var result = DiskEncryptionSetsClient.ListAssociatedResources(resourceGroupName, EncryptionSetName);
                var resultList = result.ToList();
                var nextPageLink = result.NextPageLink;
                while (!string.IsNullOrEmpty(nextPageLink))
                {
                    var pageResult = DiskEncryptionSetsClient.ListAssociatedResourcesNext(nextPageLink);
                    foreach (var pageItem in pageResult)
                    {
                        resultList.Add(pageItem);
                    }
                    nextPageLink = pageResult.NextPageLink;
                }

                WriteObject(resultList);    
            });
        }
    }
}
