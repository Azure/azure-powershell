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

using Microsoft.Azure.Management.Consumption.Models;
using ApiPriceSheetProperty = Microsoft.Azure.Management.Consumption.Models.PriceSheetProperties;

namespace Microsoft.Azure.Commands.Consumption.Models
{
    public class PSPriceSheetProperty
    {
        public string BillingPeriodId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? IncludedQuantity { get; set; }
        public MeterDetails MeterDetails { get; set; }
        public string MeterId { get; set; }
        public string PartNumber { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal? UnitPrice { get; set; }

        public PSPriceSheetProperty()
        {
        }

        public PSPriceSheetProperty(ApiPriceSheetProperty property)
        {
            this.BillingPeriodId = property.BillingPeriodId;
            this.CurrencyCode = property.CurrencyCode;
            this.IncludedQuantity = property.IncludedQuantity;
            this.MeterDetails = property.MeterDetails;
            this.MeterId = property.MeterId;
            this.PartNumber = property.PartNumber;
            this.UnitOfMeasure = property.UnitOfMeasure;
            this.UnitPrice = property.UnitPrice;
        }
    }
}
