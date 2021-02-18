namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>VMM fabric provider specific VM settings.</summary>
    public partial class VmmVirtualMachineDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmVirtualMachineDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmVirtualMachineDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings __configurationSettings = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ConfigurationSettings();

        /// <summary>Backing field for <see cref="DiskDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] _diskDetail;

        /// <summary>The Last successful failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] DiskDetail { get => this._diskDetail; set => this._diskDetail = value; }

        /// <summary>Backing field for <see cref="Generation" /> property.</summary>
        private string _generation;

        /// <summary>The id of the object in fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Generation { get => this._generation; set => this._generation = value; }

        /// <summary>Backing field for <see cref="HasFibreChannelAdapter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? _hasFibreChannelAdapter;

        /// <summary>
        /// A value indicating whether the VM has a fibre channel adapter attached. String value of {SrsDataContract.PresenceStatus}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasFibreChannelAdapter { get => this._hasFibreChannelAdapter; set => this._hasFibreChannelAdapter = value; }

        /// <summary>Backing field for <see cref="HasPhysicalDisk" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? _hasPhysicalDisk;

        /// <summary>
        /// A value indicating whether the VM has a physical disk attached. String value of {SrsDataContract.PresenceStatus} enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasPhysicalDisk { get => this._hasPhysicalDisk; set => this._hasPhysicalDisk = value; }

        /// <summary>Backing field for <see cref="HasSharedVhd" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? _hasSharedVhd;

        /// <summary>
        /// A value indicating whether the VM has a shared VHD attached. String value of {SrsDataContract.PresenceStatus} enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasSharedVhd { get => this._hasSharedVhd; set => this._hasSharedVhd = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)__configurationSettings).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)__configurationSettings).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)__configurationSettings).InstanceType = value; }

        /// <summary>Internal Acessors for OSDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVmmVirtualMachineDetailsInternal.OSDetail { get => (this._oSDetail = this._oSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails()); set { {_oSDetail = value;} } }

        /// <summary>Backing field for <see cref="OSDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails _oSDetail;

        /// <summary>The Last replication time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails OSDetail { get => (this._oSDetail = this._oSDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails()); set => this._oSDetail = value; }

        /// <summary>The OSEdition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsedition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSEdition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSEdition = value ?? null; }

        /// <summary>The OS Major Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsmajorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMajorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMajorVersion = value ?? null; }

        /// <summary>The OS Minor Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsminorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMinorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSMinorVersion = value ?? null; }

        /// <summary>VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOstype { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSType = value ?? null; }

        /// <summary>The OS Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailOsversion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).OSVersion = value ?? null; }

        /// <summary>Product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSDetailProductType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).ProductType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)OSDetail).ProductType = value ?? null; }

        /// <summary>Backing field for <see cref="SourceItemId" /> property.</summary>
        private string _sourceItemId;

        /// <summary>The source id of the object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SourceItemId { get => this._sourceItemId; set => this._sourceItemId = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__configurationSettings), __configurationSettings);
            await eventListener.AssertObjectIsValid(nameof(__configurationSettings), __configurationSettings);
        }

        /// <summary>Creates an new <see cref="VmmVirtualMachineDetails" /> instance.</summary>
        public VmmVirtualMachineDetails()
        {

        }
    }
    /// VMM fabric provider specific VM settings.
    public partial interface IVmmVirtualMachineDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings
    {
        /// <summary>The Last successful failover time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Last successful failover time.",
        SerializedName = @"diskDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] DiskDetail { get; set; }
        /// <summary>The id of the object in fabric.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The id of the object in fabric.",
        SerializedName = @"generation",
        PossibleTypes = new [] { typeof(string) })]
        string Generation { get; set; }
        /// <summary>
        /// A value indicating whether the VM has a fibre channel adapter attached. String value of {SrsDataContract.PresenceStatus}
        /// enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the VM has a fibre channel adapter attached. String value of {SrsDataContract.PresenceStatus} enum.",
        SerializedName = @"hasFibreChannelAdapter",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasFibreChannelAdapter { get; set; }
        /// <summary>
        /// A value indicating whether the VM has a physical disk attached. String value of {SrsDataContract.PresenceStatus} enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the VM has a physical disk attached. String value of {SrsDataContract.PresenceStatus} enum.",
        SerializedName = @"hasPhysicalDisk",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasPhysicalDisk { get; set; }
        /// <summary>
        /// A value indicating whether the VM has a shared VHD attached. String value of {SrsDataContract.PresenceStatus} enum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A value indicating whether the VM has a shared VHD attached. String value of {SrsDataContract.PresenceStatus} enum.",
        SerializedName = @"hasSharedVhd",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasSharedVhd { get; set; }
        /// <summary>The OSEdition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OSEdition.",
        SerializedName = @"osEdition",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsedition { get; set; }
        /// <summary>The OS Major Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Major Version.",
        SerializedName = @"oSMajorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsmajorVersion { get; set; }
        /// <summary>The OS Minor Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Minor Version.",
        SerializedName = @"oSMinorVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsminorVersion { get; set; }
        /// <summary>VM Disk details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM Disk details.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOstype { get; set; }
        /// <summary>The OS Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS Version.",
        SerializedName = @"oSVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailOsversion { get; set; }
        /// <summary>Product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Product type.",
        SerializedName = @"productType",
        PossibleTypes = new [] { typeof(string) })]
        string OSDetailProductType { get; set; }
        /// <summary>The source id of the object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The source id of the object.",
        SerializedName = @"sourceItemId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceItemId { get; set; }

    }
    /// VMM fabric provider specific VM settings.
    internal partial interface IVmmVirtualMachineDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal
    {
        /// <summary>The Last successful failover time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[] DiskDetail { get; set; }
        /// <summary>The id of the object in fabric.</summary>
        string Generation { get; set; }
        /// <summary>
        /// A value indicating whether the VM has a fibre channel adapter attached. String value of {SrsDataContract.PresenceStatus}
        /// enum.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasFibreChannelAdapter { get; set; }
        /// <summary>
        /// A value indicating whether the VM has a physical disk attached. String value of {SrsDataContract.PresenceStatus} enum.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasPhysicalDisk { get; set; }
        /// <summary>
        /// A value indicating whether the VM has a shared VHD attached. String value of {SrsDataContract.PresenceStatus} enum.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus? HasSharedVhd { get; set; }
        /// <summary>The Last replication time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails OSDetail { get; set; }
        /// <summary>The OSEdition.</summary>
        string OSDetailOsedition { get; set; }
        /// <summary>The OS Major Version.</summary>
        string OSDetailOsmajorVersion { get; set; }
        /// <summary>The OS Minor Version.</summary>
        string OSDetailOsminorVersion { get; set; }
        /// <summary>VM Disk details.</summary>
        string OSDetailOstype { get; set; }
        /// <summary>The OS Version.</summary>
        string OSDetailOsversion { get; set; }
        /// <summary>Product type.</summary>
        string OSDetailProductType { get; set; }
        /// <summary>The source id of the object.</summary>
        string SourceItemId { get; set; }

    }
}