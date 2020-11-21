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

namespace Microsoft.Azure.Commands.SecurityInsights.Models.AlertRuleTemplates
{
    public static class PSSentinelAlertRuleTemplateConvertors
    {

        public static PSSentinelAlertRuleTemplate ConvertToPSType(this AlertRuleTemplate value)
        {
            var convertedFusionValue = value as FusionAlertRuleTemplate;

            if (convertedFusionValue != null)
            {
                return convertedFusionValue.ConvertToPSType();
            }

            var convertedMicrosoftSecurityIncidentCreationValue = value as MicrosoftSecurityIncidentCreationAlertRuleTemplate;

            if (convertedMicrosoftSecurityIncidentCreationValue != null)
            {
                return convertedMicrosoftSecurityIncidentCreationValue.ConvertToPSType();
            }

            var convertedScheduledValue = value as ScheduledAlertRuleTemplate;

            if (convertedScheduledValue != null)
            {
                return convertedScheduledValue.ConvertToPSType();
            }

            return new PSSentinelAlertRuleTemplate()
            {
                Kind = "Error",
                Name = value.Name
            };
        }

        public static List<PSSentinelAlertRuleTemplate> ConvertToPSType(this IEnumerable<AlertRuleTemplate> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }

        public static PSSentinelFusionAlertRuleTemplate ConvertToPSType(this FusionAlertRuleTemplate value)
        {
            return new PSSentinelFusionAlertRuleTemplate()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Kind = "Fusion",
                AlertRulesCreatedByTemplateCount = value.AlertRulesCreatedByTemplateCount,
                Description = value.Description,
                DisplayName = value.DisplayName,
                Status = value.Status,
                CreatedDateUtc = value.CreatedDateUTC,
                Severity = value.Severity,
                Tactics = value.Tactics,
            };
        }

        public static PSSentinelMicrosoftSecurityIncidentCreationRuleTemplate ConvertToPSType(this MicrosoftSecurityIncidentCreationAlertRuleTemplate value)
        {
            return new PSSentinelMicrosoftSecurityIncidentCreationRuleTemplate()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Kind = "MicrosoftSecurityIncidentCreation",
                AlertRulesCreatedByTemplateCount = value.AlertRulesCreatedByTemplateCount,
                Description = value.Description,
                DisplayName = value.DisplayName,
                Status = value.Status,
                CreatedDateUtc = value.CreatedDateUTC,
                ProductFilter = value.ProductFilter,
                RequiredDataConnectors = value.RequiredDataConnectors.ConvertToPSType()
            };
        }

        public static PSSentinelScheduledAlertRuleTemplate ConvertToPSType(this ScheduledAlertRuleTemplate value)
        {
            return new PSSentinelScheduledAlertRuleTemplate()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Kind = "Scheduled",
                AlertRulesCreatedByTemplateCount = value.AlertRulesCreatedByTemplateCount,
                Description = value.Description,
                DisplayName = value.DisplayName,
                Status = value.Status,
                CreatedDateUtc = value.CreatedDateUTC,
                Query = value.Query,
                QueryFrequency = value.QueryFrequency,
                QueryPeriod = value.QueryPeriod,
                Severity = value.Severity,
                Tactics = value.Tactics,
                TriggerOperator = value.TriggerOperator,
                TriggerThreshold = value.TriggerThreshold,
                RequiredDataConnectors = value.RequiredDataConnectors.ConvertToPSType()
                
            };
        }

        public static PSSentinelAlertRuleTemplateDataSource ConvertToPSType(this AlertRuleTemplateDataSource value)
        {
            return new PSSentinelAlertRuleTemplateDataSource()
            {
                ConnectorId = value.ConnectorId,
                DataTypes = value.DataTypes
            };
        }

        public static List<PSSentinelAlertRuleTemplateDataSource> ConvertToPSType(this IEnumerable<AlertRuleTemplateDataSource> value)
        {
            return value.Select(dss => dss.ConvertToPSType()).ToList();
        }
    }
}
