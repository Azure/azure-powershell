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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CapacityReservationGroup", DefaultParameterSetName = DefaultParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class RemoveAzureCapacityReservationGroup : ComputeAutomationBaseCmdlet
    {

        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/capacityReservationGroups", "ResourceGroupName")]
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

        [Alias("CapacityReservationGroup")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PowerShell capacity reservation group object")]
        [ValidateNotNullOrEmpty]
        public PSCapacityReservationGroup InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.Remove))
                {
                    string resourceGroupName;
                    string capacityReservationGroupName;
                    switch (this.ParameterSetName)
                    {
                        case ResourceIDParameterSet:
                            resourceGroupName = GetResourceGroupName(this.ResourceId);
                            capacityReservationGroupName = GetResourceName(this.ResourceId, "Microsoft.Compute/capacityReservationGroups");
                            break;
                        case InputObjectParameterSet:
                            resourceGroupName = GetResourceGroupName(this.InputObject.Id);
                            capacityReservationGroupName = this.InputObject.Name;
                            break;
                        default:
                            resourceGroupName = this.ResourceGroupName;
                            capacityReservationGroupName = this.Name;
                            break;
                    }

                    var result = CapacityReservationGroupClient.DeleteWithHttpMessagesAsync(resourceGroupName, capacityReservationGroupName).GetAwaiter().GetResult();
                    PSOperationStatusResponse output = new PSOperationStatusResponse
                    {
                        StartTime = this.StartTime,
                        EndTime = DateTime.Now
                    };

                    if (result != null && result.Request != null && result.Request.RequestUri != null)
                    {
                        output.Name = GetOperationIdFromUrlString(result.Request.RequestUri.ToString());
                    }

                    WriteObject(output);
                }
            });
        }
    }
}