// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>BackupRequestBase is the base for all backup request.</summary>
    public partial class BackupRequestBase :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBase,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal
    {

        /// <summary>Backing field for <see cref="BackupSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettings _backupSetting;

        /// <summary>Backup Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettings BackupSetting { get => (this._backupSetting = this._backupSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupSettings()); set => this._backupSetting = value; }

        /// <summary>Backup Name for the current backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string BackupSettingBackupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettingsInternal)BackupSetting).BackupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettingsInternal)BackupSetting).BackupName = value ; }

        /// <summary>Internal Acessors for BackupSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettings Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal.BackupSetting { get => (this._backupSetting = this._backupSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupSettings()); set { {_backupSetting = value;} } }

        /// <summary>Creates an new <see cref="BackupRequestBase" /> instance.</summary>
        public BackupRequestBase()
        {

        }
    }
    /// BackupRequestBase is the base for all backup request.
    public partial interface IBackupRequestBase :
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
        string BackupSettingBackupName { get; set; }

    }
    /// BackupRequestBase is the base for all backup request.
    internal partial interface IBackupRequestBaseInternal

    {
        /// <summary>Backup Settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettings BackupSetting { get; set; }
        /// <summary>Backup Name for the current backup</summary>
        string BackupSettingBackupName { get; set; }

    }
}