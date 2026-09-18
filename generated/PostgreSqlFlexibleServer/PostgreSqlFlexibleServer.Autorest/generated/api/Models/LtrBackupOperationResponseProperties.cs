// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Response for the backup request.</summary>
    public partial class LtrBackupOperationResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal
    {

        /// <summary>Backing field for <see cref="BackupMetadata" /> property.</summary>
        private string _backupMetadata;

        /// <summary>
        /// Metadata to be stored in RP. Store everything that will be required to perform a successful restore using this Recovery
        /// point. e.g. Versions, DataFormat etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string BackupMetadata { get => this._backupMetadata; set => this._backupMetadata = value; }

        /// <summary>Backing field for <see cref="BackupName" /> property.</summary>
        private string _backupName;

        /// <summary>Name of Backup operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string BackupName { get => this._backupName; set => this._backupName = value; }

        /// <summary>Backing field for <see cref="DataTransferredInByte" /> property.</summary>
        private long? _dataTransferredInByte;

        /// <summary>Data transferred in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? DataTransferredInByte { get => this._dataTransferredInByte; set => this._dataTransferredInByte = value; }

        /// <summary>Backing field for <see cref="DatasourceSizeInByte" /> property.</summary>
        private long? _datasourceSizeInByte;

        /// <summary>Size of datasource in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? DatasourceSizeInByte { get => this._datasourceSizeInByte; set => this._datasourceSizeInByte = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private string _errorCode;

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string ErrorCode { get => this._errorCode; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; }

        /// <summary>Internal Acessors for ErrorCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal.ErrorCode { get => this._errorCode; set { {_errorCode = value;} } }

        /// <summary>Internal Acessors for ErrorMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal.ErrorMessage { get => this._errorMessage; set { {_errorMessage = value;} } }

        /// <summary>Backing field for <see cref="PercentComplete" /> property.</summary>
        private double? _percentComplete;

        /// <summary>Percentage completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public double? PercentComplete { get => this._percentComplete; set => this._percentComplete = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime _startTime;

        /// <summary>Start time of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Service-set extensible enum indicating the status of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="LtrBackupOperationResponseProperties" /> instance.</summary>
        public LtrBackupOperationResponseProperties()
        {

        }
    }
    /// Response for the backup request.
    public partial interface ILtrBackupOperationResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Metadata to be stored in RP. Store everything that will be required to perform a successful restore using this Recovery
        /// point. e.g. Versions, DataFormat etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Metadata to be stored in RP. Store everything that will be required to perform a successful restore using this Recovery point. e.g. Versions, DataFormat etc.",
        SerializedName = @"backupMetadata",
        PossibleTypes = new [] { typeof(string) })]
        string BackupMetadata { get; set; }
        /// <summary>Name of Backup operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of Backup operation.",
        SerializedName = @"backupName",
        PossibleTypes = new [] { typeof(string) })]
        string BackupName { get; set; }
        /// <summary>Data transferred in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Data transferred in bytes.",
        SerializedName = @"dataTransferredInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? DataTransferredInByte { get; set; }
        /// <summary>Size of datasource in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Size of datasource in bytes.",
        SerializedName = @"datasourceSizeInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? DatasourceSizeInByte { get; set; }
        /// <summary>End time of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time of the operation.",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Error code.",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCode { get;  }
        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Error message.",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get;  }
        /// <summary>Percentage completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Percentage completed.",
        SerializedName = @"percentComplete",
        PossibleTypes = new [] { typeof(double) })]
        double? PercentComplete { get; set; }
        /// <summary>Start time of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time of the operation.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime StartTime { get; set; }
        /// <summary>Service-set extensible enum indicating the status of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Service-set extensible enum indicating the status of operation.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Running", "Cancelled", "Failed", "Succeeded")]
        string Status { get; set; }

    }
    /// Response for the backup request.
    internal partial interface ILtrBackupOperationResponsePropertiesInternal

    {
        /// <summary>
        /// Metadata to be stored in RP. Store everything that will be required to perform a successful restore using this Recovery
        /// point. e.g. Versions, DataFormat etc.
        /// </summary>
        string BackupMetadata { get; set; }
        /// <summary>Name of Backup operation.</summary>
        string BackupName { get; set; }
        /// <summary>Data transferred in bytes.</summary>
        long? DataTransferredInByte { get; set; }
        /// <summary>Size of datasource in bytes.</summary>
        long? DatasourceSizeInByte { get; set; }
        /// <summary>End time of the operation.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Error code.</summary>
        string ErrorCode { get; set; }
        /// <summary>Error message.</summary>
        string ErrorMessage { get; set; }
        /// <summary>Percentage completed.</summary>
        double? PercentComplete { get; set; }
        /// <summary>Start time of the operation.</summary>
        global::System.DateTime StartTime { get; set; }
        /// <summary>Service-set extensible enum indicating the status of operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Running", "Cancelled", "Failed", "Succeeded")]
        string Status { get; set; }

    }
}