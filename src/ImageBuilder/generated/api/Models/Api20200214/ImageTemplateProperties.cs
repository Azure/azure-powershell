namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes the properties of an image template</summary>
    public partial class ImageTemplateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="BuildTimeoutInMinute" /> property.</summary>
        private int? _buildTimeoutInMinute;

        /// <summary>
        /// Maximum duration to wait while building the image template. Omit or specify 0 to use the default (4 hours).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public int? BuildTimeoutInMinute { get => this._buildTimeoutInMinute; set => this._buildTimeoutInMinute = value; }

        /// <summary>Backing field for <see cref="Customize" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[] _customize;

        /// <summary>
        /// Specifies the properties used to describe the customization steps of the image, like Image source etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[] Customize { get => this._customize; set => this._customize = value; }

        /// <summary>Backing field for <see cref="Distribute" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[] _distribute;

        /// <summary>The distribution targets where the image output needs to go to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[] Distribute { get => this._distribute; set => this._distribute = value; }

        /// <summary>Backing field for <see cref="LastRunStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatus _lastRunStatus;

        /// <summary>State of 'run' that is currently executing or was last executed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatus LastRunStatus { get => (this._lastRunStatus = this._lastRunStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateLastRunStatus()); }

        /// <summary>End time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastRunStatusEndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).EndTime = value; }

        /// <summary>Verbose information about the last run state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string LastRunStatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).Message = value; }

        /// <summary>State of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? LastRunStatusRunState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).RunState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).RunState = value; }

        /// <summary>Sub-state of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? LastRunStatusRunSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).RunSubState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).RunSubState = value; }

        /// <summary>Start time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastRunStatusStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatusInternal)LastRunStatus).StartTime = value; }

        /// <summary>Internal Acessors for LastRunStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatus Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal.LastRunStatus { get => (this._lastRunStatus = this._lastRunStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateLastRunStatus()); set { {_lastRunStatus = value;} } }

        /// <summary>Internal Acessors for ProvisioningError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningError Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal.ProvisioningError { get => (this._provisioningError = this._provisioningError ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ProvisioningError()); set { {_provisioningError = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Source</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal.Source { get => (this._source = this._source ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSource()); set { {_source = value;} } }

        /// <summary>Internal Acessors for VMProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfile Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal.VMProfile { get => (this._vMProfile = this._vMProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateVMProfile()); set { {_vMProfile = value;} } }

        /// <summary>Internal Acessors for VMProfileVnetConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal.VMProfileVnetConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).VnetConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).VnetConfig = value; }

        /// <summary>Backing field for <see cref="ProvisioningError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningError _provisioningError;

        /// <summary>Provisioning error, if any</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningError ProvisioningError { get => (this._provisioningError = this._provisioningError ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ProvisioningError()); }

        /// <summary>Error code of the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? ProvisioningErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningErrorInternal)ProvisioningError).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningErrorInternal)ProvisioningError).Code = value; }

        /// <summary>Verbose error message about the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string ProvisioningErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningErrorInternal)ProvisioningError).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningErrorInternal)ProvisioningError).Message = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource _source;

        /// <summary>Specifies the properties used to describe the source image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource Source { get => (this._source = this._source ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSource()); set => this._source = value; }

        /// <summary>Specifies the type of source image you want to start with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string SourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)Source).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSourceInternal)Source).Type = value; }

        /// <summary>Backing field for <see cref="VMProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfile _vMProfile;

        /// <summary>Describes how virtual machine is set up to build images</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfile VMProfile { get => (this._vMProfile = this._vMProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateVMProfile()); set => this._vMProfile = value; }

        /// <summary>
        /// Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public int? VMProfileOsdiskSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).OSDiskSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).OSDiskSizeGb = value; }

        /// <summary>
        /// Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default
        /// (Standard_D1_v2).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string VMProfileVmsize { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).VMSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).VMSize = value; }

        /// <summary>Resource id of a pre-existing subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string VnetConfigSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).VnetConfigSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfileInternal)VMProfile).VnetConfigSubnetId = value; }

        /// <summary>Creates an new <see cref="ImageTemplateProperties" /> instance.</summary>
        public ImageTemplateProperties()
        {

        }
    }
    /// Describes the properties of an image template
    public partial interface IImageTemplateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Maximum duration to wait while building the image template. Omit or specify 0 to use the default (4 hours).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum duration to wait while building the image template. Omit or specify 0 to use the default (4 hours).",
        SerializedName = @"buildTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? BuildTimeoutInMinute { get; set; }
        /// <summary>
        /// Specifies the properties used to describe the customization steps of the image, like Image source etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the properties used to describe the customization steps of the image, like Image source etc",
        SerializedName = @"customize",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateShellCustomizer),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateRestartCustomizer),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateWindowsUpdateCustomizer),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePowerShellCustomizer),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateFileCustomizer) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[] Customize { get; set; }
        /// <summary>The distribution targets where the image output needs to go to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The distribution targets where the image output needs to go to.",
        SerializedName = @"distribute",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateManagedImageDistributor),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSharedImageDistributor),typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVhdDistributor) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[] Distribute { get; set; }
        /// <summary>End time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the last run (UTC)",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRunStatusEndTime { get; set; }
        /// <summary>Verbose information about the last run state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Verbose information about the last run state",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string LastRunStatusMessage { get; set; }
        /// <summary>State of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"State of the last run",
        SerializedName = @"runState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? LastRunStatusRunState { get; set; }
        /// <summary>Sub-state of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Sub-state of the last run",
        SerializedName = @"runSubState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? LastRunStatusRunSubState { get; set; }
        /// <summary>Start time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the last run (UTC)",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastRunStatusStartTime { get; set; }
        /// <summary>Error code of the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Error code of the provisioning failure",
        SerializedName = @"provisioningErrorCode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? ProvisioningErrorCode { get; set; }
        /// <summary>Verbose error message about the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Verbose error message about the provisioning failure",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningErrorMessage { get; set; }
        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the resource",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Specifies the type of source image you want to start with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Specifies the type of source image you want to start with.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string SourceType { get; set; }
        /// <summary>
        /// Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.",
        SerializedName = @"osDiskSizeGB",
        PossibleTypes = new [] { typeof(int) })]
        int? VMProfileOsdiskSizeGb { get; set; }
        /// <summary>
        /// Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default
        /// (Standard_D1_v2).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default (Standard_D1_v2).",
        SerializedName = @"vmSize",
        PossibleTypes = new [] { typeof(string) })]
        string VMProfileVmsize { get; set; }
        /// <summary>Resource id of a pre-existing subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource id of a pre-existing subnet.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string VnetConfigSubnetId { get; set; }

    }
    /// Describes the properties of an image template
    public partial interface IImageTemplatePropertiesInternal

    {
        /// <summary>
        /// Maximum duration to wait while building the image template. Omit or specify 0 to use the default (4 hours).
        /// </summary>
        int? BuildTimeoutInMinute { get; set; }
        /// <summary>
        /// Specifies the properties used to describe the customization steps of the image, like Image source etc
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[] Customize { get; set; }
        /// <summary>The distribution targets where the image output needs to go to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[] Distribute { get; set; }
        /// <summary>State of 'run' that is currently executing or was last executed.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatus LastRunStatus { get; set; }
        /// <summary>End time of the last run (UTC)</summary>
        global::System.DateTime? LastRunStatusEndTime { get; set; }
        /// <summary>Verbose information about the last run state</summary>
        string LastRunStatusMessage { get; set; }
        /// <summary>State of the last run</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? LastRunStatusRunState { get; set; }
        /// <summary>Sub-state of the last run</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? LastRunStatusRunSubState { get; set; }
        /// <summary>Start time of the last run (UTC)</summary>
        global::System.DateTime? LastRunStatusStartTime { get; set; }
        /// <summary>Provisioning error, if any</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningError ProvisioningError { get; set; }
        /// <summary>Error code of the provisioning failure</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? ProvisioningErrorCode { get; set; }
        /// <summary>Verbose error message about the provisioning failure</summary>
        string ProvisioningErrorMessage { get; set; }
        /// <summary>Provisioning state of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Specifies the properties used to describe the source image.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource Source { get; set; }
        /// <summary>Specifies the type of source image you want to start with.</summary>
        string SourceType { get; set; }
        /// <summary>Describes how virtual machine is set up to build images</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfile VMProfile { get; set; }
        /// <summary>
        /// Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
        /// </summary>
        int? VMProfileOsdiskSizeGb { get; set; }
        /// <summary>
        /// Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default
        /// (Standard_D1_v2).
        /// </summary>
        string VMProfileVmsize { get; set; }
        /// <summary>
        /// Optional configuration of the virtual network to use to deploy the build virtual machine in. Omit if no specific virtual
        /// network needs to be used.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig VMProfileVnetConfig { get; set; }
        /// <summary>Resource id of a pre-existing subnet.</summary>
        string VnetConfigSubnetId { get; set; }

    }
}