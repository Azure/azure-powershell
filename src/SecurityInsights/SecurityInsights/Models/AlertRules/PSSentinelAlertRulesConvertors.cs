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

using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules
{
    public static class PSSentinelAlertRuleConvertors
    {

        public static PSSentinelAlertRule ConvertToPSType(this AlertRule value)
        {
            return new PSSentinelAlertRule()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type
            };
        }

        public static List<PSSentinelAlertRule> ConvertToPSType(this IEnumerable<AlertRule> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }
        
        public static PSSentinelFusionAlertRule ConvertToPSType(this FusionAlertRule value)
        {
            return new PSSentinelFusionAlertRule()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Kind = "Fusion",
                AlertRuleTemplateName = value.AlertRuleTemplateName,
                Description = value.Description,
                DisplayName = value.DisplayName,
                Enabled = value.Enabled,
                LastModifiedUtc = value.LastModifiedUtc,
                Severity = value.Severity,
                Tactics = value.Tactics
            };
        }

        public static List<PSSentinelFusionAlertRule> ConvertToPSType(this IEnumerable<FusionAlertRule> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelMicrosoftSecurityIncidentCreationRule ConvertToPSType(this MicrosoftSecurityIncidentCreationAlertRule value)
        {
            return new PSSentinelMicrosoftSecurityIncidentCreationRule()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Kind = "MicrosoftSecurityIncidentCreation",
                AlertRuleTemplateName = value.AlertRuleTemplateName,
                Description = value.Description,
                DisplayName = value.DisplayName,
                Enabled = value.Enabled,
                LastModifiedUtc = value.LastModifiedUtc,
                DisplayNamesExcludeFilter = value.DisplayNamesExcludeFilter,
                DisplayNamesFilter = value.DisplayNamesFilter,
                ProductFilter = value.ProductFilter,
                SeveritiesFilter = value.SeveritiesFilter
            };
        }

        public static List<PSSentinelMicrosoftSecurityIncidentCreationRule> ConvertToPSType(this IEnumerable<MicrosoftSecurityIncidentCreationAlertRule> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelScheduledAlertRule ConvertToPSType(this ScheduledAlertRule value)
        {
            return new PSSentinelScheduledAlertRule()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Kind = "MicrosoftSecurityIncidentCreation",
                AlertRuleTemplateName = value.AlertRuleTemplateName,
                Description = value.Description,
                DisplayName = value.DisplayName,
                Enabled = value.Enabled,
                LastModifiedUtc = value.LastModifiedUtc,
                Query = value.Query,
                QueryFrequency = value.QueryFrequency,
                QueryPeriod = value.QueryPeriod,
                Severity = value.Severity,
                SuppressionDuration = value.SuppressionDuration,
                SuppressionEnabled = value.SuppressionEnabled,
                Tactics = value.Tactics,
                TriggerOperator = value.TriggerOperator,
                TriggerThreshold = value.TriggerThreshold

            };
        }

        public static List<PSSentinelScheduledAlertRule> ConvertToPSType(this IEnumerable<ScheduledAlertRule> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }
    }
}
