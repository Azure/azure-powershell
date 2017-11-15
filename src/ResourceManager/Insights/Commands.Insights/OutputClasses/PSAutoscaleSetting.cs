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

using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the AutoscaleSettingGetResponse and AutoscaleSettingResource
    /// </summary>
    public class PSAutoscaleSetting : AutoscaleSettingResource
    {
        /// <summary>
        /// <para>Gets or sets the AutoscaleSettingResourceName of the object.</para>
        /// <para>This property hides a property of the super class for it not to be displayed since it is in the process of deprecation</para>
        /// </summary>
        private new string AutoscaleSettingResourceName { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSAutoscaleSetting class.
        /// </summary>
        /// <param name="autoscaleSettingSpec">The autoscale setting spec</param>
        public PSAutoscaleSetting(AutoscaleSettingResource autoscaleSettingSpec)
            : base(
                  location: autoscaleSettingSpec.Location,
                  profiles: autoscaleSettingSpec.Profiles,
                  id: autoscaleSettingSpec.Id,
                  name: autoscaleSettingSpec.Name,
                  type: autoscaleSettingSpec.Type,
                  tags: autoscaleSettingSpec.Tags,
                  notifications: autoscaleSettingSpec.Notifications,
                  enabled: autoscaleSettingSpec.Enabled,
                  targetResourceUri: autoscaleSettingSpec.TargetResourceUri)
        {
        }
    }
}
