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
using System.Linq;
using System.Security;
using Microsoft.Azure.Commands.Security.Models.Automations;
using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Commands.Security.Models.Automations
{
    public static class PSSecurityAutomationConverters
    {

        public static List<PSSecurityAutomation> ConvertToPSType(this IEnumerable<Automation> value)
        {
            return value.Select(aps => aps.ConvertToPSType()).ToList();
        }

        public static PSSecurityAutomation ConvertToPSType(this Automation value)
        {
            return new PSSecurityAutomation()
            {
                Id = value.Id,
                Name = value.Name,
                Type = value.Type,
                Location = value.Location,
                Tags = value.Tags,
                Description = value.Description,
                IsEnabled = value.IsEnabled,
                Scopes = (IList<PSSecurityAutomationScope>)value.Scopes?.Select(scope => scope.ConvertToPSType()),
                Sources = (IList<PSSecurityAutomationSource>)value.Sources?.Select(source => source.ConvertToPSType()),
                Actions = (IList<PSSecurityAutomationAction>)value.Actions?.Select(action => action.ConvertToPSType()),
            };
        }

        public static PSSecurityAutomationScope ConvertToPSType(this AutomationScope value)
        {
            return new PSSecurityAutomationScope()
            {
                Description = value.Description,
                ScopePath = value.ScopePath
            };
        }

        public static PSSecurityAutomationSource ConvertToPSType(this AutomationSource value)
        {
            return new PSSecurityAutomationSource()
            {
                EventSource = value.EventSource,
                RuleSets = (IList<PSSecurityAutomationRuleSet>)value.RuleSets?.Select(ruleSet => ruleSet.ConvertToPSType())
            };
        }

        public static PSSecurityAutomationRuleSet ConvertToPSType(this AutomationRuleSet value)
        {
            return new PSSecurityAutomationRuleSet()
            {
                Rules = (IList<PSSecurityAutomationTriggeringRule>)value.Rules?.Select(rule => rule.ConvertToPSType())
            };
        }

        public static PSSecurityAutomationTriggeringRule ConvertToPSType(this AutomationTriggeringRule value)
        {
            return new PSSecurityAutomationTriggeringRule()
            {
                ExpectedValue = value.ExpectedValue,
                OperatorProperty = value.OperatorProperty,
                PropertyJPath = value.PropertyJPath,
                PropertyType = value.PropertyType
            };
        }

        public static PSSecurityAutomationAction ConvertToPSType(this AutomationAction value)
        {
            return new PSSecurityAutomationAction()
            {
                
            };
        }

        public static PSSecurityAutomationActionEventHub ConvertToPSType(this AutomationActionEventHub value)
        {
            return new PSSecurityAutomationActionEventHub()
            {
                ConnectionString = value.ConnectionString,
                EventHubResourceId = value.EventHubResourceId,
                SasPolicyName = value.SasPolicyName
            };
        }

        public static PSSecurityAutomationActionWorkspace ConvertToPSType(this AutomationActionWorkspace value)
        {
            return new PSSecurityAutomationActionWorkspace()
            {
                WorkspaceResourceId = value.WorkspaceResourceId
            };
        }

        public static PSSecurityAutomationActionLogicApp ConvertToPSType(this AutomationActionLogicApp value)
        {
            return new PSSecurityAutomationActionLogicApp()
            {
                LogicAppResourceId = value.LogicAppResourceId,
                Uri = value.Uri
            };
        }
    }
}
