namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the resource to troubleshoot.</summary>
    public partial class TroubleshootingParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingParametersInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TroubleshootingProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingProperties _property;

        /// <summary>Properties of the troubleshooting resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TroubleshootingProperties()); set => this._property = value; }

        /// <summary>The ID for the storage account to save the troubleshoot result.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingPropertiesInternal)Property).StorageId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingPropertiesInternal)Property).StorageId = value; }

        /// <summary>The path to the blob to save the troubleshoot result in.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StoragePath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingPropertiesInternal)Property).StoragePath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingPropertiesInternal)Property).StoragePath = value; }

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>The target resource to troubleshoot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="TroubleshootingParameters" /> instance.</summary>
        public TroubleshootingParameters()
        {

        }
    }
    /// Parameters that define the resource to troubleshoot.
    public partial interface ITroubleshootingParameters :
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
        /// <summary>The target resource to troubleshoot.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The target resource to troubleshoot.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// Parameters that define the resource to troubleshoot.
    internal partial interface ITroubleshootingParametersInternal

    {
        /// <summary>Properties of the troubleshooting resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITroubleshootingProperties Property { get; set; }
        /// <summary>The ID for the storage account to save the troubleshoot result.</summary>
        string StorageId { get; set; }
        /// <summary>The path to the blob to save the troubleshoot result in.</summary>
        string StoragePath { get; set; }
        /// <summary>The target resource to troubleshoot.</summary>
        string TargetResourceId { get; set; }

    }
}