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
using Microsoft.Azure.Management.AlertsManagement.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSSmartGroup
    {
        public PSSmartGroup(SmartGroup smartGroup)
        {
            Id = smartGroup.Id;
            Name = smartGroup.Name;
            AlertsCount = (int?)smartGroup.AlertsCount;
            State = smartGroup.SmartGroupState;
            Severity = smartGroup.Severity;
            LastModifiedTime = smartGroup.LastModifiedDateTime;
            LastModifiedUserName = smartGroup.LastModifiedUserName;
            Resources = smartGroup.Resources;
            ResourceGroups = smartGroup.ResourceGroups;
            ResourceTypes = smartGroup.ResourceTypes;
            MonitorConditions = smartGroup.MonitorConditions;
            MonitorServices = smartGroup.MonitorServices;
            AlertSeverities = smartGroup.AlertSeverities;
            AlertStates = smartGroup.AlertStates;
        }

        [Ps1Xml(Label = "Id", Target = ViewControl.Table, ScriptBlock = "$_.Id.Split('/')[6]")]
        public string Id { get; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; }

        [Ps1Xml(Label = "State", Target = ViewControl.Table)]
        public string State { get; }

        [Ps1Xml(Label = "Severity", Target = ViewControl.Table)]
        public string Severity { get; }

        [Ps1Xml(Label = "AlertsCount", Target = ViewControl.Table)]
        public int? AlertsCount { get; }

        public DateTime? LastModifiedTime { get; }

        public string LastModifiedUserName { get; }

        /// <summary>
        /// Gets the resources
        /// </summary>
        public IList<SmartGroupAggregatedProperty> Resources { get; set; }

        /// <summary>
        /// Gets the resource types
        /// </summary>
        public IList<SmartGroupAggregatedProperty> ResourceTypes { get; set; }

        /// <summary>
        /// Gets the resource types
        /// </summary>
        public IList<SmartGroupAggregatedProperty> ResourceGroups { get; set; }

        /// <summary>
        /// Gets the resource types
        /// </summary>
        public IList<SmartGroupAggregatedProperty> MonitorServices { get; set; }

        /// <summary>
        /// Gets the resource types
        /// </summary>
        public IList<SmartGroupAggregatedProperty> MonitorConditions { get; set; }

        /// <summary>
        /// Gets the resource types
        /// </summary>
        public IList<SmartGroupAggregatedProperty> AlertSeverities { get; set; }

        /// <summary>
        /// Gets the resource types
        /// </summary>
        public IList<SmartGroupAggregatedProperty> AlertStates { get; set; }
    }
}