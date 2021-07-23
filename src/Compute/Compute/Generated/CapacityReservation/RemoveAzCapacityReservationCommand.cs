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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CapacityReservation", SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class RemoveAzureCapacityReservation : ComputeAutomationBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/capacityReservationGroups", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("CapacityReservationGroupName")]
        public string ReservationGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/capacityReservationGroups/capacityReservations", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("CapacityReservationName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.Remove))
                {

                    var result = CapacityReservationClient.DeleteWithHttpMessagesAsync(this.ResourceGroupName, this.ReservationGroupName, this.Name).GetAwaiter().GetResult();
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