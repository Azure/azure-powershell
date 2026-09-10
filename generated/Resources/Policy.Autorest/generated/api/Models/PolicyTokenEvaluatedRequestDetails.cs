// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy token evaluated request details.</summary>
    public partial class PolicyTokenEvaluatedRequestDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetailsInternal
    {

        /// <summary>Backing field for <see cref="ApiVersion" /> property.</summary>
        private string _apiVersion;

        /// <summary>The api-version of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ApiVersion { get => this._apiVersion; set => this._apiVersion = value; }

        /// <summary>Backing field for <see cref="AuthorizationAction" /> property.</summary>
        private string _authorizationAction;

        /// <summary>
        /// The authorization action of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string AuthorizationAction { get => this._authorizationAction; set => this._authorizationAction = value; }

        /// <summary>Backing field for <see cref="ContentHash" /> property.</summary>
        private string _contentHash;

        /// <summary>
        /// The hashed payload of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ContentHash { get => this._contentHash; set => this._contentHash = value; }

        /// <summary>Backing field for <see cref="HttpMethod" /> property.</summary>
        private string _httpMethod;

        /// <summary>The http method of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string HttpMethod { get => this._httpMethod; set => this._httpMethod = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The resource Id of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Backing field for <see cref="Uri" /> property.</summary>
        private string _uri;

        /// <summary>The request URI of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Uri { get => this._uri; set => this._uri = value; }

        /// <summary>Creates an new <see cref="PolicyTokenEvaluatedRequestDetails" /> instance.</summary>
        public PolicyTokenEvaluatedRequestDetails()
        {

        }
    }
    /// The policy token evaluated request details.
    public partial interface IPolicyTokenEvaluatedRequestDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The api-version of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The api-version of the resource operation that is targeted by the issued token.",
        SerializedName = @"apiVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ApiVersion { get; set; }
        /// <summary>
        /// The authorization action of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The authorization action of the resource operation that is targeted by the issued token.",
        SerializedName = @"authorizationAction",
        PossibleTypes = new [] { typeof(string) })]
        string AuthorizationAction { get; set; }
        /// <summary>
        /// The hashed payload of the resource operation that is targeted by the issued token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The hashed payload of the resource operation that is targeted by the issued token.",
        SerializedName = @"contentHash",
        PossibleTypes = new [] { typeof(string) })]
        string ContentHash { get; set; }
        /// <summary>The http method of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The http method of the resource operation that is targeted by the issued token.",
        SerializedName = @"httpMethod",
        PossibleTypes = new [] { typeof(string) })]
        string HttpMethod { get; set; }
        /// <summary>The resource Id of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The resource Id of the resource operation that is targeted by the issued token.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }
        /// <summary>The request URI of the resource operation that is targeted by the issued token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The request URI of the resource operation that is targeted by the issued token.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get; set; }

    }
    /// The policy token evaluated request details.
    internal partial interface IPolicyTokenEvaluatedRequestDetailsInternal

    {
        /// <summary>The api-version of the resource operation that is targeted by the issued token.</summary>
        string ApiVersion { get; set; }
        /// <summary>
        /// The authorization action of the resource operation that is targeted by the issued token.
        /// </summary>
        string AuthorizationAction { get; set; }
        /// <summary>
        /// The hashed payload of the resource operation that is targeted by the issued token.
        /// </summary>
        string ContentHash { get; set; }
        /// <summary>The http method of the resource operation that is targeted by the issued token.</summary>
        string HttpMethod { get; set; }
        /// <summary>The resource Id of the resource operation that is targeted by the issued token.</summary>
        string ResourceId { get; set; }
        /// <summary>The request URI of the resource operation that is targeted by the issued token.</summary>
        string Uri { get; set; }

    }
}