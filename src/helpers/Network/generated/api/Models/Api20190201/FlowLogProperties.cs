namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the configuration of flow log.</summary>
    public partial class FlowLogProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool _enabled;

        /// <summary>Flag to enable/disable flow logging.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="Format" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters _format;

        /// <summary>Parameters that define the flow log format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters Format { get => (this._format = this._format ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogFormatParameters()); set => this._format = value; }

        /// <summary>The file type of flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? FormatType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParametersInternal)Format).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParametersInternal)Format).Type = value; }

        /// <summary>The version (revision) of the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? FormatVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParametersInternal)Format).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParametersInternal)Format).Version = value; }

        /// <summary>Internal Acessors for Format</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal.Format { get => (this._format = this._format ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogFormatParameters()); set { {_format = value;} } }

        /// <summary>Internal Acessors for RetentionPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal.RetentionPolicy { get => (this._retentionPolicy = this._retentionPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RetentionPolicyParameters()); set { {_retentionPolicy = value;} } }

        /// <summary>Backing field for <see cref="RetentionPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters _retentionPolicy;

        /// <summary>Parameters that define the retention policy for flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters RetentionPolicy { get => (this._retentionPolicy = this._retentionPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.RetentionPolicyParameters()); set => this._retentionPolicy = value; }

        /// <summary>Number of days to retain flow log records.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? RetentionPolicyDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParametersInternal)RetentionPolicy).Day; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParametersInternal)RetentionPolicy).Day = value; }

        /// <summary>Flag to enable/disable retention.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? RetentionPolicyEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParametersInternal)RetentionPolicy).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParametersInternal)RetentionPolicy).Enabled = value; }

        /// <summary>Backing field for <see cref="StorageId" /> property.</summary>
        private string _storageId;

        /// <summary>ID of the storage account which is used to store the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StorageId { get => this._storageId; set => this._storageId = value; }

        /// <summary>Creates an new <see cref="FlowLogProperties" /> instance.</summary>
        public FlowLogProperties()
        {

        }
    }
    /// Parameters that define the configuration of flow log.
    public partial interface IFlowLogProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Flag to enable/disable flow logging.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Flag to enable/disable flow logging.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }
        /// <summary>The file type of flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The file type of flow log.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? FormatType { get; set; }
        /// <summary>The version (revision) of the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version (revision) of the flow log.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? FormatVersion { get; set; }
        /// <summary>Number of days to retain flow log records.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of days to retain flow log records.",
        SerializedName = @"days",
        PossibleTypes = new [] { typeof(int) })]
        int? RetentionPolicyDay { get; set; }
        /// <summary>Flag to enable/disable retention.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag to enable/disable retention.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RetentionPolicyEnabled { get; set; }
        /// <summary>ID of the storage account which is used to store the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ID of the storage account which is used to store the flow log.",
        SerializedName = @"storageId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageId { get; set; }

    }
    /// Parameters that define the configuration of flow log.
    internal partial interface IFlowLogPropertiesInternal

    {
        /// <summary>Flag to enable/disable flow logging.</summary>
        bool Enabled { get; set; }
        /// <summary>Parameters that define the flow log format.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters Format { get; set; }
        /// <summary>The file type of flow log.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? FormatType { get; set; }
        /// <summary>The version (revision) of the flow log.</summary>
        int? FormatVersion { get; set; }
        /// <summary>Parameters that define the retention policy for flow log.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters RetentionPolicy { get; set; }
        /// <summary>Number of days to retain flow log records.</summary>
        int? RetentionPolicyDay { get; set; }
        /// <summary>Flag to enable/disable retention.</summary>
        bool? RetentionPolicyEnabled { get; set; }
        /// <summary>ID of the storage account which is used to store the flow log.</summary>
        string StorageId { get; set; }

    }
}