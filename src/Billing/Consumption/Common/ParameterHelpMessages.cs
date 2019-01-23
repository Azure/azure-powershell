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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Consumption.Common
{
    public static class ParameterHelpMessages
    {
        public static class BudgetParameterHelpMessages
        {
            public const string Name = "Name of a budget.";
            public const string Amount = "Amount of a budget.";
            public const string Category = "Category of the budget can be cost or usage.";
            public const string TimeGrain = "Time grain of the budget can be monthly, quarterly, or annually.";

            public const string StartDate =
                "Start date (YYYY-MM-DD in UTC) of time period of a budget. Not prior to current month for monthly time grain. Not prior to three months for quarterly time grain. Not prior to twelve months for yearly time grain. Future start date not more than three months.";
            public const string EndDate = "End date (YYYY-MM-DD in UTC) of time period of a budget.";
            public const string ResourceGroupName = "Resource Group of a budget.";
            public const string MeterFilter = "Comma-separated list of meters to filter on. Required if category is usage.";
            public const string ResourceFilter = "Comma-separated list of resource instances to filter on.";
            public const string ResourceGroupFilter = "Comma-separated list of resource groups to filter on.";

            public const string NotificationKey =
                "Key of a notification associated with a budget, required to create a notification with notification enabled switch, notification threshold, contact emails, contact groups, or contact roles.";
            public const string NotificationEnabled = "The notification is enabled. If not specified, the notification is disabled by default.";

            public const string NotificationThreshold =
                "Threshold value associated with a notification. Notification is sent when the cost or usage exceeded the threshold. It is always percent and has to be between 0 and 1000.";

            public const string ContactEmail = "Email addresses to send the budget notification to when the threshold is exceeded.";
            public const string ContactGroup = "Action groups to send the budget notification to when the threshold is exceeded.";
            public const string ContactRole = "Contact roles to send the budget notification to when the threshold is exceeded.";
            public const string PassThru = "The Cmdlet returns true if a budget was successfully removed.";

            public const string InputObject = "Budget object.";
        }     
    }
}
