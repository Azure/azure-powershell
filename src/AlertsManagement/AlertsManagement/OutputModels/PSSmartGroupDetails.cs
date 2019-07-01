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
using System.Globalization;
using System.Text;
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSSmartGroupDetails
    {
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

        /// <summary>
        /// Initializes a new instance of the PSSmartGroupDetails class.
        /// </summary>
        /// <param name="inputDictionary">The input IDictionary</param>
        public PSSmartGroupDetails(SmartGroup smartGroup)
        {
            this.Resources = smartGroup.Resources;
            this.ResourceTypes = smartGroup.ResourceTypes;
            this.ResourceGroups = smartGroup.ResourceGroups;
            this.MonitorConditions = smartGroup.MonitorConditions;
            this.MonitorServices = smartGroup.MonitorServices;
            this.AlertSeverities = smartGroup.AlertSeverities;
            this.AlertStates = smartGroup.AlertStates;
        }

        /// <summary>
        /// A string representation 
        /// </summary>
        /// <returns>A string representation</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine();

            if (Resources != null)
            {
                output.Append(string.Format("Resources : "));
                output.Append(Resources.ToString());
                output.AppendLine();
            }

            if (Resources != null)
            {
                output.Append(string.Format("ResourceTypes : "));
                output.Append(ResourceTypes.ToString());
                output.AppendLine();
            }

            if (Resources != null)
            {
                output.Append(string.Format("ResourceGroups : "));
                output.Append(ResourceGroups.ToString());
                output.AppendLine();
            }

            if (Resources != null)
            {
                output.Append(string.Format("Monitor Conditions : "));
                output.Append(MonitorConditions.ToString());
                output.AppendLine();
            }

            if (Resources != null)
            {
                output.Append(string.Format("Monitor Services : "));
                output.Append(MonitorServices.ToString());
                output.AppendLine();
            }

            if (Resources != null)
            {
                output.Append(string.Format("Alert States : "));
                output.Append(AlertStates.ToString());
                output.AppendLine();
            }

            if (Resources != null)
            {
                output.Append(string.Format("Alert Severities : "));
                output.Append(AlertSeverities.ToString());
                output.AppendLine();
            }

            return output.ToString();
        }
    }
}
