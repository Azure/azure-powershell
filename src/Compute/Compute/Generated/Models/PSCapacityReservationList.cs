using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSCapacityReservationList : PSCapacityReservation
    {
        public PSCapacityReservation ToPSCapacityReservation ()
        {
            return ComputeAutomationAutoMapperProfile.Mapper.Map<PSCapacityReservation>(this);
        }
    }
}
