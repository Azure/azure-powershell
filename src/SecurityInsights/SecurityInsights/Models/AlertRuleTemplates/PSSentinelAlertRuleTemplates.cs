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

using Microsoft.Azure.Commands.SecurityInsights.Models.Actions;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.AlertRuleTemplates
{
    public class PSSentinelAlertRuleTemplate
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Kind { get; set; }

        public string Severity { get; set; }

        public string Query { get; set; }

        public string QueryFrequency { get; set; }

        public string QueryPeriod { get; set; }

        public string TriggerOperator { get; set; }

        public int TriggerThreshold { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public List<string> Tatics { get; set; }

        public DateTime? CreatedDateUTC { get; set; }

        public string Status { get; set; }

        public List<PSSentinelAlertRuleTemplateRequiredDataConnector> RequiredDataConectors { get; set; }

        public int AlertRulesCreatedByTemplateCount { get; set; }

    }
}
