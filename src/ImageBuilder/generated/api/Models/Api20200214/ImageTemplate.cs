namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>
    /// Image template is an ARM resource managed by Microsoft.VirtualMachineImages provider
    /// </summary>
    public partial class ImageTemplate :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.Resource();

        /// <summary>
        /// Maximum duration to wait while building the image template. Omit or specify 0 to use the default (4 hours).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public int? BuildTimeoutInMinute { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).BuildTimeoutInMinute; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).BuildTimeoutInMinute = value; }

        /// <summary>
        /// Specifies the properties used to describe the customization steps of the image, like Image source etc
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[] Customize { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).Customize; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).Customize = value; }

        /// <summary>The distribution targets where the image output needs to go to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[] Distribute { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).Distribute; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).Distribute = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentity _identity;

        /// <summary>The identity of the image template, if configured.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateIdentity()); set => this._identity = value; }

        /// <summary>
        /// The type of identity used for the image template. The type 'None' will remove any identities from the image template.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ResourceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityInternal)Identity).Type = value; }

        /// <summary>
        /// The list of user identities associated with the image template. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityInternal)Identity).UserAssignedIdentity = value; }

        /// <summary>End time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastRunStatusEndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusEndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusEndTime = value; }

        /// <summary>Verbose information about the last run state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string LastRunStatusMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusMessage = value; }

        /// <summary>State of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState? LastRunStatusRunState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusRunState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusRunState = value; }

        /// <summary>Sub-state of the last run</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState? LastRunStatusRunSubState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusRunSubState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusRunSubState = value; }

        /// <summary>Start time of the last run (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastRunStatusStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatusStartTime = value; }

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentity Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for LastRunStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateLastRunStatus Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.LastRunStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).LastRunStatus = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IProvisioningError Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.ProvisioningError { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningError; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningError = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Source</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).Source = value; }

        /// <summary>Internal Acessors for VMProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateVMProfile Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.VMProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfile = value; }

        /// <summary>Internal Acessors for VMProfileVnetConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IVirtualNetworkConfig Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateInternal.VMProfileVnetConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfileVnetConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfileVnetConfig = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties _property;

        /// <summary>The properties of the image template</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateProperties()); set => this._property = value; }

        /// <summary>Error code of the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode? ProvisioningErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningErrorCode = value; }

        /// <summary>Verbose error message about the provisioning failure</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string ProvisioningErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningErrorMessage = value; }

        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Specifies the type of source image you want to start with.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string SourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).SourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).SourceType = value; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal)__resource).Type; }

        /// <summary>
        /// Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public int? VMProfileOsdiskSizeGb { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfileOsdiskSizeGb; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfileOsdiskSizeGb = value; }

        /// <summary>
        /// Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default
        /// (Standard_D1_v2).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string VMProfileVmsize { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfileVmsize; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VMProfileVmsize = value; }

        /// <summary>Resource id of a pre-existing subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Inlined)]
        public string VnetConfigSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VnetConfigSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplatePropertiesInternal)Property).VnetConfigSubnetId = value; }

        /// <summary>Creates an new <see cref="ImageTemplate" /> instance.</summary>
        public ImageTemplate()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Image template is an ARM resource managed by Microsoft.VirtualMachineImages provider
    public partial interface IImageTemplate :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResource
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
        /// <summary>
        /// The type of identity used for the image template. The type 'None' will remove any identities from the image template.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity used for the image template. The type 'None' will remove any identities from the image template.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ResourceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the image template. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user identities associated with the image template. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
    /// Image template is an ARM resource managed by Microsoft.VirtualMachineImages provider
    public partial interface IImageTemplateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceInternal
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
        /// <summary>The identity of the image template, if configured.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentity Identity { get; set; }
        /// <summary>
        /// The type of identity used for the image template. The type 'None' will remove any identities from the image template.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ResourceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user identities associated with the image template. The user identity dictionary key references will be ARM
        /// resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
        /// <summary>The properties of the image template</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateProperties Property { get; set; }
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