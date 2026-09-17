// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The external evaluation endpoint invocation results.</summary>
    public partial class ExternalEvaluationEndpointInvocationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal
    {

        /// <summary>Backing field for <see cref="AdditionalInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny _additionalInfo;

        /// <summary>The endpoint specific metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny AdditionalInfo { get => (this._additionalInfo = this._additionalInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any()); set => this._additionalInfo = value; }

        /// <summary>Backing field for <see cref="Claim" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny _claim;

        /// <summary>
        /// The set of claims that will be attached to the policy token as an attestation for the result of the endpoint invocation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Claim { get => (this._claim = this._claim ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any()); set => this._claim = value; }

        /// <summary>Backing field for <see cref="EndpointKind" /> property.</summary>
        private string _endpointKind;

        /// <summary>The external evaluation endpoint kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string EndpointKind { get => this._endpointKind; set => this._endpointKind = value; }

        /// <summary>Backing field for <see cref="Expiration" /> property.</summary>
        private global::System.DateTime? _expiration;

        /// <summary>The expiration of the results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public global::System.DateTime? Expiration { get => this._expiration; set => this._expiration = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>The status message with additional details about the invocation result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Internal Acessors for PolicyInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal.PolicyInfo { get => (this._policyInfo = this._policyInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfo()); set { {_policyInfo = value;} } }

        /// <summary>Backing field for <see cref="PolicyAction" /> property.</summary>
        private string _policyAction;

        /// <summary>
        /// The effective outcome of the policy evaluation based on both the policy effect and evaluation result. Possible values
        /// are Unknown, Allow, Audit, Deny, Error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyAction { get => this._policyAction; set => this._policyAction = value; }

        /// <summary>Backing field for <see cref="PolicyEvaluationDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny _policyEvaluationDetail;

        /// <summary>The evaluation details returned by the policy evaluation engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny PolicyEvaluationDetail { get => (this._policyEvaluationDetail = this._policyEvaluationDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any()); set => this._policyEvaluationDetail = value; }

        /// <summary>Backing field for <see cref="PolicyInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo _policyInfo;

        /// <summary>The details of the policy requiring the external endpoint invocation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo PolicyInfo { get => (this._policyInfo = this._policyInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfo()); set => this._policyInfo = value; }

        /// <summary>The policy assignment Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyAssignmentId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentId = value ?? null; }

        /// <summary>The policy assignment name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyAssignmentName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentName = value ?? null; }

        /// <summary>The policy assignment scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyAssignmentScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentScope; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentScope = value ?? null; }

        /// <summary>The policy assignment version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyAssignmentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyAssignmentVersion = value ?? null; }

        /// <summary>The policy definition action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyDefinitionEffect { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionEffect; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionEffect = value ?? null; }

        /// <summary>The policy definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionId = value ?? null; }

        /// <summary>The policy definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyDefinitionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionName = value ?? null; }

        /// <summary>The policy definition instance Id inside a policy set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyDefinitionReferenceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionReferenceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionReferenceId = value ?? null; }

        /// <summary>The policy definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicyDefinitionVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicyDefinitionVersion = value ?? null; }

        /// <summary>The policy set definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicySetDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicySetDefinitionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicySetDefinitionId = value ?? null; }

        /// <summary>The policy set definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicySetDefinitionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicySetDefinitionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicySetDefinitionName = value ?? null; }

        /// <summary>The policy set definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PolicyInfoPolicySetDefinitionVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicySetDefinitionVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)PolicyInfo).PolicySetDefinitionVersion = value ?? null; }

        /// <summary>Backing field for <see cref="Result" /> property.</summary>
        private string _result;

        /// <summary>The result of the external endpoint. Possible values are Succeeded and Failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Result { get => this._result; set => this._result = value; }

        /// <summary>Backing field for <see cref="RetryAfter" /> property.</summary>
        private global::System.DateTime? _retryAfter;

        /// <summary>The date and time after which a failed endpoint invocation can be retried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public global::System.DateTime? RetryAfter { get => this._retryAfter; set => this._retryAfter = value; }

        /// <summary>
        /// Creates an new <see cref="ExternalEvaluationEndpointInvocationResult" /> instance.
        /// </summary>
        public ExternalEvaluationEndpointInvocationResult()
        {

        }
    }
    /// The external evaluation endpoint invocation results.
    public partial interface IExternalEvaluationEndpointInvocationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The endpoint specific metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The endpoint specific metadata.",
        SerializedName = @"additionalInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny AdditionalInfo { get; set; }
        /// <summary>
        /// The set of claims that will be attached to the policy token as an attestation for the result of the endpoint invocation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The set of claims that will be attached to the policy token as an attestation for the result of the endpoint invocation.",
        SerializedName = @"claims",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Claim { get; set; }
        /// <summary>The external evaluation endpoint kind.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The external evaluation endpoint kind.",
        SerializedName = @"endpointKind",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointKind { get; set; }
        /// <summary>The expiration of the results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The expiration of the results.",
        SerializedName = @"expiration",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Expiration { get; set; }
        /// <summary>The status message with additional details about the invocation result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The status message with additional details about the invocation result.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>
        /// The effective outcome of the policy evaluation based on both the policy effect and evaluation result. Possible values
        /// are Unknown, Allow, Audit, Deny, Error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The effective outcome of the policy evaluation based on both the policy effect and evaluation result. Possible values are Unknown, Allow, Audit, Deny, Error.",
        SerializedName = @"policyAction",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Unknown", "Allow", "Audit", "Deny", "Error")]
        string PolicyAction { get; set; }
        /// <summary>The evaluation details returned by the policy evaluation engine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The evaluation details returned by the policy evaluation engine.",
        SerializedName = @"policyEvaluationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny PolicyEvaluationDetail { get; set; }
        /// <summary>The policy assignment Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment Id.",
        SerializedName = @"policyAssignmentId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyAssignmentId { get; set; }
        /// <summary>The policy assignment name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment name.",
        SerializedName = @"policyAssignmentName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyAssignmentName { get; set; }
        /// <summary>The policy assignment scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment scope.",
        SerializedName = @"policyAssignmentScope",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyAssignmentScope { get; set; }
        /// <summary>The policy assignment version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy assignment version.",
        SerializedName = @"policyAssignmentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyAssignmentVersion { get; set; }
        /// <summary>The policy definition action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition action.",
        SerializedName = @"policyDefinitionEffect",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyDefinitionEffect { get; set; }
        /// <summary>The policy definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition Id.",
        SerializedName = @"policyDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyDefinitionId { get; set; }
        /// <summary>The policy definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition name.",
        SerializedName = @"policyDefinitionName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyDefinitionName { get; set; }
        /// <summary>The policy definition instance Id inside a policy set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition instance Id inside a policy set.",
        SerializedName = @"policyDefinitionReferenceId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyDefinitionReferenceId { get; set; }
        /// <summary>The policy definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy definition version.",
        SerializedName = @"policyDefinitionVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicyDefinitionVersion { get; set; }
        /// <summary>The policy set definition Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition Id.",
        SerializedName = @"policySetDefinitionId",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicySetDefinitionId { get; set; }
        /// <summary>The policy set definition name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition name.",
        SerializedName = @"policySetDefinitionName",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicySetDefinitionName { get; set; }
        /// <summary>The policy set definition version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy set definition version.",
        SerializedName = @"policySetDefinitionVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyInfoPolicySetDefinitionVersion { get; set; }
        /// <summary>The result of the external endpoint. Possible values are Succeeded and Failed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The result of the external endpoint. Possible values are Succeeded and Failed.",
        SerializedName = @"result",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Succeeded", "Failed")]
        string Result { get; set; }
        /// <summary>The date and time after which a failed endpoint invocation can be retried.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The date and time after which a failed endpoint invocation can be retried.",
        SerializedName = @"retryAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RetryAfter { get; set; }

    }
    /// The external evaluation endpoint invocation results.
    internal partial interface IExternalEvaluationEndpointInvocationResultInternal

    {
        /// <summary>The endpoint specific metadata.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny AdditionalInfo { get; set; }
        /// <summary>
        /// The set of claims that will be attached to the policy token as an attestation for the result of the endpoint invocation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Claim { get; set; }
        /// <summary>The external evaluation endpoint kind.</summary>
        string EndpointKind { get; set; }
        /// <summary>The expiration of the results.</summary>
        global::System.DateTime? Expiration { get; set; }
        /// <summary>The status message with additional details about the invocation result.</summary>
        string Message { get; set; }
        /// <summary>
        /// The effective outcome of the policy evaluation based on both the policy effect and evaluation result. Possible values
        /// are Unknown, Allow, Audit, Deny, Error.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Unknown", "Allow", "Audit", "Deny", "Error")]
        string PolicyAction { get; set; }
        /// <summary>The evaluation details returned by the policy evaluation engine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny PolicyEvaluationDetail { get; set; }
        /// <summary>The details of the policy requiring the external endpoint invocation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo PolicyInfo { get; set; }
        /// <summary>The policy assignment Id.</summary>
        string PolicyInfoPolicyAssignmentId { get; set; }
        /// <summary>The policy assignment name.</summary>
        string PolicyInfoPolicyAssignmentName { get; set; }
        /// <summary>The policy assignment scope.</summary>
        string PolicyInfoPolicyAssignmentScope { get; set; }
        /// <summary>The policy assignment version.</summary>
        string PolicyInfoPolicyAssignmentVersion { get; set; }
        /// <summary>The policy definition action.</summary>
        string PolicyInfoPolicyDefinitionEffect { get; set; }
        /// <summary>The policy definition Id.</summary>
        string PolicyInfoPolicyDefinitionId { get; set; }
        /// <summary>The policy definition name.</summary>
        string PolicyInfoPolicyDefinitionName { get; set; }
        /// <summary>The policy definition instance Id inside a policy set.</summary>
        string PolicyInfoPolicyDefinitionReferenceId { get; set; }
        /// <summary>The policy definition version.</summary>
        string PolicyInfoPolicyDefinitionVersion { get; set; }
        /// <summary>The policy set definition Id.</summary>
        string PolicyInfoPolicySetDefinitionId { get; set; }
        /// <summary>The policy set definition name.</summary>
        string PolicyInfoPolicySetDefinitionName { get; set; }
        /// <summary>The policy set definition version.</summary>
        string PolicyInfoPolicySetDefinitionVersion { get; set; }
        /// <summary>The result of the external endpoint. Possible values are Succeeded and Failed.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Succeeded", "Failed")]
        string Result { get; set; }
        /// <summary>The date and time after which a failed endpoint invocation can be retried.</summary>
        global::System.DateTime? RetryAfter { get; set; }

    }
}