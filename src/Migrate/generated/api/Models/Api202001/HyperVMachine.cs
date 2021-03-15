namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Machine REST Resource.</summary>
    public partial class HyperVMachine :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachine,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal
    {

        /// <summary>Allocated Memory in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public double? AllocatedMemoryInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AllocatedMemoryInMb; }

        /// <summary>Applications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] AppAndRoleApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleApplication; }

        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] AppAndRoleBizTalkServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleBizTalkServer; }

        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] AppAndRoleExchangeServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleExchangeServer; }

        /// <summary>Features of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] AppAndRoleFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleFeature; }

        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] AppAndRoleOtherDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleOtherDatabase; }

        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] AppAndRoleSharePointServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSharePointServer; }

        /// <summary>SQLServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] AppAndRoleSqlServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSqlServer; }

        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] AppAndRoleSystemCenter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSystemCenter; }

        /// <summary>WebApplications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] AppAndRoleWebApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleWebApplication; }

        /// <summary>Machine BIOS GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string BiosGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).BiosGuid; }

        /// <summary>Machine BIOS serial number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string BiosSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).BiosSerialNumber; }

        /// <summary>Cluster FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ClusterFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ClusterFqdn; }

        /// <summary>Cluster ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ClusterId; }

        /// <summary>Timestamp marking machine creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).CreatedTimestamp; }

        /// <summary>Disks attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk[] Disk { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Disk; }

        /// <summary>Display name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).DisplayName; }

        /// <summary>Errors for machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Error; }

        /// <summary>Firmware of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Firmware { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Firmware; }

        /// <summary>Generation of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? Generation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Generation; }

        /// <summary>The last time at which the Guest Details of machine was discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? GuestDetailsDiscoveryTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestDetailsDiscoveryTimestamp; }

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOsname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOsname; }

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOstype; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOstype = value ?? null; }

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOsversion; }

        /// <summary>Value indicating whether the VM is highly available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable? HighAvailability { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HighAvailability; }

        /// <summary>Host FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string HostFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HostFqdn; }

        /// <summary>Host ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string HostId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HostId; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>On-premise Instance UUID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string InstanceUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).InstanceUuid; }

        /// <summary>Value indicating whether VM is deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? IsDeleted { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsDeleted; }

        /// <summary>Value indicating whether dynamic memory is enabled for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? IsDynamicMemoryEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsDynamicMemoryEnabled; }

        /// <summary>
        /// Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value
        /// is true.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? IsGuestDetailsDiscoveryInProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsGuestDetailsDiscoveryInProgress; }

        /// <summary>Management server type of the machine. It is either Host or Cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ManagementServerType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ManagementServerType; }

        /// <summary>Max memory of the virtual machine in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? MaxMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).MaxMemoryMb; }

        /// <summary>Internal Acessors for AllocatedMemoryInMb</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AllocatedMemoryInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AllocatedMemoryInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AllocatedMemoryInMb = value; }

        /// <summary>Internal Acessors for AppAndRoleApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleApplication = value; }

        /// <summary>Internal Acessors for AppAndRoleBizTalkServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleBizTalkServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleBizTalkServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleBizTalkServer = value; }

        /// <summary>Internal Acessors for AppAndRoleExchangeServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleExchangeServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleExchangeServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleExchangeServer = value; }

        /// <summary>Internal Acessors for AppAndRoleFeature</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleFeature; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleFeature = value; }

        /// <summary>Internal Acessors for AppAndRoleOtherDatabase</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleOtherDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleOtherDatabase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleOtherDatabase = value; }

        /// <summary>Internal Acessors for AppAndRoleSharePointServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleSharePointServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSharePointServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSharePointServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSqlServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleSqlServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSqlServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSqlServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSystemCenter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleSystemCenter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSystemCenter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleSystemCenter = value; }

        /// <summary>Internal Acessors for AppAndRoleWebApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppAndRoleWebApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleWebApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppAndRoleWebApplication = value; }

        /// <summary>Internal Acessors for AppsAndRole</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.AppsAndRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppsAndRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).AppsAndRole = value; }

        /// <summary>Internal Acessors for BiosGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.BiosGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).BiosGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).BiosGuid = value; }

        /// <summary>Internal Acessors for BiosSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.BiosSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).BiosSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).BiosSerialNumber = value; }

        /// <summary>Internal Acessors for ClusterFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.ClusterFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ClusterFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ClusterFqdn = value; }

        /// <summary>Internal Acessors for ClusterId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ClusterId = value; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).CreatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).CreatedTimestamp = value; }

        /// <summary>Internal Acessors for Disk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVDisk[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Disk { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Disk; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Disk = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Error = value; }

        /// <summary>Internal Acessors for Firmware</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Firmware { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Firmware; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Firmware = value; }

        /// <summary>Internal Acessors for Generation</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Generation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Generation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Generation = value; }

        /// <summary>Internal Acessors for GuestDetailsDiscoveryTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.GuestDetailsDiscoveryTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestDetailsDiscoveryTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestDetailsDiscoveryTimestamp = value; }

        /// <summary>Internal Acessors for GuestOSDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.GuestOSDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetail = value; }

        /// <summary>Internal Acessors for GuestOSDetailOsname</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.GuestOSDetailOsname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOsname; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOsname = value; }

        /// <summary>Internal Acessors for GuestOSDetailOsversion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.GuestOSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOsversion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).GuestOSDetailOsversion = value; }

        /// <summary>Internal Acessors for HighAvailability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.HighlyAvailable? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.HighAvailability { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HighAvailability; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HighAvailability = value; }

        /// <summary>Internal Acessors for HostFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.HostFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HostFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HostFqdn = value; }

        /// <summary>Internal Acessors for HostId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.HostId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HostId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).HostId = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for InstanceUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.InstanceUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).InstanceUuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).InstanceUuid = value; }

        /// <summary>Internal Acessors for IsDeleted</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.IsDeleted { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsDeleted; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsDeleted = value; }

        /// <summary>Internal Acessors for IsDynamicMemoryEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.IsDynamicMemoryEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsDynamicMemoryEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsDynamicMemoryEnabled = value; }

        /// <summary>Internal Acessors for IsGuestDetailsDiscoveryInProgress</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.IsGuestDetailsDiscoveryInProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsGuestDetailsDiscoveryInProgress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).IsGuestDetailsDiscoveryInProgress = value; }

        /// <summary>Internal Acessors for ManagementServerType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.ManagementServerType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ManagementServerType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).ManagementServerType = value; }

        /// <summary>Internal Acessors for MaxMemoryMb</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.MaxMemoryMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).MaxMemoryMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).MaxMemoryMb = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for NetworkAdapter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.NetworkAdapter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NetworkAdapter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NetworkAdapter = value; }

        /// <summary>Internal Acessors for NumberOfApplication</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.NumberOfApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NumberOfApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NumberOfApplication = value; }

        /// <summary>Internal Acessors for NumberOfProcessorCore</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.NumberOfProcessorCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NumberOfProcessorCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NumberOfProcessorCore = value; }

        /// <summary>Internal Acessors for OperatingSystemDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.OperatingSystemDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetail = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.OperatingSystemDetailOSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSName = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.OperatingSystemDetailOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSType = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.OperatingSystemDetailOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSVersion = value; }

        /// <summary>Internal Acessors for PowerStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.PowerStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).PowerStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).PowerStatus = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVMachineProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).UpdatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).UpdatedTimestamp = value; }

        /// <summary>Internal Acessors for VMConfigurationFileLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.VMConfigurationFileLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).VMConfigurationFileLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).VMConfigurationFileLocation = value; }

        /// <summary>Internal Acessors for VMFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.VMFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).VMFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).VMFqdn = value; }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineInternal.Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Version = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Sites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Network adapters attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter[] NetworkAdapter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NetworkAdapter; }

        /// <summary>Number of applications installed in the guest VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? NumberOfApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NumberOfApplication; }

        /// <summary>Number of Processor Cores allocated for the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? NumberOfProcessorCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).NumberOfProcessorCore; }

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSName; }

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSType; }

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).OperatingSystemDetailOSVersion; }

        /// <summary>Machine power status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PowerStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).PowerStatus; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineProperties _property;

        /// <summary>Nested properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVMachineProperties()); }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/HyperVSites/Machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Timestamp marking last updated on the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).UpdatedTimestamp; }

        /// <summary>Root location of the VM configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string VMConfigurationFileLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).VMConfigurationFileLocation; }

        /// <summary>Machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string VMFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).VMFqdn; }

        /// <summary>VM version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachinePropertiesInternal)Property).Version; }

        /// <summary>Creates an new <see cref="HyperVMachine" /> instance.</summary>
        public HyperVMachine()
        {

        }
    }
    /// Machine REST Resource.
    public partial interface IHyperVMachine :
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
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
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
        /// <summary>Name of the Sites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Sites.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
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
        /// <summary>Type of resource. Type = Microsoft.OffAzure/HyperVSites/Machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/HyperVSites/Machines.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
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
    /// Machine REST Resource.
    internal partial interface IHyperVMachineInternal

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
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
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
        /// <summary>Name of the Sites.</summary>
        string Name { get; set; }
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
        /// <summary>Nested properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVMachineProperties Property { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/HyperVSites/Machines.</summary>
        string Type { get; set; }
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