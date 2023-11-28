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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The policy exemption properties.
    /// </summary>
    public class PsPolicyExemptionProperties
    {
        public PsPolicyExemptionProperties(JToken input)
        {
            var properties = input.ToObject<PolicyExemptionProperties>(JsonExtensions.JsonMediaTypeSerializer);
            PolicyAssignmentId = properties.PolicyAssignmentId;
            PolicyDefinitionReferenceIds = properties.PolicyDefinitionReferenceIds;
            ExemptionCategory = properties.ExemptionCategory;
            DisplayName = properties.DisplayName;
            Description = properties.Description;
            ExpiresOn = properties.ExpiresOn.HasValue ? properties.ExpiresOn.Value.ToLocalTime() : properties.ExpiresOn;
            Metadata = properties.Metadata.ToPsObject();
        }

        /// <summary>
        /// Gets or sets the policy assignment Id associated with the policy exemption.
        /// </summary>
        public string PolicyAssignmentId { get; set; }

        /// <summary>
        /// Gets or sets the policy definition reference Ids when the associated policy assignment is for a policy set (initiative).
        /// </summary>
        public string[] PolicyDefinitionReferenceIds { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption category.
        /// </summary>
        public string ExemptionCategory { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption expiration.
        /// </summary>
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the metadata.
        /// </summary>
        public PSObject Metadata { get; set; }


        /// <summary>
        /// Convert to JSON
        /// </summary>
        /// <returns>JSON representatnion of policy assignment properties</returns>
        public JToken ToJToken()
        {
            var returnValue = new JObject();
            if (this.PolicyAssignmentId != null)
            {
                returnValue["policyAssignmentId"] = this.PolicyAssignmentId;
            }

            if (this.PolicyDefinitionReferenceIds != null)
            {
                returnValue["policyDefinitionReferenceIds"] = this.PolicyDefinitionReferenceIds.ToJToken();
            }

            if (this.ExemptionCategory != null)
            {
                returnValue["exemptionCategory"] = this.ExemptionCategory;
            }

            if (this.DisplayName != null)
            {
                returnValue["displayName"] = this.DisplayName;
            }

            if (this.Description != null)
            {
                returnValue["description"] = this.Description;
            }

            if (this.ExpiresOn.HasValue)
            {
                returnValue["expiresOn"] = this.ExpiresOn.Value.ToUniversalTime().ToString(DateTimeFormatInfo.InvariantInfo);
            }

            if (this.Metadata != null)
            {
                returnValue["metadata"] = this.Metadata.ToJToken();
            }

            return returnValue;
        }
    }
}