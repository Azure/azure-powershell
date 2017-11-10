using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Reservations.Models;

namespace Microsoft.Azure.Commands.Reservations.Models
{
    public class PSReservationOrder
    {
        public string Etag { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; set; }

        public string DisplayName { get; set; }

        public DateTime? RequestDateTime { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int? OriginalQuantity { get; set; }

        public string Term { get; set; }

        public string ProvisioningState { get; set; }

        public IList<ReservationResponse> Reservations{ get; set; }


        public PSReservationOrder()
        {
        }

        public string PrintItems()
        {
            string builder = "";
            foreach (ReservationResponse item in Reservations)
            {
                builder += item.Id + "\n";
            }
            return builder;
        }

        public PSReservationOrder(ReservationOrderResponse reservation)
        {
            if (reservation != null)
            {
                Etag = reservation.Etag == null ? "" : reservation.Etag.ToString();
                Id = reservation.Id;
                Name = reservation.Name;
                Type = reservation.Type;
                DisplayName = reservation.DisplayName;
                RequestDateTime = reservation.RequestDateTime;
                CreatedDateTime = reservation.CreatedDateTime;
                ExpiryDate = reservation.ExpiryDate;
                OriginalQuantity = reservation.OriginalQuantity;
                Term = reservation.Term;
                ProvisioningState = reservation.ProvisioningState;
                Reservations = reservation.ReservationsProperty;
            }
        }
    }
}
