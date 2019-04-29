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

using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public class PSMetricAlertRuleV2: MetricAlertResource
    {
        public PSMetricAlertRuleV2(MetricAlertResource metricAlertResource)
            :base(location: metricAlertResource.Location, description: metricAlertResource.Description, severity: metricAlertResource.Severity, enabled: metricAlertResource.Enabled,evaluationFrequency: metricAlertResource.EvaluationFrequency,windowSize: metricAlertResource.WindowSize, criteria: metricAlertResource.Criteria,id: metricAlertResource.Id, name: metricAlertResource.Name, type: metricAlertResource.Type,tags: metricAlertResource.Tags, scopes: metricAlertResource.Scopes, autoMitigate: metricAlertResource.AutoMitigate, actions: metricAlertResource.Actions, lastUpdatedTime: metricAlertResource.LastUpdatedTime, targetResourceRegion: metricAlertResource.TargetResourceRegion, targetResourceType: metricAlertResource.TargetResourceType)
        {
            Criteria = new List<PSMetricCriteria>();
            if (metricAlertResource.Criteria is MetricAlertSingleResourceMultipleMetricCriteria)
            {
                var criteria = metricAlertResource.Criteria as MetricAlertSingleResourceMultipleMetricCriteria;
                foreach(var condition in criteria.AllOf)
                {
                    Criteria.Add(new PSMetricCriteria(condition));
                }
            }
            else if(metricAlertResource.Criteria is MetricAlertMultipleResourceMultipleMetricCriteria)
            {
                var criteria = metricAlertResource.Criteria as MetricAlertMultipleResourceMultipleMetricCriteria;
                foreach(var condition in criteria.AllOf)
                {
                    var obj = JsonConvert.SerializeObject(condition.AdditionalProperties, Newtonsoft.Json.Formatting.Indented);
                    MetricCriteria metricCriteria = JsonConvert.DeserializeObject<MetricCriteria>(obj);
                    Criteria.Add(new PSMetricCriteria(metricCriteria));
                }
            }
            else
            {
                //Web-Test
            }
            Actions = new ActivityLogAlertActionGroup[metricAlertResource.Actions.Count];
            for(int i = 0; i < metricAlertResource.Actions.Count;i++)
            {
                Actions[i] = new ActivityLogAlertActionGroup(metricAlertResource.Actions[i].ActionGroupId, metricAlertResource.Actions[i].WebhookProperties);
            }

            var resourceIdentifier = new ResourceIdentifier(metricAlertResource.Id);
            ResourceGroup = resourceIdentifier.ResourceGroupName;
        }

        /// <summary>
        /// Gets or sets list of criteria.
        /// </summary>
        [JsonProperty(PropertyName = "criteria")]
        public new IList<PSMetricCriteria> Criteria { get; set; }

        /// <summary>
        /// Gets or sets list of action groups.
        /// </summary>
        [JsonProperty(PropertyName = "actions")]
        public new ActivityLogAlertActionGroup[] Actions { get; set; }

        ///<summary>
        ///Gets or sets the resource group name
        ///</summary>
        [JsonProperty(PropertyName = "resourceGroup")]
        public String ResourceGroup { get; set; }
    }
}
