namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile for the container service agent pool.</summary>
    public partial class ManagedClusterAgentPoolProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties __managedClusterAgentPoolProfileProperties = new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfileProperties();

        /// <summary>Availability zones for nodes. Must use VirtualMachineScaleSets AgentPoolType.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string[] AvailabilityZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).AvailabilityZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).AvailabilityZone = value ?? null /* arrayOf */; }

        /// <summary>
        /// Number of agents (VMs) to host docker containers. Allowed values must be in the range of 0 to 100 (inclusive) for user
        /// pools and in the range of 1 to 100 (inclusive) for system pools. The default value is 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? Count { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Count; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Count = value ?? default(int); }

        /// <summary>Whether to enable auto-scaler</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public bool? EnableAutoScaling { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).EnableAutoScaling; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).EnableAutoScaling = value ?? default(bool); }

        /// <summary>Enable public IP for nodes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public bool? EnableNodePublicIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).EnableNodePublicIP; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).EnableNodePublicIP = value ?? default(bool); }

        /// <summary>Maximum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? MaxCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).MaxCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).MaxCount = value ?? default(int); }

        /// <summary>Maximum number of pods that can run on a node.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? MaxPod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).MaxPod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).MaxPod = value ?? default(int); }

        /// <summary>Internal Acessors for NodeImageVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal.NodeImageVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).NodeImageVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).NodeImageVersion = value; }

        /// <summary>Internal Acessors for PowerState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal.PowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).PowerState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).PowerState = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ProvisioningState = value; }

        /// <summary>Minimum number of nodes for auto-scaling</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? MinCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).MinCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).MinCount = value ?? default(int); }

        /// <summary>AgentPoolMode represents mode of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode? Mode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Mode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Mode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode)""); }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Unique name of the agent pool profile in the context of the subscription and resource group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Version of node image</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string NodeImageVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).NodeImageVersion; }

        /// <summary>Agent pool node labels to be persisted across all nodes in agent pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels NodeLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).NodeLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).NodeLabel = value ?? null /* model class */; }

        /// <summary>
        /// Taints added to new nodes during node pool create and scale. For example, key=value:NoSchedule.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string[] NodeTaint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).NodeTaint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).NodeTaint = value ?? null /* arrayOf */; }

        /// <summary>
        /// OS Disk Size in GB to be used to specify the disk size for every machine in this master/agent pool. If you specify 0,
        /// it will apply the default osDisk size according to the vmSize specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public int? OSDiskSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OSDiskSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OSDiskSizeGb = value ?? default(int); }

        /// <summary>
        /// OS disk type to be used for machines in a given agent pool. Allowed values are 'Ephemeral' and 'Managed'. Defaults to
        /// 'Managed'. May not be changed after creation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType? OSDiskType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OSDiskType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OSDiskType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType)""); }

        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType? OSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OSType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType)""); }

        /// <summary>Version of orchestrator specified when creating the managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string OrchestratorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OrchestratorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).OrchestratorVersion = value ?? null; }

        /// <summary>Describes whether the Agent Pool is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState PowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).PowerState; }

        /// <summary>Tells whether the cluster is Running or Stopped</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code? PowerStateCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).PowerStateCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).PowerStateCode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code)""); }

        /// <summary>
        /// The current deployment or provisioning state, which only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ProvisioningState; }

        /// <summary>The ID for Proximity Placement Group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string ProximityPlacementGroupId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ProximityPlacementGroupId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ProximityPlacementGroupId = value ?? null; }

        /// <summary>
        /// ScaleSetEvictionPolicy to be used to specify eviction policy for Spot virtual machine scale set. Default to Delete.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy? ScaleSetEvictionPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ScaleSetEvictionPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ScaleSetEvictionPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy)""); }

        /// <summary>
        /// ScaleSetPriority to be used to specify virtual machine scale set priority. Default to regular.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority? ScaleSetPriority { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ScaleSetPriority; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).ScaleSetPriority = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority)""); }

        /// <summary>
        /// SpotMaxPrice to be used to specify the maximum price you are willing to pay in US Dollars. Possible values are any decimal
        /// value greater than zero or -1 which indicates default price to be up-to on-demand.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public float? SpotMaxPrice { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).SpotMaxPrice; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).SpotMaxPrice = value ?? default(float); }

        /// <summary>Agent pool tags to be persisted on the agent pool virtual machine scale set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Tag = value ?? null /* model class */; }

        /// <summary>AgentPoolType represents types of an agent pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType? Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType)""); }

        /// <summary>Settings for upgrading the agentpool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings UpgradeSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).UpgradeSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).UpgradeSetting = value ?? null /* model class */; }

        /// <summary>
        /// Count or percentage of additional nodes to be added during upgrade. If empty uses AKS default
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string UpgradeSettingMaxSurge { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).UpgradeSettingMaxSurge; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).UpgradeSettingMaxSurge = value ?? null; }

        /// <summary>Size of agent VMs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes? VMSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).VMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).VMSize = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes)""); }

        /// <summary>VNet SubnetID specifies the VNet's subnet identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string VnetSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).VnetSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal)__managedClusterAgentPoolProfileProperties).VnetSubnetId = value ?? null; }

        /// <summary>Creates an new <see cref="ManagedClusterAgentPoolProfile" /> instance.</summary>
        public ManagedClusterAgentPoolProfile()
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
            await eventListener.AssertNotNull(nameof(__managedClusterAgentPoolProfileProperties), __managedClusterAgentPoolProfileProperties);
            await eventListener.AssertObjectIsValid(nameof(__managedClusterAgentPoolProfileProperties), __managedClusterAgentPoolProfileProperties);
        }
    }
    /// Profile for the container service agent pool.
    public partial interface IManagedClusterAgentPoolProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties
    {
        /// <summary>
        /// Unique name of the agent pool profile in the context of the subscription and resource group.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Unique name of the agent pool profile in the context of the subscription and resource group.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Profile for the container service agent pool.
    internal partial interface IManagedClusterAgentPoolProfileInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesInternal
    {
        /// <summary>
        /// Unique name of the agent pool profile in the context of the subscription and resource group.
        /// </summary>
        string Name { get; set; }

    }
}