namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    /// </summary>
    public partial class AzureFileVolume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal
    {

        /// <summary>Backing field for <see cref="ReadOnly" /> property.</summary>
        private bool? _readOnly;

        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public bool? ReadOnly { get => this._readOnly; set => this._readOnly = value; }

        /// <summary>Backing field for <see cref="ShareName" /> property.</summary>
        private string _shareName;

        /// <summary>The name of the Azure File share to be mounted as a volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string ShareName { get => this._shareName; set => this._shareName = value; }

        /// <summary>Backing field for <see cref="StorageAccountKey" /> property.</summary>
        private string _storageAccountKey;

        /// <summary>The storage account access key used to access the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string StorageAccountKey { get => this._storageAccountKey; set => this._storageAccountKey = value; }

        /// <summary>Backing field for <see cref="StorageAccountName" /> property.</summary>
        private string _storageAccountName;

        /// <summary>The name of the storage account that contains the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string StorageAccountName { get => this._storageAccountName; set => this._storageAccountName = value; }

        /// <summary>Creates an new <see cref="AzureFileVolume" /> instance.</summary>
        public AzureFileVolume()
        {

        }
    }
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    public partial interface IAzureFileVolume :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The flag indicating whether the Azure File shared mounted as a volume is read-only.",
        SerializedName = @"readOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ReadOnly { get; set; }
        /// <summary>The name of the Azure File share to be mounted as a volume.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the Azure File share to be mounted as a volume.",
        SerializedName = @"shareName",
        PossibleTypes = new [] { typeof(string) })]
        string ShareName { get; set; }
        /// <summary>The storage account access key used to access the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The storage account access key used to access the Azure File share.",
        SerializedName = @"storageAccountKey",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountKey { get; set; }
        /// <summary>The name of the storage account that contains the Azure File share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the storage account that contains the Azure File share.",
        SerializedName = @"storageAccountName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountName { get; set; }

    }
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    internal partial interface IAzureFileVolumeInternal

    {
        /// <summary>
        /// The flag indicating whether the Azure File shared mounted as a volume is read-only.
        /// </summary>
        bool? ReadOnly { get; set; }
        /// <summary>The name of the Azure File share to be mounted as a volume.</summary>
        string ShareName { get; set; }
        /// <summary>The storage account access key used to access the Azure File share.</summary>
        string StorageAccountKey { get; set; }
        /// <summary>The name of the storage account that contains the Azure File share.</summary>
        string StorageAccountName { get; set; }

    }
}