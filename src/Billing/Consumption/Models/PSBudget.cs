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

using System.Collections.Generic;
using Microsoft.Azure.Management.Consumption.Models;
using ApiBudget = Microsoft.Azure.Management.Consumption.Models.Budget;

namespace Microsoft.Azure.Commands.Consumption.Models
{
    public class PSBudget
    {
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public CurrentSpend CurrentSpend { get; set; }
        public string ETag { get; set; }
        public Filters Filter { get; set; }
        public string Id { get; private set; }
        public string Name { get; set; }
        public IDictionary<string, Notification> Notification { get; set; }
        public string TimeGrain { get; set; }
        public BudgetTimePeriod TimePeriod { get; set; }
        public string Type { get; set; }

        public PSBudget()
        {
        }

        public PSBudget(ApiBudget budget)
        {
            this.Amount = budget.Amount;
            this.Category = budget.Category;
            this.CurrentSpend = budget.CurrentSpend;
            this.ETag = budget.ETag;
            this.Filter = budget.Filters;
            this.Id = budget.Id;
            this.Name = budget.Name;
            this.Notification = budget.Notifications;
            this.TimeGrain = budget.TimeGrain;
            this.TimePeriod = budget.TimePeriod;
            this.Type = budget.Type;
        }
    }
}
