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
using Microsoft.Azure.Management.Security.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules
{
    public static class PSAlertsSuppressionRuleConverters
    {
        public static PSAlertsSuppressionRule ConvertToPSType(this AlertsSuppressionRule value)
        {
            return new PSAlertsSuppressionRule()
            {
                AlertType = value.AlertType,
                Comment = value.Comment,
                ExpirationDateUtc = value.ExpirationDateUtc,
                Id = value.Id,
                Name = value.Name,
                Reason = value.Reason,
                State = value.State.ConvertToPSType(),
                SuppressionAlertsScope = value.SuppressionAlertsScope.ConvertToPSType()
            };
        }

        public static PSRuleState ConvertToPSType(this RuleState value)
        {
            switch (value)
            {
                case RuleState.Enabled:
                    return PSRuleState.Enabled;
                case RuleState.Disabled:
                    return PSRuleState.Disabled;
                case RuleState.Expired:
                    return PSRuleState.Expired;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public static PSSuppressionAlertsScope ConvertToPSType(this SuppressionAlertsScope value)
        {
            return new PSSuppressionAlertsScope
            {
                AllOf = value?.AllOf?.Select(sc => sc.ConvertToPSType()).ToList()
            };
        }

        public static PSIScopeElement ConvertToPSType(this ScopeElement value)
        {
            if (value == null)
            {
                return null;
            }

            var hasInValue = value.AdditionalProperties.Any(keyValuePair => "in".Equals(keyValuePair.Key, StringComparison.InvariantCultureIgnoreCase));
            if (hasInValue)
            {
                return new PSScopeElementIn(value.Field,
                    (value.AdditionalProperties.First(keyValuePair => "in".Equals(keyValuePair.Key, StringComparison.InvariantCultureIgnoreCase)).Value as JArray)?.ToObject<string[]>());
            }

            return new PSScopeElementContains(
                value.Field,
                value.AdditionalProperties.FirstOrDefault(keyValuePair => "contains".Equals(keyValuePair.Key, StringComparison.InvariantCultureIgnoreCase)).Value?.ToString());
        }

        public static List<PSAlertsSuppressionRule> ConvertToPSType(this IEnumerable<AlertsSuppressionRule> value)
        {
            return value.Select(sc => sc.ConvertToPSType()).ToList();
        }

        public static AlertsSuppressionRule ConvertToNetType(this PSAlertsSuppressionRule value)
        {
            return new AlertsSuppressionRule(
                value.AlertType, 
                value.Reason, 
                value.State.ConvertToNetType(), 
                value.Id,
                value.Name, 
                value.Type, 
                value.LastModifiedUtc,
                value.ExpirationDateUtc, 
                value.Comment,
                value.SuppressionAlertsScope.ConvertToNetType());
        }

        public static RuleState ConvertToNetType(this PSRuleState value)
        {
            switch (value)
            {
                case PSRuleState.Enabled:
                    return RuleState.Enabled;
                case PSRuleState.Disabled:
                    return RuleState.Disabled;
                case PSRuleState.Expired:
                    return RuleState.Expired;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public static SuppressionAlertsScope ConvertToNetType(this PSSuppressionAlertsScope value)
        {
            if (value?.AllOf == null)
            {
                return null;
            }

            return new SuppressionAlertsScope(value.AllOf?.Select(sc => sc.ConvertToNetType()).ToList());
        }

        public static ScopeElement ConvertToNetType(this PSIScopeElement value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is PSScopeElementIn inValue)
            {
                return new ScopeElement(new Dictionary<string, object>
                    {
                        {"in", JArray.FromObject(inValue.In)}
                    },
                    inValue.Field);
            }

            if (value is PSScopeElementContains containsValue)
            {
                return new ScopeElement(new Dictionary<string, object>
                    {
                        {"contains", containsValue.Contains}
                    },
                    containsValue.Field);
            }

            return null;
        }
    }
}