namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMwareCbt protected disk details.</summary>
    public partial class VMwareCbtProtectedDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal
    {

        /// <summary>Backing field for <see cref="CapacityInByte" /> property.</summary>
        private long? _capacityInByte;

        /// <summary>The disk capacity in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public long? CapacityInByte { get => this._capacityInByte; }

        /// <summary>Backing field for <see cref="DiskEncryptionSetId" /> property.</summary>
        private string _diskEncryptionSetId;

        /// <summary>The DiskEncryptionSet ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskEncryptionSetId { get => this._diskEncryptionSetId; }

        /// <summary>Backing field for <see cref="DiskId" /> property.</summary>
        private string _diskId;

        /// <summary>The disk id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskId { get => this._diskId; }

        /// <summary>Backing field for <see cref="DiskName" /> property.</summary>
        private string _diskName;

        /// <summary>The disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskName { get => this._diskName; }

        /// <summary>Backing field for <see cref="DiskPath" /> property.</summary>
        private string _diskPath;

        /// <summary>The disk path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DiskPath { get => this._diskPath; }

        /// <summary>Backing field for <see cref="DiskType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType? _diskType;

        /// <summary>The disk type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType? DiskType { get => this._diskType; set => this._diskType = value; }

        /// <summary>Backing field for <see cref="IsOSDisk" /> property.</summary>
        private string _isOSDisk;

        /// <summary>A value indicating whether the disk is the OS disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IsOSDisk { get => this._isOSDisk; }

        /// <summary>Backing field for <see cref="LogStorageAccountId" /> property.</summary>
        private string _logStorageAccountId;

        /// <summary>The log storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LogStorageAccountId { get => this._logStorageAccountId; }

        /// <summary>Backing field for <see cref="LogStorageAccountSasSecretName" /> property.</summary>
        private string _logStorageAccountSasSecretName;

        /// <summary>The key vault secret name of the log storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LogStorageAccountSasSecretName { get => this._logStorageAccountSasSecretName; }

        /// <summary>Internal Acessors for CapacityInByte</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.CapacityInByte { get => this._capacityInByte; set { {_capacityInByte = value;} } }

        /// <summary>Internal Acessors for DiskEncryptionSetId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.DiskEncryptionSetId { get => this._diskEncryptionSetId; set { {_diskEncryptionSetId = value;} } }

        /// <summary>Internal Acessors for DiskId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.DiskId { get => this._diskId; set { {_diskId = value;} } }

        /// <summary>Internal Acessors for DiskName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.DiskName { get => this._diskName; set { {_diskName = value;} } }

        /// <summary>Internal Acessors for DiskPath</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.DiskPath { get => this._diskPath; set { {_diskPath = value;} } }

        /// <summary>Internal Acessors for IsOSDisk</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.IsOSDisk { get => this._isOSDisk; set { {_isOSDisk = value;} } }

        /// <summary>Internal Acessors for LogStorageAccountId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.LogStorageAccountId { get => this._logStorageAccountId; set { {_logStorageAccountId = value;} } }

        /// <summary>Internal Acessors for LogStorageAccountSasSecretName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.LogStorageAccountSasSecretName { get => this._logStorageAccountSasSecretName; set { {_logStorageAccountSasSecretName = value;} } }

        /// <summary>Internal Acessors for SeedManagedDiskId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.SeedManagedDiskId { get => this._seedManagedDiskId; set { {_seedManagedDiskId = value;} } }

        /// <summary>Internal Acessors for TargetManagedDiskId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareCbtProtectedDiskDetailsInternal.TargetManagedDiskId { get => this._targetManagedDiskId; set { {_targetManagedDiskId = value;} } }

        /// <summary>Backing field for <see cref="SeedManagedDiskId" /> property.</summary>
        private string _seedManagedDiskId;

        /// <summary>The ARM Id of the seed managed disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SeedManagedDiskId { get => this._seedManagedDiskId; }

        /// <summary>Backing field for <see cref="TargetManagedDiskId" /> property.</summary>
        private string _targetManagedDiskId;

        /// <summary>The ARM Id of the target managed disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetManagedDiskId { get => this._targetManagedDiskId; }

        /// <summary>Creates an new <see cref="VMwareCbtProtectedDiskDetails" /> instance.</summary>
        public VMwareCbtProtectedDiskDetails()
        {

        }
    }
    /// VMwareCbt protected disk details.
    public partial interface IVMwareCbtProtectedDiskDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The disk capacity in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The disk capacity in bytes.",
        SerializedName = @"capacityInBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? CapacityInByte { get;  }
        /// <summary>The DiskEncryptionSet ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The DiskEncryptionSet ARM Id.",
        SerializedName = @"diskEncryptionSetId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskEncryptionSetId { get;  }
        /// <summary>The disk id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The disk id.",
        SerializedName = @"diskId",
        PossibleTypes = new [] { typeof(string) })]
        string DiskId { get;  }
        /// <summary>The disk name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The disk name.",
        SerializedName = @"diskName",
        PossibleTypes = new [] { typeof(string) })]
        string DiskName { get;  }
        /// <summary>The disk path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The disk path.",
        SerializedName = @"diskPath",
        PossibleTypes = new [] { typeof(string) })]
        string DiskPath { get;  }
        /// <summary>The disk type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disk type.",
        SerializedName = @"diskType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType? DiskType { get; set; }
        /// <summary>A value indicating whether the disk is the OS disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A value indicating whether the disk is the OS disk.",
        SerializedName = @"isOSDisk",
        PossibleTypes = new [] { typeof(string) })]
        string IsOSDisk { get;  }
        /// <summary>The log storage account ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The log storage account ARM Id.",
        SerializedName = @"logStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string LogStorageAccountId { get;  }
        /// <summary>The key vault secret name of the log storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The key vault secret name of the log storage account.",
        SerializedName = @"logStorageAccountSasSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string LogStorageAccountSasSecretName { get;  }
        /// <summary>The ARM Id of the seed managed disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ARM Id of the seed managed disk.",
        SerializedName = @"seedManagedDiskId",
        PossibleTypes = new [] { typeof(string) })]
        string SeedManagedDiskId { get;  }
        /// <summary>The ARM Id of the target managed disk.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ARM Id of the target managed disk.",
        SerializedName = @"targetManagedDiskId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetManagedDiskId { get;  }

    }
    /// VMwareCbt protected disk details.
    internal partial interface IVMwareCbtProtectedDiskDetailsInternal

    {
        /// <summary>The disk capacity in bytes.</summary>
        long? CapacityInByte { get; set; }
        /// <summary>The DiskEncryptionSet ARM Id.</summary>
        string DiskEncryptionSetId { get; set; }
        /// <summary>The disk id.</summary>
        string DiskId { get; set; }
        /// <summary>The disk name.</summary>
        string DiskName { get; set; }
        /// <summary>The disk path.</summary>
        string DiskPath { get; set; }
        /// <summary>The disk type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.DiskAccountType? DiskType { get; set; }
        /// <summary>A value indicating whether the disk is the OS disk.</summary>
        string IsOSDisk { get; set; }
        /// <summary>The log storage account ARM Id.</summary>
        string LogStorageAccountId { get; set; }
        /// <summary>The key vault secret name of the log storage account.</summary>
        string LogStorageAccountSasSecretName { get; set; }
        /// <summary>The ARM Id of the seed managed disk.</summary>
        string SeedManagedDiskId { get; set; }
        /// <summary>The ARM Id of the target managed disk.</summary>
        string TargetManagedDiskId { get; set; }

    }
}