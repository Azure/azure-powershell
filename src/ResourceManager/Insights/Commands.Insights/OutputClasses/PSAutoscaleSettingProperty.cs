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

using Microsoft.Azure.Management.Insights.Models;
using System.Text;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// An AutoscaleSetting with the ToString modified to allow for details to be displayed
    /// </summary>
    public class PSAutoscaleSettingProperty : AutoscaleSetting
    {
        /// <summary>
        /// Initializes an instance of the PSAutoscaleSettingProperty class.
        /// </summary>
        /// <param name="autoscaleSetting">The autoscale setting to use as base</param>
        public PSAutoscaleSettingProperty(AutoscaleSetting autoscaleSetting)
        {
            if (autoscaleSetting != null)
            {
                this.Enabled = autoscaleSetting.Enabled;
                this.Name = autoscaleSetting.Name;
                this.Profiles = autoscaleSetting.Profiles;
                this.TargetResourceUri = autoscaleSetting.TargetResourceUri;
                this.Notifications = autoscaleSetting.Notifications;
            }
        }

        /// <summary>
        /// A string representation of the PSAutoscaleSettingProperty
        /// </summary>
        /// <returns>A string representation of the PSAutoscaleSettingProperty</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Name             : " + this.Name);
            output.AppendLine("TargetResourceId : " + this.TargetResourceUri);
            output.AppendLine("Enabled          : " + this.Enabled);
            output.Append("Profiles         : " + this.Profiles.ToString(indentationTabs: 2));
            output.Append("Notifications    : " + this.Notifications.ToString(indentationTabs: 2));
            return output.ToString();
        }
    }
}
