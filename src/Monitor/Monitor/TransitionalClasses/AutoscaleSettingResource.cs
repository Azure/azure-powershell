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

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the AutoscaleSettingResource, but in the old namespace
    /// </summary>
    public class AutoscaleSettingResource : Monitor.Models.AutoscaleSettingResource
    {
        /// <summary>
        /// Gets or sets the Profiles list of the AutoscaleSettingResource
        /// </summary>
        public new IList<AutoscaleProfile> Profiles { get; set; }

        /// <summary>
        /// Gets or sets the Notifications list of the AutoscaleSettingResource
        /// </summary>
        public new IList<AutoscaleNotification> Notifications { get; set; }

        /// <summary>
        /// Initializes a new instance of the AutoscaleSettingResource class.
        /// </summary>
        /// <param name="autoscaleSettingResource">The scale rule</param>
        public AutoscaleSettingResource(Monitor.Models.AutoscaleSettingResource autoscaleSettingResource)
            : base(
                  location: autoscaleSettingResource?.Location,
                  profiles: autoscaleSettingResource?.Profiles,
                  id: autoscaleSettingResource?.Id,
                  name: autoscaleSettingResource?.Name,
                  type: autoscaleSettingResource?.Type,
                  tags: autoscaleSettingResource?.Tags,
                  notifications: autoscaleSettingResource?.Notifications,
                  enabled: autoscaleSettingResource?.Enabled,
                  autoscaleSettingResourceName: autoscaleSettingResource?.AutoscaleSettingResourceName,
                  targetResourceUri: autoscaleSettingResource?.TargetResourceUri)
        {
            this.Profiles = autoscaleSettingResource?.Profiles?.Select(Commands.Insights.TransitionalClasses.TransitionHelpers.ConvertNamespace).ToList();
            this.Notifications = autoscaleSettingResource?.Notifications?.Select(Commands.Insights.TransitionalClasses.TransitionHelpers.ConvertNamespace).ToList();
        }
    }
}
