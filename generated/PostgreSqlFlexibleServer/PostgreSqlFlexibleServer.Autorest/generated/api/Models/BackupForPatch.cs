// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Backup properties of a server.</summary>
    public partial class BackupForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatch,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatchInternal
    {

        /// <summary>Backing field for <see cref="BackupRetentionDay" /> property.</summary>
        private int? _backupRetentionDay;

        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int? BackupRetentionDay { get => this._backupRetentionDay; set => this._backupRetentionDay = value; }

        /// <summary>Backing field for <see cref="EarliestRestoreDate" /> property.</summary>
        private global::System.DateTime? _earliestRestoreDate;

        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? EarliestRestoreDate { get => this._earliestRestoreDate; }

        /// <summary>Backing field for <see cref="GeoRedundantBackup" /> property.</summary>
        private string _geoRedundantBackup;

        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string GeoRedundantBackup { get => this._geoRedundantBackup; }

        /// <summary>Internal Acessors for EarliestRestoreDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatchInternal.EarliestRestoreDate { get => this._earliestRestoreDate; set { {_earliestRestoreDate = value;} } }

        /// <summary>Internal Acessors for GeoRedundantBackup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupForPatchInternal.GeoRedundantBackup { get => this._geoRedundantBackup; set { {_geoRedundantBackup = value;} } }

        /// <summary>Creates an new <see cref="BackupForPatch" /> instance.</summary>
        public BackupForPatch()
        {

        }
    }
    /// Backup properties of a server.
    public partial interface IBackupForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Backup retention days for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Backup retention days for the server.",
        SerializedName = @"backupRetentionDays",
        PossibleTypes = new [] { typeof(int) })]
        int? BackupRetentionDay { get; set; }
        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Earliest restore point time (ISO8601 format) for a server.",
        SerializedName = @"earliestRestoreDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EarliestRestoreDate { get;  }
        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if the server is configured to create geographically redundant backups.",
        SerializedName = @"geoRedundantBackup",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string GeoRedundantBackup { get;  }

    }
    /// Backup properties of a server.
    internal partial interface IBackupForPatchInternal

    {
        /// <summary>Backup retention days for the server.</summary>
        int? BackupRetentionDay { get; set; }
        /// <summary>Earliest restore point time (ISO8601 format) for a server.</summary>
        global::System.DateTime? EarliestRestoreDate { get; set; }
        /// <summary>
        /// Indicates if the server is configured to create geographically redundant backups.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string GeoRedundantBackup { get; set; }

    }
}