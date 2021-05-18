namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The policy assignment non compliance message used to describe why a resource is non-compliant with a policy.
    /// </summary>
    public class PsNonComplianceMessage
    {
        /// <summary>
        /// Creates an instance of <see cref="PsNonComplianceMessage"/>.
        /// </summary>
        public PsNonComplianceMessage()
        {
        }

        /// <summary>
        /// Creates an instance of <see cref="PsNonComplianceMessage"/> from the equivalent model representation.
        /// </summary>
        /// <param name="messageModel">The non-compliance message model.</param>
        public PsNonComplianceMessage(NonComplianceMessage messageModel)
        {
            this.Message = messageModel.Message;
            this.PolicyDefinitionReferenceId = messageModel.PolicyDefinitionReferenceId;
        }

        /// <summary>
        /// The message that describes why a resource is non-compliant with the policy. This is shown in 'deny' error messages and 
        /// on resource's non-compliant compliance results.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The policy definition reference ID within a policy set definition that the message is intended for. This is only applicable if
        /// the policy assignment assigns a policy set definition. If this is not provided the message applies to all policies assigned by this
        /// policy assignment.
        /// </summary>
        public string PolicyDefinitionReferenceId { get; set; }

        /// <summary>
        /// Convert to JSON
        /// </summary>
        /// <returns>JSON representatnion of the non-compliance message.</returns>
        public JToken ToJToken()
        {
            var returnValue = new JObject();
            if (this.Message != null)
            {
                returnValue["message"] = this.Message;
            }

            if (this.PolicyDefinitionReferenceId != null)
            {
                returnValue["policyDefinitionReferenceId"] = this.PolicyDefinitionReferenceId;
            }

            return returnValue;
        }

        /// <summary>
        /// Converts the powershell model to the entity model.
        /// </summary>
        public NonComplianceMessage ToModel()
        {
            return new NonComplianceMessage
            {
                Message = this.Message,
                PolicyDefinitionReferenceId = this.PolicyDefinitionReferenceId
            };
        }
    }
}
