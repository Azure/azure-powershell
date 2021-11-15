using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSCapacityReservationGroupList : PSCapacityReservationGroup
    {
        public PSCapacityReservationGroup ToPSCapacityReservationGroup()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSCapacityReservationGroup>(this);
        }
    }
}
