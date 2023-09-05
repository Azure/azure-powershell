namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// OsProfile - describes the configuration of the operating system and sets login data
    /// </summary>
    public partial class VirtualMachinePropertiesOSProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfile,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal
    {

        /// <summary>Backing field for <see cref="AdminPassword" /> property.</summary>
        private string _adminPassword;

        /// <summary>AdminPassword - admin password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string AdminPassword { get => this._adminPassword; set => this._adminPassword = value; }

        /// <summary>Backing field for <see cref="AdminUsername" /> property.</summary>
        private string _adminUsername;

        /// <summary>AdminUsername - admin username</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string AdminUsername { get => this._adminUsername; set => this._adminUsername = value; }

        /// <summary>Backing field for <see cref="ComputerName" /> property.</summary>
        private string _computerName;

        /// <summary>ComputerName - name of the compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ComputerName { get => this._computerName; set => this._computerName = value; }

        /// <summary>Backing field for <see cref="LinuxConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration _linuxConfiguration;

        /// <summary>
        /// LinuxConfiguration - linux specific configuration values for the virtual machine
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration LinuxConfiguration { get => (this._linuxConfiguration = this._linuxConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfiguration()); set => this._linuxConfiguration = value; }

        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? LinuxConfigurationDisablePasswordAuthentication { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).DisablePasswordAuthentication; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).DisablePasswordAuthentication = value ?? default(bool); }

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? LinuxConfigurationProvisionVMAgent { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).ProvisionVMAgent; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).ProvisionVMAgent = value ?? default(bool); }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] LinuxConfigurationSshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).SshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).SshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for LinuxConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal.LinuxConfiguration { get => (this._linuxConfiguration = this._linuxConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileLinuxConfiguration()); set { {_linuxConfiguration = value;} } }

        /// <summary>Internal Acessors for LinuxConfigurationSsh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal.LinuxConfigurationSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).Ssh; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationInternal)LinuxConfiguration).Ssh = value; }

        /// <summary>Internal Acessors for WindowConfigurationSsh</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal.WindowConfigurationSsh { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).Ssh; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).Ssh = value; }

        /// <summary>Internal Acessors for WindowsConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileInternal.WindowsConfiguration { get => (this._windowsConfiguration = this._windowsConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfiguration()); set { {_windowsConfiguration = value;} } }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? _oSType;

        /// <summary>OsType - string specifying whether the OS is Linux or Windows</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? WindowConfigurationEnableAutomaticUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).EnableAutomaticUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).EnableAutomaticUpdate = value ?? default(bool); }

        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public bool? WindowConfigurationProvisionVMAgent { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).ProvisionVMAgent; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).ProvisionVMAgent = value ?? default(bool); }

        /// <summary>TimeZone for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string WindowConfigurationTimeZone { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).TimeZone; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).TimeZone = value ?? null; }

        /// <summary>Backing field for <see cref="WindowsConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration _windowsConfiguration;

        /// <summary>Windows Configuration for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration WindowsConfiguration { get => (this._windowsConfiguration = this._windowsConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualMachinePropertiesOSProfileWindowsConfiguration()); set => this._windowsConfiguration = value; }

        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] WindowsConfigurationSshPublicKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).SshPublicKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationInternal)WindowsConfiguration).SshPublicKey = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="VirtualMachinePropertiesOSProfile" /> instance.</summary>
        public VirtualMachinePropertiesOSProfile()
        {

        }
    }
    /// OsProfile - describes the configuration of the operating system and sets login data
    public partial interface IVirtualMachinePropertiesOSProfile :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>AdminPassword - admin password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AdminPassword - admin password",
        SerializedName = @"adminPassword",
        PossibleTypes = new [] { typeof(string) })]
        string AdminPassword { get; set; }
        /// <summary>AdminUsername - admin username</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"AdminUsername - admin username",
        SerializedName = @"adminUsername",
        PossibleTypes = new [] { typeof(string) })]
        string AdminUsername { get; set; }
        /// <summary>ComputerName - name of the compute</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ComputerName - name of the compute",
        SerializedName = @"computerName",
        PossibleTypes = new [] { typeof(string) })]
        string ComputerName { get; set; }
        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"DisablePasswordAuthentication - whether password authentication should be disabled",
        SerializedName = @"disablePasswordAuthentication",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LinuxConfigurationDisablePasswordAuthentication { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.",
        SerializedName = @"provisionVMAgent",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LinuxConfigurationProvisionVMAgent { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] LinuxConfigurationSshPublicKey { get; set; }
        /// <summary>OsType - string specifying whether the OS is Linux or Windows</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"OsType - string specifying whether the OS is Linux or Windows",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? OSType { get; set; }
        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to EnableAutomaticUpdates on the machine",
        SerializedName = @"enableAutomaticUpdates",
        PossibleTypes = new [] { typeof(bool) })]
        bool? WindowConfigurationEnableAutomaticUpdate { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.",
        SerializedName = @"provisionVMAgent",
        PossibleTypes = new [] { typeof(bool) })]
        bool? WindowConfigurationProvisionVMAgent { get; set; }
        /// <summary>TimeZone for the virtual machine</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"TimeZone for the virtual machine",
        SerializedName = @"timeZone",
        PossibleTypes = new [] { typeof(string) })]
        string WindowConfigurationTimeZone { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.",
        SerializedName = @"publicKeys",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] WindowsConfigurationSshPublicKey { get; set; }

    }
    /// OsProfile - describes the configuration of the operating system and sets login data
    internal partial interface IVirtualMachinePropertiesOSProfileInternal

    {
        /// <summary>AdminPassword - admin password</summary>
        string AdminPassword { get; set; }
        /// <summary>AdminUsername - admin username</summary>
        string AdminUsername { get; set; }
        /// <summary>ComputerName - name of the compute</summary>
        string ComputerName { get; set; }
        /// <summary>
        /// LinuxConfiguration - linux specific configuration values for the virtual machine
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfiguration LinuxConfiguration { get; set; }
        /// <summary>
        /// DisablePasswordAuthentication - whether password authentication should be disabled
        /// </summary>
        bool? LinuxConfigurationDisablePasswordAuthentication { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        bool? LinuxConfigurationProvisionVMAgent { get; set; }
        /// <summary>SSH - contains settings related to ssh configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSsh LinuxConfigurationSsh { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[] LinuxConfigurationSshPublicKey { get; set; }
        /// <summary>OsType - string specifying whether the OS is Linux or Windows</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum? OSType { get; set; }
        /// <summary>Whether to EnableAutomaticUpdates on the machine</summary>
        bool? WindowConfigurationEnableAutomaticUpdate { get; set; }
        /// <summary>
        /// Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
        /// </summary>
        bool? WindowConfigurationProvisionVMAgent { get; set; }
        /// <summary>SSH Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSsh WindowConfigurationSsh { get; set; }
        /// <summary>TimeZone for the virtual machine</summary>
        string WindowConfigurationTimeZone { get; set; }
        /// <summary>Windows Configuration for the virtual machine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfiguration WindowsConfiguration { get; set; }
        /// <summary>
        /// PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[] WindowsConfigurationSshPublicKey { get; set; }

    }
}