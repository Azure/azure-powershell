namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Storage mapping properties.</summary>
    public partial class StorageClassificationMappingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMappingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMappingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="TargetStorageClassificationId" /> property.</summary>
        private string _targetStorageClassificationId;

        /// <summary>Target storage object Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetStorageClassificationId { get => this._targetStorageClassificationId; set => this._targetStorageClassificationId = value; }

        /// <summary>Creates an new <see cref="StorageClassificationMappingProperties" /> instance.</summary>
        public StorageClassificationMappingProperties()
        {

        }
    }
    /// Storage mapping properties.
    public partial interface IStorageClassificationMappingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Target storage object Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target storage object Id.",
        SerializedName = @"targetStorageClassificationId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetStorageClassificationId { get; set; }

    }
    /// Storage mapping properties.
    internal partial interface IStorageClassificationMappingPropertiesInternal

    {
        /// <summary>Target storage object Id.</summary>
        string TargetStorageClassificationId { get; set; }

    }
}