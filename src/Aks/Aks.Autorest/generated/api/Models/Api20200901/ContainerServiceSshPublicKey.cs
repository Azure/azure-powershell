namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Contains information about SSH certificate public key data.</summary>
    public partial class ContainerServiceSshPublicKey :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKeyInternal
    {

        /// <summary>Backing field for <see cref="KeyData" /> property.</summary>
        private string _keyData;

        /// <summary>
        /// Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without
        /// headers.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string KeyData { get => this._keyData; set => this._keyData = value; }

        /// <summary>Creates an new <see cref="ContainerServiceSshPublicKey" /> instance.</summary>
        public ContainerServiceSshPublicKey()
        {

        }
    }
    /// Contains information about SSH certificate public key data.
    public partial interface IContainerServiceSshPublicKey :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without
        /// headers.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without headers.",
        SerializedName = @"keyData",
        PossibleTypes = new [] { typeof(string) })]
        string KeyData { get; set; }

    }
    /// Contains information about SSH certificate public key data.
    internal partial interface IContainerServiceSshPublicKeyInternal

    {
        /// <summary>
        /// Certificate public key used to authenticate with VMs through SSH. The certificate must be in PEM format with or without
        /// headers.
        /// </summary>
        string KeyData { get; set; }

    }
}