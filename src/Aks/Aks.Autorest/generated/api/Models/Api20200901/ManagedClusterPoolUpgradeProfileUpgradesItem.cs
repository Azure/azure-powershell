namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    public partial class ManagedClusterPoolUpgradeProfileUpgradesItem :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItemInternal
    {

        /// <summary>Backing field for <see cref="IsPreview" /> property.</summary>
        private bool? _isPreview;

        /// <summary>Whether Kubernetes version is currently in preview.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool? IsPreview { get => this._isPreview; set => this._isPreview = value; }

        /// <summary>Backing field for <see cref="KubernetesVersion" /> property.</summary>
        private string _kubernetesVersion;

        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string KubernetesVersion { get => this._kubernetesVersion; set => this._kubernetesVersion = value; }

        /// <summary>
        /// Creates an new <see cref="ManagedClusterPoolUpgradeProfileUpgradesItem" /> instance.
        /// </summary>
        public ManagedClusterPoolUpgradeProfileUpgradesItem()
        {

        }
    }
    public partial interface IManagedClusterPoolUpgradeProfileUpgradesItem :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Whether Kubernetes version is currently in preview.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether Kubernetes version is currently in preview.",
        SerializedName = @"isPreview",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPreview { get; set; }
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kubernetes version (major, minor, patch).",
        SerializedName = @"kubernetesVersion",
        PossibleTypes = new [] { typeof(string) })]
        string KubernetesVersion { get; set; }

    }
    internal partial interface IManagedClusterPoolUpgradeProfileUpgradesItemInternal

    {
        /// <summary>Whether Kubernetes version is currently in preview.</summary>
        bool? IsPreview { get; set; }
        /// <summary>Kubernetes version (major, minor, patch).</summary>
        string KubernetesVersion { get; set; }

    }
}