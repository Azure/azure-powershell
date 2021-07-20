namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile for the container service master.</summary>
    public partial class ContainerServiceMasterProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal
    {

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>
        /// Number of masters (VMs) in the container service cluster. Allowed values are 1, 3, and 5. The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? Count { get => this._count; set => this._count = value; }

        /// <summary>Backing field for <see cref="DnsPrefix" /> property.</summary>
        private string _dnsPrefix;

        /// <summary>DNS prefix to be used to create the FQDN for the master pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string DnsPrefix { get => this._dnsPrefix; set => this._dnsPrefix = value; }

        /// <summary>Backing field for <see cref="FirstConsecutiveStaticIP" /> property.</summary>
        private string _firstConsecutiveStaticIP;

        /// <summary>FirstConsecutiveStaticIP used to specify the first static ip of masters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string FirstConsecutiveStaticIP { get => this._firstConsecutiveStaticIP; set => this._firstConsecutiveStaticIP = value; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>FQDN for the master pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; }

        /// <summary>Internal Acessors for Fqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal.Fqdn { get => this._fqdn; set { {_fqdn = value;} } }

        /// <summary>Backing field for <see cref="OSDiskSizeGb" /> property.</summary>
        private int? _oSDiskSizeGb;

        /// <summary>
        /// OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0,
        /// it will apply the default osDisk size according to the vmSize specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? OSDiskSizeGb { get => this._oSDiskSizeGb; set => this._oSDiskSizeGb = value; }

        /// <summary>Backing field for <see cref="StorageProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes? _storageProfile;

        /// <summary>
        /// Storage profile specifies what kind of storage used. Choose from StorageAccount and ManagedDisks. Leave it empty, we will
        /// choose for you based on the orchestrator choice.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes? StorageProfile { get => this._storageProfile; set => this._storageProfile = value; }

        /// <summary>Backing field for <see cref="VMSize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes _vMSize;

        /// <summary>Size of agent VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes VMSize { get => this._vMSize; set => this._vMSize = value; }

        /// <summary>Backing field for <see cref="VnetSubnetId" /> property.</summary>
        private string _vnetSubnetId;

        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string VnetSubnetId { get => this._vnetSubnetId; set => this._vnetSubnetId = value; }

        /// <summary>Creates an new <see cref="ContainerServiceMasterProfile" /> instance.</summary>
        public ContainerServiceMasterProfile()
        {

        }
    }
    /// Profile for the container service master.
    public partial interface IContainerServiceMasterProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Number of masters (VMs) in the container service cluster. Allowed values are 1, 3, and 5. The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of masters (VMs) in the container service cluster. Allowed values are 1, 3, and 5. The default value is 1.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get; set; }
        /// <summary>DNS prefix to be used to create the FQDN for the master pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"DNS prefix to be used to create the FQDN for the master pool.",
        SerializedName = @"dnsPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string DnsPrefix { get; set; }
        /// <summary>FirstConsecutiveStaticIP used to specify the first static ip of masters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"FirstConsecutiveStaticIP used to specify the first static ip of masters.",
        SerializedName = @"firstConsecutiveStaticIP",
        PossibleTypes = new [] { typeof(string) })]
        string FirstConsecutiveStaticIP { get; set; }
        /// <summary>FQDN for the master pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"FQDN for the master pool.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get;  }
        /// <summary>
        /// OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0,
        /// it will apply the default osDisk size according to the vmSize specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0, it will apply the default osDisk size according to the vmSize specified.",
        SerializedName = @"osDiskSizeGB",
        PossibleTypes = new [] { typeof(int) })]
        int? OSDiskSizeGb { get; set; }
        /// <summary>
        /// Storage profile specifies what kind of storage used. Choose from StorageAccount and ManagedDisks. Leave it empty, we will
        /// choose for you based on the orchestrator choice.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Storage profile specifies what kind of storage used. Choose from StorageAccount and ManagedDisks. Leave it empty, we will choose for you based on the orchestrator choice.",
        SerializedName = @"storageProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes? StorageProfile { get; set; }
        /// <summary>Size of agent VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Size of agent VMs.",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes VMSize { get; set; }
        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VNet SubnetID specifies the VNet's subnet identifier.",
        SerializedName = @"vnetSubnetID",
        PossibleTypes = new [] { typeof(string) })]
        string VnetSubnetId { get; set; }

    }
    /// Profile for the container service master.
    internal partial interface IContainerServiceMasterProfileInternal

    {
        /// <summary>
        /// Number of masters (VMs) in the container service cluster. Allowed values are 1, 3, and 5. The default value is 1.
        /// </summary>
        int? Count { get; set; }
        /// <summary>DNS prefix to be used to create the FQDN for the master pool.</summary>
        string DnsPrefix { get; set; }
        /// <summary>FirstConsecutiveStaticIP used to specify the first static ip of masters.</summary>
        string FirstConsecutiveStaticIP { get; set; }
        /// <summary>FQDN for the master pool.</summary>
        string Fqdn { get; set; }
        /// <summary>
        /// OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0,
        /// it will apply the default osDisk size according to the vmSize specified.
        /// </summary>
        int? OSDiskSizeGb { get; set; }
        /// <summary>
        /// Storage profile specifies what kind of storage used. Choose from StorageAccount and ManagedDisks. Leave it empty, we will
        /// choose for you based on the orchestrator choice.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes? StorageProfile { get; set; }
        /// <summary>Size of agent VMs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes VMSize { get; set; }
        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        string VnetSubnetId { get; set; }

    }
}