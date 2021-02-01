namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Storage mapping input.</summary>
    public partial class StorageClassificationMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMappingInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMappingInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMappingInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.StorageMappingInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputProperties _property;

        /// <summary>Storage mapping input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.StorageMappingInputProperties()); set => this._property = value; }

        /// <summary>The ID of the storage object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TargetStorageClassificationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputPropertiesInternal)Property).TargetStorageClassificationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputPropertiesInternal)Property).TargetStorageClassificationId = value ?? null; }

        /// <summary>Creates an new <see cref="StorageClassificationMappingInput" /> instance.</summary>
        public StorageClassificationMappingInput()
        {

        }
    }
    /// Storage mapping input.
    public partial interface IStorageClassificationMappingInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The ID of the storage object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the storage object.",
        SerializedName = @"targetStorageClassificationId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetStorageClassificationId { get; set; }

    }
    /// Storage mapping input.
    internal partial interface IStorageClassificationMappingInputInternal

    {
        /// <summary>Storage mapping input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputProperties Property { get; set; }
        /// <summary>The ID of the storage object.</summary>
        string TargetStorageClassificationId { get; set; }

    }
}