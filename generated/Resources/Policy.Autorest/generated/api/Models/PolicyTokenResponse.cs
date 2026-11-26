// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy token response properties.</summary>
    public partial class PolicyTokenResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal
    {

        /// <summary>Backing field for <see cref="ChangeReference" /> property.</summary>
        private string _changeReference;

        /// <summary>
        /// The change reference associated with the operation for which the token is acquired.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ChangeReference { get => this._changeReference; set => this._changeReference = value; }

        /// <summary>Backing field for <see cref="Expiration" /> property.</summary>
        private global::System.DateTime? _expiration;

        /// <summary>The expiration of the policy token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public global::System.DateTime? Expiration { get => this._expiration; set => this._expiration = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>
        /// Status message with additional details about the token acquisition operation result.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Internal Acessors for RequestDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetails Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal.RequestDetail { get => (this._requestDetail = this._requestDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenEvaluatedRequestDetails()); set { {_requestDetail = value;} } }

        /// <summary>Backing field for <see cref="RequestDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetails _requestDetail;

        /// <summary>The external evaluation request details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetails RequestDetail { get => (this._requestDetail = this._requestDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenEvaluatedRequestDetails()); set => this._requestDetail = value; }

        /// <summary>The api-version of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string RequestDetailApiVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).ApiVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).ApiVersion = value ?? null; }

        /// <summary>
        /// The authorization action of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string RequestDetailAuthorizationAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).AuthorizationAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).AuthorizationAction = value ?? null; }

        /// <summary>
        /// The hashed payload of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string RequestDetailContentHash { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).ContentHash; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).ContentHash = value ?? null; }

        /// <summary>The http method of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string RequestDetailHttpMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).HttpMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).HttpMethod = value ?? null; }

        /// <summary>The resource Id of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string RequestDetailResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).ResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).ResourceId = value ?? null; }

        /// <summary>The request URI of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string RequestDetailUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).Uri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal)RequestDetail).Uri = value ?? null; }

        /// <summary>Backing field for <see cref="Result" /> property.</summary>
        private string _result;

        /// <summary>
        /// The result of the completed token acquisition operation. Possible values are Succeeded and Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Result { get => this._result; set => this._result = value; }

        /// <summary>Backing field for <see cref="Results" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult> _results;

        /// <summary>An array of external evaluation endpoint invocation results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult> Results { get => this._results; set => this._results = value; }

        /// <summary>Backing field for <see cref="RetryAfter" /> property.</summary>
        private global::System.DateTime? _retryAfter;

        /// <summary>
        /// The date and time after which the client can try to acquire a token again in the case of retry-able failures.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public global::System.DateTime? RetryAfter { get => this._retryAfter; set => this._retryAfter = value; }

        /// <summary>Backing field for <see cref="Token" /> property.</summary>
        private string _token;

        /// <summary>The issued policy token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Token { get => this._token; set => this._token = value; }

        /// <summary>Backing field for <see cref="TokenId" /> property.</summary>
        private string _tokenId;

        /// <summary>The unique Id assigned to the policy token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string TokenId { get => this._tokenId; set => this._tokenId = value; }

        /// <summary>Creates an new <see cref="PolicyTokenResponse" /> instance.</summary>
        public PolicyTokenResponse()
        {

        }
    }
    /// The policy token response properties.
    public partial interface IPolicyTokenResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The change reference associated with the operation for which the token is acquired.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The change reference associated with the operation for which the token is acquired.",
        SerializedName = @"changeReference",
        PossibleTypes = new [] { typeof(string) })]
        string ChangeReference { get; set; }
        /// <summary>The expiration of the policy token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The expiration of the policy token.",
        SerializedName = @"expiration",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Expiration { get; set; }
        /// <summary>
        /// Status message with additional details about the token acquisition operation result.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Status message with additional details about the token acquisition operation result.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>The api-version of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The api-version of the resource operation that is targeted by the issued token.",
        SerializedName = @"apiVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RequestDetailApiVersion { get; set; }
        /// <summary>
        /// The authorization action of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The authorization action of the resource operation that is targeted by the issued token.",
        SerializedName = @"authorizationAction",
        PossibleTypes = new [] { typeof(string) })]
        string RequestDetailAuthorizationAction { get; set; }
        /// <summary>
        /// The hashed payload of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The hashed payload of the resource operation that is targeted by the issued token.",
        SerializedName = @"contentHash",
        PossibleTypes = new [] { typeof(string) })]
        string RequestDetailContentHash { get; set; }
        /// <summary>The http method of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The http method of the resource operation that is targeted by the issued token.",
        SerializedName = @"httpMethod",
        PossibleTypes = new [] { typeof(string) })]
        string RequestDetailHttpMethod { get; set; }
        /// <summary>The resource Id of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The resource Id of the resource operation that is targeted by the issued token.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string RequestDetailResourceId { get; set; }
        /// <summary>The request URI of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The request URI of the resource operation that is targeted by the issued token.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string RequestDetailUri { get; set; }
        /// <summary>
        /// The result of the completed token acquisition operation. Possible values are Succeeded and Failed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The result of the completed token acquisition operation. Possible values are Succeeded and Failed.",
        SerializedName = @"result",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Succeeded", "Failed")]
        string Result { get; set; }
        /// <summary>An array of external evaluation endpoint invocation results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"An array of external evaluation endpoint invocation results.",
        SerializedName = @"results",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult> Results { get; set; }
        /// <summary>
        /// The date and time after which the client can try to acquire a token again in the case of retry-able failures.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The date and time after which the client can try to acquire a token again in the case of retry-able failures.",
        SerializedName = @"retryAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RetryAfter { get; set; }
        /// <summary>The issued policy token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The issued policy token.",
        SerializedName = @"token",
        PossibleTypes = new [] { typeof(string) })]
        string Token { get; set; }
        /// <summary>The unique Id assigned to the policy token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The unique Id assigned to the policy token.",
        SerializedName = @"tokenId",
        PossibleTypes = new [] { typeof(string) })]
        string TokenId { get; set; }

    }
    /// The policy token response properties.
    internal partial interface IPolicyTokenResponseInternal

    {
        /// <summary>
        /// The change reference associated with the operation for which the token is acquired.
        /// </summary>
        string ChangeReference { get; set; }
        /// <summary>The expiration of the policy token.</summary>
        global::System.DateTime? Expiration { get; set; }
        /// <summary>
        /// Status message with additional details about the token acquisition operation result.
        /// </summary>
        string Message { get; set; }
        /// <summary>The external evaluation request details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetails RequestDetail { get; set; }
        /// <summary>The api-version of the resource operation that is targeted by the issued token.</summary>
        string RequestDetailApiVersion { get; set; }
        /// <summary>
        /// The authorization action of the resource operation that is targeted by the issued token.
        /// </summary>
        string RequestDetailAuthorizationAction { get; set; }
        /// <summary>
        /// The hashed payload of the resource operation that is targeted by the issued token.
        /// </summary>
        string RequestDetailContentHash { get; set; }
        /// <summary>The http method of the resource operation that is targeted by the issued token.</summary>
        string RequestDetailHttpMethod { get; set; }
        /// <summary>The resource Id of the resource operation that is targeted by the issued token.</summary>
        string RequestDetailResourceId { get; set; }
        /// <summary>The request URI of the resource operation that is targeted by the issued token.</summary>
        string RequestDetailUri { get; set; }
        /// <summary>
        /// The result of the completed token acquisition operation. Possible values are Succeeded and Failed.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("Succeeded", "Failed")]
        string Result { get; set; }
        /// <summary>An array of external evaluation endpoint invocation results.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult> Results { get; set; }
        /// <summary>
        /// The date and time after which the client can try to acquire a token again in the case of retry-able failures.
        /// </summary>
        global::System.DateTime? RetryAfter { get; set; }
        /// <summary>The issued policy token.</summary>
        string Token { get; set; }
        /// <summary>The unique Id assigned to the policy token.</summary>
        string TokenId { get; set; }

    }
}