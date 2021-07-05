namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The list of available upgrades for an agent pool.</summary>
    public partial class AgentPoolUpgradeProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Id of the agent pool upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string KubernetesVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).KubernetesVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).KubernetesVersion = value ; }

        /// <summary>LatestNodeImageVersion is the latest AKS supported node image version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public string LatestNodeImageVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).LatestNodeImageVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).LatestNodeImageVersion = value ?? null; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileProperties Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolUpgradeProfileProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the agent pool upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType OSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).OSType = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileProperties _property;

        /// <summary>Properties of agent pool upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolUpgradeProfileProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the agent pool upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesUpgradesItem[] Upgrade { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).Upgrade; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesInternal)Property).Upgrade = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="AgentPoolUpgradeProfile" /> instance.</summary>
        public AgentPoolUpgradeProfile()
        {

        }
    }
    /// The list of available upgrades for an agent pool.
    public partial interface IAgentPoolUpgradeProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Id of the agent pool upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id of the agent pool upgrade profile.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Kubernetes version (major, minor, patch).",
        SerializedName = @"kubernetesVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KubernetesVersion { get; set; }
        /// <summary>LatestNodeImageVersion is the latest AKS supported node image version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"LatestNodeImageVersion is the latest AKS supported node image version.",
        SerializedName = @"latestNodeImageVersion",
        PossibleTypes = new [] { typeof(string) })]
        string LatestNodeImageVersion { get; set; }
        /// <summary>Name of the agent pool upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the agent pool upgrade profile.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType OSType { get; set; }
        /// <summary>Type of the agent pool upgrade profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of the agent pool upgrade profile.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of orchestrator types and versions available for upgrade.",
        SerializedName = @"upgrades",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesUpgradesItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesUpgradesItem[] Upgrade { get; set; }

    }
    /// The list of available upgrades for an agent pool.
    internal partial interface IAgentPoolUpgradeProfileInternal

    {
        /// <summary>Id of the agent pool upgrade profile.</summary>
        string Id { get; set; }
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        string KubernetesVersion { get; set; }
        /// <summary>LatestNodeImageVersion is the latest AKS supported node image version.</summary>
        string LatestNodeImageVersion { get; set; }
        /// <summary>Name of the agent pool upgrade profile.</summary>
        string Name { get; set; }
        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType OSType { get; set; }
        /// <summary>Properties of agent pool upgrade profile.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfileProperties Property { get; set; }
        /// <summary>Type of the agent pool upgrade profile.</summary>
        string Type { get; set; }
        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeProfilePropertiesUpgradesItem[] Upgrade { get; set; }

    }
}