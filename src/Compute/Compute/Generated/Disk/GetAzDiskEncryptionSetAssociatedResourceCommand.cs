
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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiskEncryptionSetAssociatedResources")]
    [OutputType(typeof(Uri[]))]
    public partial class GetAzureDiskEncryptionSetAssociatedResources : ComputeAutomationBaseCmdlet
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
                //var psObject = new List<string>();
                //foreach (var r in resultList)
                //{
                //    psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<DiskAccess, PSDiskAccessList>(r));
                //}
                //WriteObject(TopLevelWildcardFilter(resourceGroupName, diskAccessName, psObject), true);


                //var result = DiskEncryptionSetsClient.
                //var result = DiskEncryptionSetsClient.Get(resourceGroupName, diskEncryptionSetName);

                /*
                if (ShouldGetByName(resourceGroupName, Name))
                {
                    var result = DiskAccessesClient.Get(resourceGroupName, diskAccessName);
                    var psObject = new PSDiskAccess();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<DiskAccess, PSDiskAccess>(result, psObject);
                    WriteObject(psObject);
                }
                else if (ShouldListByResourceGroup(resourceGroupName, diskAccessName))
                {
                    var result = DiskAccessesClient.ListByResourceGroup(resourceGroupName);
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = DiskAccessesClient.ListByResourceGroupNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSDiskAccessList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<DiskAccess, PSDiskAccessList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, diskAccessName, psObject), true);
                }
                else
                {
                    var result = DiskAccessesClient.List();
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = DiskAccessesClient.ListNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSDiskAccessList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<DiskAccess, PSDiskAccessList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, diskAccessName, psObject), true);
                }
                */
            });
        }
    }
}
