namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the move resource properties.</summary>
    public partial class MoveResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DependsOn" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency[] _dependsOn;

        /// <summary>Gets or sets the move resource dependencies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency[] DependsOn { get => this._dependsOn; }

        /// <summary>Backing field for <see cref="DependsOnOverride" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride[] _dependsOnOverride;

        /// <summary>Gets or sets the move resource dependencies overrides.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride[] DependsOnOverride { get => this._dependsOnOverride; set => this._dependsOnOverride = value; }

        /// <summary>Backing field for <see cref="Error" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError _error;

        /// <summary>Defines the move resource errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceError()); }

        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string ErrorsPropertiesCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Code; }

        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] ErrorsPropertiesDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Detail; }

        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string ErrorsPropertiesMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Message; }

        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string ErrorsPropertiesTarget { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Target; }

        /// <summary>Backing field for <see cref="ExistingTargetId" /> property.</summary>
        private string _existingTargetId;

        /// <summary>Gets or sets the existing target ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string ExistingTargetId { get => this._existingTargetId; set => this._existingTargetId = value; }

        /// <summary>Backing field for <see cref="IsResolveRequired" /> property.</summary>
        private bool? _isResolveRequired;

        /// <summary>
        /// Gets a value indicating whether the resolve action is required over the move collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public bool? IsResolveRequired { get => this._isResolveRequired; }

        /// <summary>Defines the job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobStatusJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatusJobName; }

        /// <summary>Gets or sets the monitoring job percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string JobStatusJobProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatusJobProgress; }

        /// <summary>Internal Acessors for DependsOn</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.DependsOn { get => this._dependsOn; set { {_dependsOn = value;} } }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.Error { get => (this._error = this._error ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceError()); set { {_error = value;} } }

        /// <summary>Internal Acessors for ErrorsPropertiesCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.ErrorsPropertiesCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Code = value; }

        /// <summary>Internal Acessors for ErrorsPropertiesDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.ErrorsPropertiesDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Detail = value; }

        /// <summary>Internal Acessors for ErrorsPropertiesMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.ErrorsPropertiesMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Message = value; }

        /// <summary>Internal Acessors for ErrorsPropertiesTarget</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.ErrorsPropertiesTarget { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Target = value; }

        /// <summary>Internal Acessors for ErrorsProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.ErrorsProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorInternal)Error).Property = value; }

        /// <summary>Internal Acessors for IsResolveRequired</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.IsResolveRequired { get => this._isResolveRequired; set { {_isResolveRequired = value;} } }

        /// <summary>Internal Acessors for JobStatusJobName</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.JobStatusJobName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatusJobName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatusJobName = value; }

        /// <summary>Internal Acessors for JobStatusJobProgress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.JobStatusJobProgress { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatusJobProgress; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatusJobProgress = value; }

        /// <summary>Internal Acessors for MoveStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatus { get => (this._moveStatus = this._moveStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatus()); set { {_moveStatus = value;} } }

        /// <summary>Internal Acessors for MoveStatusError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusError { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Error = value; }

        /// <summary>Internal Acessors for MoveStatusErrorsPropertiesCode</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusErrorsPropertiesCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Code = value; }

        /// <summary>Internal Acessors for MoveStatusErrorsPropertiesDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusErrorsPropertiesDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Detail; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Detail = value; }

        /// <summary>Internal Acessors for MoveStatusErrorsPropertiesMessage</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusErrorsPropertiesMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Message = value; }

        /// <summary>Internal Acessors for MoveStatusErrorsPropertiesTarget</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusErrorsPropertiesTarget { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Target = value; }

        /// <summary>Internal Acessors for MoveStatusErrorsProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusErrorsProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).ErrorProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).ErrorProperty = value; }

        /// <summary>Internal Acessors for MoveStatusJobStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatus Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusJobStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).JobStatus = value; }

        /// <summary>Internal Acessors for MoveStatusMoveState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.MoveStatusMoveState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).MoveState; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).MoveState = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SourceResourceSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.SourceResourceSetting { get => (this._sourceResourceSetting = this._sourceResourceSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings()); set { {_sourceResourceSetting = value;} } }

        /// <summary>Internal Acessors for TargetId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal.TargetId { get => this._targetId; set { {_targetId = value;} } }

        /// <summary>Backing field for <see cref="MoveStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus _moveStatus;

        /// <summary>Defines the move resource status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus MoveStatus { get => (this._moveStatus = this._moveStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatus()); }

        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string MoveStatusErrorsPropertiesCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Code; }

        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] MoveStatusErrorsPropertiesDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Detail; }

        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string MoveStatusErrorsPropertiesMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Message; }

        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string MoveStatusErrorsPropertiesTarget { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).Target; }

        /// <summary>Defines the MoveResource states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? MoveStatusMoveState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)MoveStatus).MoveState; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? _provisioningState;

        /// <summary>Defines the provisioning states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings _resourceSetting;

        /// <summary>Gets or sets the resource settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings ResourceSetting { get => (this._resourceSetting = this._resourceSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings()); set => this._resourceSetting = value; }

        /// <summary>Backing field for <see cref="SourceId" /> property.</summary>
        private string _sourceId;

        /// <summary>Gets or sets the Source ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string SourceId { get => this._sourceId; set => this._sourceId = value; }

        /// <summary>Backing field for <see cref="SourceResourceSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings _sourceResourceSetting;

        /// <summary>Gets or sets the source resource settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings SourceResourceSetting { get => (this._sourceResourceSetting = this._sourceResourceSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings()); }

        /// <summary>Backing field for <see cref="TargetId" /> property.</summary>
        private string _targetId;

        /// <summary>Gets or sets the Target ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string TargetId { get => this._targetId; }

        /// <summary>Creates an new <see cref="MoveResourceProperties" /> instance.</summary>
        public MoveResourceProperties()
        {

        }
    }
    /// Defines the move resource properties.
    public partial interface IMoveResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the move resource dependencies.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the move resource dependencies.",
        SerializedName = @"dependsOn",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency[] DependsOn { get;  }
        /// <summary>Gets or sets the move resource dependencies overrides.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the move resource dependencies overrides.",
        SerializedName = @"dependsOnOverrides",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride[] DependsOnOverride { get; set; }
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An identifier for the error. Codes are invariant and are intended to be consumed programmatically.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorsPropertiesCode { get;  }
        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of additional details about the error.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] ErrorsPropertiesDetail { get;  }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A message describing the error, intended to be suitable for display in a user interface.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorsPropertiesMessage { get;  }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target of the particular error. For example, the name of the property in error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorsPropertiesTarget { get;  }
        /// <summary>Gets or sets the existing target ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the existing target ARM Id of the resource.",
        SerializedName = @"existingTargetId",
        PossibleTypes = new [] { typeof(string) })]
        string ExistingTargetId { get; set; }
        /// <summary>
        /// Gets a value indicating whether the resolve action is required over the move collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets a value indicating whether the resolve action is required over the move collection.",
        SerializedName = @"isResolveRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsResolveRequired { get;  }
        /// <summary>Defines the job name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Defines the job name.",
        SerializedName = @"jobName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobStatusJobName { get;  }
        /// <summary>Gets or sets the monitoring job percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the monitoring job percentage.",
        SerializedName = @"jobProgress",
        PossibleTypes = new [] { typeof(string) })]
        string JobStatusJobProgress { get;  }
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"An identifier for the error. Codes are invariant and are intended to be consumed programmatically.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string MoveStatusErrorsPropertiesCode { get;  }
        /// <summary>A list of additional details about the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of additional details about the error.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] MoveStatusErrorsPropertiesDetail { get;  }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A message describing the error, intended to be suitable for display in a user interface.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string MoveStatusErrorsPropertiesMessage { get;  }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The target of the particular error. For example, the name of the property in error.",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(string) })]
        string MoveStatusErrorsPropertiesTarget { get;  }
        /// <summary>Defines the MoveResource states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Defines the MoveResource states.",
        SerializedName = @"moveState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? MoveStatusMoveState { get;  }
        /// <summary>Defines the provisioning states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Defines the provisioning states.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Gets or sets the resource settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the resource settings.",
        SerializedName = @"resourceSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings ResourceSetting { get; set; }
        /// <summary>Gets or sets the Source ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the Source ARM Id of the resource.",
        SerializedName = @"sourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SourceId { get; set; }
        /// <summary>Gets or sets the source resource settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the source resource settings.",
        SerializedName = @"sourceResourceSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings SourceResourceSetting { get;  }
        /// <summary>Gets or sets the Target ARM Id of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets or sets the Target ARM Id of the resource.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetId { get;  }

    }
    /// Defines the move resource properties.
    internal partial interface IMoveResourcePropertiesInternal

    {
        /// <summary>Gets or sets the move resource dependencies.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency[] DependsOn { get; set; }
        /// <summary>Gets or sets the move resource dependencies overrides.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride[] DependsOnOverride { get; set; }
        /// <summary>Defines the move resource errors.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError Error { get; set; }
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        string ErrorsPropertiesCode { get; set; }
        /// <summary>A list of additional details about the error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] ErrorsPropertiesDetail { get; set; }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        string ErrorsPropertiesMessage { get; set; }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        string ErrorsPropertiesTarget { get; set; }
        /// <summary>The move resource error body.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody ErrorsProperty { get; set; }
        /// <summary>Gets or sets the existing target ARM Id of the resource.</summary>
        string ExistingTargetId { get; set; }
        /// <summary>
        /// Gets a value indicating whether the resolve action is required over the move collection.
        /// </summary>
        bool? IsResolveRequired { get; set; }
        /// <summary>Defines the job name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName? JobStatusJobName { get; set; }
        /// <summary>Gets or sets the monitoring job percentage.</summary>
        string JobStatusJobProgress { get; set; }
        /// <summary>Defines the move resource status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus MoveStatus { get; set; }
        /// <summary>An error response from the azure resource mover service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError MoveStatusError { get; set; }
        /// <summary>
        /// An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
        /// </summary>
        string MoveStatusErrorsPropertiesCode { get; set; }
        /// <summary>A list of additional details about the error.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[] MoveStatusErrorsPropertiesDetail { get; set; }
        /// <summary>
        /// A message describing the error, intended to be suitable for display in a user interface.
        /// </summary>
        string MoveStatusErrorsPropertiesMessage { get; set; }
        /// <summary>
        /// The target of the particular error. For example, the name of the property in error.
        /// </summary>
        string MoveStatusErrorsPropertiesTarget { get; set; }
        /// <summary>The move resource error body.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody MoveStatusErrorsProperty { get; set; }
        /// <summary>Defines the job status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatus MoveStatusJobStatus { get; set; }
        /// <summary>Defines the MoveResource states.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState? MoveStatusMoveState { get; set; }
        /// <summary>Defines the provisioning states.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Gets or sets the resource settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings ResourceSetting { get; set; }
        /// <summary>Gets or sets the Source ARM Id of the resource.</summary>
        string SourceId { get; set; }
        /// <summary>Gets or sets the source resource settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings SourceResourceSetting { get; set; }
        /// <summary>Gets or sets the Target ARM Id of the resource.</summary>
        string TargetId { get; set; }

    }
}