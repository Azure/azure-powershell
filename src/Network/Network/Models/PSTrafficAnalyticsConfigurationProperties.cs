// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;
    using WindowsAzure.Commands.Common.Attributes;

    /// <summary>
    /// Parameters that define the configuration of traffic analytics.
    /// </summary>
    public partial class PSTrafficAnalyticsConfigurationProperties
    {
       
        /// <summary>
        /// Gets or sets flag to enable/disable traffic analytics.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the resource guid of the attached workspace
        /// </summary>
        [JsonProperty(PropertyName = "workspaceId")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the location of the attached workspace
        /// </summary>
        [JsonProperty(PropertyName = "workspaceRegion")]
        [Ps1Xml(Target = ViewControl.Table)]
        public string WorkspaceRegion { get; set; }

        /// <summary>
        /// Gets or sets resource Id of the attached workspace
        /// </summary>
        [JsonProperty(PropertyName = "workspaceResourceId")]
        public string WorkspaceResourceId { get; set; }

        /// <summary>
        /// Gets or sets the interval in minutes which would decide how frequently TA service should do flow analytics
        /// </summary>
        [JsonProperty(PropertyName = "trafficAnalyticsInterval")]
        public int? TrafficAnalyticsInterval { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (WorkspaceId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "WorkspaceId");
            }
            if (WorkspaceRegion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "WorkspaceRegion");
            }
            if (WorkspaceResourceId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "WorkspaceResourceId");
            }
        }
    }
}
