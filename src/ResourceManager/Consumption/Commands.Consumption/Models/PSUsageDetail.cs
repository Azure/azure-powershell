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
using ApiUsageDetail = Microsoft.Azure.Management.Consumption.Models.UsageDetail;
using MeterDetails = Microsoft.Azure.Management.Consumption.Models.MeterDetails;

namespace Microsoft.Azure.Commands.Consumption.Models
{
    public class PSUsageDetail
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public IDictionary<string, string> Tags { get; private set; }
        public string BillingPeriodId { get; set; }
        public string InvoiceId { get; set; }
        public DateTime? UsageStart { get; private set; }
        public DateTime? UsageEnd { get; private set; }        
        public string InstanceName { get; set; }
        public string InstanceId { get; set; }
        public string InstanceLocation { get; set; }
        public string Currency { get; set; }
        public decimal? UsageQuantity { get; set; }
        public decimal? BillableQuantity { get; set; }
        public decimal? PretaxCost { get; set; }
        public bool? IsEstimated { get; set; }
        public string MeterId { get; set; }
        public MeterDetails MeterDetails { get; set; }
        public string SubscriptionGuid { get; set; }
        public string SubscriptionName { get; set; }
        public string AccountName { get; set; }
        public string DepartmentName { get; set; }
        public string Product { get; set; }
        public string ConsumedService { get; set; }
        public string CostCenter { get; set; }
        public string AdditionalProperties { get; set; }

        public PSUsageDetail()
        {
        }

        public PSUsageDetail(ApiUsageDetail usageDetail)
        {
            if (usageDetail != null)
            {
                this.Id = usageDetail.Id;
                this.Type = usageDetail.Type;
                this.Name = usageDetail.Name;
                this.Tags = usageDetail.Tags;
                this.BillingPeriodId = usageDetail.BillingPeriodId;
                this.InvoiceId = usageDetail.InvoiceId;
                this.UsageStart = usageDetail.UsageStart;
                this.UsageEnd = usageDetail.UsageEnd;
                this.InstanceName = usageDetail.InstanceName;
                this.InstanceId = usageDetail.InstanceId;                
                this.InstanceLocation = usageDetail.InstanceLocation;
                this.Currency = usageDetail.Currency;
                this.UsageQuantity = usageDetail.UsageQuantity;
                this.BillableQuantity = usageDetail.BillableQuantity;
                this.PretaxCost = usageDetail.PretaxCost;
                this.IsEstimated = usageDetail.IsEstimated;
                this.MeterId = usageDetail.MeterId;
                this.MeterDetails = usageDetail.MeterDetails;
                this.SubscriptionGuid = usageDetail.SubscriptionGuid;
                this.SubscriptionName = usageDetail.SubscriptionName;
                this.AccountName = usageDetail.AccountName;
                this.DepartmentName = usageDetail.DepartmentName;
                this.Product = usageDetail.Product;
                this.ConsumedService = usageDetail.ConsumedService;
                this.CostCenter = usageDetail.CostCenter;
                this.AdditionalProperties = usageDetail.AdditionalProperties;
            }
        }
    }
}
