
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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CapacityReservationGroup", DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(PSCapacityReservationGroup))]
    public partial class GetAzureCapacityReservationGroup : ComputeAutomationBaseCmdlet
    {
        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/capacityReservationGroups", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("CapacityReservationGroupName")]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = ResourceIDParameterSet,
           ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your capacity reservation group.")]
        [ResourceIdCompleter("Microsoft.Compute/capacityReservationGroups")]
        public string ResourceId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Get the Instance View of the Capacity Reservation Group.")]
        public SwitchParameter InstanceView { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string capacityReservationGroupName;

                if (this.ParameterSetName == ResourceIDParameterSet)
                {
                    resourceGroupName = GetResourceGroupName(this.ResourceId);
                    capacityReservationGroupName = GetResourceName(this.ResourceId, "Microsoft.Compute/capacityReservationGroups");
                }
                else
                {
                    resourceGroupName = this.ResourceGroupName;
                    capacityReservationGroupName = this.Name;
                }

                if (ShouldGetByName(resourceGroupName, capacityReservationGroupName))
                {
                    CapacityReservationGroup result = new CapacityReservationGroup();
                    if (this.InstanceView.IsPresent)
                    {
                        result = CapacityReservationGroupClient.Get(resourceGroupName, capacityReservationGroupName, "InstanceView");
                    }
                    else
                    {
                        result = CapacityReservationGroupClient.Get(resourceGroupName, capacityReservationGroupName);
                    }
                    var psObject = new PSCapacityReservationGroup();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<CapacityReservationGroup, PSCapacityReservationGroup>(result, psObject);
                    WriteObject(psObject);
                }
                else if (ShouldListByResourceGroup(resourceGroupName, capacityReservationGroupName))
                {
                    var result = CapacityReservationGroupClient.ListByResourceGroup(resourceGroupName);
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = CapacityReservationGroupClient.ListByResourceGroupNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSCapacityReservationGroupList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<CapacityReservationGroup, PSCapacityReservationGroupList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, capacityReservationGroupName, psObject), true);
                }
                else
                {
                    var result = CapacityReservationGroupClient.ListBySubscription();
                    var resultList = result.ToList();
                    var nextPageLink = result.NextPageLink;
                    while (!string.IsNullOrEmpty(nextPageLink))
                    {
                        var pageResult = CapacityReservationGroupClient.ListBySubscriptionNext(nextPageLink);
                        foreach (var pageItem in pageResult)
                        {
                            resultList.Add(pageItem);
                        }
                        nextPageLink = pageResult.NextPageLink;
                    }
                    var psObject = new List<PSCapacityReservationGroupList>();
                    foreach (var r in resultList)
                    {
                        psObject.Add(ComputeAutomationAutoMapperProfile.Mapper.Map<CapacityReservationGroup, PSCapacityReservationGroupList>(r));
                    }
                    WriteObject(TopLevelWildcardFilter(resourceGroupName, capacityReservationGroupName, psObject), true);
                }
            });
        }
    }
}
