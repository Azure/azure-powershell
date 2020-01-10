namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Storage location provided for troubleshoot.</summary>
    public partial class TroubleshootingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="StorageId" /> property.</summary>
        private string _storageId;

        /// <summary>The ID for the storage account to save the troubleshoot result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StorageId { get => this._storageId; set => this._storageId = value; }

        /// <summary>Backing field for <see cref="StoragePath" /> property.</summary>
        private string _storagePath;

        /// <summary>The path to the blob to save the troubleshoot result in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StoragePath { get => this._storagePath; set => this._storagePath = value; }

        /// <summary>Creates an new <see cref="TroubleshootingProperties" /> instance.</summary>
        public TroubleshootingProperties()
        {

        }
    }
    /// Storage location provided for troubleshoot.
    public partial interface ITroubleshootingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The ID for the storage account to save the troubleshoot result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID for the storage account to save the troubleshoot result.",
        SerializedName = @"storageId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageId { get; set; }
        /// <summary>The path to the blob to save the troubleshoot result in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The path to the blob to save the troubleshoot result in.",
        SerializedName = @"storagePath",
        PossibleTypes = new [] { typeof(string) })]
        string StoragePath { get; set; }

    }
    /// Storage location provided for troubleshoot.
    internal partial interface ITroubleshootingPropertiesInternal

    {
        /// <summary>The ID for the storage account to save the troubleshoot result.</summary>
        string StorageId { get; set; }
        /// <summary>The path to the blob to save the troubleshoot result in.</summary>
        string StoragePath { get; set; }

    }
}