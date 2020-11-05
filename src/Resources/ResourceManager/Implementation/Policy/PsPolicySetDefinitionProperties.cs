namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The policy assignment properties.
    /// </summary>
    public class PsPolicySetDefinitionProperties
    {
        public PsPolicySetDefinitionProperties(JToken input)
        {
            var properties = input.ToObject<PolicySetDefinitionProperties>(JsonExtensions.JsonMediaTypeSerializer);
            Description = properties.Description;
            DisplayName = properties.DisplayName;
            Metadata = properties.Metadata.ToPsObject();
            Parameters = properties.Parameters.ToPsObject();
            PolicyDefinitionGroups = properties.PolicyDefinitionGroups.ToPsObject();
            PolicyDefinitions = properties.PolicyDefinitions.ToPsObject();
            PolicyType = PsPolicyDefinitionProperties.PolicyTypeToPsPolicyType(properties.PolicyType);
        }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The policy set definition metadata.
        /// </summary>
        public PSObject Metadata { get; set; }

        /// <summary>
        /// The parameters declaration.
        /// </summary>
        public PSObject Parameters { get; set; }

        /// <summary>
        /// The policy definition groups.
        /// </summary>
        public PSObject PolicyDefinitionGroups { get; set; }

        /// <summary>
        /// The policy reference.
        /// </summary>
        public PSObject PolicyDefinitions { get; set; }

        /// <summary>
        /// The policy type.
        /// </summary>
        public PsPolicyType PolicyType { get; set; }

        /// <summary>
        /// Convert to JSON
        /// </summary>
        /// <returns>JSON representatnion of policy set definition properties</returns>
        public JToken ToJToken()
        {
            var returnValue = new JObject();
            if (this.Description != null)
            {
                returnValue["description"] = this.Description;
            }

            if (this.DisplayName != null)
            {
                returnValue["displayName"] = this.DisplayName;
            }

            if (this.Metadata != null)
            {
                returnValue["metaData"] = this.Metadata.ToJToken();
            }

            if (this.Parameters != null)
            {
                returnValue["parameters"] = this.Parameters.ToJToken();
            }

            if (this.PolicyDefinitionGroups != null)
            {
                returnValue["policyDefinitionGroups"] = this.PolicyDefinitionGroups.ToJToken();
            }

            if (this.PolicyDefinitions != null)
            {
                returnValue["policyDefinitions"] = this.PolicyDefinitions.ToJToken();
            }

            returnValue["policyType"] = this.PolicyType.ToString();
            return returnValue;
        }
    }
}
