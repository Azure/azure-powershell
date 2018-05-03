using Microsoft.Azure.Management.Reservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Reservations.Models
{
    public class PSReservation
    {
        public string Sku { get; set; }

        public string Location { get; private set; }
        public string Etag { get; private set; }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public Kind? Kind { get; set; }

        public string Type { get; set; }

        public string DisplayName { get; set; }

        public IList<string> AppliedScopes { get; set; }

        public string AppliedScopeType { get; set; }

        public string Quantity { get; set; }

        public string ProvisioningState { get; set; }

        public DateTime? EffectiveDateTime { get; set; }

        public DateTime? LastUpdatedDateTime { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public ExtendedStatusInfo ExtendedStatusInfo { get; set; }

        public ReservationSplitProperties SplitProperties { get; set; }

        public ReservationMergeProperties MergeProperties { get; set; }


        public PSReservation()
        {

        }

        public string PrintAppliedScopes()
        {
            string builder = "";
            if (AppliedScopes.Count > 0)
            {
                builder += AppliedScopes[0];
                for (int i = 1; i < AppliedScopes.Count; i++)
                {
                    builder += "\n" + AppliedScopes[i];
                }
            }
            return builder;
        }

        public string PrintSplitProperties()
        {
            string builder = "";
            string splitDestinationsSpace = "                   ";
            if (SplitProperties.SplitDestinations != null)
            {
                builder += "SplitDestinations: ";
                builder += SplitProperties.SplitDestinations[0];
                for (int i = 1; i < SplitProperties.SplitDestinations.Count; i++)
                {
                    builder += "\n" + splitDestinationsSpace + SplitProperties.SplitDestinations[i];
                }
            }
            if (SplitProperties.SplitSource != null)
            {
                builder += "SplitSource: " + SplitProperties.SplitSource;
            }
            return builder;
        }

        public string PrintMergeProperties()
        {
            string builder = "";
            string mergeSourcesSpace = "              ";
            if (MergeProperties.MergeDestination != null)
            {
                builder += "MergeDestination: " + MergeProperties.MergeDestination;
            }
            if (MergeProperties.MergeSources != null)
            {
                builder += "MergeSources: ";
                builder += MergeProperties.MergeSources[0];
                for (int i = 1; i < MergeProperties.MergeSources.Count; i++)
                {
                    builder += "\n"+ mergeSourcesSpace + MergeProperties.MergeSources[i];
                }
            }
            return builder;
        }

        public string PrintStatusInfo()
        {
            return "StatusCode: " + ExtendedStatusInfo.StatusCode + "\n"
                + "Message: " + ExtendedStatusInfo.Message;
        }

        public PSReservation(ReservationResponse Reservation)
        {
            if (Reservation != null)
            {
                Sku = Reservation.Sku.Name;
                Location = Reservation.Location;
                Etag = Reservation.Etag == null ? "" : Reservation.Etag.ToString();
                Id = Reservation.Id;
                Name = Reservation.Name;
                Kind = Reservation.Kind;
                Type = Reservation.Type;
                DisplayName = Reservation.Properties.DisplayName;
                AppliedScopes = Reservation.Properties.AppliedScopes;
                AppliedScopeType = Reservation.Properties.AppliedScopeType;
                Quantity = Reservation.Properties.Quantity == null ? "" : Reservation.Properties.Quantity.ToString();
                ProvisioningState = Reservation.Properties.ProvisioningState;
                EffectiveDateTime = Reservation.Properties.EffectiveDateTime;
                LastUpdatedDateTime = Reservation.Properties.LastUpdatedDateTime;
                ExpiryDate = Reservation.Properties.ExpiryDate;
                ExtendedStatusInfo = Reservation.Properties.ExtendedStatusInfo;
                SplitProperties = Reservation.Properties.SplitProperties;
                MergeProperties = Reservation.Properties.MergeProperties;
            }
        }
    }
}
