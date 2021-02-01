﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.SecurityInsights.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.AlertRuleTemplates
{
    public class PSSentinelScheduledAlertRuleTemplate : PSSentinelAlertRuleTemplate
    {
        public int? AlertRulesCreatedByTemplateCount { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
        
        public DateTime? CreatedDateUtc { get; set; }

        public string Query { get; set; }

        public TimeSpan? QueryFrequency { get; set; }

        public TimeSpan? QueryPeriod { get; set; }

        public IList<PSSentinelAlertRuleTemplateDataSource> RequiredDataConnectors { get; set; }

        public string Severity { get; set; }
      
        public TriggerOperator? TriggerOperator { get; set; }

        public int? TriggerThreshold { get; set; }

        public IList<string> Tactics { get; set; }

    }
}
