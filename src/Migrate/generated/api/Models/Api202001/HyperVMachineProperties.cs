namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for machine properties.</summary>
    public partial class HyperVMachineProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal
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

        /// <summary>Apps and Roles of the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles AppsAndRole { get => (this._appsAndRole = this._appsAndRole ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles()); }

        /// <summary>Backing field for <see cref="BiosGuid" /> property.</summary>
        private string _biosGuid;

        /// <summary>Machine BIOS GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string BiosGuid { get => this._biosGuid; }

        /// <summary>Backing field for <see cref="BiosSerialNumber" /> property.</summary>
        private string _biosSerialNumber;

        /// <summary>Machine BIOS serial number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string BiosSerialNumber { get => this._biosSerialNumber; }

        /// <summary>Backing field for <see cref="ClusterFqdn" /> property.</summary>
        private string _clusterFqdn;

        /// <summary>Cluster FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ClusterFqdn { get => this._clusterFqdn; }

        /// <summary>Backing field for <see cref="ClusterId" /> property.</summary>
        private string _clusterId;

        /// <summary>Cluster ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ClusterId { get => this._clusterId; }

        /// <summary>Backing field for <see cref="CreatedTimestamp" /> property.</summary>
        private string _createdTimestamp;

        /// <summary>Timestamp marking machine creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string CreatedTimestamp { get => this._createdTimestamp; }

        /// <summary>Backing field for <see cref="Disk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk[] _disk;

        /// <summary>Disks attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk[] Disk { get => this._disk; }

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

        /// <summary>Backing field for <see cref="Generation" /> property.</summary>
        private int? _generation;

        /// <summary>Generation of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? Generation { get => this._generation; }

        /// <summary>Backing field for <see cref="GuestDetailsDiscoveryTimestamp" /> property.</summary>
        private global::System.DateTime? _guestDetailsDiscoveryTimestamp;

        /// <summary>The last time at which the Guest Details of machine was discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? GuestDetailsDiscoveryTimestamp { get => this._guestDetailsDiscoveryTimestamp; }

        /// <summary>Backing field for <see cref="GuestOSDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails _guestOSDetail;

        /// <summary>
        /// Operating System Details extracted from the guest by executing script inside the guest VM.
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

        /// <summary>Backing field for <see cref="HighAvailability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable? _highAvailability;

        /// <summary>Value indicating whether the VM is highly available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable? HighAvailability { get => this._highAvailability; }

        /// <summary>Backing field for <see cref="HostFqdn" /> property.</summary>
        private string _hostFqdn;

        /// <summary>Host FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostFqdn { get => this._hostFqdn; }

        /// <summary>Backing field for <see cref="HostId" /> property.</summary>
        private string _hostId;

        /// <summary>Host ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string HostId { get => this._hostId; }

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

        /// <summary>Backing field for <see cref="IsDynamicMemoryEnabled" /> property.</summary>
        private bool? _isDynamicMemoryEnabled;

        /// <summary>Value indicating whether dynamic memory is enabled for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsDynamicMemoryEnabled { get => this._isDynamicMemoryEnabled; }

        /// <summary>Backing field for <see cref="IsGuestDetailsDiscoveryInProgress" /> property.</summary>
        private bool? _isGuestDetailsDiscoveryInProgress;

        /// <summary>
        /// Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value
        /// is true.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsGuestDetailsDiscoveryInProgress { get => this._isGuestDetailsDiscoveryInProgress; }

        /// <summary>Backing field for <see cref="ManagementServerType" /> property.</summary>
        private string _managementServerType;

        /// <summary>Management server type of the machine. It is either Host or Cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ManagementServerType { get => this._managementServerType; }

        /// <summary>Backing field for <see cref="MaxMemoryMb" /> property.</summary>
        private int? _maxMemoryMb;

        /// <summary>Max memory of the virtual machine in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MaxMemoryMb { get => this._maxMemoryMb; }

        /// <summary>Internal Acessors for AllocatedMemoryInMb</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AllocatedMemoryInMb { get => this._allocatedMemoryInMb; set { {_allocatedMemoryInMb = value;} } }

        /// <summary>Internal Acessors for AppAndRoleApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Application; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Application = value; }

        /// <summary>Internal Acessors for AppAndRoleBizTalkServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleBizTalkServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).BizTalkServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).BizTalkServer = value; }

        /// <summary>Internal Acessors for AppAndRoleExchangeServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleExchangeServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).ExchangeServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).ExchangeServer = value; }

        /// <summary>Internal Acessors for AppAndRoleFeature</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Feature; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).Feature = value; }

        /// <summary>Internal Acessors for AppAndRoleOtherDatabase</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleOtherDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).OtherDatabase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).OtherDatabase = value; }

        /// <summary>Internal Acessors for AppAndRoleSharePointServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleSharePointServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SharePointServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SharePointServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSqlServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleSqlServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SqlServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SqlServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSystemCenter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleSystemCenter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SystemCenter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).SystemCenter = value; }

        /// <summary>Internal Acessors for AppAndRoleWebApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppAndRoleWebApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).WebApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal)AppsAndRole).WebApplication = value; }

        /// <summary>Internal Acessors for AppsAndRole</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.AppsAndRole { get => (this._appsAndRole = this._appsAndRole ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.AppsAndRoles()); set { {_appsAndRole = value;} } }

        /// <summary>Internal Acessors for BiosGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.BiosGuid { get => this._biosGuid; set { {_biosGuid = value;} } }

        /// <summary>Internal Acessors for BiosSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.BiosSerialNumber { get => this._biosSerialNumber; set { {_biosSerialNumber = value;} } }

        /// <summary>Internal Acessors for ClusterFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.ClusterFqdn { get => this._clusterFqdn; set { {_clusterFqdn = value;} } }

        /// <summary>Internal Acessors for ClusterId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.ClusterId { get => this._clusterId; set { {_clusterId = value;} } }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.CreatedTimestamp { get => this._createdTimestamp; set { {_createdTimestamp = value;} } }

        /// <summary>Internal Acessors for Disk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.Disk { get => this._disk; set { {_disk = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.Error { get => this._error; set { {_error = value;} } }

        /// <summary>Internal Acessors for Firmware</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.Firmware { get => this._firmware; set { {_firmware = value;} } }

        /// <summary>Internal Acessors for Generation</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.Generation { get => this._generation; set { {_generation = value;} } }

        /// <summary>Internal Acessors for GuestDetailsDiscoveryTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.GuestDetailsDiscoveryTimestamp { get => this._guestDetailsDiscoveryTimestamp; set { {_guestDetailsDiscoveryTimestamp = value;} } }

        /// <summary>Internal Acessors for GuestOSDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.GuestOSDetail { get => (this._guestOSDetail = this._guestOSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.GuestOSDetails()); set { {_guestOSDetail = value;} } }

        /// <summary>Internal Acessors for GuestOSDetailOsname</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.GuestOSDetailOsname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSName = value; }

        /// <summary>Internal Acessors for GuestOSDetailOsversion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.GuestOSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetailsInternal)GuestOSDetail).OSVersion = value; }

        /// <summary>Internal Acessors for HighAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.HighAvailability { get => this._highAvailability; set { {_highAvailability = value;} } }

        /// <summary>Internal Acessors for HostFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.HostFqdn { get => this._hostFqdn; set { {_hostFqdn = value;} } }

        /// <summary>Internal Acessors for HostId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.HostId { get => this._hostId; set { {_hostId = value;} } }

        /// <summary>Internal Acessors for InstanceUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.InstanceUuid { get => this._instanceUuid; set { {_instanceUuid = value;} } }

        /// <summary>Internal Acessors for IsDeleted</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.IsDeleted { get => this._isDeleted; set { {_isDeleted = value;} } }

        /// <summary>Internal Acessors for IsDynamicMemoryEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.IsDynamicMemoryEnabled { get => this._isDynamicMemoryEnabled; set { {_isDynamicMemoryEnabled = value;} } }

        /// <summary>Internal Acessors for IsGuestDetailsDiscoveryInProgress</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.IsGuestDetailsDiscoveryInProgress { get => this._isGuestDetailsDiscoveryInProgress; set { {_isGuestDetailsDiscoveryInProgress = value;} } }

        /// <summary>Internal Acessors for ManagementServerType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.ManagementServerType { get => this._managementServerType; set { {_managementServerType = value;} } }

        /// <summary>Internal Acessors for MaxMemoryMb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.MaxMemoryMb { get => this._maxMemoryMb; set { {_maxMemoryMb = value;} } }

        /// <summary>Internal Acessors for NetworkAdapter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.NetworkAdapter { get => this._networkAdapter; set { {_networkAdapter = value;} } }

        /// <summary>Internal Acessors for NumberOfApplication</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.NumberOfApplication { get => this._numberOfApplication; set { {_numberOfApplication = value;} } }

        /// <summary>Internal Acessors for NumberOfProcessorCore</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.NumberOfProcessorCore { get => this._numberOfProcessorCore; set { {_numberOfProcessorCore = value;} } }

        /// <summary>Internal Acessors for OperatingSystemDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.OperatingSystemDetail { get => (this._operatingSystemDetail = this._operatingSystemDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OperatingSystem()); set { {_operatingSystemDetail = value;} } }

        /// <summary>Internal Acessors for OperatingSystemDetailOSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.OperatingSystemDetailOSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSName = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.OperatingSystemDetailOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSType = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.OperatingSystemDetailOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemInternal)OperatingSystemDetail).OSVersion = value; }

        /// <summary>Internal Acessors for PowerStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.PowerStatus { get => this._powerStatus; set { {_powerStatus = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.UpdatedTimestamp { get => this._updatedTimestamp; set { {_updatedTimestamp = value;} } }

        /// <summary>Internal Acessors for VMConfigurationFileLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.VMConfigurationFileLocation { get => this._vMConfigurationFileLocation; set { {_vMConfigurationFileLocation = value;} } }

        /// <summary>Internal Acessors for VMFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.VMFqdn { get => this._vMFqdn; set { {_vMFqdn = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="NetworkAdapter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter[] _networkAdapter;

        /// <summary>Network adapters attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter[] NetworkAdapter { get => this._networkAdapter; }

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

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>VM version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="HyperVMachineProperties" /> instance.</summary>
        public HyperVMachineProperties()
        {

        }
    }
    /// Class for machine properties.
    public partial interface IHyperVMachineProperties :
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
        /// <summary>Machine BIOS GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Machine BIOS GUID.",
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
        /// <summary>Cluster FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Cluster FQDN/IPAddress.",
        SerializedName = @"clusterFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterFqdn { get;  }
        /// <summary>Cluster ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Cluster ARM ID.",
        SerializedName = @"clusterId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterId { get;  }
        /// <summary>Timestamp marking machine creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Timestamp marking machine creation.",
        SerializedName = @"createdTimestamp",
        PossibleTypes = new [] { typeof(string) })]
        string CreatedTimestamp { get;  }
        /// <summary>Disks attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Disks attached to the machine.",
        SerializedName = @"disks",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk[] Disk { get;  }
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
        /// <summary>Generation of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Generation of the virtual machine.",
        SerializedName = @"generation",
        PossibleTypes = new [] { typeof(int) })]
        int? Generation { get;  }
        /// <summary>The last time at which the Guest Details of machine was discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The last time at which the Guest Details of machine was discovered.",
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
        /// <summary>Value indicating whether the VM is highly available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value indicating whether the VM is highly available.",
        SerializedName = @"highAvailability",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable? HighAvailability { get;  }
        /// <summary>Host FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Host FQDN/IPAddress.",
        SerializedName = @"hostFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string HostFqdn { get;  }
        /// <summary>Host ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Host ARM ID.",
        SerializedName = @"hostId",
        PossibleTypes = new [] { typeof(string) })]
        string HostId { get;  }
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
        /// <summary>Value indicating whether dynamic memory is enabled for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value indicating whether dynamic memory is enabled for the VM.",
        SerializedName = @"isDynamicMemoryEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDynamicMemoryEnabled { get;  }
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
        /// <summary>Management server type of the machine. It is either Host or Cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Management server type of the machine. It is either Host or Cluster.",
        SerializedName = @"managementServerType",
        PossibleTypes = new [] { typeof(string) })]
        string ManagementServerType { get;  }
        /// <summary>Max memory of the virtual machine in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Max memory of the virtual machine in MB.",
        SerializedName = @"maxMemoryMB",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxMemoryMb { get;  }
        /// <summary>Network adapters attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Network adapters attached to the machine.",
        SerializedName = @"networkAdapters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter[] NetworkAdapter { get;  }
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
        /// <summary>VM version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"VM version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// Class for machine properties.
    internal partial interface IHyperVMachinePropertiesInternal

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
        /// <summary>Apps and Roles of the VM.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles AppsAndRole { get; set; }
        /// <summary>Machine BIOS GUID.</summary>
        string BiosGuid { get; set; }
        /// <summary>Machine BIOS serial number.</summary>
        string BiosSerialNumber { get; set; }
        /// <summary>Cluster FQDN/IPAddress.</summary>
        string ClusterFqdn { get; set; }
        /// <summary>Cluster ARM ID.</summary>
        string ClusterId { get; set; }
        /// <summary>Timestamp marking machine creation.</summary>
        string CreatedTimestamp { get; set; }
        /// <summary>Disks attached to the machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk[] Disk { get; set; }
        /// <summary>Display name of the machine.</summary>
        string DisplayName { get; set; }
        /// <summary>Errors for machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get; set; }
        /// <summary>Firmware of the machine.</summary>
        string Firmware { get; set; }
        /// <summary>Generation of the virtual machine.</summary>
        int? Generation { get; set; }
        /// <summary>The last time at which the Guest Details of machine was discovered.</summary>
        global::System.DateTime? GuestDetailsDiscoveryTimestamp { get; set; }
        /// <summary>
        /// Operating System Details extracted from the guest by executing script inside the guest VM.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails GuestOSDetail { get; set; }
        /// <summary>Name of the operating system.</summary>
        string GuestOSDetailOsname { get; set; }
        /// <summary>Type of the operating system.</summary>
        string GuestOSDetailOstype { get; set; }
        /// <summary>Version of the operating system.</summary>
        string GuestOSDetailOsversion { get; set; }
        /// <summary>Value indicating whether the VM is highly available.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable? HighAvailability { get; set; }
        /// <summary>Host FQDN/IPAddress.</summary>
        string HostFqdn { get; set; }
        /// <summary>Host ARM ID.</summary>
        string HostId { get; set; }
        /// <summary>On-premise Instance UUID of the machine.</summary>
        string InstanceUuid { get; set; }
        /// <summary>Value indicating whether VM is deleted.</summary>
        bool? IsDeleted { get; set; }
        /// <summary>Value indicating whether dynamic memory is enabled for the VM.</summary>
        bool? IsDynamicMemoryEnabled { get; set; }
        /// <summary>
        /// Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value
        /// is true.
        /// </summary>
        bool? IsGuestDetailsDiscoveryInProgress { get; set; }
        /// <summary>Management server type of the machine. It is either Host or Cluster.</summary>
        string ManagementServerType { get; set; }
        /// <summary>Max memory of the virtual machine in MB.</summary>
        int? MaxMemoryMb { get; set; }
        /// <summary>Network adapters attached to the machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter[] NetworkAdapter { get; set; }
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
        /// <summary>Root location of the VM configuration file.</summary>
        string VMConfigurationFileLocation { get; set; }
        /// <summary>Machine FQDN.</summary>
        string VMFqdn { get; set; }
        /// <summary>VM version.</summary>
        string Version { get; set; }

    }
}