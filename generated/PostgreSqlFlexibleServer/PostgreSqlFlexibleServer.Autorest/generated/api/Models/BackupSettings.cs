// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Settings for the long term backup.</summary>
    public partial class BackupSettings :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettings,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettingsInternal
    {

        /// <summary>Backing field for <see cref="BackupName" /> property.</summary>
        private string _backupName;

        /// <summary>Backup Name for the current backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string BackupName { get => this._backupName; set => this._backupName = value; }

        /// <summary>Creates an new <see cref="BackupSettings" /> instance.</summary>
        public BackupSettings()
        {

        }
    }
    /// Settings for the long term backup.
    public partial interface IBackupSettings :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Backup Name for the current backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Backup Name for the current backup",
        SerializedName = @"backupName",
        PossibleTypes = new [] { typeof(string) })]
        string BackupName { get; set; }

    }
    /// Settings for the long term backup.
    internal partial interface IBackupSettingsInternal

    {
        /// <summary>Backup Name for the current backup</summary>
        string BackupName { get; set; }

    }
}