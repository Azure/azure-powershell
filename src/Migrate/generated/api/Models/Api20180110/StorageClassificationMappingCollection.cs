namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of storage mapping details.</summary>
    public partial class StorageClassificationMappingCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMappingCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMappingCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMapping[] _value;

        /// <summary>The storage details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMapping[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="StorageClassificationMappingCollection" /> instance.</summary>
        public StorageClassificationMappingCollection()
        {

        }
    }
    /// Collection of storage mapping details.
    public partial interface IStorageClassificationMappingCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The storage details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The storage details.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMapping[] Value { get; set; }

    }
    /// Collection of storage mapping details.
    internal partial interface IStorageClassificationMappingCollectionInternal

    {
        /// <summary>The value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>The storage details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationMapping[] Value { get; set; }

    }
}