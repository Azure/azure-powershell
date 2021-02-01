namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for machine properties.</summary>
    public partial class VMwareMachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllocatedMemoryInMb" /> property.</summary>
        private double? _allocatedMemoryInMb;

        /// <summary>Allocated Memory in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public double? AllocatedMemoryInMb { get => this._allocatedMemoryInMb; }

        /// <summary>Applications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] AppAndRoleApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Application; }

        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] AppAndRoleBizTalkServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).BizTalkServer; }

        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] AppAndRoleExchangeServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).ExchangeServer; }

        /// <summary>Features of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] AppAndRoleFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Feature; }

        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] AppAndRoleOtherDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).OtherDatabase; }

        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] AppAndRoleSharePointServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SharePointServer; }

        /// <summary>SQLServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] AppAndRoleSqlServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SqlServer; }

        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] AppAndRoleSystemCenter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SystemCenter; }

        /// <summary>WebApplications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] AppAndRoleWebApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).WebApplication; }

        /// <summary>Backing field for <see cref="AppsAndRole" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles _appsAndRole;

        /// <summary>Apps And Roles of the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles AppsAndRole { get => (this._appsAndRole = this._appsAndRole ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles()); }

        /// <summary>Backing field for <see cref="BiosGuid" /> property.</summary>
        private string _biosGuid;

        /// <summary>BIOS GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string BiosGuid { get => this._biosGuid; }

        /// <summary>Backing field for <see cref="BiosSerialNumber" /> property.</summary>
        private string _biosSerialNumber;

        /// <summary>Machine BIOS serial number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string BiosSerialNumber { get => this._biosSerialNumber; }

        /// <summary>Backing field for <see cref="ChangeTrackingEnabled" /> property.</summary>
        private bool? _changeTrackingEnabled;

        /// <summary>Value indicating whether change tracking is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? ChangeTrackingEnabled { get => this._changeTrackingEnabled; }

        /// <summary>Backing field for <see cref="ChangeTrackingSupported" /> property.</summary>
        private bool? _changeTrackingSupported;

        /// <summary>Value indicating whether change tracking is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? ChangeTrackingSupported { get => this._changeTrackingSupported; }

        /// <summary>Backing field for <see cref="CreatedTimestamp" /> property.</summary>
        private string _createdTimestamp;

        /// <summary>Timestamp marking machine creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CreatedTimestamp { get => this._createdTimestamp; }

        /// <summary>Backing field for <see cref="DataCenterScope" /> property.</summary>
        private string _dataCenterScope;

        /// <summary>Scope of the data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DataCenterScope { get => this._dataCenterScope; }

        /// <summary>Backing field for <see cref="DependencyMapping" /> property.</summary>
        private string _dependencyMapping;

        /// <summary>If dependency mapping feature is enabled or not for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DependencyMapping { get => this._dependencyMapping; }

        /// <summary>Backing field for <see cref="DependencyMappingStartTime" /> property.</summary>
        private global::System.DateTime? _dependencyMappingStartTime;

        /// <summary>When dependency mapping collection is last started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? DependencyMappingStartTime { get => this._dependencyMappingStartTime; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>User description of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="Disk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk[] _disk;

        /// <summary>Disks attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk[] Disk { get => this._disk; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] _error;

        /// <summary>Errors for machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => this._error; }

        /// <summary>Backing field for <see cref="Firmware" /> property.</summary>
        private string _firmware;

        /// <summary>Firmware of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Firmware { get => this._firmware; }

        /// <summary>Backing field for <see cref="GuestDetailsDiscoveryTimestamp" /> property.</summary>
        private global::System.DateTime? _guestDetailsDiscoveryTimestamp;

        /// <summary>
        /// The last time at which the Guest Details was discovered or the error while discovering guest details based discovery of
        /// the machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? GuestDetailsDiscoveryTimestamp { get => this._guestDetailsDiscoveryTimestamp; }

        /// <summary>Backing field for <see cref="GuestOSDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails _guestOSDetail;

        /// <summary>
        /// Operating System Details extracted from the guest bu executing script inside the guest VM.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails GuestOSDetail { get => (this._guestOSDetail = this._guestOSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.GuestOSDetails()); }

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOsname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSName; }

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSType = value ?? null; }

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSVersion; }

        /// <summary>Backing field for <see cref="HostInMaintenanceMode" /> property.</summary>
        private bool? _hostInMaintenanceMode;

        /// <summary>Indicates whether the host is in maintenance mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? HostInMaintenanceMode { get => this._hostInMaintenanceMode; }

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string _hostName;

        /// <summary>The host name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostName { get => this._hostName; }

        /// <summary>Backing field for <see cref="HostPowerState" /> property.</summary>
        private string _hostPowerState;

        /// <summary>The host power state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostPowerState { get => this._hostPowerState; }

        /// <summary>Backing field for <see cref="HostVersion" /> property.</summary>
        private string _hostVersion;

        /// <summary>The host version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostVersion { get => this._hostVersion; }

        /// <summary>Backing field for <see cref="InstanceUuid" /> property.</summary>
        private string _instanceUuid;

        /// <summary>On-premise Instance UUID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceUuid { get => this._instanceUuid; }

        /// <summary>Backing field for <see cref="IsDeleted" /> property.</summary>
        private bool? _isDeleted;

        /// <summary>Value indicating whether VM is deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsDeleted { get => this._isDeleted; }

        /// <summary>Backing field for <see cref="IsGuestDetailsDiscoveryInProgress" /> property.</summary>
        private bool? _isGuestDetailsDiscoveryInProgress;

        /// <summary>
        /// Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value
        /// is true.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsGuestDetailsDiscoveryInProgress { get => this._isGuestDetailsDiscoveryInProgress; }

        /// <summary>Backing field for <see cref="MaxSnapshot" /> property.</summary>
        private int? _maxSnapshot;

        /// <summary>Maximum number of snapshots for the VM. Default value is -1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MaxSnapshot { get => this._maxSnapshot; }

        /// <summary>Internal Acessors for AllocatedMemoryInMb</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AllocatedMemoryInMb { get => this._allocatedMemoryInMb; set { {_allocatedMemoryInMb = value;} } }

        /// <summary>Internal Acessors for AppAndRoleApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Application; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Application = value; }

        /// <summary>Internal Acessors for AppAndRoleBizTalkServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleBizTalkServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).BizTalkServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).BizTalkServer = value; }

        /// <summary>Internal Acessors for AppAndRoleExchangeServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleExchangeServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).ExchangeServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).ExchangeServer = value; }

        /// <summary>Internal Acessors for AppAndRoleFeature</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Feature; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Feature = value; }

        /// <summary>Internal Acessors for AppAndRoleOtherDatabase</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleOtherDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).OtherDatabase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).OtherDatabase = value; }

        /// <summary>Internal Acessors for AppAndRoleSharePointServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleSharePointServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SharePointServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SharePointServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSqlServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleSqlServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SqlServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SqlServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSystemCenter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleSystemCenter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SystemCenter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SystemCenter = value; }

        /// <summary>Internal Acessors for AppAndRoleWebApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppAndRoleWebApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).WebApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).WebApplication = value; }

        /// <summary>Internal Acessors for AppsAndRole</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.AppsAndRole { get => (this._appsAndRole = this._appsAndRole ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles()); set { {_appsAndRole = value;} } }

        /// <summary>Internal Acessors for BiosGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.BiosGuid { get => this._biosGuid; set { {_biosGuid = value;} } }

        /// <summary>Internal Acessors for BiosSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.BiosSerialNumber { get => this._biosSerialNumber; set { {_biosSerialNumber = value;} } }

        /// <summary>Internal Acessors for ChangeTrackingEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.ChangeTrackingEnabled { get => this._changeTrackingEnabled; set { {_changeTrackingEnabled = value;} } }

        /// <summary>Internal Acessors for ChangeTrackingSupported</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.ChangeTrackingSupported { get => this._changeTrackingSupported; set { {_changeTrackingSupported = value;} } }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.CreatedTimestamp { get => this._createdTimestamp; set { {_createdTimestamp = value;} } }

        /// <summary>Internal Acessors for DataCenterScope</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.DataCenterScope { get => this._dataCenterScope; set { {_dataCenterScope = value;} } }

        /// <summary>Internal Acessors for DependencyMapping</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.DependencyMapping { get => this._dependencyMapping; set { {_dependencyMapping = value;} } }

        /// <summary>Internal Acessors for DependencyMappingStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.DependencyMappingStartTime { get => this._dependencyMappingStartTime; set { {_dependencyMappingStartTime = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for Disk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.Disk { get => this._disk; set { {_disk = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.Error { get => this._error; set { {_error = value;} } }

        /// <summary>Internal Acessors for Firmware</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.Firmware { get => this._firmware; set { {_firmware = value;} } }

        /// <summary>Internal Acessors for GuestDetailsDiscoveryTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.GuestDetailsDiscoveryTimestamp { get => this._guestDetailsDiscoveryTimestamp; set { {_guestDetailsDiscoveryTimestamp = value;} } }

        /// <summary>Internal Acessors for GuestOSDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.GuestOSDetail { get => (this._guestOSDetail = this._guestOSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.GuestOSDetails()); set { {_guestOSDetail = value;} } }

        /// <summary>Internal Acessors for GuestOSDetailOsname</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.GuestOSDetailOsname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSName = value; }

        /// <summary>Internal Acessors for GuestOSDetailOsversion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.GuestOSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSVersion = value; }

        /// <summary>Internal Acessors for HostInMaintenanceMode</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.HostInMaintenanceMode { get => this._hostInMaintenanceMode; set { {_hostInMaintenanceMode = value;} } }

        /// <summary>Internal Acessors for HostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.HostName { get => this._hostName; set { {_hostName = value;} } }

        /// <summary>Internal Acessors for HostPowerState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.HostPowerState { get => this._hostPowerState; set { {_hostPowerState = value;} } }

        /// <summary>Internal Acessors for HostVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.HostVersion { get => this._hostVersion; set { {_hostVersion = value;} } }

        /// <summary>Internal Acessors for InstanceUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.InstanceUuid { get => this._instanceUuid; set { {_instanceUuid = value;} } }

        /// <summary>Internal Acessors for IsDeleted</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.IsDeleted { get => this._isDeleted; set { {_isDeleted = value;} } }

        /// <summary>Internal Acessors for IsGuestDetailsDiscoveryInProgress</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.IsGuestDetailsDiscoveryInProgress { get => this._isGuestDetailsDiscoveryInProgress; set { {_isGuestDetailsDiscoveryInProgress = value;} } }

        /// <summary>Internal Acessors for MaxSnapshot</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.MaxSnapshot { get => this._maxSnapshot; set { {_maxSnapshot = value;} } }

        /// <summary>Internal Acessors for NetworkAdapter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.NetworkAdapter { get => this._networkAdapter; set { {_networkAdapter = value;} } }

        /// <summary>Internal Acessors for NumberOfApplication</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.NumberOfApplication { get => this._numberOfApplication; set { {_numberOfApplication = value;} } }

        /// <summary>Internal Acessors for NumberOfProcessorCore</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.NumberOfProcessorCore { get => this._numberOfProcessorCore; set { {_numberOfProcessorCore = value;} } }

        /// <summary>Internal Acessors for OperatingSystemDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.OperatingSystemDetail { get => (this._operatingSystemDetail = this._operatingSystemDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperatingSystem()); set { {_operatingSystemDetail = value;} } }

        /// <summary>Internal Acessors for OperatingSystemDetailOSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.OperatingSystemDetailOSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSName = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.OperatingSystemDetailOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSType = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.OperatingSystemDetailOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSVersion = value; }

        /// <summary>Internal Acessors for PowerStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.PowerStatus { get => this._powerStatus; set { {_powerStatus = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.UpdatedTimestamp { get => this._updatedTimestamp; set { {_updatedTimestamp = value;} } }

        /// <summary>Internal Acessors for VCenterFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.VCenterFqdn { get => this._vCenterFqdn; set { {_vCenterFqdn = value;} } }

        /// <summary>Internal Acessors for VCenterId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.VCenterId { get => this._vCenterId; set { {_vCenterId = value;} } }

        /// <summary>Internal Acessors for VMConfigurationFileLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.VMConfigurationFileLocation { get => this._vMConfigurationFileLocation; set { {_vMConfigurationFileLocation = value;} } }

        /// <summary>Internal Acessors for VMFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.VMFqdn { get => this._vMFqdn; set { {_vMFqdn = value;} } }

        /// <summary>Internal Acessors for VMwareToolsStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal.VMwareToolsStatus { get => this._vMwareToolsStatus; set { {_vMwareToolsStatus = value;} } }

        /// <summary>Backing field for <see cref="NetworkAdapter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter[] _networkAdapter;

        /// <summary>Network adapters attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter[] NetworkAdapter { get => this._networkAdapter; }

        /// <summary>Backing field for <see cref="NumberOfApplication" /> property.</summary>
        private int? _numberOfApplication;

        /// <summary>Number of applications installed in the guest VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? NumberOfApplication { get => this._numberOfApplication; }

        /// <summary>Backing field for <see cref="NumberOfProcessorCore" /> property.</summary>
        private int? _numberOfProcessorCore;

        /// <summary>Number of Processor Cores allocated for the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? NumberOfProcessorCore { get => this._numberOfProcessorCore; }

        /// <summary>Backing field for <see cref="OperatingSystemDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem _operatingSystemDetail;

        /// <summary>Operating System Details installed on the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem OperatingSystemDetail { get => (this._operatingSystemDetail = this._operatingSystemDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperatingSystem()); }

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSName; }

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSType; }

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSVersion; }

        /// <summary>Backing field for <see cref="PowerStatus" /> property.</summary>
        private string _powerStatus;

        /// <summary>Machine power status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PowerStatus { get => this._powerStatus; }

        /// <summary>Backing field for <see cref="UpdatedTimestamp" /> property.</summary>
        private string _updatedTimestamp;

        /// <summary>Timestamp marking last updated on the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string UpdatedTimestamp { get => this._updatedTimestamp; }

        /// <summary>Backing field for <see cref="VCenterFqdn" /> property.</summary>
        private string _vCenterFqdn;

        /// <summary>VCenter FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VCenterFqdn { get => this._vCenterFqdn; }

        /// <summary>Backing field for <see cref="VCenterId" /> property.</summary>
        private string _vCenterId;

        /// <summary>VCenter ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VCenterId { get => this._vCenterId; }

        /// <summary>Backing field for <see cref="VMConfigurationFileLocation" /> property.</summary>
        private string _vMConfigurationFileLocation;

        /// <summary>Root location of the VM configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMConfigurationFileLocation { get => this._vMConfigurationFileLocation; }

        /// <summary>Backing field for <see cref="VMFqdn" /> property.</summary>
        private string _vMFqdn;

        /// <summary>Machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMFqdn { get => this._vMFqdn; }

        /// <summary>Backing field for <see cref="VMwareToolsStatus" /> property.</summary>
        private string _vMwareToolsStatus;

        /// <summary>VMware tools status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string VMwareToolsStatus { get => this._vMwareToolsStatus; }

        /// <summary>Creates an new <see cref="VMwareMachineProperties" /> instance.</summary>
        public VMwareMachineProperties()
        {

        }
    }
    /// Class for machine properties.
    public partial interface IVMwareMachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Allocated Memory in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Allocated Memory in MB.",
        SerializedName = @"allocatedMemoryInMB",
        PossibleTypes = new [] { typeof(double) })]
        double? AllocatedMemoryInMb { get;  }
        /// <summary>Applications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Applications of the AppsAndRoles.",
        SerializedName = @"applications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] AppAndRoleApplication { get;  }
        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"BizTalkServers of the AppsAndRoles.",
        SerializedName = @"bizTalkServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] AppAndRoleBizTalkServer { get;  }
        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ExchangeServers of the AppsAndRoles.",
        SerializedName = @"exchangeServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] AppAndRoleExchangeServer { get;  }
        /// <summary>Features of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Features of the AppsAndRoles.",
        SerializedName = @"features",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] AppAndRoleFeature { get;  }
        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"OtherDatabaseServers of the AppsAndRoles.",
        SerializedName = @"otherDatabases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] AppAndRoleOtherDatabase { get;  }
        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SharePointServers of the AppsAndRoles.",
        SerializedName = @"sharePointServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] AppAndRoleSharePointServer { get;  }
        /// <summary>SQLServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SQLServers of the AppsAndRoles.",
        SerializedName = @"sqlServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] AppAndRoleSqlServer { get;  }
        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SystemCenters of the AppsAndRoles.",
        SerializedName = @"systemCenters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] AppAndRoleSystemCenter { get;  }
        /// <summary>WebApplications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"WebApplications of the AppsAndRoles.",
        SerializedName = @"webApplications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] AppAndRoleWebApplication { get;  }
        /// <summary>BIOS GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"BIOS GUID.",
        SerializedName = @"biosGuid",
        PossibleTypes = new [] { typeof(string) })]
        string BiosGuid { get;  }
        /// <summary>Machine BIOS serial number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Machine BIOS serial number.",
        SerializedName = @"biosSerialNumber",
        PossibleTypes = new [] { typeof(string) })]
        string BiosSerialNumber { get;  }
        /// <summary>Value indicating whether change tracking is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value indicating whether change tracking is enabled.",
        SerializedName = @"changeTrackingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ChangeTrackingEnabled { get;  }
        /// <summary>Value indicating whether change tracking is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value indicating whether change tracking is supported.",
        SerializedName = @"changeTrackingSupported",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ChangeTrackingSupported { get;  }
        /// <summary>Timestamp marking machine creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking machine creation.",
        SerializedName = @"createdTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedTimestamp { get;  }
        /// <summary>Scope of the data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Scope of the data center.",
        SerializedName = @"dataCenterScope",
        PossibleTypes = new [] { typeof(string) })]
        string DataCenterScope { get;  }
        /// <summary>If dependency mapping feature is enabled or not for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"If dependency mapping feature is enabled or not for the VM.",
        SerializedName = @"dependencyMapping",
        PossibleTypes = new [] { typeof(string) })]
        string DependencyMapping { get;  }
        /// <summary>When dependency mapping collection is last started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"When dependency mapping collection is last started.",
        SerializedName = @"dependencyMappingStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DependencyMappingStartTime { get;  }
        /// <summary>User description of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"User description of the machine.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Disks attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Disks attached to the machine.",
        SerializedName = @"disks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk[] Disk { get;  }
        /// <summary>Display name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name of the machine.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Errors for machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Errors for machine.",
        SerializedName = @"errors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get;  }
        /// <summary>Firmware of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Firmware of the machine.",
        SerializedName = @"firmware",
        PossibleTypes = new [] { typeof(string) })]
        string Firmware { get;  }
        /// <summary>
        /// The last time at which the Guest Details was discovered or the error while discovering guest details based discovery of
        /// the machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The last time at which the Guest Details was discovered or the error while discovering guest details based discovery of the machine.",
        SerializedName = @"guestDetailsDiscoveryTimestamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? GuestDetailsDiscoveryTimestamp { get;  }
        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the operating system.",
        SerializedName = @"osName",
        PossibleTypes = new [] { typeof(string) })]
        string GuestOSDetailOsname { get;  }
        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of the operating system.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string GuestOSDetailOstype { get; set; }
        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the operating system.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string GuestOSDetailOsversion { get;  }
        /// <summary>Indicates whether the host is in maintenance mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates whether the host is in maintenance mode.",
        SerializedName = @"hostInMaintenanceMode",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HostInMaintenanceMode { get;  }
        /// <summary>The host name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The host name.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get;  }
        /// <summary>The host power state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The host power state.",
        SerializedName = @"hostPowerState",
        PossibleTypes = new [] { typeof(string) })]
        string HostPowerState { get;  }
        /// <summary>The host version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The host version.",
        SerializedName = @"hostVersion",
        PossibleTypes = new [] { typeof(string) })]
        string HostVersion { get;  }
        /// <summary>On-premise Instance UUID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"On-premise Instance UUID of the machine.",
        SerializedName = @"instanceUuid",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceUuid { get;  }
        /// <summary>Value indicating whether VM is deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value indicating whether VM is deleted.",
        SerializedName = @"isDeleted",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDeleted { get;  }
        /// <summary>
        /// Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value
        /// is true.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value is true.",
        SerializedName = @"isGuestDetailsDiscoveryInProgress",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsGuestDetailsDiscoveryInProgress { get;  }
        /// <summary>Maximum number of snapshots for the VM. Default value is -1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Maximum number of snapshots for the VM. Default value is -1.",
        SerializedName = @"maxSnapshots",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxSnapshot { get;  }
        /// <summary>Network adapters attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Network adapters attached to the machine.",
        SerializedName = @"networkAdapters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter[] NetworkAdapter { get;  }
        /// <summary>Number of applications installed in the guest VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of applications installed in the guest VM.",
        SerializedName = @"numberOfApplications",
        PossibleTypes = new [] { typeof(int) })]
        int? NumberOfApplication { get;  }
        /// <summary>Number of Processor Cores allocated for the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of Processor Cores allocated for the machine.",
        SerializedName = @"numberOfProcessorCore",
        PossibleTypes = new [] { typeof(int) })]
        int? NumberOfProcessorCore { get;  }
        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the operating system.",
        SerializedName = @"osName",
        PossibleTypes = new [] { typeof(string) })]
        string OperatingSystemDetailOSName { get;  }
        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of the operating system.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OperatingSystemDetailOSType { get;  }
        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the operating system.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OperatingSystemDetailOSVersion { get;  }
        /// <summary>Machine power status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Machine power status.",
        SerializedName = @"powerStatus",
        PossibleTypes = new [] { typeof(string) })]
        string PowerStatus { get;  }
        /// <summary>Timestamp marking last updated on the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking last updated on the machine.",
        SerializedName = @"updatedTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatedTimestamp { get;  }
        /// <summary>VCenter FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"VCenter FQDN/IPAddress.",
        SerializedName = @"vCenterFQDN",
        PossibleTypes = new [] { typeof(string) })]
        string VCenterFqdn { get;  }
        /// <summary>VCenter ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"VCenter ARM ID.",
        SerializedName = @"vCenterId",
        PossibleTypes = new [] { typeof(string) })]
        string VCenterId { get;  }
        /// <summary>Root location of the VM configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Root location of the VM configuration file.",
        SerializedName = @"vmConfigurationFileLocation",
        PossibleTypes = new [] { typeof(string) })]
        string VMConfigurationFileLocation { get;  }
        /// <summary>Machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Machine FQDN.",
        SerializedName = @"vmFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string VMFqdn { get;  }
        /// <summary>VMware tools status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"VMware tools status.",
        SerializedName = @"vMwareToolsStatus",
        PossibleTypes = new [] { typeof(string) })]
        string VMwareToolsStatus { get;  }

    }
    /// Class for machine properties.
    internal partial interface IVMwareMachinePropertiesInternal

    {
        /// <summary>Allocated Memory in MB.</summary>
        double? AllocatedMemoryInMb { get; set; }
        /// <summary>Applications of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] AppAndRoleApplication { get; set; }
        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] AppAndRoleBizTalkServer { get; set; }
        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] AppAndRoleExchangeServer { get; set; }
        /// <summary>Features of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] AppAndRoleFeature { get; set; }
        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] AppAndRoleOtherDatabase { get; set; }
        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] AppAndRoleSharePointServer { get; set; }
        /// <summary>SQLServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] AppAndRoleSqlServer { get; set; }
        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] AppAndRoleSystemCenter { get; set; }
        /// <summary>WebApplications of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] AppAndRoleWebApplication { get; set; }
        /// <summary>Apps And Roles of the VM.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles AppsAndRole { get; set; }
        /// <summary>BIOS GUID.</summary>
        string BiosGuid { get; set; }
        /// <summary>Machine BIOS serial number.</summary>
        string BiosSerialNumber { get; set; }
        /// <summary>Value indicating whether change tracking is enabled.</summary>
        bool? ChangeTrackingEnabled { get; set; }
        /// <summary>Value indicating whether change tracking is supported.</summary>
        bool? ChangeTrackingSupported { get; set; }
        /// <summary>Timestamp marking machine creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Scope of the data center.</summary>
        string DataCenterScope { get; set; }
        /// <summary>If dependency mapping feature is enabled or not for the VM.</summary>
        string DependencyMapping { get; set; }
        /// <summary>When dependency mapping collection is last started.</summary>
        global::System.DateTime? DependencyMappingStartTime { get; set; }
        /// <summary>User description of the machine.</summary>
        string Description { get; set; }
        /// <summary>Disks attached to the machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk[] Disk { get; set; }
        /// <summary>Display name of the machine.</summary>
        string DisplayName { get; set; }
        /// <summary>Errors for machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get; set; }
        /// <summary>Firmware of the machine.</summary>
        string Firmware { get; set; }
        /// <summary>
        /// The last time at which the Guest Details was discovered or the error while discovering guest details based discovery of
        /// the machine.
        /// </summary>
        global::System.DateTime? GuestDetailsDiscoveryTimestamp { get; set; }
        /// <summary>
        /// Operating System Details extracted from the guest bu executing script inside the guest VM.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails GuestOSDetail { get; set; }
        /// <summary>Name of the operating system.</summary>
        string GuestOSDetailOsname { get; set; }
        /// <summary>Type of the operating system.</summary>
        string GuestOSDetailOstype { get; set; }
        /// <summary>Version of the operating system.</summary>
        string GuestOSDetailOsversion { get; set; }
        /// <summary>Indicates whether the host is in maintenance mode.</summary>
        bool? HostInMaintenanceMode { get; set; }
        /// <summary>The host name.</summary>
        string HostName { get; set; }
        /// <summary>The host power state.</summary>
        string HostPowerState { get; set; }
        /// <summary>The host version.</summary>
        string HostVersion { get; set; }
        /// <summary>On-premise Instance UUID of the machine.</summary>
        string InstanceUuid { get; set; }
        /// <summary>Value indicating whether VM is deleted.</summary>
        bool? IsDeleted { get; set; }
        /// <summary>
        /// Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value
        /// is true.
        /// </summary>
        bool? IsGuestDetailsDiscoveryInProgress { get; set; }
        /// <summary>Maximum number of snapshots for the VM. Default value is -1.</summary>
        int? MaxSnapshot { get; set; }
        /// <summary>Network adapters attached to the machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter[] NetworkAdapter { get; set; }
        /// <summary>Number of applications installed in the guest VM.</summary>
        int? NumberOfApplication { get; set; }
        /// <summary>Number of Processor Cores allocated for the machine.</summary>
        int? NumberOfProcessorCore { get; set; }
        /// <summary>Operating System Details installed on the machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem OperatingSystemDetail { get; set; }
        /// <summary>Name of the operating system.</summary>
        string OperatingSystemDetailOSName { get; set; }
        /// <summary>Type of the operating system.</summary>
        string OperatingSystemDetailOSType { get; set; }
        /// <summary>Version of the operating system.</summary>
        string OperatingSystemDetailOSVersion { get; set; }
        /// <summary>Machine power status.</summary>
        string PowerStatus { get; set; }
        /// <summary>Timestamp marking last updated on the machine.</summary>
        string UpdatedTimestamp { get; set; }
        /// <summary>VCenter FQDN/IPAddress.</summary>
        string VCenterFqdn { get; set; }
        /// <summary>VCenter ARM ID.</summary>
        string VCenterId { get; set; }
        /// <summary>Root location of the VM configuration file.</summary>
        string VMConfigurationFileLocation { get; set; }
        /// <summary>Machine FQDN.</summary>
        string VMFqdn { get; set; }
        /// <summary>VMware tools status.</summary>
        string VMwareToolsStatus { get; set; }

    }
}