namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Control plane and agent pool upgrade profiles.</summary>
    public partial class ManagedClusterUpgradeProfileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AgentPoolProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile[] _agentPoolProfile;

        /// <summary>The list of available upgrade versions for agent pools.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile[] AgentPoolProfile { get => this._agentPoolProfile; set => this._agentPoolProfile = value; }

        /// <summary>Backing field for <see cref="ControlPlaneProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile _controlPlaneProfile;

        /// <summary>The list of available upgrade versions for the control plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile ControlPlaneProfile { get => (this._controlPlaneProfile = this._controlPlaneProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfile()); set => this._controlPlaneProfile = value; }

        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ControlPlaneProfileKubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).KubernetesVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).KubernetesVersion = value ; }

        /// <summary>Pool name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ControlPlaneProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).Name = value ?? null; }

        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType ControlPlaneProfileOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).OSType = value ; }

        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] ControlPlaneProfileUpgrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).Upgrade; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal)ControlPlaneProfile).Upgrade = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for ControlPlaneProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal.ControlPlaneProfile { get => (this._controlPlaneProfile = this._controlPlaneProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfile()); set { {_controlPlaneProfile = value;} } }

        /// <summary>Creates an new <see cref="ManagedClusterUpgradeProfileProperties" /> instance.</summary>
        public ManagedClusterUpgradeProfileProperties()
        {

        }
    }
    /// Control plane and agent pool upgrade profiles.
    public partial interface IManagedClusterUpgradeProfileProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The list of available upgrade versions for agent pools.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of available upgrade versions for agent pools.",
        SerializedName = @"agentPoolProfiles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile[] AgentPoolProfile { get; set; }
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Kubernetes version (major, minor, patch).",
        SerializedName = @"kubernetesVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ControlPlaneProfileKubernetesVersion { get; set; }
        /// <summary>Pool name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Pool name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string ControlPlaneProfileName { get; set; }
        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType ControlPlaneProfileOSType { get; set; }
        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of orchestrator types and versions available for upgrade.",
        SerializedName = @"upgrades",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] ControlPlaneProfileUpgrade { get; set; }

    }
    /// Control plane and agent pool upgrade profiles.
    internal partial interface IManagedClusterUpgradeProfilePropertiesInternal

    {
        /// <summary>The list of available upgrade versions for agent pools.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile[] AgentPoolProfile { get; set; }
        /// <summary>The list of available upgrade versions for the control plane.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile ControlPlaneProfile { get; set; }
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        string ControlPlaneProfileKubernetesVersion { get; set; }
        /// <summary>Pool name.</summary>
        string ControlPlaneProfileName { get; set; }
        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType ControlPlaneProfileOSType { get; set; }
        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] ControlPlaneProfileUpgrade { get; set; }

    }
}