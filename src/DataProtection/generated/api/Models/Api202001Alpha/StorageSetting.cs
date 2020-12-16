namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Storage setting</summary>
    public partial class StorageSetting :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IStorageSetting,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IStorageSettingInternal
    {

        /// <summary>Backing field for <see cref="DataStoreType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes? _dataStoreType;

        /// <summary>Gets or sets the type of the datastore.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes? DataStoreType { get => this._dataStoreType; set => this._dataStoreType = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.StorageSettingTypes? _type;

        /// <summary>Gets or sets the type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.StorageSettingTypes? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="StorageSetting" /> instance.</summary>
        public StorageSetting()
        {

        }
    }
    /// Storage setting
    public partial interface IStorageSetting :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the type of the datastore.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the type of the datastore.",
        SerializedName = @"dataStoreType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes? DataStoreType { get; set; }
        /// <summary>Gets or sets the type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.StorageSettingTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.StorageSettingTypes? Type { get; set; }

    }
    /// Storage setting
    internal partial interface IStorageSettingInternal

    {
        /// <summary>Gets or sets the type of the datastore.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes? DataStoreType { get; set; }
        /// <summary>Gets or sets the type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.StorageSettingTypes? Type { get; set; }

    }
}