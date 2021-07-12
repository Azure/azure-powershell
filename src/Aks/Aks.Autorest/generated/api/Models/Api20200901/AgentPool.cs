namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Agent Pool.</summary>
    public partial class AgentPool :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.SubResource();

        /// <summary>Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string[] AvailabilityZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).AvailabilityZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).AvailabilityZone = value ?? null /* arrayOf */; }

        /// <summary>
        /// Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 100 (inclusive) for user
        /// pools and in the range of 1 to 100 (inclusive) for system pools. The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? Count { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Count; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Count = value ?? default(int); }

        /// <summary>Whether to enable auto-scaler</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool? EnableAutoScaling { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).EnableAutoScaling; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).EnableAutoScaling = value ?? default(bool); }

        /// <summary>Enable public IP for nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public bool? EnableNodePublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).EnableNodePublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).EnableNodePublicIP = value ?? default(bool); }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Id; }

        /// <summary>Maximum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? MaxCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).MaxCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).MaxCount = value ?? default(int); }

        /// <summary>Maximum number of pods that can run on a node.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? MaxPod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).MaxPod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).MaxPod = value ?? default(int); }

        /// <summary>Internal Acessors for NodeImageVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal.NodeImageVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).NodeImageVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).NodeImageVersion = value; }

        /// <summary>Internal Acessors for PowerState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal.PowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).PowerState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).PowerState = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfileProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for UpgradeSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal.UpgradeSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).UpgradeSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).UpgradeSetting = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Type = value; }

        /// <summary>Minimum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? MinCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).MinCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).MinCount = value ?? default(int); }

        /// <summary>AgentPoolMode represents mode of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode? Mode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Mode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Mode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode)""); }

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Name; }

        /// <summary>Version of node image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string NodeImageVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).NodeImageVersion; }

        /// <summary>Agent pool node labels to be persisted across all nodes in agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels NodeLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).NodeLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).NodeLabel = value ?? null /* model class */; }

        /// <summary>
        /// Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string[] NodeTaint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).NodeTaint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).NodeTaint = value ?? null /* arrayOf */; }

        /// <summary>
        /// OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0,
        /// it will apply the default osDisk size according to the vmSize specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public int? OSDiskSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OSDiskSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OSDiskSizeGb = value ?? default(int); }

        /// <summary>
        /// OS disk type to be used for machines in a given agent pool. Allowed values are 'Ephemeral' and 'Managed'. Defaults to
        /// 'Managed'. May not be changed after creation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType? OSDiskType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OSDiskType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OSDiskType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType)""); }

        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType? OSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OSType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType)""); }

        /// <summary>Version of orchestrator specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string OrchestratorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OrchestratorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).OrchestratorVersion = value ?? null; }

        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).PowerStateCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).PowerStateCode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code)""); }

        /// <summary>AgentPoolType represents types of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? PropertiesType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType)""); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties _property;

        /// <summary>Properties of an agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfileProperties()); set => this._property = value; }

        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ProvisioningState; }

        /// <summary>The ID for Proximity Placement Group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ProximityPlacementGroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ProximityPlacementGroupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ProximityPlacementGroupId = value ?? null; }

        /// <summary>
        /// ScaleSetEvictionPolicy to be used to specify eviction policy for Spot virtual machine scale set. Default to Delete.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy? ScaleSetEvictionPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ScaleSetEvictionPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ScaleSetEvictionPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy)""); }

        /// <summary>
        /// ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority? ScaleSetPriority { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ScaleSetPriority; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).ScaleSetPriority = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority)""); }

        /// <summary>
        /// SpotMaxPrice to be used to specify the maximum price you are willing to pay in US Dollars. Possible values are any decimal
        /// value greater than zero or -1 which indicates default price to be up-to on-demand.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public float? SpotMaxPrice { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).SpotMaxPrice; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).SpotMaxPrice = value ?? default(float); }

        /// <summary>Agent pool tags to be persisted on the agent pool virtual machine scale set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).Tag = value ?? null /* model class */; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)__subResource).Type; }

        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string UpgradeSettingMaxSurge { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).UpgradeSettingMaxSurge; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).UpgradeSettingMaxSurge = value ?? null; }

        /// <summary>Size of agent VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes? VMSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).VMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).VMSize = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes)""); }

        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string VnetSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).VnetSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)Property).VnetSubnetId = value ?? null; }

        /// <summary>Creates an new <see cref="AgentPool" /> instance.</summary>
        public AgentPool()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }
    }
    /// Agent Pool.
    public partial interface IAgentPool :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResource
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
        /// <summary>AgentPoolType represents types of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AgentPoolType represents types of an agent pool",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? PropertiesType { get; set; }
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
    /// Agent Pool.
    internal partial interface IAgentPoolInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal
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
        /// <summary>AgentPoolType represents types of an agent pool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? PropertiesType { get; set; }
        /// <summary>Properties of an agent pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties Property { get; set; }
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