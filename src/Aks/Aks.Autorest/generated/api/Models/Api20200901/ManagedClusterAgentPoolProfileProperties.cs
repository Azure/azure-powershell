namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Properties for the container service agent pool profile.</summary>
    public partial class ManagedClusterAgentPoolProfileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AvailabilityZone" /> property.</summary>
        private string[] _availabilityZone;

        /// <summary>Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string[] AvailabilityZone { get => this._availabilityZone; set => this._availabilityZone = value; }

        /// <summary>Backing field for <see cref="Count" /> property.</summary>
        private int? _count;

        /// <summary>
        /// Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 100 (inclusive) for user
        /// pools and in the range of 1 to 100 (inclusive) for system pools. The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? Count { get => this._count; set => this._count = value; }

        /// <summary>Backing field for <see cref="EnableAutoScaling" /> property.</summary>
        private bool? _enableAutoScaling;

        /// <summary>Whether to enable auto-scaler</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool? EnableAutoScaling { get => this._enableAutoScaling; set => this._enableAutoScaling = value; }

        /// <summary>Backing field for <see cref="EnableNodePublicIP" /> property.</summary>
        private bool? _enableNodePublicIP;

        /// <summary>Enable public IP for nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool? EnableNodePublicIP { get => this._enableNodePublicIP; set => this._enableNodePublicIP = value; }

        /// <summary>Backing field for <see cref="MaxCount" /> property.</summary>
        private int? _maxCount;

        /// <summary>Maximum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? MaxCount { get => this._maxCount; set => this._maxCount = value; }

        /// <summary>Backing field for <see cref="MaxPod" /> property.</summary>
        private int? _maxPod;

        /// <summary>Maximum number of pods that can run on a node.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? MaxPod { get => this._maxPod; set => this._maxPod = value; }

        /// <summary>Internal Acessors for NodeImageVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal.NodeImageVersion { get => this._nodeImageVersion; set { {_nodeImageVersion = value;} } }

        /// <summary>Internal Acessors for PowerState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal.PowerState { get => (this._powerState = this._powerState ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PowerState()); set { {_powerState = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for UpgradeSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal.UpgradeSetting { get => (this._upgradeSetting = this._upgradeSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolUpgradeSettings()); set { {_upgradeSetting = value;} } }

        /// <summary>Backing field for <see cref="MinCount" /> property.</summary>
        private int? _minCount;

        /// <summary>Minimum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? MinCount { get => this._minCount; set => this._minCount = value; }

        /// <summary>Backing field for <see cref="Mode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode? _mode;

        /// <summary>AgentPoolMode represents mode of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode? Mode { get => this._mode; set => this._mode = value; }

        /// <summary>Backing field for <see cref="NodeImageVersion" /> property.</summary>
        private string _nodeImageVersion;

        /// <summary>Version of node image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string NodeImageVersion { get => this._nodeImageVersion; }

        /// <summary>Backing field for <see cref="NodeLabel" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels _nodeLabel;

        /// <summary>Agent pool node labels to be persisted across all nodes in agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels NodeLabel { get => (this._nodeLabel = this._nodeLabel ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesNodeLabels()); set => this._nodeLabel = value; }

        /// <summary>Backing field for <see cref="NodeTaint" /> property.</summary>
        private string[] _nodeTaint;

        /// <summary>
        /// Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string[] NodeTaint { get => this._nodeTaint; set => this._nodeTaint = value; }

        /// <summary>Backing field for <see cref="OSDiskSizeGb" /> property.</summary>
        private int? _oSDiskSizeGb;

        /// <summary>
        /// OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0,
        /// it will apply the default osDisk size according to the vmSize specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public int? OSDiskSizeGb { get => this._oSDiskSizeGb; set => this._oSDiskSizeGb = value; }

        /// <summary>Backing field for <see cref="OSDiskType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType? _oSDiskType;

        /// <summary>
        /// OS disk type to be used for machines in a given agent pool. Allowed values are 'Ephemeral' and 'Managed'. Defaults to
        /// 'Managed'. May not be changed after creation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType? OSDiskType { get => this._oSDiskType; set => this._oSDiskType = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType? _oSType;

        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType? OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="OrchestratorVersion" /> property.</summary>
        private string _orchestratorVersion;

        /// <summary>Version of orchestrator specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string OrchestratorVersion { get => this._orchestratorVersion; set => this._orchestratorVersion = value; }

        /// <summary>Backing field for <see cref="PowerState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState _powerState;

        /// <summary>Describes whether the Agent Pool is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState PowerState { get => (this._powerState = this._powerState ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PowerState()); }

        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerStateInternal)PowerState).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerStateInternal)PowerState).Code = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code)""); }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ProximityPlacementGroupId" /> property.</summary>
        private string _proximityPlacementGroupId;

        /// <summary>The ID for Proximity Placement Group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ProximityPlacementGroupId { get => this._proximityPlacementGroupId; set => this._proximityPlacementGroupId = value; }

        /// <summary>Backing field for <see cref="ScaleSetEvictionPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy? _scaleSetEvictionPolicy;

        /// <summary>
        /// ScaleSetEvictionPolicy to be used to specify eviction policy for Spot virtual machine scale set. Default to Delete.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy? ScaleSetEvictionPolicy { get => this._scaleSetEvictionPolicy; set => this._scaleSetEvictionPolicy = value; }

        /// <summary>Backing field for <see cref="ScaleSetPriority" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority? _scaleSetPriority;

        /// <summary>
        /// ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority? ScaleSetPriority { get => this._scaleSetPriority; set => this._scaleSetPriority = value; }

        /// <summary>Backing field for <see cref="SpotMaxPrice" /> property.</summary>
        private float? _spotMaxPrice;

        /// <summary>
        /// SpotMaxPrice to be used to specify the maximum price you are willing to pay in US Dollars. Possible values are any decimal
        /// value greater than zero or -1 which indicates default price to be up-to on-demand.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public float? SpotMaxPrice { get => this._spotMaxPrice; set => this._spotMaxPrice = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags _tag;

        /// <summary>Agent pool tags to be persisted on the agent pool virtual machine scale set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? _type;

        /// <summary>AgentPoolType represents types of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="UpgradeSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings _upgradeSetting;

        /// <summary>Settings for upgrading the agentpool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings UpgradeSetting { get => (this._upgradeSetting = this._upgradeSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolUpgradeSettings()); set => this._upgradeSetting = value; }

        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string UpgradeSettingMaxSurge { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettingsInternal)UpgradeSetting).MaxSurge; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettingsInternal)UpgradeSetting).MaxSurge = value ?? null; }

        /// <summary>Backing field for <see cref="VMSize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes? _vMSize;

        /// <summary>Size of agent VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes? VMSize { get => this._vMSize; set => this._vMSize = value; }

        /// <summary>Backing field for <see cref="VnetSubnetId" /> property.</summary>
        private string _vnetSubnetId;

        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string VnetSubnetId { get => this._vnetSubnetId; set => this._vnetSubnetId = value; }

        /// <summary>
        /// Creates an new <see cref="ManagedClusterAgentPoolProfileProperties" /> instance.
        /// </summary>
        public ManagedClusterAgentPoolProfileProperties()
        {

        }
    }
    /// Properties for the container service agent pool profile.
    public partial interface IManagedClusterAgentPoolProfileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.",
        SerializedName = @"availabilityZones",
        PossibleTypes = new [] { typeof(string) })]
        string[] AvailabilityZone { get; set; }
        /// <summary>
        /// Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 100 (inclusive) for user
        /// pools and in the range of 1 to 100 (inclusive) for system pools. The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 100 (inclusive) for user pools and in the range of 1 to 100 (inclusive) for system pools. The default value is 1.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? Count { get; set; }
        /// <summary>Whether to enable auto-scaler</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to enable auto-scaler",
        SerializedName = @"enableAutoScaling",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAutoScaling { get; set; }
        /// <summary>Enable public IP for nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Enable public IP for nodes",
        SerializedName = @"enableNodePublicIP",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableNodePublicIP { get; set; }
        /// <summary>Maximum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of nodes for auto-scaling",
        SerializedName = @"maxCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxCount { get; set; }
        /// <summary>Maximum number of pods that can run on a node.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of pods that can run on a node.",
        SerializedName = @"maxPods",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxPod { get; set; }
        /// <summary>Minimum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of nodes for auto-scaling",
        SerializedName = @"minCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MinCount { get; set; }
        /// <summary>AgentPoolMode represents mode of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AgentPoolMode represents mode of an agent pool",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode? Mode { get; set; }
        /// <summary>Version of node image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of node image",
        SerializedName = @"nodeImageVersion",
        PossibleTypes = new [] { typeof(string) })]
        string NodeImageVersion { get;  }
        /// <summary>Agent pool node labels to be persisted across all nodes in agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Agent pool node labels to be persisted across all nodes in agent pool.",
        SerializedName = @"nodeLabels",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels NodeLabel { get; set; }
        /// <summary>
        /// Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.",
        SerializedName = @"nodeTaints",
        PossibleTypes = new [] { typeof(string) })]
        string[] NodeTaint { get; set; }
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
        /// OS disk type to be used for machines in a given agent pool. Allowed values are 'Ephemeral' and 'Managed'. Defaults to
        /// 'Managed'. May not be changed after creation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OS disk type to be used for machines in a given agent pool. Allowed values are 'Ephemeral' and 'Managed'. Defaults to 'Managed'. May not be changed after creation.",
        SerializedName = @"osDiskType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType? OSDiskType { get; set; }
        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType? OSType { get; set; }
        /// <summary>Version of orchestrator specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of orchestrator specified when creating the managed cluster.",
        SerializedName = @"orchestratorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OrchestratorVersion { get; set; }
        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tells whether the cluster is Running or Stopped",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get; set; }
        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current deployment or provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The ID for Proximity Placement Group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID for Proximity Placement Group.",
        SerializedName = @"proximityPlacementGroupID",
        PossibleTypes = new [] { typeof(string) })]
        string ProximityPlacementGroupId { get; set; }
        /// <summary>
        /// ScaleSetEvictionPolicy to be used to specify eviction policy for Spot virtual machine scale set. Default to Delete.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ScaleSetEvictionPolicy to be used to specify eviction policy for Spot virtual machine scale set. Default to Delete.",
        SerializedName = @"scaleSetEvictionPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy? ScaleSetEvictionPolicy { get; set; }
        /// <summary>
        /// ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.",
        SerializedName = @"scaleSetPriority",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority? ScaleSetPriority { get; set; }
        /// <summary>
        /// SpotMaxPrice to be used to specify the maximum price you are willing to pay in US Dollars. Possible values are any decimal
        /// value greater than zero or -1 which indicates default price to be up-to on-demand.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SpotMaxPrice to be used to specify the maximum price you are willing to pay in US Dollars. Possible values are any decimal value greater than zero or -1 which indicates default price to be up-to on-demand.",
        SerializedName = @"spotMaxPrice",
        PossibleTypes = new [] { typeof(float) })]
        float? SpotMaxPrice { get; set; }
        /// <summary>Agent pool tags to be persisted on the agent pool virtual machine scale set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Agent pool tags to be persisted on the agent pool virtual machine scale set.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags Tag { get; set; }
        /// <summary>AgentPoolType represents types of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AgentPoolType represents types of an agent pool",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? Type { get; set; }
        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default",
        SerializedName = @"maxSurge",
        PossibleTypes = new [] { typeof(string) })]
        string UpgradeSettingMaxSurge { get; set; }
        /// <summary>Size of agent VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of agent VMs.",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes? VMSize { get; set; }
        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VNet SubnetID specifies the VNet's subnet identifier.",
        SerializedName = @"vnetSubnetID",
        PossibleTypes = new [] { typeof(string) })]
        string VnetSubnetId { get; set; }

    }
    /// Properties for the container service agent pool profile.
    internal partial interface IManagedClusterAgentPoolProfilePropertiesInternal

    {
        /// <summary>Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.</summary>
        string[] AvailabilityZone { get; set; }
        /// <summary>
        /// Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 100 (inclusive) for user
        /// pools and in the range of 1 to 100 (inclusive) for system pools. The default value is 1.
        /// </summary>
        int? Count { get; set; }
        /// <summary>Whether to enable auto-scaler</summary>
        bool? EnableAutoScaling { get; set; }
        /// <summary>Enable public IP for nodes</summary>
        bool? EnableNodePublicIP { get; set; }
        /// <summary>Maximum number of nodes for auto-scaling</summary>
        int? MaxCount { get; set; }
        /// <summary>Maximum number of pods that can run on a node.</summary>
        int? MaxPod { get; set; }
        /// <summary>Minimum number of nodes for auto-scaling</summary>
        int? MinCount { get; set; }
        /// <summary>AgentPoolMode represents mode of an agent pool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode? Mode { get; set; }
        /// <summary>Version of node image</summary>
        string NodeImageVersion { get; set; }
        /// <summary>Agent pool node labels to be persisted across all nodes in agent pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels NodeLabel { get; set; }
        /// <summary>
        /// Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
        /// </summary>
        string[] NodeTaint { get; set; }
        /// <summary>
        /// OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0,
        /// it will apply the default osDisk size according to the vmSize specified.
        /// </summary>
        int? OSDiskSizeGb { get; set; }
        /// <summary>
        /// OS disk type to be used for machines in a given agent pool. Allowed values are 'Ephemeral' and 'Managed'. Defaults to
        /// 'Managed'. May not be changed after creation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType? OSDiskType { get; set; }
        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType? OSType { get; set; }
        /// <summary>Version of orchestrator specified when creating the managed cluster.</summary>
        string OrchestratorVersion { get; set; }
        /// <summary>Describes whether the Agent Pool is Running or Stopped</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState PowerState { get; set; }
        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get; set; }
        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The ID for Proximity Placement Group.</summary>
        string ProximityPlacementGroupId { get; set; }
        /// <summary>
        /// ScaleSetEvictionPolicy to be used to specify eviction policy for Spot virtual machine scale set. Default to Delete.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy? ScaleSetEvictionPolicy { get; set; }
        /// <summary>
        /// ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority? ScaleSetPriority { get; set; }
        /// <summary>
        /// SpotMaxPrice to be used to specify the maximum price you are willing to pay in US Dollars. Possible values are any decimal
        /// value greater than zero or -1 which indicates default price to be up-to on-demand.
        /// </summary>
        float? SpotMaxPrice { get; set; }
        /// <summary>Agent pool tags to be persisted on the agent pool virtual machine scale set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags Tag { get; set; }
        /// <summary>AgentPoolType represents types of an agent pool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? Type { get; set; }
        /// <summary>Settings for upgrading the agentpool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings UpgradeSetting { get; set; }
        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        string UpgradeSettingMaxSurge { get; set; }
        /// <summary>Size of agent VMs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes? VMSize { get; set; }
        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        string VnetSubnetId { get; set; }

    }
}