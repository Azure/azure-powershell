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

namespace Microsoft.Azure.Commands.Consumption.Common
{
    public class Constants
    {
        public class ParameterSetNames
        {
            public const string SubscriptionItemParameterSet = "Subscription";
            public const string InvoiceItemParameterSet = "Invoice";
            public const string BillingPeriodItemParameterSet = "BillingPeriod";
        }

        public class Expands
        {
            public const string MeterDetails = "meterDetails";
            public const string AdditionalInfo = "additionalInfo";
            public const string AdditionalProperties = "additionalProperties";
        }

        public class Formats
        {
            public const string SubscriptionScopeFormat = "/subscriptions/{0}";
            public const string InvoiceScopeFormat = "/subscriptions/{0}/providers/Microsoft.Billing/invoices/{1}";
            public const string BillingPeriodScopeFormat = "/subscriptions/{0}/providers/Microsoft.Billing/billingPeriods/{1}";
            public const string DateTimeParameterFormat = "yyyy-MM-dd";
        }
    }
}
