namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Machine REST Resource.</summary>
    public partial class VMwareMachine :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal
    {

        /// <summary>Allocated Memory in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public double? AllocatedMemoryInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AllocatedMemoryInMb; }

        /// <summary>Applications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] AppAndRoleApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleApplication; }

        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] AppAndRoleBizTalkServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleBizTalkServer; }

        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] AppAndRoleExchangeServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleExchangeServer; }

        /// <summary>Features of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] AppAndRoleFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleFeature; }

        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] AppAndRoleOtherDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleOtherDatabase; }

        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] AppAndRoleSharePointServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSharePointServer; }

        /// <summary>SQLServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] AppAndRoleSqlServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSqlServer; }

        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] AppAndRoleSystemCenter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSystemCenter; }

        /// <summary>WebApplications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] AppAndRoleWebApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleWebApplication; }

        /// <summary>BIOS GUID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string BiosGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).BiosGuid; }

        /// <summary>Machine BIOS serial number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string BiosSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).BiosSerialNumber; }

        /// <summary>Value indicating whether change tracking is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? ChangeTrackingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).ChangeTrackingEnabled; }

        /// <summary>Value indicating whether change tracking is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? ChangeTrackingSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).ChangeTrackingSupported; }

        /// <summary>Timestamp marking machine creation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).CreatedTimestamp; }

        /// <summary>Scope of the data center.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DataCenterScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DataCenterScope; }

        /// <summary>If dependency mapping feature is enabled or not for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DependencyMapping { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DependencyMapping; }

        /// <summary>When dependency mapping collection is last started.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? DependencyMappingStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DependencyMappingStartTime; }

        /// <summary>User description of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Description; }

        /// <summary>Disks attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk[] Disk { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Disk; }

        /// <summary>Display name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DisplayName; }

        /// <summary>Errors for machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Error; }

        /// <summary>Firmware of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string Firmware { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Firmware; }

        /// <summary>
        /// The last time at which the Guest Details was discovered or the error while discovering guest details based discovery of
        /// the machine.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public global::System.DateTime? GuestDetailsDiscoveryTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestDetailsDiscoveryTimestamp; }

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOsname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOsname; }

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOstype; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOstype = value ?? null; }

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string GuestOSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOsversion; }

        /// <summary>Indicates whether the host is in maintenance mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? HostInMaintenanceMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostInMaintenanceMode; }

        /// <summary>The host name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostName; }

        /// <summary>The host power state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string HostPowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostPowerState; }

        /// <summary>The host version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string HostVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostVersion; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>On-premise Instance UUID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string InstanceUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).InstanceUuid; }

        /// <summary>Value indicating whether VM is deleted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? IsDeleted { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).IsDeleted; }

        /// <summary>
        /// Whether Refresh Fabric Layout Guest Details has been completed once. Portal will show discovery in progress, if this value
        /// is true.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? IsGuestDetailsDiscoveryInProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).IsGuestDetailsDiscoveryInProgress; }

        /// <summary>Maximum number of snapshots for the VM. Default value is -1.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? MaxSnapshot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).MaxSnapshot; }

        /// <summary>Internal Acessors for AllocatedMemoryInMb</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AllocatedMemoryInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AllocatedMemoryInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AllocatedMemoryInMb = value; }

        /// <summary>Internal Acessors for AppAndRoleApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleApplication = value; }

        /// <summary>Internal Acessors for AppAndRoleBizTalkServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleBizTalkServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleBizTalkServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleBizTalkServer = value; }

        /// <summary>Internal Acessors for AppAndRoleExchangeServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleExchangeServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleExchangeServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleExchangeServer = value; }

        /// <summary>Internal Acessors for AppAndRoleFeature</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleFeature { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleFeature; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleFeature = value; }

        /// <summary>Internal Acessors for AppAndRoleOtherDatabase</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleOtherDatabase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleOtherDatabase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleOtherDatabase = value; }

        /// <summary>Internal Acessors for AppAndRoleSharePointServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleSharePointServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSharePointServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSharePointServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSqlServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleSqlServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSqlServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSqlServer = value; }

        /// <summary>Internal Acessors for AppAndRoleSystemCenter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleSystemCenter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSystemCenter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleSystemCenter = value; }

        /// <summary>Internal Acessors for AppAndRoleWebApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppAndRoleWebApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleWebApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppAndRoleWebApplication = value; }

        /// <summary>Internal Acessors for AppsAndRole</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.AppsAndRole { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppsAndRole; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).AppsAndRole = value; }

        /// <summary>Internal Acessors for BiosGuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.BiosGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).BiosGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).BiosGuid = value; }

        /// <summary>Internal Acessors for BiosSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.BiosSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).BiosSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).BiosSerialNumber = value; }

        /// <summary>Internal Acessors for ChangeTrackingEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.ChangeTrackingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).ChangeTrackingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).ChangeTrackingEnabled = value; }

        /// <summary>Internal Acessors for ChangeTrackingSupported</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.ChangeTrackingSupported { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).ChangeTrackingSupported; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).ChangeTrackingSupported = value; }

        /// <summary>Internal Acessors for CreatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.CreatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).CreatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).CreatedTimestamp = value; }

        /// <summary>Internal Acessors for DataCenterScope</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.DataCenterScope { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DataCenterScope; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DataCenterScope = value; }

        /// <summary>Internal Acessors for DependencyMapping</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.DependencyMapping { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DependencyMapping; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DependencyMapping = value; }

        /// <summary>Internal Acessors for DependencyMappingStartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.DependencyMappingStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DependencyMappingStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DependencyMappingStartTime = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for Disk</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Disk { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Disk; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Disk = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHealthErrorDetails[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Error = value; }

        /// <summary>Internal Acessors for Firmware</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Firmware { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Firmware; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).Firmware = value; }

        /// <summary>Internal Acessors for GuestDetailsDiscoveryTimestamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.GuestDetailsDiscoveryTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestDetailsDiscoveryTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestDetailsDiscoveryTimestamp = value; }

        /// <summary>Internal Acessors for GuestOSDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IGuestOSDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.GuestOSDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetail = value; }

        /// <summary>Internal Acessors for GuestOSDetailOsname</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.GuestOSDetailOsname { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOsname; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOsname = value; }

        /// <summary>Internal Acessors for GuestOSDetailOsversion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.GuestOSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOsversion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).GuestOSDetailOsversion = value; }

        /// <summary>Internal Acessors for HostInMaintenanceMode</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.HostInMaintenanceMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostInMaintenanceMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostInMaintenanceMode = value; }

        /// <summary>Internal Acessors for HostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostName = value; }

        /// <summary>Internal Acessors for HostPowerState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.HostPowerState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostPowerState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostPowerState = value; }

        /// <summary>Internal Acessors for HostVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.HostVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).HostVersion = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for InstanceUuid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.InstanceUuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).InstanceUuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).InstanceUuid = value; }

        /// <summary>Internal Acessors for IsDeleted</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.IsDeleted { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).IsDeleted; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).IsDeleted = value; }

        /// <summary>Internal Acessors for IsGuestDetailsDiscoveryInProgress</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.IsGuestDetailsDiscoveryInProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).IsGuestDetailsDiscoveryInProgress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).IsGuestDetailsDiscoveryInProgress = value; }

        /// <summary>Internal Acessors for MaxSnapshot</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.MaxSnapshot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).MaxSnapshot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).MaxSnapshot = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for NetworkAdapter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.NetworkAdapter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NetworkAdapter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NetworkAdapter = value; }

        /// <summary>Internal Acessors for NumberOfApplication</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.NumberOfApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NumberOfApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NumberOfApplication = value; }

        /// <summary>Internal Acessors for NumberOfProcessorCore</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.NumberOfProcessorCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NumberOfProcessorCore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NumberOfProcessorCore = value; }

        /// <summary>Internal Acessors for OperatingSystemDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystem Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.OperatingSystemDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetail = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.OperatingSystemDetailOSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSName = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.OperatingSystemDetailOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSType = value; }

        /// <summary>Internal Acessors for OperatingSystemDetailOSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.OperatingSystemDetailOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSVersion = value; }

        /// <summary>Internal Acessors for PowerStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.PowerStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).PowerStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).PowerStatus = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareMachineProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UpdatedTimestamp</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).UpdatedTimestamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).UpdatedTimestamp = value; }

        /// <summary>Internal Acessors for VCenterFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.VCenterFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VCenterFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VCenterFqdn = value; }

        /// <summary>Internal Acessors for VCenterId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.VCenterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VCenterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VCenterId = value; }

        /// <summary>Internal Acessors for VMConfigurationFileLocation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.VMConfigurationFileLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMConfigurationFileLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMConfigurationFileLocation = value; }

        /// <summary>Internal Acessors for VMFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.VMFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMFqdn = value; }

        /// <summary>Internal Acessors for VMwareToolsStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineInternal.VMwareToolsStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMwareToolsStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMwareToolsStatus = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Sites.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Network adapters attached to the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareNetworkAdapter[] NetworkAdapter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NetworkAdapter; }

        /// <summary>Number of applications installed in the guest VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? NumberOfApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NumberOfApplication; }

        /// <summary>Number of Processor Cores allocated for the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? NumberOfProcessorCore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).NumberOfProcessorCore; }

        /// <summary>Name of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSName; }

        /// <summary>Type of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSType; }

        /// <summary>Version of the operating system.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OperatingSystemDetailOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).OperatingSystemDetailOSVersion; }

        /// <summary>Machine power status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PowerStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).PowerStatus; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineProperties _property;

        /// <summary>Nested properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareMachineProperties()); }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/Machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Timestamp marking last updated on the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string UpdatedTimestamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).UpdatedTimestamp; }

        /// <summary>VCenter FQDN/IPAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string VCenterFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VCenterFqdn; }

        /// <summary>VCenter ARM ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string VCenterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VCenterId; }

        /// <summary>Root location of the VM configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string VMConfigurationFileLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMConfigurationFileLocation; }

        /// <summary>Machine FQDN.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string VMFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMFqdn; }

        /// <summary>VMware tools status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string VMwareToolsStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachinePropertiesInternal)Property).VMwareToolsStatus; }

        /// <summary>Creates an new <see cref="VMwareMachine" /> instance.</summary>
        public VMwareMachine()
        {

        }
    }
    /// Machine REST Resource.
    public partial interface IVMwareMachine :
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
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/Machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of resource. Type = Microsoft.OffAzure/VMWareSites/Machines.",
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
    /// Machine REST Resource.
    internal partial interface IVMwareMachineInternal

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
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
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
        /// <summary>Name of the Sites.</summary>
        string Name { get; set; }
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
        /// <summary>Nested properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineProperties Property { get; set; }
        /// <summary>Type of resource. Type = Microsoft.OffAzure/VMWareSites/Machines.</summary>
        string Type { get; set; }
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