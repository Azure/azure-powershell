namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The data store details of the MT.</summary>
    public partial class DataStore :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStore,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDataStoreInternal
    {

        /// <summary>Backing field for <see cref="Capacity" /> property.</summary>
        private string _capacity;

        /// <summary>The capacity of data store in GBs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Capacity { get => this._capacity; set => this._capacity = value; }

        /// <summary>Backing field for <see cref="FreeSpace" /> property.</summary>
        private string _freeSpace;

        /// <summary>The free space of data store in GBs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FreeSpace { get => this._freeSpace; set => this._freeSpace = value; }

        /// <summary>Backing field for <see cref="SymbolicName" /> property.</summary>
        private string _symbolicName;

        /// <summary>The symbolic name of data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SymbolicName { get => this._symbolicName; set => this._symbolicName = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Uuid" /> property.</summary>
        private string _uuid;

        /// <summary>The uuid of data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Uuid { get => this._uuid; set => this._uuid = value; }

        /// <summary>Creates an new <see cref="DataStore" /> instance.</summary>
        public DataStore()
        {

        }
    }
    /// The data store details of the MT.
    public partial interface IDataStore :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The capacity of data store in GBs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The capacity of data store in GBs.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(string) })]
        string Capacity { get; set; }
        /// <summary>The free space of data store in GBs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The free space of data store in GBs.",
        SerializedName = @"freeSpace",
        PossibleTypes = new [] { typeof(string) })]
        string FreeSpace { get; set; }
        /// <summary>The symbolic name of data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The symbolic name of data store.",
        SerializedName = @"symbolicName",
        PossibleTypes = new [] { typeof(string) })]
        string SymbolicName { get; set; }
        /// <summary>The type of data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of data store.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>The uuid of data store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The uuid of data store.",
        SerializedName = @"uuid",
        PossibleTypes = new [] { typeof(string) })]
        string Uuid { get; set; }

    }
    /// The data store details of the MT.
    internal partial interface IDataStoreInternal

    {
        /// <summary>The capacity of data store in GBs.</summary>
        string Capacity { get; set; }
        /// <summary>The free space of data store in GBs.</summary>
        string FreeSpace { get; set; }
        /// <summary>The symbolic name of data store.</summary>
        string SymbolicName { get; set; }
        /// <summary>The type of data store.</summary>
        string Type { get; set; }
        /// <summary>The uuid of data store.</summary>
        string Uuid { get; set; }

    }
}