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

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The properties related to the fallback route based on which the IoT
    /// hub routes messages to the fallback endpoint.
    /// </summary>
    public partial class PSFallbackRouteProperties
    {
        /// <summary>
        /// Initializes a new instance of the FallbackRouteProperties class.
        /// </summary>
        public PSFallbackRouteProperties() { }

        /// <summary>
        /// Initializes a new instance of the FallbackRouteProperties class.
        /// </summary>
        public PSFallbackRouteProperties(IList<string> endpointNames, bool isEnabled, string condition = default(string))
        {
            Condition = condition;
            EndpointNames = endpointNames;
            IsEnabled = isEnabled;
        }
        /// <summary>
        /// Static constructor for FallbackRouteProperties class.
        /// </summary>
        static PSFallbackRouteProperties()
        {
            Source = "DeviceMessages";
        }

        /// <summary>
        /// The condition which is evaluated in order to apply the fallback
        /// route.
        /// </summary>
        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }

        /// <summary>
        /// The list of endpoints to which the messages that satisfy the
        /// condition are routed to.
        /// </summary>
        [JsonProperty(PropertyName = "endpointNames")]
        public IList<string> EndpointNames { get; set; }

        /// <summary>
        /// Used to specify whether the fallback route is enabled or not.
        /// </summary>
        [JsonProperty(PropertyName = "isEnabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The source to which the routing rule is to be applied to. e.g.
        /// DeviceMessages
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public static string Source { get; private set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (EndpointNames == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EndpointNames");
            }
            if (this.EndpointNames != null)
            {
                if (this.EndpointNames.Count > 1)
                {
                    throw new ValidationException(ValidationRules.MaxItems, "EndpointNames", 1);
                }
                if (this.EndpointNames.Count < 1)
                {
                    throw new ValidationException(ValidationRules.MinItems, "EndpointNames", 1);
                }
            }
        }
    }
}
