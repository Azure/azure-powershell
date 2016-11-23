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
using Microsoft.Azure.Management.Insights.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the AutoscaleSettingGetResponse and AutoscaleSettingResource
    /// </summary>
    public sealed class PSAutoscaleSetting : AutoscaleSettingResource
    {
        /// <summary>
        /// <para>Gets or sets the Tags of the object.</para>
        /// <para>This property hides a property of the super class to enable the display of details</para>
        /// </summary>
        public new PSDictionaryElement Tags { get; set; }

        /// <summary>
        /// <para>Gets or sets the Tags of the object.</para>
        /// <para>This property hides a property of the super class to enable the display of details</para>
        /// </summary>
        public new PSAutoscaleProfilesList Profiles { get; set; }

        /// <summary>
        /// Initializes a new instance of the PSAutoscaleSetting class.
        /// </summary>
        /// <param name="autoscaleSettingSpec">The autoscale setting spec</param>
        public PSAutoscaleSetting(AutoscaleSettingResource autoscaleSettingSpec)
            : base(id: autoscaleSettingSpec.Id, location: autoscaleSettingSpec.Location, autoscaleSettingResourceName: autoscaleSettingSpec.Name, profiles: autoscaleSettingSpec.Profiles, type: autoscaleSettingSpec.Type, tags: autoscaleSettingSpec.Tags)
        {
            this.Name = autoscaleSettingSpec.Name;
            this.TargetResourceUri = autoscaleSettingSpec.TargetResourceUri;
            this.Enabled = autoscaleSettingSpec.Enabled;
            this.Notifications = autoscaleSettingSpec.Notifications;
            this.Tags = new PSDictionaryElement(autoscaleSettingSpec.Tags);
            this.Profiles = new PSAutoscaleProfilesList(autoscaleSettingSpec.Profiles);
        }
    }
}
