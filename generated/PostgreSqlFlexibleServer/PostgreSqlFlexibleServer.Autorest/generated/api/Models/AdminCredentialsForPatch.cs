// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Credentials of administrator users for source and target servers.</summary>
    public partial class AdminCredentialsForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsForPatch,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsForPatchInternal
    {

        /// <summary>Backing field for <see cref="SourceServerPassword" /> property.</summary>
        private System.Security.SecureString _sourceServerPassword;

        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Security.SecureString SourceServerPassword { get => this._sourceServerPassword; set => this._sourceServerPassword = value; }

        /// <summary>Backing field for <see cref="TargetServerPassword" /> property.</summary>
        private System.Security.SecureString _targetServerPassword;

        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Security.SecureString TargetServerPassword { get => this._targetServerPassword; set => this._targetServerPassword = value; }

        /// <summary>Creates an new <see cref="AdminCredentialsForPatch" /> instance.</summary>
        public AdminCredentialsForPatch()
        {

        }
    }
    /// Credentials of administrator users for source and target servers.
    public partial interface IAdminCredentialsForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
        Update = true,
        Description = @"Password for the user of the source server.",
        SerializedName = @"sourceServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString SourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = false,
        Update = true,
        Description = @"Password for the user of the target server.",
        SerializedName = @"targetServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString TargetServerPassword { get; set; }

    }
    /// Credentials of administrator users for source and target servers.
    internal partial interface IAdminCredentialsForPatchInternal

    {
        /// <summary>Password for the user of the source server.</summary>
        System.Security.SecureString SourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        System.Security.SecureString TargetServerPassword { get; set; }

    }
}