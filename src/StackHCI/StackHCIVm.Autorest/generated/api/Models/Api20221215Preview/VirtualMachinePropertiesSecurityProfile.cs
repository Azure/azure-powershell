namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>SecurityProfile - Specifies the security settings for the virtual machine.</summary>
    public partial class VirtualMachinePropertiesSecurityProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfile,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal
    {

        /// <summary>Backing field for <see cref="EnableTpm" /> property.</summary>
        private bool? _enableTpm;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public bool? EnableTpm { get => this._enableTpm; set => this._enableTpm = value; }

        /// <summary>Internal Acessors for UefiSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileInternal.UefiSetting { get => (this._uefiSetting = this._uefiSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfileUefiSettings()); set { {_uefiSetting = value;} } }

        /// <summary>Backing field for <see cref="UefiSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings _uefiSetting;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings UefiSetting { get => (this._uefiSetting = this._uefiSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesSecurityProfileUefiSettings()); set => this._uefiSetting = value; }

        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? UefiSettingSecureBootEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettingsInternal)UefiSetting).SecureBootEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettingsInternal)UefiSetting).SecureBootEnabled = value ?? default(bool); }

        /// <summary>Creates an new <see cref="VirtualMachinePropertiesSecurityProfile" /> instance.</summary>
        public VirtualMachinePropertiesSecurityProfile()
        {

        }
    }
    /// SecurityProfile - Specifies the security settings for the virtual machine.
    public partial interface IVirtualMachinePropertiesSecurityProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableTPM",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableTpm { get; set; }
        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether secure boot should be enabled on the virtual machine.",
        SerializedName = @"secureBootEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? UefiSettingSecureBootEnabled { get; set; }

    }
    /// SecurityProfile - Specifies the security settings for the virtual machine.
    internal partial interface IVirtualMachinePropertiesSecurityProfileInternal

    {
        bool? EnableTpm { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesSecurityProfileUefiSettings UefiSetting { get; set; }
        /// <summary>Specifies whether secure boot should be enabled on the virtual machine.</summary>
        bool? UefiSettingSecureBootEnabled { get; set; }

    }
}