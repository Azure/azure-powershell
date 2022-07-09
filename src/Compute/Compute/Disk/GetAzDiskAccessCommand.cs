
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Microsoft.Azure.Commands.Compute.Track2;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiskAccess", DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSDiskAccess))]
    public partial class GetAzureDiskAccess : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/diskAccesses", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("diskAccessName")]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 0,
           ParameterSetName = ResourceIDParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your disk access.")]
        [ResourceIdCompleter("Microsoft.Compute/diskAccesses")]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string diskAccessName;

                if (this.ParameterSetName == ResourceIDParameterSet)
                {
                    resourceGroupName = GetResourceGroupName(this.ResourceId);
                    diskAccessName = GetResourceName(this.ResourceId, "Microsoft.Compute/diskAccesses");
                }
                else
                {
                    resourceGroupName = this.ResourceGroupName;
                    diskAccessName = this.Name;
                }

                if (ShouldGetByName(resourceGroupName, diskAccessName))
                {
                    //var result = DiskAccessesClient.Get(resourceGroupName, diskAccessName);
                    var result = this.ComputeClientTrack2.GetDiskAccess2(resourceGroupName, diskAccessName);
                    var psObject = new PSDiskAccess();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<DiskAccessData, PSDiskAccess>(result.Data, psObject);
                    WriteObject(psObject);
                }
                else if (ShouldListByResourceGroup(resourceGroupName, diskAccessName))
                {
                    //var result = DiskAccessesClient.ListByResourceGroup(resourceGroupName);
                    var result = this.ComputeClientTrack2.ListDiskAccessesByResourceGroup(resourceGroupName);
                    var resultList = result.ToList();
                    /*
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
                    */
                    var psObject = new List<PSDiskAccess>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<DiskAccessResource, PSDiskAccess>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, diskAccessName, psObject), true);
                }
                else
                {
                    var result = this.ComputeClientTrack2.ListDiskAccessesBySubscription();
                    //var result = DiskAccessesClient.List();
                    var resultList = result.ToList();
                    /*
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
                    */
                    var psObject = new List<PSDiskAccessList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<DiskAccessResource, PSDiskAccessList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, diskAccessName, psObject), true);
                }
            });
        }
    }
}
