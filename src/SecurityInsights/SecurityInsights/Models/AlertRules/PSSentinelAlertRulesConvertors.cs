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
            var convertedFusionValue = value as FusionAlertRule;

            if (convertedFusionValue != null)
            {
                return convertedFusionValue.ConvertToPSType();
            }

            var convertedMicrosoftSecurityIncidentCreationValue = value as MicrosoftSecurityIncidentCreationAlertRule;

            if (convertedMicrosoftSecurityIncidentCreationValue != null)
            {
                return convertedMicrosoftSecurityIncidentCreationValue.ConvertToPSType();
            }

            var convertedScheduledValue = value as ScheduledAlertRule;

            if (convertedScheduledValue != null)
            {
                return convertedScheduledValue.ConvertToPSType();
            }

            return new PSSentinelAlertRule()
            {
                Kind = "Error",
                Name = value.Name
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

        public static AlertRule CreatePSStype(this PSSentinelAlertRule value)
        {
            var convertedFusionValue = value as PSSentinelFusionAlertRule;

            if (convertedFusionValue != null)
            {
                return convertedFusionValue.CreatePSType();
            }

            var convertedMicrosoftSecurityIncidentCreationValue = value as PSSentinelMicrosoftSecurityIncidentCreationRule;

            if (convertedMicrosoftSecurityIncidentCreationValue != null)
            {
                return convertedMicrosoftSecurityIncidentCreationValue.CreatePSType();
            }

            var convertedScheduledValue = value as PSSentinelScheduledAlertRule;

            if (convertedScheduledValue != null)
            {
                return convertedScheduledValue.CreatePSType();
            }

            return new AlertRule()
            { };
        }

        public static FusionAlertRule CreatePSType(this PSSentinelFusionAlertRule value)
        {
            return new FusionAlertRule()
            {
                AlertRuleTemplateName = value.AlertRuleTemplateName,
                Enabled = value.Enabled
            };
        }

        public static List<FusionAlertRule> CreatePSType(this IEnumerable<PSSentinelFusionAlertRule> value)
        {
            return value.Select(rec => rec.CreatePSType()).ToList();
        }

        public static MicrosoftSecurityIncidentCreationAlertRule CreatePSType(this PSSentinelMicrosoftSecurityIncidentCreationRule value)
        {
            return new MicrosoftSecurityIncidentCreationAlertRule()
            {
                DisplayName = value.DisplayName,
                Enabled = value.Enabled,
                ProductFilter = value.ProductFilter,
                AlertRuleTemplateName = value.AlertRuleTemplateName,
                Description = value.Description,
                DisplayNamesExcludeFilter = value.DisplayNamesExcludeFilter,
                DisplayNamesFilter = value.DisplayNamesFilter,
                SeveritiesFilter = value.SeveritiesFilter
                
            };
        }

        public static List<MicrosoftSecurityIncidentCreationAlertRule> CreatePSType(this IEnumerable<PSSentinelMicrosoftSecurityIncidentCreationRule> value)
        {
            return value.Select(rec => rec.CreatePSType()).ToList();
        }

        public static ScheduledAlertRule CreatePSType(this PSSentinelScheduledAlertRule value)
        {
            return new ScheduledAlertRule()
            {
                DisplayName = value.DisplayName,
                Enabled = value.Enabled,
                SuppressionDuration = value.SuppressionDuration,
                SuppressionEnabled = value.SuppressionEnabled,
                AlertRuleTemplateName = value.AlertRuleTemplateName,
                Description = value.Description,
                Query = value.Query,
                QueryFrequency = value.QueryFrequency,
                QueryPeriod = value.QueryPeriod,
                Severity = value.Severity,
                Tactics = value.Tactics,
                TriggerOperator = value.TriggerOperator,
                TriggerThreshold = value.TriggerThreshold

            };
        }

        public static List<ScheduledAlertRule> CreatePSType(this IEnumerable<PSSentinelScheduledAlertRule> value)
        {
            return value.Select(rec => rec.CreatePSType()).ToList();
        }
    }
}
