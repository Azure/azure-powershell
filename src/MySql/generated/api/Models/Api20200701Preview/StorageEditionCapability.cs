namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>storage edition capability</summary>
    public partial class StorageEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal
    {

        /// <summary>Backing field for <see cref="MaxBackupRetentionDay" /> property.</summary>
        private long? _maxBackupRetentionDay;

        /// <summary>Maximum backup retention days</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public long? MaxBackupRetentionDay { get => this._maxBackupRetentionDay; }

        /// <summary>Backing field for <see cref="MaxStorageSize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability _maxStorageSize;

        /// <summary>The maximum supported storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability MaxStorageSize { get => (this._maxStorageSize = this._maxStorageSize ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapability()); }

        /// <summary>storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public long? MaxStorageSizeMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MaxStorageSize).StorageSizeMb; }

        /// <summary>storage MB name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string MaxStorageSizeName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MaxStorageSize).Name; }

        /// <summary>Internal Acessors for MaxBackupRetentionDay</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MaxBackupRetentionDay { get => this._maxBackupRetentionDay; set { {_maxBackupRetentionDay = value;} } }

        /// <summary>Internal Acessors for MaxStorageSize</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MaxStorageSize { get => (this._maxStorageSize = this._maxStorageSize ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapability()); set { {_maxStorageSize = value;} } }

        /// <summary>Internal Acessors for MaxStorageSizeMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MaxStorageSizeMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MaxStorageSize).StorageSizeMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MaxStorageSize).StorageSizeMb = value; }

        /// <summary>Internal Acessors for MaxStorageSizeName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MaxStorageSizeName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MaxStorageSize).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MaxStorageSize).Name = value; }

        /// <summary>Internal Acessors for MinBackupRetentionDay</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MinBackupRetentionDay { get => this._minBackupRetentionDay; set { {_minBackupRetentionDay = value;} } }

        /// <summary>Internal Acessors for MinStorageSize</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MinStorageSize { get => (this._minStorageSize = this._minStorageSize ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapability()); set { {_minStorageSize = value;} } }

        /// <summary>Internal Acessors for MinStorageSizeMb</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MinStorageSizeMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MinStorageSize).StorageSizeMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MinStorageSize).StorageSizeMb = value; }

        /// <summary>Internal Acessors for MinStorageSizeName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.MinStorageSizeName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MinStorageSize).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MinStorageSize).Name = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="MinBackupRetentionDay" /> property.</summary>
        private long? _minBackupRetentionDay;

        /// <summary>Minimal backup retention days</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public long? MinBackupRetentionDay { get => this._minBackupRetentionDay; }

        /// <summary>Backing field for <see cref="MinStorageSize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability _minStorageSize;

        /// <summary>The minimal supported storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability MinStorageSize { get => (this._minStorageSize = this._minStorageSize ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.StorageMbCapability()); }

        /// <summary>storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public long? MinStorageSizeMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MinStorageSize).StorageSizeMb; }

        /// <summary>storage MB name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Inlined)]
        public string MinStorageSizeName { get => ((Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapabilityInternal)MinStorageSize).Name; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>storage edition name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Creates an new <see cref="StorageEditionCapability" /> instance.</summary>
        public StorageEditionCapability()
        {

        }
    }
    /// storage edition capability
    public partial interface IStorageEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>Maximum backup retention days</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Maximum backup retention days",
        SerializedName = @"maxBackupRetentionDays",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxBackupRetentionDay { get;  }
        /// <summary>storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"storage size in MB",
        SerializedName = @"storageSizeMB",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxStorageSizeMb { get;  }
        /// <summary>storage MB name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"storage MB name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string MaxStorageSizeName { get;  }
        /// <summary>Minimal backup retention days</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Minimal backup retention days",
        SerializedName = @"minBackupRetentionDays",
        PossibleTypes = new [] { typeof(long) })]
        long? MinBackupRetentionDay { get;  }
        /// <summary>storage size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"storage size in MB",
        SerializedName = @"storageSizeMB",
        PossibleTypes = new [] { typeof(long) })]
        long? MinStorageSizeMb { get;  }
        /// <summary>storage MB name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"storage MB name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string MinStorageSizeName { get;  }
        /// <summary>storage edition name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"storage edition name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

    }
    /// storage edition capability
    internal partial interface IStorageEditionCapabilityInternal

    {
        /// <summary>Maximum backup retention days</summary>
        long? MaxBackupRetentionDay { get; set; }
        /// <summary>The maximum supported storage size in MB</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability MaxStorageSize { get; set; }
        /// <summary>storage size in MB</summary>
        long? MaxStorageSizeMb { get; set; }
        /// <summary>storage MB name</summary>
        string MaxStorageSizeName { get; set; }
        /// <summary>Minimal backup retention days</summary>
        long? MinBackupRetentionDay { get; set; }
        /// <summary>The minimal supported storage size in MB</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageMbCapability MinStorageSize { get; set; }
        /// <summary>storage size in MB</summary>
        long? MinStorageSizeMb { get; set; }
        /// <summary>storage MB name</summary>
        string MinStorageSizeName { get; set; }
        /// <summary>storage edition name</summary>
        string Name { get; set; }

    }
}