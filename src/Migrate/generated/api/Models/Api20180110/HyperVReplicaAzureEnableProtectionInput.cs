namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Azure specific enable protection input.</summary>
    public partial class HyperVReplicaAzureEnableProtectionInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureEnableProtectionInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput __enableProtectionProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EnableProtectionProviderSpecificInput();

        /// <summary>Backing field for <see cref="DisksToInclude" /> property.</summary>
        private string[] _disksToInclude;

        /// <summary>The list of VHD IDs of disks to be protected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] DisksToInclude { get => this._disksToInclude; set => this._disksToInclude = value; }

        /// <summary>Backing field for <see cref="EnableRdpOnTargetOption" /> property.</summary>
        private string _enableRdpOnTargetOption;

        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnableRdpOnTargetOption { get => this._enableRdpOnTargetOption; set => this._enableRdpOnTargetOption = value; }

        /// <summary>Backing field for <see cref="HvHostVMId" /> property.</summary>
        private string _hvHostVMId;

        /// <summary>The Hyper-V host Vm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HvHostVMId { get => this._hvHostVMId; set => this._hvHostVMId = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)__enableProtectionProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal)__enableProtectionProviderSpecificInput).InstanceType = value; }

        /// <summary>Backing field for <see cref="LogStorageAccountId" /> property.</summary>
        private string _logStorageAccountId;

        /// <summary>The storage account to be used for logging during replication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string LogStorageAccountId { get => this._logStorageAccountId; set => this._logStorageAccountId = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The OS type associated with vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="TargetAzureNetworkId" /> property.</summary>
        private string _targetAzureNetworkId;

        /// <summary>The selected target Azure network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetAzureNetworkId { get => this._targetAzureNetworkId; set => this._targetAzureNetworkId = value; }

        /// <summary>Backing field for <see cref="TargetAzureSubnetId" /> property.</summary>
        private string _targetAzureSubnetId;

        /// <summary>The selected target Azure subnet Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetAzureSubnetId { get => this._targetAzureSubnetId; set => this._targetAzureSubnetId = value; }

        /// <summary>Backing field for <see cref="TargetAzureV1ResourceGroupId" /> property.</summary>
        private string _targetAzureV1ResourceGroupId;

        /// <summary>
        /// The Id of the target resource group (for classic deployment) in which the failover VM is to be created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetAzureV1ResourceGroupId { get => this._targetAzureV1ResourceGroupId; set => this._targetAzureV1ResourceGroupId = value; }

        /// <summary>Backing field for <see cref="TargetAzureV2ResourceGroupId" /> property.</summary>
        private string _targetAzureV2ResourceGroupId;

        /// <summary>
        /// The Id of the target resource group (for resource manager deployment) in which the failover VM is to be created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetAzureV2ResourceGroupId { get => this._targetAzureV2ResourceGroupId; set => this._targetAzureV2ResourceGroupId = value; }

        /// <summary>Backing field for <see cref="TargetAzureVMName" /> property.</summary>
        private string _targetAzureVMName;

        /// <summary>The target azure Vm Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetAzureVMName { get => this._targetAzureVMName; set => this._targetAzureVMName = value; }

        /// <summary>Backing field for <see cref="TargetStorageAccountId" /> property.</summary>
        private string _targetStorageAccountId;

        /// <summary>The storage account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetStorageAccountId { get => this._targetStorageAccountId; set => this._targetStorageAccountId = value; }

        /// <summary>Backing field for <see cref="UseManagedDisk" /> property.</summary>
        private string _useManagedDisk;

        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UseManagedDisk { get => this._useManagedDisk; set => this._useManagedDisk = value; }

        /// <summary>Backing field for <see cref="VMName" /> property.</summary>
        private string _vMName;

        /// <summary>The Vm Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMName { get => this._vMName; set => this._vMName = value; }

        /// <summary>Backing field for <see cref="VhdId" /> property.</summary>
        private string _vhdId;

        /// <summary>The OS disk VHD id associated with vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VhdId { get => this._vhdId; set => this._vhdId = value; }

        /// <summary>Creates an new <see cref="HyperVReplicaAzureEnableProtectionInput" /> instance.</summary>
        public HyperVReplicaAzureEnableProtectionInput()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__enableProtectionProviderSpecificInput), __enableProtectionProviderSpecificInput);
            await eventListener.AssertObjectIsValid(nameof(__enableProtectionProviderSpecificInput), __enableProtectionProviderSpecificInput);
        }
    }
    /// Azure specific enable protection input.
    public partial interface IHyperVReplicaAzureEnableProtectionInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInput
    {
        /// <summary>The list of VHD IDs of disks to be protected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of VHD IDs of disks to be protected.",
        SerializedName = @"disksToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] DisksToInclude { get; set; }
        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption} enum.",
        SerializedName = @"enableRdpOnTargetOption",
        PossibleTypes = new [] { typeof(string) })]
        string EnableRdpOnTargetOption { get; set; }
        /// <summary>The Hyper-V host Vm Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Hyper-V host Vm Id.",
        SerializedName = @"hvHostVmId",
        PossibleTypes = new [] { typeof(string) })]
        string HvHostVMId { get; set; }
        /// <summary>The storage account to be used for logging during replication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The storage account to be used for logging during replication.",
        SerializedName = @"logStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string LogStorageAccountId { get; set; }
        /// <summary>The OS type associated with vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS type associated with vm.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }
        /// <summary>The selected target Azure network Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected target Azure network Id.",
        SerializedName = @"targetAzureNetworkId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetAzureNetworkId { get; set; }
        /// <summary>The selected target Azure subnet Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The selected target Azure subnet Id.",
        SerializedName = @"targetAzureSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetAzureSubnetId { get; set; }
        /// <summary>
        /// The Id of the target resource group (for classic deployment) in which the failover VM is to be created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the target resource group (for classic deployment) in which the failover VM is to be created.",
        SerializedName = @"targetAzureV1ResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetAzureV1ResourceGroupId { get; set; }
        /// <summary>
        /// The Id of the target resource group (for resource manager deployment) in which the failover VM is to be created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the target resource group (for resource manager deployment) in which the failover VM is to be created.",
        SerializedName = @"targetAzureV2ResourceGroupId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetAzureV2ResourceGroupId { get; set; }
        /// <summary>The target azure Vm Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target azure Vm Name.",
        SerializedName = @"targetAzureVmName",
        PossibleTypes = new [] { typeof(string) })]
        string TargetAzureVMName { get; set; }
        /// <summary>The storage account name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The storage account name.",
        SerializedName = @"targetStorageAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetStorageAccountId { get; set; }
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether managed disks should be used during failover.",
        SerializedName = @"useManagedDisks",
        PossibleTypes = new [] { typeof(string) })]
        string UseManagedDisk { get; set; }
        /// <summary>The Vm Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Vm Name.",
        SerializedName = @"vmName",
        PossibleTypes = new [] { typeof(string) })]
        string VMName { get; set; }
        /// <summary>The OS disk VHD id associated with vm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS disk VHD id associated with vm.",
        SerializedName = @"vhdId",
        PossibleTypes = new [] { typeof(string) })]
        string VhdId { get; set; }

    }
    /// Azure specific enable protection input.
    internal partial interface IHyperVReplicaAzureEnableProtectionInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEnableProtectionProviderSpecificInputInternal
    {
        /// <summary>The list of VHD IDs of disks to be protected.</summary>
        string[] DisksToInclude { get; set; }
        /// <summary>
        /// The selected option to enable RDP\SSH on target vm after failover. String value of {SrsDataContract.EnableRDPOnTargetOption}
        /// enum.
        /// </summary>
        string EnableRdpOnTargetOption { get; set; }
        /// <summary>The Hyper-V host Vm Id.</summary>
        string HvHostVMId { get; set; }
        /// <summary>The storage account to be used for logging during replication.</summary>
        string LogStorageAccountId { get; set; }
        /// <summary>The OS type associated with vm.</summary>
        string OSType { get; set; }
        /// <summary>The selected target Azure network Id.</summary>
        string TargetAzureNetworkId { get; set; }
        /// <summary>The selected target Azure subnet Id.</summary>
        string TargetAzureSubnetId { get; set; }
        /// <summary>
        /// The Id of the target resource group (for classic deployment) in which the failover VM is to be created.
        /// </summary>
        string TargetAzureV1ResourceGroupId { get; set; }
        /// <summary>
        /// The Id of the target resource group (for resource manager deployment) in which the failover VM is to be created.
        /// </summary>
        string TargetAzureV2ResourceGroupId { get; set; }
        /// <summary>The target azure Vm Name.</summary>
        string TargetAzureVMName { get; set; }
        /// <summary>The storage account name.</summary>
        string TargetStorageAccountId { get; set; }
        /// <summary>A value indicating whether managed disks should be used during failover.</summary>
        string UseManagedDisk { get; set; }
        /// <summary>The Vm Name.</summary>
        string VMName { get; set; }
        /// <summary>The OS disk VHD id associated with vm.</summary>
        string VhdId { get; set; }

    }
}