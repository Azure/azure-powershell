namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Windows Configuration for the virtual machine</summary>
    public partial class VirtualMachinePropertiesOSProfileWindowsConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal
    {

        /// <summary>Backing field for <see cref="EnableAutomaticUpdate" /> property.</summary>
        private bool? _enableAutomaticUpdate;

        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public bool? EnableAutomaticUpdate { get => this._enableAutomaticUpdate; set => this._enableAutomaticUpdate = value; }

        /// <summary>Internal Acessors for Ssh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal.Ssh { get => (this._ssh = this._ssh ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationSsh()); set { {_ssh = value;} } }

        /// <summary>Backing field for <see cref="ProvisionVMAgent" /> property.</summary>
        private bool? _provisionVMAgent;

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public bool? ProvisionVMAgent { get => this._provisionVMAgent; set => this._provisionVMAgent = value; }

        /// <summary>Backing field for <see cref="Ssh" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh _ssh;

        /// <summary>SSH Configuration</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh Ssh { get => (this._ssh = this._ssh ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfigurationSsh()); set => this._ssh = value; }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] SshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshInternal)Ssh).PublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshInternal)Ssh).PublicKey = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="TimeZone" /> property.</summary>
        private string _timeZone;

        /// <summary>TimeZone for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string TimeZone { get => this._timeZone; set => this._timeZone = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualMachinePropertiesOSProfileWindowsConfiguration" /> instance.
        /// </summary>
        public VirtualMachinePropertiesOSProfileWindowsConfiguration()
        {

        }
    }
    /// Windows Configuration for the virtual machine
    public partial interface IVirtualMachinePropertiesOSProfileWindowsConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to EnableAutomaticUpdates on the machine",
        SerializedName = @"enableAutomaticUpdates",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAutomaticUpdate { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] SshPublicKey { get; set; }
        /// <summary>TimeZone for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"TimeZone for the virtual machine",
        SerializedName = @"timeZone",
        PossibleTypes = new [] { typeof(string) })]
        string TimeZone { get; set; }

    }
    /// Windows Configuration for the virtual machine
    internal partial interface IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal

    {
        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        bool? EnableAutomaticUpdate { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        bool? ProvisionVMAgent { get; set; }
        /// <summary>SSH Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh Ssh { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] SshPublicKey { get; set; }
        /// <summary>TimeZone for the virtual machine</summary>
        string TimeZone { get; set; }

    }
}