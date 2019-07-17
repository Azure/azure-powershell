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

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSSuppressionActionRule : PSActionRule
    {
        public PSSuppressionActionRule(ActionRule rule) : base(rule)
        {
            Suppression suppression = (Suppression)rule.Properties;
            SuppressionConfig = new PSSuppressionConfig(suppression.SuppressionConfig);
        }

        [Ps1Xml(Label = "RecurrenceType", Target = ViewControl.All, ScriptBlock = "$_.SuppressionConfig.RecurrenceType")]
        [Ps1Xml(Label = "StartDate", Target = ViewControl.All, ScriptBlock = "$_.SuppressionConfig.StartDate")]
        [Ps1Xml(Label = "StartTime", Target = ViewControl.All, ScriptBlock = "$_.SuppressionConfig.StartTime")]
        [Ps1Xml(Label = "EndDate", Target = ViewControl.All, ScriptBlock = "$_.SuppressionConfig.EndDate")]
        [Ps1Xml(Label = "EndTime", Target = ViewControl.All, ScriptBlock = "$_.SuppressionConfig.EndTime")]
        [Ps1Xml(Label = "RecurrenceValues", Target = ViewControl.All, ScriptBlock = "$_.SuppressionConfig.RecurrenceValues.ToString()")]
        public PSSuppressionConfig SuppressionConfig { get; }
    }
}
