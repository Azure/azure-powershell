using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Reservations.Models
{
    public class PSReservationOrderPage : IPage<PSReservationOrder>
    {
        public string NextPageLink { get; set; }

        private IList<PSReservationOrder> Items { get; set; }

        public PSReservationOrderPage()
        {
        }

        public PSReservationOrderPage(IPage<ReservationOrderResponse> ReservationOrderList)
        {
            if (ReservationOrderList != null)
            {
                NextPageLink = ReservationOrderList.NextPageLink;
                var enumerator = ReservationOrderList.GetEnumerator();
                Items = new List<PSReservationOrder>();
                while (enumerator.MoveNext())
                {
                    Items.Add(new PSReservationOrder(enumerator.Current));
                }
            }
        }

        public IEnumerator<PSReservationOrder> GetEnumerator()
        {
            return Items == null ? System.Linq.Enumerable.Empty<PSReservationOrder>().GetEnumerator() : Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
