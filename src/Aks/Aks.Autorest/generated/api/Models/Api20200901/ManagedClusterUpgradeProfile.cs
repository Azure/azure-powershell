namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The list of available upgrades for compute pools.</summary>
    public partial class ManagedClusterUpgradeProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal
    {

        /// <summary>The list of available upgrade versions for agent pools.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile[] AgentPoolProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).AgentPoolProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).AgentPoolProfile = value ; }

        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ControlPlaneProfileKubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileKubernetesVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileKubernetesVersion = value ; }

        /// <summary>Pool name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string ControlPlaneProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileName = value ?? null; }

        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType ControlPlaneProfileOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileOSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileOSType = value ; }

        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] ControlPlaneProfileUpgrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileUpgrade; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfileUpgrade = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Id of upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Internal Acessors for ControlPlaneProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal.ControlPlaneProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfilePropertiesInternal)Property).ControlPlaneProfile = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileProperties Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfileProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileProperties _property;

        /// <summary>Properties of upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfileProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ManagedClusterUpgradeProfile" /> instance.</summary>
        public ManagedClusterUpgradeProfile()
        {

        }
    }
    /// The list of available upgrades for compute pools.
    public partial interface IManagedClusterUpgradeProfile :
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
        /// <summary>Id of upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of upgrade profile.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Name of upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of upgrade profile.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Type of upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of upgrade profile.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The list of available upgrades for compute pools.
    internal partial interface IManagedClusterUpgradeProfileInternal

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
        /// <summary>Id of upgrade profile.</summary>
        string Id { get; set; }
        /// <summary>Name of upgrade profile.</summary>
        string Name { get; set; }
        /// <summary>Properties of upgrade profile.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileProperties Property { get; set; }
        /// <summary>Type of upgrade profile.</summary>
        string Type { get; set; }

    }
}