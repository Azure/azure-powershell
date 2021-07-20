namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>SSH configuration for Linux-based VMs running on Azure.</summary>
    public partial class ContainerServiceSshConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshConfigurationInternal
    {

        /// <summary>Backing field for <see cref="PublicKey" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] _publicKey;

        /// <summary>
        /// The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] PublicKey { get => this._publicKey; set => this._publicKey = value; }

        /// <summary>Creates an new <see cref="ContainerServiceSshConfiguration" /> instance.</summary>
        public ContainerServiceSshConfiguration()
        {

        }
    }
    /// SSH configuration for Linux-based VMs running on Azure.
    public partial interface IContainerServiceSshConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] PublicKey { get; set; }

    }
    /// SSH configuration for Linux-based VMs running on Azure.
    internal partial interface IContainerServiceSshConfigurationInternal

    {
        /// <summary>
        /// The list of SSH public keys used to authenticate with Linux-based VMs. Only expect one key specified.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[] PublicKey { get; set; }

    }
}