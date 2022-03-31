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
                ETag = value.Etag,
                Tags = value.Tags,
                Description = value.Description,
                IsEnabled = value.IsEnabled,
                Scopes = value.Scopes?.Select(scope => scope.ConvertToPSType()).ToList(),
                Sources = value.Sources?.Select(source => source.ConvertToPSType()).ToList(),
                Actions = value.Actions?.Select(action => action.ConvertToPSType()).ToList()
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
                RuleSets = value.RuleSets?.Select(ruleSet => ruleSet.ConvertToPSType()).ToList()
            };
        }

        public static PSSecurityAutomationRuleSet ConvertToPSType(this AutomationRuleSet value)
        {
            return new PSSecurityAutomationRuleSet()
            {
                Rules = value.Rules?.Select(rule => rule.ConvertToPSType()).ToList()
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
            if(value is AutomationActionEventHub)
            {
                var valueAsAutomationActionEventHub = (AutomationActionEventHub)value;
                return new PSSecurityAutomationActionEventHub()
                {
                    ConnectionString = valueAsAutomationActionEventHub.ConnectionString,
                    EventHubResourceId = valueAsAutomationActionEventHub.EventHubResourceId,
                    SasPolicyName = valueAsAutomationActionEventHub.SasPolicyName
                };
            }
            else if (value is AutomationActionWorkspace)
            {
                var valueAsAutomationActionWorkspace = (AutomationActionWorkspace)value;
                return new PSSecurityAutomationActionWorkspace()
                {
                    WorkspaceResourceId = valueAsAutomationActionWorkspace.WorkspaceResourceId
                };
            }
            else if (value is AutomationActionLogicApp)
            {
                var valueAsAutomationActionLogicApp = (AutomationActionLogicApp)value;
                return new PSSecurityAutomationActionLogicApp()
                {
                    LogicAppResourceId = valueAsAutomationActionLogicApp.LogicAppResourceId,
                    Uri = valueAsAutomationActionLogicApp.Uri
                };
            }
            else
            {
                return new PSSecurityAutomationAction();
            }
        }
    }
}
