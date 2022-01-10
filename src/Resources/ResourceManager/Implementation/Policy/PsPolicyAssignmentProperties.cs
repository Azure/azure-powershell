namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using System.Linq;
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
            NonComplianceMessages = properties
                .NonComplianceMessages?
                .Where(message => message != null)
                .SelectArray(message => new PsNonComplianceMessage(message));
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
        /// The non-compliance messages used to describe why a resource is non-compliant with the policy.
        /// </summary>
        public PsNonComplianceMessage[] NonComplianceMessages { get; set; }

        /// <summary>
        /// Convert to JSON
        /// </summary>
        /// <returns>JSON representation of policy assignment properties</returns>
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

            if (this.NonComplianceMessages != null)
            {
                returnValue["nonComplianceMessages"] = this.NonComplianceMessages.ToJToken();
            }

            return returnValue;
        }
    }
}
