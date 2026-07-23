// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a backup.</summary>
    public partial class BackupAutomaticAndOnDemandProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupAutomaticAndOnDemandProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupAutomaticAndOnDemandPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BackupType" /> property.</summary>
        private string _backupType;

        /// <summary>Type of backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string BackupType { get => this._backupType; set => this._backupType = value; }

        /// <summary>Backing field for <see cref="CompletedTime" /> property.</summary>
        private global::System.DateTime? _completedTime;

        /// <summary>Time(ISO8601 format) at which the backup was completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? CompletedTime { get => this._completedTime; set => this._completedTime = value; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Source of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Creates an new <see cref="BackupAutomaticAndOnDemandProperties" /> instance.</summary>
        public BackupAutomaticAndOnDemandProperties()
        {

        }
    }
    /// Properties of a backup.
    public partial interface IBackupAutomaticAndOnDemandProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Type of backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of backup.",
        SerializedName = @"backupType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Full", "Customer On-Demand")]
        string BackupType { get; set; }
        /// <summary>Time(ISO8601 format) at which the backup was completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Time(ISO8601 format) at which the backup was completed.",
        SerializedName = @"completedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CompletedTime { get; set; }
        /// <summary>Source of the backup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Source of the backup.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }

    }
    /// Properties of a backup.
    internal partial interface IBackupAutomaticAndOnDemandPropertiesInternal

    {
        /// <summary>Type of backup.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Full", "Customer On-Demand")]
        string BackupType { get; set; }
        /// <summary>Time(ISO8601 format) at which the backup was completed.</summary>
        global::System.DateTime? CompletedTime { get; set; }
        /// <summary>Source of the backup.</summary>
        string Source { get; set; }

    }
}