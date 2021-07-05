namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The list of credential result response.</summary>
    public partial class CredentialResults :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResults,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResultsInternal
    {

        /// <summary>Backing field for <see cref="Kubeconfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResult[] _kubeconfig;

        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResult[] Kubeconfig { get => this._kubeconfig; }

        /// <summary>Internal Acessors for Kubeconfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResult[] Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResultsInternal.Kubeconfig { get => this._kubeconfig; set { {_kubeconfig = value;} } }

        /// <summary>Creates an new <see cref="CredentialResults" /> instance.</summary>
        public CredentialResults()
        {

        }
    }
    /// The list of credential result response.
    public partial interface ICredentialResults :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Base64-encoded Kubernetes configuration file.",
        SerializedName = @"kubeconfigs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResult[] Kubeconfig { get;  }

    }
    /// The list of credential result response.
    internal partial interface ICredentialResultsInternal

    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResult[] Kubeconfig { get; set; }

    }
}