
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CapacityReservation", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSCapacityReservation))]
    public class UpdateAzureCapacityReservation : ComputeAutomationBaseCmdlet
    {

        private const string DefaultParameterSet = "DefaultParameterSet";
        private const string InputObjectParameterSet = "InputObjectParameterSet";
        private const string ResourceIDParameterSet = "ResourceIDParameterSet";

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/capacityReservationGroups", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("CapacityReservationGroupName")]
        public string ReservationGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationName")]
        [ResourceNameCompleter("Microsoft.Compute/capacityReservationGroups/capacityReservations", "ResourceGroupName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            HelpMessage = "PSCapacityReservation object to update.")]
        [ResourceGroupCompleter]
        public PSCapacityReservation CapacityReservation { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = ResourceIDParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Resource ID for your Capacity Reservation.")]
        [ResourceIdCompleter("Microsoft.Compute/capacityReservationGroups/capacityReservations")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the number of virtual machines in the scale set.")]
        public int CapacityToReserve { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string reservationGroupName;
                string name;

                switch (this.ParameterSetName)
                {
                    case ResourceIDParameterSet:
                        resourceGroupName = GetResourceGroupName(this.ResourceId);
                        reservationGroupName = GetResourceName(this.ResourceId, "Microsoft.Compute/capacityReservationGroups", "capacityReservations");
                        name = GetResourceName(this.ResourceId, "capacityReservations");
                        break;
                    case InputObjectParameterSet:
                        resourceGroupName = GetResourceGroupName(this.CapacityReservation.Id);
                        reservationGroupName = GetResourceName(this.CapacityReservation.Id, "Microsoft.Compute/capacityReservationGroups", "capacityReservations");
                        name = this.CapacityReservation.Name;
                        break;
                    default:
                        resourceGroupName = this.ResourceGroupName;
                        reservationGroupName = this.ReservationGroupName;
                        name = this.Name;
                        break;
                }

                CapacityReservationUpdate updateParams = new CapacityReservationUpdate();
                if (this.IsParameterBound(c => c.Tag))
                {
                    updateParams.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                }
                if (this.IsParameterBound(c => c.CapacityToReserve))
                {
                    updateParams.Sku = new Sku();
                    updateParams.Sku.Capacity = this.CapacityToReserve;
                }
                
                var result = CapacityReservationClient.Update(resourceGroupName, reservationGroupName, name, updateParams);
                var psObject = new PSCapacityReservation();
                ComputeAutomationAutoMapperProfile.Mapper.Map<CapacityReservation, PSCapacityReservation>(result, psObject);
                WriteObject(psObject);
            });
        }
    }
}
