// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>Access token request object</summary>
    public partial class AccessTokenReadRequest :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenReadRequest,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenReadRequestInternal
    {

        /// <summary>Backing field for <see cref="RequestId" /> property.</summary>
        private string _requestId;

        /// <summary>The name of the publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string RequestId { get => this._requestId; set => this._requestId = value; }

        /// <summary>Creates an new <see cref="AccessTokenReadRequest" /> instance.</summary>
        public AccessTokenReadRequest()
        {

        }
    }
    /// Access token request object
    public partial interface IAccessTokenReadRequest :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The name of the publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the publisher.",
        SerializedName = @"requestId",
        PossibleTypes = new [] { typeof(string) })]
        string RequestId { get; set; }

    }
    /// Access token request object
    internal partial interface IAccessTokenReadRequestInternal

    {
        /// <summary>The name of the publisher.</summary>
        string RequestId { get; set; }

    }
}