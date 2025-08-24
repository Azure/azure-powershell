// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The private endpoint resource.</summary>
    public partial class PrivateEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The resource identifier of the private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPrivateEndpointInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Creates an new <see cref="PrivateEndpoint" /> instance.</summary>
        public PrivateEndpoint()
        {

        }
    }
    /// The private endpoint resource.
    public partial interface IPrivateEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>The resource identifier of the private endpoint</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource identifier of the private endpoint",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }

    }
    /// The private endpoint resource.
    internal partial interface IPrivateEndpointInternal

    {
        /// <summary>The resource identifier of the private endpoint</summary>
        string Id { get; set; }

    }
}