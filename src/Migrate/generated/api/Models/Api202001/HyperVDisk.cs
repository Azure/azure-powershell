namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Second level object returned as part of Machine REST resource.</summary>
    public partial class HyperVDisk :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal
    {

        /// <summary>Backing field for <see cref="DiskType" /> property.</summary>
        private string _diskType;

        /// <summary>Type of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskType { get => this._diskType; }

        /// <summary>Backing field for <see cref="InstanceId" /> property.</summary>
        private string _instanceId;

        /// <summary>Id of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceId { get => this._instanceId; }

        /// <summary>Backing field for <see cref="Lun" /> property.</summary>
        private int? _lun;

        /// <summary>LUN of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? Lun { get => this._lun; }

        /// <summary>Backing field for <see cref="MaxSizeInByte" /> property.</summary>
        private long? _maxSizeInByte;

        /// <summary>Bytes allocated for the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? MaxSizeInByte { get => this._maxSizeInByte; }

        /// <summary>Internal Acessors for DiskType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal.DiskType { get => this._diskType; set { {_diskType = value;} } }

        /// <summary>Internal Acessors for InstanceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal.InstanceId { get => this._instanceId; set { {_instanceId = value;} } }

        /// <summary>Internal Acessors for Lun</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal.Lun { get => this._lun; set { {_lun = value;} } }

        /// <summary>Internal Acessors for MaxSizeInByte</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal.MaxSizeInByte { get => this._maxSizeInByte; set { {_maxSizeInByte = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Path</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal.Path { get => this._path; set { {_path = value;} } }

        /// <summary>Internal Acessors for VhdId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDiskInternal.VhdId { get => this._vhdId; set { {_vhdId = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>Path of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Path { get => this._path; }

        /// <summary>Backing field for <see cref="VhdId" /> property.</summary>
        private string _vhdId;

        /// <summary>VHD Id of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdId { get => this._vhdId; }

        /// <summary>Creates an new <see cref="HyperVDisk" /> instance.</summary>
        public HyperVDisk()
        {

        }
    }
    /// Second level object returned as part of Machine REST resource.
    public partial interface IHyperVDisk :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Type of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of the disk.",
        SerializedName = @"diskType",
        PossibleTypes = new [] { typeof(string) })]
        string DiskType { get;  }
        /// <summary>Id of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the disk.",
        SerializedName = @"instanceId",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceId { get;  }
        /// <summary>LUN of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"LUN of the disk.",
        SerializedName = @"lun",
        PossibleTypes = new [] { typeof(int) })]
        int? Lun { get;  }
        /// <summary>Bytes allocated for the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Bytes allocated for the disk.",
        SerializedName = @"maxSizeInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? MaxSizeInByte { get;  }
        /// <summary>Name of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the disk.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Path of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Path of the disk.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get;  }
        /// <summary>VHD Id of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"VHD Id of the disk.",
        SerializedName = @"vhdId",
        PossibleTypes = new [] { typeof(string) })]
        string VhdId { get;  }

    }
    /// Second level object returned as part of Machine REST resource.
    internal partial interface IHyperVDiskInternal

    {
        /// <summary>Type of the disk.</summary>
        string DiskType { get; set; }
        /// <summary>Id of the disk.</summary>
        string InstanceId { get; set; }
        /// <summary>LUN of the disk.</summary>
        int? Lun { get; set; }
        /// <summary>Bytes allocated for the disk.</summary>
        long? MaxSizeInByte { get; set; }
        /// <summary>Name of the disk.</summary>
        string Name { get; set; }
        /// <summary>Path of the disk.</summary>
        string Path { get; set; }
        /// <summary>VHD Id of the disk.</summary>
        string VhdId { get; set; }

    }
}