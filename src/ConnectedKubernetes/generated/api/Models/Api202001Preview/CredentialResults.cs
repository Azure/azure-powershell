namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>The list of credential result response.</summary>
    public partial class CredentialResults :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResults,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResultsInternal
    {

        /// <summary>Backing field for <see cref="Kubeconfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResult[] _kubeconfig;

        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResult[] Kubeconfig { get => this._kubeconfig; }

        /// <summary>Internal Acessors for Kubeconfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResult[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResultsInternal.Kubeconfig { get => this._kubeconfig; set { {_kubeconfig = value;} } }

        /// <summary>Creates an new <see cref="CredentialResults" /> instance.</summary>
        public CredentialResults()
        {

        }
    }
    /// The list of credential result response.
    public partial interface ICredentialResults :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable
    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Base64-encoded Kubernetes configuration file.",
        SerializedName = @"kubeconfigs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResult[] Kubeconfig { get;  }

    }
    /// The list of credential result response.
    internal partial interface ICredentialResultsInternal

    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api202001Preview.ICredentialResult[] Kubeconfig { get; set; }

    }
}