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
using Newtonsoft.Json;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSSuppressionActionRule : PSActionRule
    {
        public PSSuppressionActionRule(ActionRule rule) : base(rule)
        {
            Suppression suppression = (Suppression)rule.Properties;
            RecurrenceType = suppression.SuppressionConfig?.RecurrenceType;
            StartDate = suppression.SuppressionConfig?.Schedule?.StartDate;
            EndDate = suppression.SuppressionConfig?.Schedule?.EndDate;
            StartTime = suppression.SuppressionConfig?.Schedule?.StartTime;
            EndTime = suppression.SuppressionConfig?.Schedule?.EndTime;
            RecurrenceValues = suppression.SuppressionConfig?.Schedule?.RecurrenceValues;
        }

        public string RecurrenceType { get; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public IList<int?> RecurrenceValues { get; set; }
    }
}
