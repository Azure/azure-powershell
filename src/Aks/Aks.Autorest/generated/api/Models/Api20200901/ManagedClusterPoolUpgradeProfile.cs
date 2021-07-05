namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The list of available upgrade versions.</summary>
    public partial class ManagedClusterPoolUpgradeProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileInternal
    {

        /// <summary>Backing field for <see cref="KubernetesVersion" /> property.</summary>
        private string _kubernetesVersion;

        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string KubernetesVersion { get => this._kubernetesVersion; set => this._kubernetesVersion = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Pool name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType _oSType;

        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="Upgrade" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] _upgrade;

        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] Upgrade { get => this._upgrade; set => this._upgrade = value; }

        /// <summary>Creates an new <see cref="ManagedClusterPoolUpgradeProfile" /> instance.</summary>
        public ManagedClusterPoolUpgradeProfile()
        {

        }
    }
    /// The list of available upgrade versions.
    public partial interface IManagedClusterPoolUpgradeProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Kubernetes version (major, minor, patch).",
        SerializedName = @"kubernetesVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KubernetesVersion { get; set; }
        /// <summary>Pool name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Pool name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of orchestrator types and versions available for upgrade.",
        SerializedName = @"upgrades",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] Upgrade { get; set; }

    }
    /// The list of available upgrade versions.
    internal partial interface IManagedClusterPoolUpgradeProfileInternal

    {
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        string KubernetesVersion { get; set; }
        /// <summary>Pool name.</summary>
        string Name { get; set; }
        /// <summary>
        /// OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType OSType { get; set; }
        /// <summary>List of orchestrator types and versions available for upgrade.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[] Upgrade { get; set; }

    }
}