namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure VM disk input details.</summary>
    public partial class A2AvmDiskInputDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AvmDiskInputDetailsInternal
    {

        /// <summary>Backing field for <see cref="DiskUri" /> property.</summary>
        private string _diskUri;

        /// <summary>The disk Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskUri { get => this._diskUri; set => this._diskUri = value; }

        /// <summary>Backing field for <see cref="PrimaryStagingAzureStorageAccountId" /> property.</summary>
        private string _primaryStagingAzureStorageAccountId;

        /// <summary>The primary staging storage account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PrimaryStagingAzureStorageAccountId { get => this._primaryStagingAzureStorageAccountId; set => this._primaryStagingAzureStorageAccountId = value; }

        /// <summary>Backing field for <see cref="RecoveryAzureStorageAccountId" /> property.</summary>
        private string _recoveryAzureStorageAccountId;

        /// <summary>The recovery VHD storage account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RecoveryAzureStorageAccountId { get => this._recoveryAzureStorageAccountId; set => this._recoveryAzureStorageAccountId = value; }

        /// <summary>Creates an new <see cref="A2AvmDiskInputDetails" /> instance.</summary>
        public A2AvmDiskInputDetails()
        {

        }
    }
    /// Azure VM disk input details.
    public partial interface IA2AvmDiskInputDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The disk Uri.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk Uri.",
        SerializedName = @"diskUri",
        PossibleTypes = new [] { typeof(string) })]
        string DiskUri { get; set; }
        /// <summary>The primary staging storage account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The primary staging storage account Id.",
        SerializedName = @"primaryStagingAzureStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryStagingAzureStorageAccountId { get; set; }
        /// <summary>The recovery VHD storage account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery VHD storage account Id.",
        SerializedName = @"recoveryAzureStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryAzureStorageAccountId { get; set; }

    }
    /// Azure VM disk input details.
    internal partial interface IA2AvmDiskInputDetailsInternal

    {
        /// <summary>The disk Uri.</summary>
        string DiskUri { get; set; }
        /// <summary>The primary staging storage account Id.</summary>
        string PrimaryStagingAzureStorageAccountId { get; set; }
        /// <summary>The recovery VHD storage account Id.</summary>
        string RecoveryAzureStorageAccountId { get; set; }

    }
}