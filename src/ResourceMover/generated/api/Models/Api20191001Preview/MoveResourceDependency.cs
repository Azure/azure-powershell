namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines the dependency of the move resource.</summary>
    public partial class MoveResourceDependency :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceDependency,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceDependencyInternal
    {

        /// <summary>Backing field for <see cref="AutomaticResolution" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionProperties _automaticResolution;

        /// <summary>Defines the properties for automatic resolution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionProperties AutomaticResolution { get => (this._automaticResolution = this._automaticResolution ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.AutomaticResolutionProperties()); set => this._automaticResolution = value; }

        /// <summary>
        /// Gets the MoveResource ARM ID of
        /// the dependent resource if the resolution type is Automatic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string AutomaticResolutionMoveResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionPropertiesInternal)AutomaticResolution).MoveResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionPropertiesInternal)AutomaticResolution).MoveResourceId = value; }

        /// <summary>Backing field for <see cref="DependencyType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.DependencyType? _dependencyType;

        /// <summary>Defines the dependency type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.DependencyType? DependencyType { get => this._dependencyType; set => this._dependencyType = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Gets the source ARM ID of the dependent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="IsOptional" /> property.</summary>
        private string _isOptional;

        /// <summary>Gets or sets a value indicating whether the dependency is optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string IsOptional { get => this._isOptional; set => this._isOptional = value; }

        /// <summary>Backing field for <see cref="ManualResolution" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionProperties _manualResolution;

        /// <summary>Defines the properties for manual resolution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionProperties ManualResolution { get => (this._manualResolution = this._manualResolution ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ManualResolutionProperties()); set => this._manualResolution = value; }

        /// <summary>
        /// Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string ManualResolutionTargetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionPropertiesInternal)ManualResolution).TargetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionPropertiesInternal)ManualResolution).TargetId = value; }

        /// <summary>Internal Acessors for AutomaticResolution</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionProperties Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceDependencyInternal.AutomaticResolution { get => (this._automaticResolution = this._automaticResolution ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.AutomaticResolutionProperties()); set { {_automaticResolution = value;} } }

        /// <summary>Internal Acessors for ManualResolution</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionProperties Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IMoveResourceDependencyInternal.ManualResolution { get => (this._manualResolution = this._manualResolution ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ManualResolutionProperties()); set { {_manualResolution = value;} } }

        /// <summary>Backing field for <see cref="ResolutionStatus" /> property.</summary>
        private string _resolutionStatus;

        /// <summary>Gets the dependency resolution status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string ResolutionStatus { get => this._resolutionStatus; set => this._resolutionStatus = value; }

        /// <summary>Backing field for <see cref="ResolutionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResolutionType? _resolutionType;

        /// <summary>Defines the resolution type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResolutionType? ResolutionType { get => this._resolutionType; set => this._resolutionType = value; }

        /// <summary>Creates an new <see cref="MoveResourceDependency" /> instance.</summary>
        public MoveResourceDependency()
        {

        }
    }
    /// Defines the dependency of the move resource.
    public partial interface IMoveResourceDependency :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets the MoveResource ARM ID of
        /// the dependent resource if the resolution type is Automatic.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the MoveResource ARM ID of
        the dependent resource if the resolution type is Automatic.",
        SerializedName = @"moveResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string AutomaticResolutionMoveResourceId { get; set; }
        /// <summary>Defines the dependency type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines the dependency type.",
        SerializedName = @"dependencyType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.DependencyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.DependencyType? DependencyType { get; set; }
        /// <summary>Gets the source ARM ID of the dependent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the source ARM ID of the dependent resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Gets or sets a value indicating whether the dependency is optional.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a value indicating whether the dependency is optional.",
        SerializedName = @"isOptional",
        PossibleTypes = new [] { typeof(string) })]
        string IsOptional { get; set; }
        /// <summary>
        /// Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.",
        SerializedName = @"targetId",
        PossibleTypes = new [] { typeof(string) })]
        string ManualResolutionTargetId { get; set; }
        /// <summary>Gets the dependency resolution status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the dependency resolution status.",
        SerializedName = @"resolutionStatus",
        PossibleTypes = new [] { typeof(string) })]
        string ResolutionStatus { get; set; }
        /// <summary>Defines the resolution type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Defines the resolution type.",
        SerializedName = @"resolutionType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResolutionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResolutionType? ResolutionType { get; set; }

    }
    /// Defines the dependency of the move resource.
    internal partial interface IMoveResourceDependencyInternal

    {
        /// <summary>Defines the properties for automatic resolution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAutomaticResolutionProperties AutomaticResolution { get; set; }
        /// <summary>
        /// Gets the MoveResource ARM ID of
        /// the dependent resource if the resolution type is Automatic.
        /// </summary>
        string AutomaticResolutionMoveResourceId { get; set; }
        /// <summary>Defines the dependency type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.DependencyType? DependencyType { get; set; }
        /// <summary>Gets the source ARM ID of the dependent resource.</summary>
        string Id { get; set; }
        /// <summary>Gets or sets a value indicating whether the dependency is optional.</summary>
        string IsOptional { get; set; }
        /// <summary>Defines the properties for manual resolution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IManualResolutionProperties ManualResolution { get; set; }
        /// <summary>
        /// Gets or sets the target resource ARM ID of the dependent resource if the resource type is Manual.
        /// </summary>
        string ManualResolutionTargetId { get; set; }
        /// <summary>Gets the dependency resolution status.</summary>
        string ResolutionStatus { get; set; }
        /// <summary>Defines the resolution type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ResolutionType? ResolutionType { get; set; }

    }
}