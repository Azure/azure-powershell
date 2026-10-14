// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Request made for a long term retention backup.</summary>
    public partial class BackupsLongTermRetentionRequest :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionRequest,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionRequestInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBase __backupRequestBase = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupRequestBase();

        /// <summary>Backup Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettings BackupSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal)__backupRequestBase).BackupSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal)__backupRequestBase).BackupSetting = value ?? null /* model class */; }

        /// <summary>Backup Name for the current backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string BackupSettingBackupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal)__backupRequestBase).BackupSettingBackupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal)__backupRequestBase).BackupSettingBackupName = value ; }

        /// <summary>Internal Acessors for BackupSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupSettings Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal.BackupSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal)__backupRequestBase).BackupSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal)__backupRequestBase).BackupSetting = value ?? null /* model class */; }

        /// <summary>Internal Acessors for TargetDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetails Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionRequestInternal.TargetDetail { get => (this._targetDetail = this._targetDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupStoreDetails()); set { {_targetDetail = value;} } }

        /// <summary>Backing field for <see cref="TargetDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetails _targetDetail;

        /// <summary>Backup store detail for target server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetails TargetDetail { get => (this._targetDetail = this._targetDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupStoreDetails()); set => this._targetDetail = value; }

        /// <summary>
        /// List of SAS uri of storage containers where backup data is to be streamed/copied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<System.Security.SecureString> TargetDetailSasUriList { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetailsInternal)TargetDetail).SasUriList; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetailsInternal)TargetDetail).SasUriList = value ; }

        /// <summary>Creates an new <see cref="BackupsLongTermRetentionRequest" /> instance.</summary>
        public BackupsLongTermRetentionRequest()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__backupRequestBase), __backupRequestBase);
            await eventListener.AssertObjectIsValid(nameof(__backupRequestBase), __backupRequestBase);
        }
    }
    /// Request made for a long term retention backup.
    public partial interface IBackupsLongTermRetentionRequest :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBase
    {
        /// <summary>
        /// List of SAS uri of storage containers where backup data is to be streamed/copied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of SAS uri of storage containers where backup data is to be streamed/copied.",
        SerializedName = @"sasUriList",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Collections.Generic.List<System.Security.SecureString> TargetDetailSasUriList { get; set; }

    }
    /// Request made for a long term retention backup.
    internal partial interface IBackupsLongTermRetentionRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal
    {
        /// <summary>Backup store detail for target server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetails TargetDetail { get; set; }
        /// <summary>
        /// List of SAS uri of storage containers where backup data is to be streamed/copied.
        /// </summary>
        System.Collections.Generic.List<System.Security.SecureString> TargetDetailSasUriList { get; set; }

    }
}