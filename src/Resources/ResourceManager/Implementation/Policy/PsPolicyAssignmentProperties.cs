namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The policy assignment properties.
    /// </summary>
    public class PsPolicyAssignmentProperties
    {
        public PsPolicyAssignmentProperties(JToken input)
        {
            var properties = input.ToObject<PolicyAssignmentProperties>(JsonExtensions.JsonMediaTypeSerializer);
            Scope = properties.Scope;
            NotScopes = properties.NotScopes;
            DisplayName = properties.DisplayName;
            Description = properties.Description;
            Metadata = properties.Metadata.ToPsObject();
            EnforcementMode = (PsPolicyAssignmentEnforcementMode)properties.EnforcementMode;
            PolicyDefinitionId = properties.PolicyDefinitionId;
            Parameters = properties.Parameters.ToPsObject();
        }

        /// <summary>
        /// The scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// The not scopes array.
        /// </summary>
        public string[] NotScopes { get; set; }

        /// <summary>
        /// The display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The policy assignment metadata.
        /// </summary>
        public PSObject Metadata { get; set; }

        /// <summary>
        /// The policy assignment enforcement mode.
        /// </summary>
        public PsPolicyAssignmentEnforcementMode? EnforcementMode { get; set; }

        /// <summary>
        /// The policy definition id.
        /// </summary>
        public string PolicyDefinitionId { get; set; }

        /// <summary>
        /// The parameter values.
        /// </summary>
        public PSObject Parameters { get; set; }

        /// <summary>
        /// Convert to JSON
        /// </summary>
        /// <returns>JSON representatnion of policy assignment properties</returns>
        public JToken ToJToken()
        {
            var returnValue = new JObject();
            if (this.Scope != null)
            {
                returnValue["scope"] = this.Scope;
            }

            if (this.NotScopes != null)
            {
                returnValue["notScopes"] = this.NotScopes.ToJToken();
            }

            if (this.DisplayName != null)
            {
                returnValue["displayName"] = this.DisplayName;
            }

            if (this.Description != null)
            {
                returnValue["description"] = this.Description;
            }

            if (this.Metadata != null)
            {
                returnValue["metaData"] = this.Metadata.ToJToken();
            }

            returnValue["enforcementMode"] = this.EnforcementMode.ToString();

            if (this.PolicyDefinitionId != null)
            {
                returnValue["policyDefinitionId"] = this.PolicyDefinitionId;
            }

            if (this.Parameters != null)
            {
                returnValue["parameters"] = this.Parameters.ToJToken();
            }

            return returnValue;
        }
    }
}
