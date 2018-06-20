// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using ApiReservationDetail = Microsoft.Azure.Management.Consumption.Models.ReservationDetails;

namespace Microsoft.Azure.Commands.Consumption.Models
{
    public class PSReservationDetail
    {
        public string Id { get; set; }
        public string InstanceId { get; set; }
        public string Name { get; set; }
        public string ReservationId { get; set; }
        public string ReservationOrderId { get; set; }
        public decimal? ReservedHour { get; set; }
        public string SkuName { get; set; }
        public IDictionary<string, string> Tag { get; set; }
        public decimal? TotalReservedQuantity { get; set; }
        public string Type { get; set; }
        public DateTime? UsageDate { get; set; }
        public decimal? UsedHour { get; set; }

        public PSReservationDetail()
        {
        }

        public PSReservationDetail(ApiReservationDetail reservationDetail)
        {
            this.Id = reservationDetail.Id;
            this.InstanceId = reservationDetail.InstanceId;
            this.Name = reservationDetail.Name;
            this.ReservationId = reservationDetail.ReservationId;
            this.ReservationOrderId = reservationDetail.ReservationOrderId;
            this.ReservedHour = reservationDetail.ReservedHours;
            this.SkuName = reservationDetail.SkuName;
            this.Tag = reservationDetail.Tags;
            this.TotalReservedQuantity = reservationDetail.TotalReservedQuantity;
            this.Type = reservationDetail.Type;
            this.UsageDate = reservationDetail.UsageDate;
            this.UsedHour = reservationDetail.UsedHours;
        }
    }
}
