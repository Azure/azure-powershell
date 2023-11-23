namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The policy assignment properties.
    /// </summary>
    public class PsPolicyDefinitionProperties
    {
        public static PsPolicyType PolicyTypeToPsPolicyType(PolicyType policyType)
        {
            switch (policyType)
            {
                case Entities.Policy.PolicyType.BuiltIn:
                    return PsPolicyType.BuiltIn;
                case Entities.Policy.PolicyType.Custom:
                    return PsPolicyType.Custom;
                case Entities.Policy.PolicyType.Static:
                    return PsPolicyType.Static;
                default:
                    return PsPolicyType.None;
            }
        }

        public PsPolicyDefinitionProperties(JToken input)
        {
            var properties = input.ToObject<PolicyDefinitionProperties>(JsonExtensions.JsonMediaTypeSerializer);
            Description = properties.Description;
            DisplayName = properties.DisplayName;
            Metadata = properties.Metadata.ToPsObject();
            Mode = properties.Mode;
            Parameters = properties.Parameters.ToPsObject();
            PolicyRule = properties.PolicyRule.ToPsObject();
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
        /// The policy definition metadata.
        /// </summary>
        public PSObject Metadata { get; set; }

        /// <summary>
        /// The mode.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// The parameters declaration.
        /// </summary>
        public PSObject Parameters { get; set; }

        /// <summary>
        /// The policy rule.
        /// </summary>
        public PSObject PolicyRule { get; set; }

        /// <summary>
        /// The policy type.
        /// </summary>
        public PsPolicyType PolicyType { get; set; }

        /// <summary>
        /// Convert to JSON
        /// </summary>
        /// <returns>JSON representatnion of policy definition properties</returns>
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

            if (this.Mode != null)
            {
                returnValue["mode"] = this.Mode.ToString();
            }

            if (this.Parameters != null)
            {
                returnValue["parameters"] = this.Parameters.ToJToken();
            }

            if (this.PolicyRule != null)
            {
                returnValue["policyRule"] = this.PolicyRule.ToJToken();
            }

            returnValue["policyType"] = this.PolicyType.ToString();
            return returnValue;
        }
    }
}
