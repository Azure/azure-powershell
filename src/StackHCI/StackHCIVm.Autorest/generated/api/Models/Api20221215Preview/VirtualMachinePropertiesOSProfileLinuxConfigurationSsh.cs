namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>SSH - contains settings related to ssh configuration</summary>
    public partial class VirtualMachinePropertiesOSProfileLinuxConfigurationSsh :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshInternal
    {

        /// <summary>Backing field for <see cref="PublicKey" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] _publicKey;

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] PublicKey { get => this._publicKey; set => this._publicKey = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesOSProfileLinuxConfigurationSsh" /> instance.
        /// </summary>
        public VirtualMachinePropertiesOSProfileLinuxConfigurationSsh()
        {

        }
    }
    /// SSH - contains settings related to ssh configuration
    public partial interface IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] PublicKey { get; set; }

    }
    /// SSH - contains settings related to ssh configuration
    internal partial interface IVirtualMachinePropertiesOSProfileLinuxConfigurationSshInternal

    {
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] PublicKey { get; set; }

    }
}