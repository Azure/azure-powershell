using Microsoft.Azure.Management.Reservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Reservations.Models
{
    public class PSAppliedReservationOrderId
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; set; }

        public IList<string> AppliedReservationOrderId { get; set; }



        public PSAppliedReservationOrderId()
        {

        }

        public string PrintAppliedReservationOrderId()
        {
            string builder = "";
            foreach (string orderId in AppliedReservationOrderId)
            {
                builder += orderId + "\n";
            }
            return builder;
        }

        public PSAppliedReservationOrderId(AppliedReservations appliedReservationOrder)
        {
            if (appliedReservationOrder != null)
            {
                Id = appliedReservationOrder.Id;
                Name = appliedReservationOrder.Name;
                Type = appliedReservationOrder.Type;
                AppliedReservationOrderId = appliedReservationOrder.ReservationOrderIds.Value;
            }
        }
    }
}
