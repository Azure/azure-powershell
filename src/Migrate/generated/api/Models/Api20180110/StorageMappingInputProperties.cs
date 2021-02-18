namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Storage mapping input properties.</summary>
    public partial class StorageMappingInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageMappingInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="TargetStorageClassificationId" /> property.</summary>
        private string _targetStorageClassificationId;

        /// <summary>The ID of the storage object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetStorageClassificationId { get => this._targetStorageClassificationId; set => this._targetStorageClassificationId = value; }

        /// <summary>Creates an new <see cref="StorageMappingInputProperties" /> instance.</summary>
        public StorageMappingInputProperties()
        {

        }
    }
    /// Storage mapping input properties.
    public partial interface IStorageMappingInputProperties :
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
    /// Storage mapping input properties.
    internal partial interface IStorageMappingInputPropertiesInternal

    {
        /// <summary>The ID of the storage object.</summary>
        string TargetStorageClassificationId { get; set; }

    }
}