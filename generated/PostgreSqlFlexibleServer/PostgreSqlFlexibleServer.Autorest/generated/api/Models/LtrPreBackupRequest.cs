// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>A request that is made for pre-backup.</summary>
    public partial class LtrPreBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupRequest,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupRequestInternal,
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

        /// <summary>Creates an new <see cref="LtrPreBackupRequest" /> instance.</summary>
        public LtrPreBackupRequest()
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
    /// A request that is made for pre-backup.
    public partial interface ILtrPreBackupRequest :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBase
    {

    }
    /// A request that is made for pre-backup.
    internal partial interface ILtrPreBackupRequestInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupRequestBaseInternal
    {

    }
}