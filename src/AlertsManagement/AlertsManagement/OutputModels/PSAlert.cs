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
using Microsoft.Azure.Management.AlertsManagement.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSAlert
    {
        /// <summary>
        /// Initializes a new instance of the PSAlert class.
        /// </summary>
        public PSAlert(Alert alert)
        {
            Id = alert.Id;
            Name = alert.Name;
            StartDateTime = alert.Properties.Essentials.StartDateTime;
            SourceCreatedId = alert.Properties.Essentials.SourceCreatedId;
            AlertRule = alert.Properties.Essentials.AlertRule;
            TargetResource = alert.Properties.Essentials.TargetResource;
            Severity = alert.Properties.Essentials.Severity;
            MonitorCondition = alert.Properties.Essentials.MonitorCondition;
            State = alert.Properties.Essentials.AlertState;
            MonitorService = alert.Properties.Essentials.MonitorService;
            SignalType = alert.Properties.Essentials.SignalType;
            LastModifiedDateTime = alert.Properties.Essentials.LastModifiedDateTime;
            LastModifiedUserName = alert.Properties.Essentials.LastModifiedUserName;
            SmartGroupId = alert.Properties.Essentials.SmartGroupId;
            SmartGroupingReason = alert.Properties.Essentials.SmartGroupingReason;
            MonitorConditionResolvedDateTime = alert.Properties.Essentials.MonitorConditionResolvedDateTime;
            ContextPayload = alert.Properties.Context?.ToString();
            EgressConfig = alert.Properties.EgressConfig?.ToString();
        }

        [Ps1Xml(Label = "Id", Target = ViewControl.Table, ScriptBlock = "$_.Id.Split('/')[6]")]
        public string Id { get; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; }

        [Ps1Xml(Label = "StartDateTime", Target = ViewControl.Table)]
        public DateTime? StartDateTime { get; }

        public string SourceCreatedId { get; }

        public string AlertRule { get; }

        public string TargetResource { get; }

        [Ps1Xml(Label = "MonitorCondition", Target = ViewControl.Table)]
        public string MonitorCondition { get; }

        [Ps1Xml(Label = "Severity", Target = ViewControl.Table)]
        public string Severity { get; }

        [Ps1Xml(Label = "State", Target = ViewControl.Table)]
        public string State { get; }

        [Ps1Xml(Label = "MonitorService", Target = ViewControl.Table)]
        public string MonitorService { get; }

        public string SignalType { get; }

        public DateTime? MonitorConditionResolvedDateTime { get; }

        public DateTime? LastModifiedDateTime { get; }

        public string LastModifiedUserName { get; }

        public string SmartGroupId { get; }

        public string SmartGroupingReason { get; }

        public string ContextPayload { get; }

        public string EgressConfig { get; }
    }
}