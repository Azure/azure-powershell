namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class VirtualMachinePropertiesSecurityProfileUefiSettings :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettingsInternal
    {

        /// <summary>Backing field for <see cref="SecureBootEnabled" /> property.</summary>
        private bool? _secureBootEnabled;

        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public bool? SecureBootEnabled { get => this._secureBootEnabled; set => this._secureBootEnabled = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesSecurityProfileUefiSettings" /> instance.
        /// </summary>
        public VirtualMachinePropertiesSecurityProfileUefiSettings()
        {

        }
    }
    public partial interface IVirtualMachinePropertiesSecurityProfileUefiSettings :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether secure boot should be enabled on the virtual machine.",
        SerializedName = @"secureBootEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SecureBootEnabled { get; set; }

    }
    internal partial interface IVirtualMachinePropertiesSecurityProfileUefiSettingsInternal

    {
        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        bool? SecureBootEnabled { get; set; }

    }
}