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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSAlertProcessingRule
    {
        /// <summary>
        /// Initializes a new instance of PSActionRule
        /// </summary>
        public PSAlertProcessingRule()
        {
        }

        /// <summary>
        /// Initializes a new instance of PSActionRule
        /// </summary>
        /// <param name="rule"></param>
        public PSAlertProcessingRule(AlertProcessingRule rule)
        {
            Id = rule.Id;
            Name = rule.Name;
            Description = rule.Properties.Description;
            Enabled = rule.Properties.Enabled.ToString();
            CreatedAt = rule.SystemData.CreatedAt;
            CreatedBy = rule.SystemData.CreatedBy;
            LastModifiedAt = rule.SystemData.LastModifiedAt;
            LastModifiedBy = rule.SystemData.LastModifiedBy;
            Scopes = JsonConvert.SerializeObject(rule.Properties.Scopes);
            if(rule.Tags != null)
            {
                Tags = JsonConvert.SerializeObject(rule.Tags);
            }

            if (rule.Properties.Conditions != null)
            {
                Conditions = JsonConvert.SerializeObject(rule.Properties.Conditions);
            }

            if (rule.Properties.Schedule != null)
            {
                Schedule = JsonConvert.SerializeObject(rule.Properties.Schedule);
            }
           
            if (rule.Properties.Actions[0] is AddActionGroups)
            {
                AlertProcessingType = "AddActionGroups";
            }
            else
            {
                AlertProcessingType = "RemoveAllActionGroups";
            }
        }

        public string Id { get; }

        [Ps1Xml(Label = "Name", Target = ViewControl.Table)]
        public string Name { get; }

        public string Description { get; }

        [Ps1Xml(Label = "Enabled", Target = ViewControl.Table)]
        public string Enabled { get; set; }

        public string Scopes { get; }

        public string Tags { get; }

        public string Conditions { get; }

        public string Schedule { get; }

        public DateTime? CreatedAt { get; }

        public string CreatedBy { get; }

        [Ps1Xml(Label = "LastModifiedAt", Target = ViewControl.Table)]
        public DateTime? LastModifiedAt { get; }

        [Ps1Xml(Label = "LastModifiedBy", Target = ViewControl.Table)]
        public string LastModifiedBy { get; }

        [Ps1Xml(Label = "Type", Target = ViewControl.Table)]
        public string AlertProcessingType { get; }

    }
}