namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Target copy settings</summary>
    public partial class TargetCopySetting :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetCopySetting,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetCopySettingInternal
    {

        /// <summary>Backing field for <see cref="CopyAfter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOption _copyAfter;

        /// <summary>It can be CustomCopyOption or ImmediateCopyOption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOption CopyAfter { get => (this._copyAfter = this._copyAfter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.CopyOption()); set => this._copyAfter = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string CopyAfterObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOptionInternal)CopyAfter).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOptionInternal)CopyAfter).ObjectType = value ; }

        /// <summary>Backing field for <see cref="DataStore" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase _dataStore;

        /// <summary>Info of target datastore</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase DataStore { get => (this._dataStore = this._dataStore ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DataStoreInfoBase()); set => this._dataStore = value; }

        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DataStoreObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).ObjectType = value ; }

        /// <summary>type of datastore; Operational/Vault/Archive</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).DataStoreType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBaseInternal)DataStore).DataStoreType = value ; }

        /// <summary>Internal Acessors for CopyAfter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOption Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetCopySettingInternal.CopyAfter { get => (this._copyAfter = this._copyAfter ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.CopyOption()); set { {_copyAfter = value;} } }

        /// <summary>Internal Acessors for DataStore</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ITargetCopySettingInternal.DataStore { get => (this._dataStore = this._dataStore ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DataStoreInfoBase()); set { {_dataStore = value;} } }

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
        /// <summary>type of datastore; Operational/Vault/Archive</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"type of datastore; Operational/Vault/Archive",
        SerializedName = @"dataStoreType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get; set; }

    }
    /// Target copy settings
    internal partial interface ITargetCopySettingInternal

    {
        /// <summary>It can be CustomCopyOption or ImmediateCopyOption.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOption CopyAfter { get; set; }
        /// <summary>Type of the specific object - used for deserializing</summary>
        string CopyAfterObjectType { get; set; }
        /// <summary>Info of target datastore</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreInfoBase DataStore { get; set; }
        /// <summary>Type of Datasource object, used to initialize the right inherited type</summary>
        string DataStoreObjectType { get; set; }
        /// <summary>type of datastore; Operational/Vault/Archive</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DataStoreTypes DataStoreType { get; set; }

    }
}