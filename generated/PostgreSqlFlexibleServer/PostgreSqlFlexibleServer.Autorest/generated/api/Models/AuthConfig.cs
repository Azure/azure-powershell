// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Authentication configuration properties of a server.</summary>
    public partial class AuthConfig :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfig,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAuthConfigInternal
    {

        /// <summary>Backing field for <see cref="ActiveDirectoryAuth" /> property.</summary>
        private string _activeDirectoryAuth;

        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string ActiveDirectoryAuth { get => this._activeDirectoryAuth; set => this._activeDirectoryAuth = value; }

        /// <summary>Backing field for <see cref="PasswordAuth" /> property.</summary>
        private string _passwordAuth;

        /// <summary>Indicates if the server supports password based authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PasswordAuth { get => this._passwordAuth; set => this._passwordAuth = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Creates an new <see cref="AuthConfig" /> instance.</summary>
        public AuthConfig()
        {

        }
    }
    /// Authentication configuration properties of a server.
    public partial interface IAuthConfig :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if the server supports Microsoft Entra authentication.",
        SerializedName = @"activeDirectoryAuth",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string ActiveDirectoryAuth { get; set; }
        /// <summary>Indicates if the server supports password based authentication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates if the server supports password based authentication.",
        SerializedName = @"passwordAuth",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PasswordAuth { get; set; }
        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Identifier of the tenant of the delegated resource.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// Authentication configuration properties of a server.
    internal partial interface IAuthConfigInternal

    {
        /// <summary>Indicates if the server supports Microsoft Entra authentication.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string ActiveDirectoryAuth { get; set; }
        /// <summary>Indicates if the server supports password based authentication.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string PasswordAuth { get; set; }
        /// <summary>Identifier of the tenant of the delegated resource.</summary>
        string TenantId { get; set; }

    }
}