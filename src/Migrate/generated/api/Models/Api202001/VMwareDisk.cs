namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Second level object returned as part of Machine REST resource.</summary>
    public partial class VMwareDisk :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal
    {

        /// <summary>Backing field for <see cref="DiskMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode? _diskMode;

        /// <summary>Disk mode property used for identifying independent disks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode? DiskMode { get => this._diskMode; }

        /// <summary>Backing field for <see cref="DiskProvisioningPolicy" /> property.</summary>
        private string _diskProvisioningPolicy;

        /// <summary>
        /// The provisioning policy of the disk. It is Thin or Thick or Unknown for the VMWare.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskProvisioningPolicy { get => this._diskProvisioningPolicy; }

        /// <summary>Backing field for <see cref="DiskScrubbingPolicy" /> property.</summary>
        private string _diskScrubbingPolicy;

        /// <summary>The scrubbing policy of disks which can be eagerly zeroed or lazily zeroed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskScrubbingPolicy { get => this._diskScrubbingPolicy; }

        /// <summary>Backing field for <see cref="DiskType" /> property.</summary>
        private string _diskType;

        /// <summary>Type of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskType { get => this._diskType; }

        /// <summary>Backing field for <see cref="Label" /> property.</summary>
        private string _label;

        /// <summary>Label of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Label { get => this._label; }

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

        /// <summary>Internal Acessors for DiskMode</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.DiskMode { get => this._diskMode; set { {_diskMode = value;} } }

        /// <summary>Internal Acessors for DiskProvisioningPolicy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.DiskProvisioningPolicy { get => this._diskProvisioningPolicy; set { {_diskProvisioningPolicy = value;} } }

        /// <summary>Internal Acessors for DiskScrubbingPolicy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.DiskScrubbingPolicy { get => this._diskScrubbingPolicy; set { {_diskScrubbingPolicy = value;} } }

        /// <summary>Internal Acessors for DiskType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.DiskType { get => this._diskType; set { {_diskType = value;} } }

        /// <summary>Internal Acessors for Label</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.Label { get => this._label; set { {_label = value;} } }

        /// <summary>Internal Acessors for Lun</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.Lun { get => this._lun; set { {_lun = value;} } }

        /// <summary>Internal Acessors for MaxSizeInByte</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.MaxSizeInByte { get => this._maxSizeInByte; set { {_maxSizeInByte = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Path</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.Path { get => this._path; set { {_path = value;} } }

        /// <summary>Internal Acessors for Uuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal.Uuid { get => this._uuid; set { {_uuid = value;} } }

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

        /// <summary>Backing field for <see cref="Uuid" /> property.</summary>
        private string _uuid;

        /// <summary>Disk UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Uuid { get => this._uuid; }

        /// <summary>Creates an new <see cref="VMwareDisk" /> instance.</summary>
        public VMwareDisk()
        {

        }
    }
    /// Second level object returned as part of Machine REST resource.
    public partial interface IVMwareDisk :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Disk mode property used for identifying independent disks.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Disk mode property used for identifying independent disks.",
        SerializedName = @"diskMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode? DiskMode { get;  }
        /// <summary>
        /// The provisioning policy of the disk. It is Thin or Thick or Unknown for the VMWare.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning policy of the disk. It is Thin or Thick or Unknown for the VMWare.",
        SerializedName = @"diskProvisioningPolicy",
        PossibleTypes = new [] { typeof(string) })]
        string DiskProvisioningPolicy { get;  }
        /// <summary>The scrubbing policy of disks which can be eagerly zeroed or lazily zeroed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The scrubbing policy of disks which can be eagerly zeroed or lazily zeroed.",
        SerializedName = @"diskScrubbingPolicy",
        PossibleTypes = new [] { typeof(string) })]
        string DiskScrubbingPolicy { get;  }
        /// <summary>Type of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of the disk.",
        SerializedName = @"diskType",
        PossibleTypes = new [] { typeof(string) })]
        string DiskType { get;  }
        /// <summary>Label of the disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Label of the disk.",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get;  }
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
        /// <summary>Disk UUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Disk UUID.",
        SerializedName = @"uuid",
        PossibleTypes = new [] { typeof(string) })]
        string Uuid { get;  }

    }
    /// Second level object returned as part of Machine REST resource.
    internal partial interface IVMwareDiskInternal

    {
        /// <summary>Disk mode property used for identifying independent disks.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode? DiskMode { get; set; }
        /// <summary>
        /// The provisioning policy of the disk. It is Thin or Thick or Unknown for the VMWare.
        /// </summary>
        string DiskProvisioningPolicy { get; set; }
        /// <summary>The scrubbing policy of disks which can be eagerly zeroed or lazily zeroed.</summary>
        string DiskScrubbingPolicy { get; set; }
        /// <summary>Type of the disk.</summary>
        string DiskType { get; set; }
        /// <summary>Label of the disk.</summary>
        string Label { get; set; }
        /// <summary>LUN of the disk.</summary>
        int? Lun { get; set; }
        /// <summary>Bytes allocated for the disk.</summary>
        long? MaxSizeInByte { get; set; }
        /// <summary>Name of the disk.</summary>
        string Name { get; set; }
        /// <summary>Path of the disk.</summary>
        string Path { get; set; }
        /// <summary>Disk UUID.</summary>
        string Uuid { get; set; }

    }
}