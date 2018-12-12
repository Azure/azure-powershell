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
using ApiReservationSummary = Microsoft.Azure.Management.Consumption.Models.ReservationSummaries;

namespace Microsoft.Azure.Commands.Consumption.Models
{
    public class PSReservationSummary
    {
        public decimal? AveUtilizationPercentage { get; set; }
        public string Id { get; set; }
        public decimal? MaxUtilizationPercentage { get; set; }
        public decimal? MinUtilizationPercentage { get; set; }
        public string Name { get; set; }
        public string ReservationId { get; set; }
        public string ReservationOrderId { get; set; }
        public decimal? ReservedHour { get; set; }
        public string SkuName { get; set; }
        public IDictionary<string, string> Tag { get; set; }
        public string Type { get; set; }
        public DateTime? UsageDate { get; set; }
        public decimal? UsedHour { get; set; }

        public PSReservationSummary()
        {
        }

        public PSReservationSummary(ApiReservationSummary reservationSummary)
        {
            this.AveUtilizationPercentage = reservationSummary.AvgUtilizationPercentage;
            this.Id = reservationSummary.Id;
            this.MaxUtilizationPercentage = reservationSummary.MaxUtilizationPercentage;
            this.MinUtilizationPercentage = reservationSummary.MinUtilizationPercentage;
            this.Name = reservationSummary.Name;
            this.ReservationId = reservationSummary.ReservationId;
            this.ReservationOrderId = reservationSummary.ReservationOrderId;
            this.ReservedHour = reservationSummary.ReservedHours;
            this.SkuName = reservationSummary.SkuName;
            this.Tag = reservationSummary.Tags;
            this.Type = reservationSummary.Type;
            this.UsageDate = reservationSummary.UsageDate;
            this.UsedHour = reservationSummary.UsedHours;
        }
    }
}
