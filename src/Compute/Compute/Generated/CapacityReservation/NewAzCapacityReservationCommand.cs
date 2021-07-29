
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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CapacityReservation", SupportsShouldProcess = true)]
    [OutputType(typeof(PSCapacityReservation))]
    public class NewAzureCapacityReservation : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/capacityReservations", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("CapacityReservationGroupName")]
        public string ReservationGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true)]
        [LocationCompleter("Microsoft.Compute/capacityReservationGroups/capacityReservations")]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Specifies the number of virtual machines in the scale set.")]
        public int CapacityToReserve { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "SKU of the resource for which capacity needs be reserved.")]
        [Alias("Size")]
        public string Sku { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Availability Zone to use for this capacity reservation.")]
        public string[] Zone { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.New))
                {
                    CapacityReservation capacityReservation = new CapacityReservation();
                    capacityReservation.Location = this.Location;

                    capacityReservation.Sku = new Sku();
                    capacityReservation.Sku.Name = this.Sku;
                    capacityReservation.Sku.Capacity = this.CapacityToReserve;

                    if (this.IsParameterBound(c => c.Tag))
                    {
                        capacityReservation.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                    }
                    if (this.IsParameterBound(c => c.Zone))
                    {
                        capacityReservation.Zones = this.Zone;
                    }

                    var result = CapacityReservationClient.CreateOrUpdate(this.ResourceGroupName, this.ReservationGroupName,this.Name, capacityReservation);
                    var psObject = new PSCapacityReservation();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<CapacityReservation, PSCapacityReservation>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
