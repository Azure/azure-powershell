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

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the ActivityLogAlertResource, but in the old namespace
    /// </summary>
    public class ActivityLogAlertResource : Monitor.Models.ActivityLogAlertResource
    {
        /// <summary>
        /// Gets or sets the Actions of the ActivityLogResource
        /// </summary>
        public new ActivityLogAlertActionList Actions { get; set; }

        /// <summary>
        /// Gets or sets the Condition of the ActivityLogResource
        /// </summary>
        public new ActivityLogAlertAllOfCondition Condition { get; set; }

        /// <summary>
        /// Initializes a new instance of the ActivityLogAlertResource class.
        /// </summary>
        public ActivityLogAlertResource()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the ActivityLogAlertResource class.
        /// </summary>
        /// <param name="activityLogAlertResource">The ActivityLogAlertResource object</param>
        public ActivityLogAlertResource(Monitor.Models.ActivityLogAlertResource activityLogAlertResource)
            : base(
                  location: activityLogAlertResource?.Location,
                  scopes: activityLogAlertResource?.Scopes,
                  condition: activityLogAlertResource?.Condition,
                  actions: activityLogAlertResource?.Actions,
                  id: activityLogAlertResource?.Id,
                  name: activityLogAlertResource?.Name,
                  type: activityLogAlertResource?.Type,
                  tags: activityLogAlertResource?.Tags,
                  enabled: activityLogAlertResource?.Enabled,
                  description: activityLogAlertResource?.Description)
        {
            if (activityLogAlertResource != null)
            {
                this.Actions = activityLogAlertResource.Actions != null ? new ActivityLogAlertActionList(activityLogAlertResource.Actions) : null;
                this.Condition = activityLogAlertResource.Condition != null ? new ActivityLogAlertAllOfCondition(activityLogAlertResource.Condition) : null;
            }
        }
    }
}
