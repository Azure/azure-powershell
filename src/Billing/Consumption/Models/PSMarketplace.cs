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
using ApiMarketplace = Microsoft.Azure.Management.Consumption.Models.Marketplace;

namespace Microsoft.Azure.Commands.Consumption.Models
{
    public class PSMarketplace
    {
        public string AccountName { get; set; }
        public string AdditionalProperties { get; set; }
        public string BillingPeriodId { get; set; }
        public decimal? ConsumedQuantity { get; set; }
        public string ConsumedService { get; set; }
        public string CostCenter { get; set; }
        public string Currency { get; set; }
        public string DepartmentName { get; set; }
        public string Id { get; set; }
        public string InstanceId { get; set; }
        public string InstanceName { get; set; }
        public bool? IsEstimated { get; set; }
        public string MeterId { get; set; }
        public string Name { get; set; }
        public string OfferName { get; set; }
        public string OrderNumber { get; set; }
        public string PlanName { get; set; }
        public decimal? PretaxCost { get; set; }
        public string PublisherName { get; set; }
        public string ResourceGroup { get; set; }
        public decimal? ResourceRate { get; set; }
        public string SubscriptionGuid { get; set; }
        public string SubscriptionName { get; set; }
        public IDictionary<string, string> Tag { get; set; }
        public string Type { get; set; }
        public string UnitOfMeasure { get; set; }
        public DateTime? UsageEnd { get; set; }
        public DateTime? UsageStart { get; set; }

        public PSMarketplace()
        {
        }

        public PSMarketplace(ApiMarketplace marketplace)
        {
            this.AccountName = marketplace.AccountName;
            this.AdditionalProperties = marketplace.AdditionalProperties;
            this.BillingPeriodId = marketplace.BillingPeriodId;
            this.ConsumedQuantity = marketplace.ConsumedQuantity;
            this.ConsumedService = marketplace.ConsumedService;
            this.CostCenter = marketplace.CostCenter;
            this.Currency = marketplace.Currency;
            this.DepartmentName = marketplace.DepartmentName;
            this.Id = marketplace.Id;
            this.InstanceId = marketplace.InstanceId;
            this.InstanceName = marketplace.InstanceName;
            this.IsEstimated = marketplace.IsEstimated;
            this.MeterId = marketplace.MeterId;
            this.Name = marketplace.Name;
            this.OfferName = marketplace.OfferName;
            this.OrderNumber = marketplace.OrderNumber;
            this.PlanName = marketplace.PlanName;
            this.PretaxCost = marketplace.PretaxCost;
            this.PublisherName = marketplace.PublisherName;
            this.ResourceGroup = marketplace.ResourceGroup;
            this.ResourceRate = marketplace.ResourceRate;
            this.SubscriptionGuid = marketplace.SubscriptionGuid;
            this.SubscriptionName = marketplace.SubscriptionName;
            this.Tag = marketplace.Tags;
            this.Type = marketplace.Type;
            this.UnitOfMeasure = marketplace.UnitOfMeasure;
            this.UsageEnd = marketplace.UsageEnd;
            this.UsageStart = marketplace.UsageStart;
        }
    }
}
