namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Access profile for managed cluster API server.</summary>
    public partial class ManagedClusterApiServerAccessProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterApiServerAccessProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterApiServerAccessProfileInternal
    {

        /// <summary>Backing field for <see cref="AuthorizedIPRange" /> property.</summary>
        private string[] _authorizedIPRange;

        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string[] AuthorizedIPRange { get => this._authorizedIPRange; set => this._authorizedIPRange = value; }

        /// <summary>Backing field for <see cref="EnablePrivateCluster" /> property.</summary>
        private bool? _enablePrivateCluster;

        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public bool? EnablePrivateCluster { get => this._enablePrivateCluster; set => this._enablePrivateCluster = value; }

        /// <summary>Creates an new <see cref="ManagedClusterApiServerAccessProfile" /> instance.</summary>
        public ManagedClusterApiServerAccessProfile()
        {

        }
    }
    /// Access profile for managed cluster API server.
    public partial interface IManagedClusterApiServerAccessProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authorized IP Ranges to kubernetes API server.",
        SerializedName = @"authorizedIPRanges",
        PossibleTypes = new [] { typeof(string) })]
        string[] AuthorizedIPRange { get; set; }
        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to create the cluster as a private cluster or not.",
        SerializedName = @"enablePrivateCluster",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnablePrivateCluster { get; set; }

    }
    /// Access profile for managed cluster API server.
    internal partial interface IManagedClusterApiServerAccessProfileInternal

    {
        /// <summary>Authorized IP Ranges to kubernetes API server.</summary>
        string[] AuthorizedIPRange { get; set; }
        /// <summary>Whether to create the cluster as a private cluster or not.</summary>
        bool? EnablePrivateCluster { get; set; }

    }
}