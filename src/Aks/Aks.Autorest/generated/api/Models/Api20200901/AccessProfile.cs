namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Profile for enabling a user to access a managed cluster.</summary>
    public partial class AccessProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfileInternal
    {

        /// <summary>Backing field for <see cref="KubeConfig" /> property.</summary>
        private byte[] _kubeConfig;

        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public byte[] KubeConfig { get => this._kubeConfig; set => this._kubeConfig = value; }

        /// <summary>Creates an new <see cref="AccessProfile" /> instance.</summary>
        public AccessProfile()
        {

        }
    }
    /// Profile for enabling a user to access a managed cluster.
    public partial interface IAccessProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64-encoded Kubernetes configuration file.",
        SerializedName = @"kubeConfig",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] KubeConfig { get; set; }

    }
    /// Profile for enabling a user to access a managed cluster.
    internal partial interface IAccessProfileInternal

    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        byte[] KubeConfig { get; set; }

    }
}