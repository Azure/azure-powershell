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

    /// <summary>
    /// Parameters that define the configuration of traffic analytics.
    /// </summary>
    public partial class PSTrafficAnalyticsProperties
    {

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "networkWatcherFlowAnalyticsConfiguration")]
        public PSTrafficAnalyticsConfigurationProperties NetworkWatcherFlowAnalyticsConfiguration { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (NetworkWatcherFlowAnalyticsConfiguration == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NetworkWatcherFlowAnalyticsConfiguration");
            }
            if (NetworkWatcherFlowAnalyticsConfiguration != null)
            {
                NetworkWatcherFlowAnalyticsConfiguration.Validate();
            }
        }
    }
}
