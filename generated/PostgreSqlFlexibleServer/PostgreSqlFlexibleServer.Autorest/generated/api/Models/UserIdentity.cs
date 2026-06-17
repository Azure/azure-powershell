// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>User assigned managed identity associated with a server.</summary>
    public partial class UserIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserIdentity,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IUserIdentityInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>
        /// Identifier of the client of the service principal associated to the user assigned managed identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; set => this._clientId = value; }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>
        /// Identifier of the object of the service principal associated to the user assigned managed identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; set => this._principalId = value; }

        /// <summary>Creates an new <see cref="UserIdentity" /> instance.</summary>
        public UserIdentity()
        {

        }
    }
    /// User assigned managed identity associated with a server.
    public partial interface IUserIdentity :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Identifier of the client of the service principal associated to the user assigned managed identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the client of the service principal associated to the user assigned managed identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>
        /// Identifier of the object of the service principal associated to the user assigned managed identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the object of the service principal associated to the user assigned managed identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get; set; }

    }
    /// User assigned managed identity associated with a server.
    internal partial interface IUserIdentityInternal

    {
        /// <summary>
        /// Identifier of the client of the service principal associated to the user assigned managed identity.
        /// </summary>
        string ClientId { get; set; }
        /// <summary>
        /// Identifier of the object of the service principal associated to the user assigned managed identity.
        /// </summary>
        string PrincipalId { get; set; }

    }
}