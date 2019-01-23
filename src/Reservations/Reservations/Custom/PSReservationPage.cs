using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Microsoft.Azure.Commands.Reservations.Models
{
    public class PSReservationPage : IPage<PSReservation>
    {
        public string NextPageLink { get; private set; }

        private List<PSReservation> Items { get; set; }

        public PSReservationPage()
        {
        }

        public PSReservationPage(IPage<ReservationResponse> reservationItemList)
        {
            if (reservationItemList != null)
            {
                NextPageLink = reservationItemList.NextPageLink;
                var enumerator = reservationItemList.GetEnumerator();
                Items = new List<PSReservation>();
                while (enumerator.MoveNext())
                {
                    Items.Add(new PSReservation(enumerator.Current));
                }
            }
        }

        public IEnumerator<PSReservation> GetEnumerator()
        {
            return Items == null ? System.Linq.Enumerable.Empty<PSReservation>().GetEnumerator() : Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
