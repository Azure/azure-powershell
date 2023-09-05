namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// LinuxConfiguration - linux specific configuration values for the virtual machine
    /// </summary>
    public partial class VirtualMachinePropertiesOSProfileLinuxConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal
    {

        /// <summary>Backing field for <see cref="DisablePasswordAuthentication" /> property.</summary>
        private bool? _disablePasswordAuthentication;

        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public bool? DisablePasswordAuthentication { get => this._disablePasswordAuthentication; set => this._disablePasswordAuthentication = value; }

        /// <summary>Internal Acessors for Ssh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal.Ssh { get => (this._ssh = this._ssh ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationSsh()); set { {_ssh = value;} } }

        /// <summary>Backing field for <see cref="ProvisionVMAgent" /> property.</summary>
        private bool? _provisionVMAgent;

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public bool? ProvisionVMAgent { get => this._provisionVMAgent; set => this._provisionVMAgent = value; }

        /// <summary>Backing field for <see cref="Ssh" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh _ssh;

        /// <summary>SSH - contains settings related to ssh configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh Ssh { get => (this._ssh = this._ssh ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfigurationSsh()); set => this._ssh = value; }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] SshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshInternal)Ssh).PublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshInternal)Ssh).PublicKey = value ?? null /* arrayOf */; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesOSProfileLinuxConfiguration" /> instance.
        /// </summary>
        public VirtualMachinePropertiesOSProfileLinuxConfiguration()
        {

        }
    }
    /// LinuxConfiguration - linux specific configuration values for the virtual machine
    public partial interface IVirtualMachinePropertiesOSProfileLinuxConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DisablePasswordAuthentication - whether password authentication should be disabled",
        SerializedName = @"disablePasswordAuthentication",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisablePasswordAuthentication { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.",
        SerializedName = @"provisionVMAgent",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ProvisionVMAgent { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] SshPublicKey { get; set; }

    }
    /// LinuxConfiguration - linux specific configuration values for the virtual machine
    internal partial interface IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal

    {
        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        bool? DisablePasswordAuthentication { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        bool? ProvisionVMAgent { get; set; }
        /// <summary>SSH - contains settings related to ssh configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh Ssh { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] SshPublicKey { get; set; }

    }
}