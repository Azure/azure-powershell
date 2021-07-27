
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
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CapacityReservationGroup", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSCapacityReservationGroup))]
    public class NewAzureCapacityReservationGroup : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationGroupName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true)]
        [LocationCompleter("Microsoft.Compute/capacityReservationGroups")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, 
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }
        
        [Parameter(
            Mandatory = false)]
        public string[] Zone { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Name, VerbsCommon.New))
                {
                    CapacityReservationGroup capacityReservationGroup = new CapacityReservationGroup();
                    capacityReservationGroup.Location = this.Location;

                    if (this.IsParameterBound(c => c.Tag))
                    {
                        capacityReservationGroup.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(ht => (string)ht.Key, ht => (string)ht.Value);
                    }
                    if (this.IsParameterBound(c => c.Zone))
                    {
                        capacityReservationGroup.Zones = this.Zone;
                    }

                    var result = CapacityReservationGroupClient.CreateOrUpdate(this.ResourceGroupName, this.Name, capacityReservationGroup);
                    var psObject = new PSCapacityReservationGroup();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<CapacityReservationGroup, PSCapacityReservationGroup>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }
    }
}
