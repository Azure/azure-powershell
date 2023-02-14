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

using Microsoft.Rest;
using Newtonsoft.Json;
using System.Linq;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// State of the private endpoint connection.
    /// </summary>
    public class PSPrivateLinkServiceConnectionStateProperty
    {
        /// <summary>
        /// Initializes a new instance of the
        /// PrivateLinkServiceConnectionStateProperty class.
        /// </summary>
        /// <param name="status">The private link service connection
        /// status.</param>
        /// <param name="description">The private link service connection
        /// description.</param>
        /// <param name="actionsRequired">The actions required for private link
        /// service connection.</param>
        public PSPrivateLinkServiceConnectionStateProperty(string status, string description, string actionsRequired = default(string))
        {
            Status = status;
            Description = description;
            ActionsRequired = actionsRequired;
        }

        /// <summary>
        /// Gets or sets the private link service connection status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the private link service connection description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets the actions required for private link service connection.
        /// </summary>
        [JsonProperty(PropertyName = "actionsRequired")]
        public string ActionsRequired { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Status == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Status");
            }
            if (Description == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Description");
            }
        }
    }
}
