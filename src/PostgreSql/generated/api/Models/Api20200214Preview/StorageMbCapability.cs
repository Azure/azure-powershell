namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>storage size in MB capability</summary>
    public partial class StorageMbCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageMbCapability,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageMbCapabilityInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageMbCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for StorageSizeMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageMbCapabilityInternal.StorageSizeMb { get => this._storageSizeMb; set { {_storageSizeMb = value;} } }

        /// <summary>Internal Acessors for SupportedIop</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageMbCapabilityInternal.SupportedIop { get => this._supportedIop; set { {_supportedIop = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>storage MB name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="StorageSizeMb" /> property.</summary>
        private long? _storageSizeMb;

        /// <summary>storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public long? StorageSizeMb { get => this._storageSizeMb; }

        /// <summary>Backing field for <see cref="SupportedIop" /> property.</summary>
        private long? _supportedIop;

        /// <summary>supported IOPS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public long? SupportedIop { get => this._supportedIop; }

        /// <summary>Creates an new <see cref="StorageMbCapability" /> instance.</summary>
        public StorageMbCapability()
        {

        }
    }
    /// storage size in MB capability
    public partial interface IStorageMbCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>storage MB name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"storage MB name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"storage size in MB",
        SerializedName = @"storageSizeMB",
        PossibleTypes = new [] { typeof(long) })]
        long? StorageSizeMb { get;  }
        /// <summary>supported IOPS</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"supported IOPS",
        SerializedName = @"supportedIops",
        PossibleTypes = new [] { typeof(long) })]
        long? SupportedIop { get;  }

    }
    /// storage size in MB capability
    internal partial interface IStorageMbCapabilityInternal

    {
        /// <summary>storage MB name</summary>
        string Name { get; set; }
        /// <summary>storage size in MB</summary>
        long? StorageSizeMb { get; set; }
        /// <summary>supported IOPS</summary>
        long? SupportedIop { get; set; }

    }
}