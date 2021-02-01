namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>InMageAzureV2 specific provider input.</summary>
    public partial class InMageReprotectInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInput"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInput __reverseReplicationProviderSpecificInput = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReverseReplicationProviderSpecificInput();

        /// <summary>Backing field for <see cref="DatastoreName" /> property.</summary>
        private string _datastoreName;

        /// <summary>The target data store name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string DatastoreName { get => this._datastoreName; set => this._datastoreName = value; }

        /// <summary>Backing field for <see cref="DiskExclusionInput" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInput _diskExclusionInput;

        /// <summary>The enable disk exclusion input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInput DiskExclusionInput { get => (this._diskExclusionInput = this._diskExclusionInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageDiskExclusionInput()); set => this._diskExclusionInput = value; }

        /// <summary>The guest disk signature based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[] DiskExclusionInputDiskSignatureOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInputInternal)DiskExclusionInput).DiskSignatureOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInputInternal)DiskExclusionInput).DiskSignatureOption = value ?? null /* arrayOf */; }

        /// <summary>The volume label based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[] DiskExclusionInputVolumeOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInputInternal)DiskExclusionInput).VolumeOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInputInternal)DiskExclusionInput).VolumeOption = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="DisksToInclude" /> property.</summary>
        private string[] _disksToInclude;

        /// <summary>The disks to include list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] DisksToInclude { get => this._disksToInclude; set => this._disksToInclude = value; }

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInputInternal)__reverseReplicationProviderSpecificInput).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInputInternal)__reverseReplicationProviderSpecificInput).InstanceType = value; }

        /// <summary>Backing field for <see cref="MasterTargetId" /> property.</summary>
        private string _masterTargetId;

        /// <summary>The Master Target Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MasterTargetId { get => this._masterTargetId; set => this._masterTargetId = value; }

        /// <summary>Internal Acessors for DiskExclusionInput</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInput Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal.DiskExclusionInput { get => (this._diskExclusionInput = this._diskExclusionInput ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageDiskExclusionInput()); set { {_diskExclusionInput = value;} } }

        /// <summary>Backing field for <see cref="ProcessServerId" /> property.</summary>
        private string _processServerId;

        /// <summary>The Process Server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProcessServerId { get => this._processServerId; set => this._processServerId = value; }

        /// <summary>Backing field for <see cref="ProfileId" /> property.</summary>
        private string _profileId;

        /// <summary>The Policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProfileId { get => this._profileId; set => this._profileId = value; }

        /// <summary>Backing field for <see cref="RetentionDrive" /> property.</summary>
        private string _retentionDrive;

        /// <summary>The retention drive to use on the MT.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RetentionDrive { get => this._retentionDrive; set => this._retentionDrive = value; }

        /// <summary>Backing field for <see cref="RunAsAccountId" /> property.</summary>
        private string _runAsAccountId;

        /// <summary>The CS account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RunAsAccountId { get => this._runAsAccountId; set => this._runAsAccountId = value; }

        /// <summary>Creates an new <see cref="InMageReprotectInput" /> instance.</summary>
        public InMageReprotectInput()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__reverseReplicationProviderSpecificInput), __reverseReplicationProviderSpecificInput);
            await eventListener.AssertObjectIsValid(nameof(__reverseReplicationProviderSpecificInput), __reverseReplicationProviderSpecificInput);
        }
    }
    /// InMageAzureV2 specific provider input.
    public partial interface IInMageReprotectInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInput
    {
        /// <summary>The target data store name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The target data store name.",
        SerializedName = @"datastoreName",
        PossibleTypes = new [] { typeof(string) })]
        string DatastoreName { get; set; }
        /// <summary>The guest disk signature based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The guest disk signature based option for disk exclusion.",
        SerializedName = @"diskSignatureOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[] DiskExclusionInputDiskSignatureOption { get; set; }
        /// <summary>The volume label based option for disk exclusion.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume label based option for disk exclusion.",
        SerializedName = @"volumeOptions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[] DiskExclusionInputVolumeOption { get; set; }
        /// <summary>The disks to include list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The disks to include list.",
        SerializedName = @"disksToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] DisksToInclude { get; set; }
        /// <summary>The Master Target Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Master Target Id.",
        SerializedName = @"masterTargetId",
        PossibleTypes = new [] { typeof(string) })]
        string MasterTargetId { get; set; }
        /// <summary>The Process Server Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Process Server Id.",
        SerializedName = @"processServerId",
        PossibleTypes = new [] { typeof(string) })]
        string ProcessServerId { get; set; }
        /// <summary>The Policy Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Policy Id.",
        SerializedName = @"profileId",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileId { get; set; }
        /// <summary>The retention drive to use on the MT.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The retention drive to use on the MT.",
        SerializedName = @"retentionDrive",
        PossibleTypes = new [] { typeof(string) })]
        string RetentionDrive { get; set; }
        /// <summary>The CS account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CS account Id.",
        SerializedName = @"runAsAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RunAsAccountId { get; set; }

    }
    /// InMageAzureV2 specific provider input.
    internal partial interface IInMageReprotectInputInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInputInternal
    {
        /// <summary>The target data store name.</summary>
        string DatastoreName { get; set; }
        /// <summary>The enable disk exclusion input.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInput DiskExclusionInput { get; set; }
        /// <summary>The guest disk signature based option for disk exclusion.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[] DiskExclusionInputDiskSignatureOption { get; set; }
        /// <summary>The volume label based option for disk exclusion.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[] DiskExclusionInputVolumeOption { get; set; }
        /// <summary>The disks to include list.</summary>
        string[] DisksToInclude { get; set; }
        /// <summary>The Master Target Id.</summary>
        string MasterTargetId { get; set; }
        /// <summary>The Process Server Id.</summary>
        string ProcessServerId { get; set; }
        /// <summary>The Policy Id.</summary>
        string ProfileId { get; set; }
        /// <summary>The retention drive to use on the MT.</summary>
        string RetentionDrive { get; set; }
        /// <summary>The CS account Id.</summary>
        string RunAsAccountId { get; set; }

    }
}