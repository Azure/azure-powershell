namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Azure Files or Blob Storage access information value for dictionary storage.</summary>
    public partial class AzureStorageInfoValue :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureStorageInfoValue,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureStorageInfoValueInternal
    {

        /// <summary>Backing field for <see cref="AccessKey" /> property.</summary>
        private string _accessKey;

        /// <summary>Access key for the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AccessKey { get => this._accessKey; set => this._accessKey = value; }

        /// <summary>Backing field for <see cref="AccountName" /> property.</summary>
        private string _accountName;

        /// <summary>Name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AccountName { get => this._accountName; set => this._accountName = value; }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAzureStorageInfoValueInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Backing field for <see cref="MountPath" /> property.</summary>
        private string _mountPath;

        /// <summary>Path to mount the storage within the site's runtime environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MountPath { get => this._mountPath; set => this._mountPath = value; }

        /// <summary>Backing field for <see cref="ShareName" /> property.</summary>
        private string _shareName;

        /// <summary>Name of the file share (container name, for Blob storage).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ShareName { get => this._shareName; set => this._shareName = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageState? _state;

        /// <summary>State of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageState? State { get => this._state; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageType? _type;

        /// <summary>Type of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="AzureStorageInfoValue" /> instance.</summary>
        public AzureStorageInfoValue()
        {

        }
    }
    /// Azure Files or Blob Storage access information value for dictionary storage.
    public partial interface IAzureStorageInfoValue :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Access key for the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Access key for the storage account.",
        SerializedName = @"accessKey",
        PossibleTypes = new [] { typeof(string) })]
        string AccessKey { get; set; }
        /// <summary>Name of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the storage account.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string AccountName { get; set; }
        /// <summary>Path to mount the storage within the site's runtime environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path to mount the storage within the site's runtime environment.",
        SerializedName = @"mountPath",
        PossibleTypes = new [] { typeof(string) })]
        string MountPath { get; set; }
        /// <summary>Name of the file share (container name, for Blob storage).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the file share (container name, for Blob storage).",
        SerializedName = @"shareName",
        PossibleTypes = new [] { typeof(string) })]
        string ShareName { get; set; }
        /// <summary>State of the storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the storage account.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageState? State { get;  }
        /// <summary>Type of storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of storage.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageType? Type { get; set; }

    }
    /// Azure Files or Blob Storage access information value for dictionary storage.
    internal partial interface IAzureStorageInfoValueInternal

    {
        /// <summary>Access key for the storage account.</summary>
        string AccessKey { get; set; }
        /// <summary>Name of the storage account.</summary>
        string AccountName { get; set; }
        /// <summary>Path to mount the storage within the site's runtime environment.</summary>
        string MountPath { get; set; }
        /// <summary>Name of the file share (container name, for Blob storage).</summary>
        string ShareName { get; set; }
        /// <summary>State of the storage account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageState? State { get; set; }
        /// <summary>Type of storage.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureStorageType? Type { get; set; }

    }
}