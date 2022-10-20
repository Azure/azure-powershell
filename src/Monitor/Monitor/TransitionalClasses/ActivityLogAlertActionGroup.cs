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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the MetricSettings, but in the old namespace
    /// </summary>
    public class ActivityLogAlertActionGroup
    {
        /// <summary>
        /// Initializes a new instance of the ActivityLogAlertActionGroup class.
        /// </summary>
        public ActivityLogAlertActionGroup()
        { }

        /// <summary>
        /// Initializes a new instance of the ActivityLogAlertActionGroup
        /// class.
        /// </summary>
        /// <param name="actionGroupId">The resourceId of the action group.
        /// This cannot be null or empty.</param>
        /// <param name="webhookProperties">the dictionary of custom properties
        /// to include with the post operation. These data are appended to the
        /// webhook payload.</param>
        public ActivityLogAlertActionGroup(string actionGroupId, IDictionary<string, string> webhookProperties = default(IDictionary<string, string>))
        {
            ActionGroupId = actionGroupId;
            WebhookProperties = webhookProperties;
        }

        /// <summary>
        /// Gets or sets the resourceId of the action group. This cannot be
        /// null or empty.
        /// </summary>
        public string ActionGroupId { get; set; }

        /// <summary>
        /// Gets or sets the dictionary of custom properties to include with
        /// the post operation. These data are appended to the webhook payload.
        /// </summary>
        public IDictionary<string, string> WebhookProperties { get; set; }
    }
}
