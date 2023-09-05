namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>SSH Configuration</summary>
    public partial class VirtualMachinePropertiesOSProfileWindowsConfigurationSsh :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshInternal
    {

        /// <summary>Backing field for <see cref="PublicKey" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] _publicKey;

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] PublicKey { get => this._publicKey; set => this._publicKey = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesOSProfileWindowsConfigurationSsh" /> instance.
        /// </summary>
        public VirtualMachinePropertiesOSProfileWindowsConfigurationSsh()
        {

        }
    }
    /// SSH Configuration
    public partial interface IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh :
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] PublicKey { get; set; }

    }
    /// SSH Configuration
    internal partial interface IVirtualMachinePropertiesOSProfileWindowsConfigurationSshInternal

    {
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] PublicKey { get; set; }

    }
}