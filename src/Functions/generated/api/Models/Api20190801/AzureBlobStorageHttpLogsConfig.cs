namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Http logs to azure blob storage configuration.</summary>
    public partial class AzureBlobStorageHttpLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureBlobStorageHttpLogsConfigInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="RetentionInDay" /> property.</summary>
        private int? _retentionInDay;

        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? RetentionInDay { get => this._retentionInDay; set => this._retentionInDay = value; }

        /// <summary>Backing field for <see cref="SasUrl" /> property.</summary>
        private string _sasUrl;

        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SasUrl { get => this._sasUrl; set => this._sasUrl = value; }

        /// <summary>Creates an new <see cref="AzureBlobStorageHttpLogsConfig" /> instance.</summary>
        public AzureBlobStorageHttpLogsConfig()
        {

        }
    }
    /// Http logs to azure blob storage configuration.
    public partial interface IAzureBlobStorageHttpLogsConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if configuration is enabled, false if it is disabled and null if configuration is not set.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Retention in days.
        Remove blobs older than X days.
        0 or lower means no retention.",
        SerializedName = @"retentionInDays",
        PossibleTypes = new [] { typeof(int) })]
        int? RetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SAS url to a azure blob container with read/write/list/delete permissions.",
        SerializedName = @"sasUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SasUrl { get; set; }

    }
    /// Http logs to azure blob storage configuration.
    internal partial interface IAzureBlobStorageHttpLogsConfigInternal

    {
        /// <summary>
        /// True if configuration is enabled, false if it is disabled and null if configuration is not set.
        /// </summary>
        bool? Enabled { get; set; }
        /// <summary>
        /// Retention in days.
        /// Remove blobs older than X days.
        /// 0 or lower means no retention.
        /// </summary>
        int? RetentionInDay { get; set; }
        /// <summary>SAS url to a azure blob container with read/write/list/delete permissions.</summary>
        string SasUrl { get; set; }

    }
}