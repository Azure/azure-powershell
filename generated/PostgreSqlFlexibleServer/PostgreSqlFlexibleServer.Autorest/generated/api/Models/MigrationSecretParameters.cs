// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration secret parameters.</summary>
    public partial class MigrationSecretParameters :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParameters,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal
    {

        /// <summary>Backing field for <see cref="AdminCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials _adminCredentials;

        /// <summary>Credentials of administrator users for source and target servers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials AdminCredentials { get => (this._adminCredentials = this._adminCredentials ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentials()); set => this._adminCredentials = value; }

        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsSourceServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsInternal)AdminCredentials).SourceServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsInternal)AdminCredentials).SourceServerPassword = value ?? null; }

        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Security.SecureString AdminCredentialsTargetServerPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsInternal)AdminCredentials).TargetServerPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentialsInternal)AdminCredentials).TargetServerPassword = value ?? null; }

        /// <summary>Internal Acessors for AdminCredentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationSecretParametersInternal.AdminCredentials { get => (this._adminCredentials = this._adminCredentials ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdminCredentials()); set { {_adminCredentials = value;} } }

        /// <summary>Backing field for <see cref="SourceServerUsername" /> property.</summary>
        private string _sourceServerUsername;

        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SourceServerUsername { get => this._sourceServerUsername; set => this._sourceServerUsername = value; }

        /// <summary>Backing field for <see cref="TargetServerUsername" /> property.</summary>
        private string _targetServerUsername;

        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TargetServerUsername { get => this._targetServerUsername; set => this._targetServerUsername = value; }

        /// <summary>Creates an new <see cref="MigrationSecretParameters" /> instance.</summary>
        public MigrationSecretParameters()
        {

        }
    }
    /// Migration secret parameters.
    public partial interface IMigrationSecretParameters :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Password for the user of the source server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password for the user of the source server.",
        SerializedName = @"sourceServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdminCredentialsSourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password for the user of the target server.",
        SerializedName = @"targetServerPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdminCredentialsTargetServerPassword { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.",
        SerializedName = @"sourceServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        string SourceServerUsername { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.",
        SerializedName = @"targetServerUsername",
        PossibleTypes = new [] { typeof(string) })]
        string TargetServerUsername { get; set; }

    }
    /// Migration secret parameters.
    internal partial interface IMigrationSecretParametersInternal

    {
        /// <summary>Credentials of administrator users for source and target servers.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdminCredentials AdminCredentials { get; set; }
        /// <summary>Password for the user of the source server.</summary>
        System.Security.SecureString AdminCredentialsSourceServerPassword { get; set; }
        /// <summary>Password for the user of the target server.</summary>
        System.Security.SecureString AdminCredentialsTargetServerPassword { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the source server. This user doesn't need to be an administrator.
        /// </summary>
        string SourceServerUsername { get; set; }
        /// <summary>
        /// Gets or sets the name of the user for the target server. This user doesn't need to be an administrator.
        /// </summary>
        string TargetServerUsername { get; set; }

    }
}