namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Target copy settings</summary>
    public partial class TargetCopySetting :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySetting,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal
    {

        /// <summary>Backing field for <see cref="CopyAfter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOption _copyAfter;

        /// <summary>It can be CustomCopyOption or ImmediateCopyOption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOption CopyAfter { get => (this._copyAfter = this._copyAfter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.CopyOption()); set => this._copyAfter = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string CopyAfterObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOptionInternal)CopyAfter).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOptionInternal)CopyAfter).ObjectType = value; }

        /// <summary>Backing field for <see cref="DataStore" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBase _dataStore;

        /// <summary>Info of target datastore</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBase DataStore { get => (this._dataStore = this._dataStore ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DataStoreInfoBase()); set => this._dataStore = value; }

        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataStoreObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBaseInternal)DataStore).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBaseInternal)DataStore).ObjectType = value; }

        /// <summary>type of datastore; SnapShot/Hot/Archive</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBaseInternal)DataStore).DataStoreType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBaseInternal)DataStore).DataStoreType = value; }

        /// <summary>Internal Acessors for CopyAfter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOption Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal.CopyAfter { get => (this._copyAfter = this._copyAfter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.CopyOption()); set { {_copyAfter = value;} } }

        /// <summary>Internal Acessors for DataStore</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBase Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ITargetCopySettingInternal.DataStore { get => (this._dataStore = this._dataStore ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.DataStoreInfoBase()); set { {_dataStore = value;} } }

        /// <summary>Creates an new <see cref="TargetCopySetting" /> instance.</summary>
        public TargetCopySetting()
        {

        }
    }
    /// Target copy settings
    public partial interface ITargetCopySetting :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of the specific object - used for deserializing",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string CopyAfterObjectType { get; set; }
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of Datasource object, used to initialize the right inherited type",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string DataStoreObjectType { get; set; }
        /// <summary>type of datastore; SnapShot/Hot/Archive</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"type of datastore; SnapShot/Hot/Archive",
        SerializedName = @"dataStoreType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get; set; }

    }
    /// Target copy settings
    internal partial interface ITargetCopySettingInternal

    {
        /// <summary>It can be CustomCopyOption or ImmediateCopyOption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.ICopyOption CopyAfter { get; set; }
        /// <summary>Type of the specific object - used for deserializing</summary>
        string CopyAfterObjectType { get; set; }
        /// <summary>Info of target datastore</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDataStoreInfoBase DataStore { get; set; }
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        string DataStoreObjectType { get; set; }
        /// <summary>type of datastore; SnapShot/Hot/Archive</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get; set; }

    }
}