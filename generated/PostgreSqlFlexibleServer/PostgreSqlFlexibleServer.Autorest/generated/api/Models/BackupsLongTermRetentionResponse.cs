// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Response for the LTR backup API call</summary>
    public partial class BackupsLongTermRetentionResponse :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponse,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IHeaderSerializable
    {

        /// <summary>
        /// Metadata to be stored in RP. Store everything that will be required to perform a successful restore using this Recovery
        /// point. e.g. Versions, DataFormat etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string BackupMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).BackupMetadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).BackupMetadata = value ?? null; }

        /// <summary>Name of Backup operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string BackupName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).BackupName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).BackupName = value ?? null; }

        /// <summary>Data transferred in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public long? DataTransferredInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).DataTransferredInByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).DataTransferredInByte = value ?? default(long); }

        /// <summary>Size of datasource in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public long? DatasourceSizeInByte { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).DatasourceSizeInByte; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).DatasourceSizeInByte = value ?? default(long); }

        /// <summary>End time of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).EndTime = value ?? default(global::System.DateTime); }

        /// <summary>Error code.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).ErrorCode; }

        /// <summary>Error message.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string ErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).ErrorMessage; }

        /// <summary>Internal Acessors for ErrorCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseInternal.ErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).ErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).ErrorCode = value ?? null; }

        /// <summary>Internal Acessors for ErrorMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseInternal.ErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).ErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).ErrorMessage = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponseProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.LtrBackupOperationResponseProperties()); set { {_property = value;} } }

        /// <summary>Percentage completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public double? PercentComplete { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).PercentComplete; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).PercentComplete = value ?? default(double); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponseProperties _property;

        /// <summary>Long Term Retention Backup Operation Resource Properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.LtrBackupOperationResponseProperties()); set => this._property = value; }

        /// <summary>Start time of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public global::System.DateTime? StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).StartTime = value ?? default(global::System.DateTime); }

        /// <summary>Service-set extensible enum indicating the status of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponsePropertiesInternal)Property).Status = value ?? null; }

        /// <summary>Backing field for <see cref="XmsRequestId" /> property.</summary>
        private string _xmsRequestId;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string XmsRequestId { get => this._xmsRequestId; set => this._xmsRequestId = value; }

        /// <summary>Creates an new <see cref="BackupsLongTermRetentionResponse" /> instance.</summary>
        public BackupsLongTermRetentionResponse()
        {

        }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("x-ms-request-id", out var __xMSRequestIdHeader0))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseInternal)this).XmsRequestId = System.Linq.Enumerable.FirstOrDefault(__xMSRequestIdHeader0) is string __headerXMSRequestIdHeader0 ? __headerXMSRequestIdHeader0 : (string)null;
            }
        }
    }
    /// Response for the LTR backup API call
    public partial interface IBackupsLongTermRetentionResponse :
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
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time of the operation.",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Service-set extensible enum indicating the status of operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Service-set extensible enum indicating the status of operation.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Running", "Cancelled", "Failed", "Succeeded")]
        string Status { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"x-ms-request-id",
        PossibleTypes = new [] { typeof(string) })]
        string XmsRequestId { get; set; }

    }
    /// Response for the LTR backup API call
    internal partial interface IBackupsLongTermRetentionResponseInternal

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
        /// <summary>Long Term Retention Backup Operation Resource Properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrBackupOperationResponseProperties Property { get; set; }
        /// <summary>Start time of the operation.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Service-set extensible enum indicating the status of operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Running", "Cancelled", "Failed", "Succeeded")]
        string Status { get; set; }

        string XmsRequestId { get; set; }

    }
}