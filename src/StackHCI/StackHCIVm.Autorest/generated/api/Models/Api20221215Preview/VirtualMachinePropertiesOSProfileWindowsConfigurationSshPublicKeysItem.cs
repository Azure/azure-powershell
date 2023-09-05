namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class VirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItemInternal
    {

        /// <summary>Backing field for <see cref="KeyData" /> property.</summary>
        private string _keyData;

        /// <summary>
        /// KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit
        /// and in ssh-rsa format. <br><br> For creating ssh keys, see [Create SSH keys on Linux and Mac for Li nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string KeyData { get => this._keyData; set => this._keyData = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>
        /// Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified
        /// key is appended to the file. Example: /home/user/.ssh/authorized_keys
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem" /> instance.
        /// </summary>
        public VirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem()
        {

        }
    }
    public partial interface IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit
        /// and in ssh-rsa format. <br><br> For creating ssh keys, see [Create SSH keys on Linux and Mac for Li nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format. <br><br> For creating ssh keys, see [Create SSH keys on Linux and Mac for Li      nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).",
        SerializedName = @"keyData",
        PossibleTypes = new [] { typeof(string) })]
        string KeyData { get; set; }
        /// <summary>
        /// Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified
        /// key is appended to the file. Example: /home/user/.ssh/authorized_keys
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }

    }
    internal partial interface IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItemInternal

    {
        /// <summary>
        /// KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit
        /// and in ssh-rsa format. <br><br> For creating ssh keys, see [Create SSH keys on Linux and Mac for Li nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
        /// </summary>
        string KeyData { get; set; }
        /// <summary>
        /// Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified
        /// key is appended to the file. Example: /home/user/.ssh/authorized_keys
        /// </summary>
        string Path { get; set; }

    }
}