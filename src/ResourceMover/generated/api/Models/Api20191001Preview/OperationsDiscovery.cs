namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Operations discovery class.</summary>
    public partial class OperationsDiscovery :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscovery,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscoveryInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplay _display;

        /// <summary>
        /// Contains the localized display information for this particular operation / action. These
        /// value will be used by several clients for
        /// (1) custom role definitions for RBAC;
        /// (2) complex query filters for the event service; and
        /// (3) audit history / records for management operations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.Display()); set => this._display = value; }

        /// <summary>
        /// Gets or sets the description.
        /// The localized friendly description for the operation, as it should be shown to the
        /// user.
        /// It should be thorough, yet concise – it will be used in tool tips and detailed views.
        /// Prescriptive guidance for namespace:
        /// Read any 'display.provider' resource
        /// Create or Update any 'display.provider' resource
        /// Delete any 'display.provider' resource
        /// Perform any other action on any 'display.provider' resource
        /// Prescriptive guidance for namespace:
        /// Read any 'display.resource' Create or Update any 'display.resource' Delete any
        /// 'display.resource' 'ActionName' any 'display.resources'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Description = value; }

        /// <summary>
        /// Gets or sets the operation.
        /// The localized friendly name for the operation, as it should be shown to the user.
        /// It should be concise (to fit in drop downs) but clear (i.e. self-documenting).
        /// It should use Title Casing.
        /// Prescriptive guidance: Read Create or Update Delete 'ActionName'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Operation = value; }

        /// <summary>
        /// Gets or sets the provider.
        /// The localized friendly form of the resource provider name – it is expected to also
        /// include the publisher/company responsible.
        /// It should use Title Casing and begin with "Microsoft" for 1st party services.
        /// e.g. "Microsoft Monitoring Insights" or "Microsoft Compute.".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Provider = value; }

        /// <summary>
        /// Gets or sets the resource.
        /// The localized friendly form of the resource related to this action/operation – it
        /// should match the public documentation for the resource provider.
        /// It should use Title Casing.
        /// This value should be unique for a particular URL type (e.g. nested types should *not*
        /// reuse their parent’s display.resource field)
        /// e.g. "Virtual Machines" or "Scheduler Job Collections", or "Virtual Machine VM Sizes"
        /// or "Scheduler Jobs".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplay Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscoveryInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.Display()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Gets or sets Name of the API.
        /// The name of the operation being performed on this particular object. It should
        /// match the action name that appears in RBAC / the event service.
        /// Examples of operations include:
        /// * Microsoft.Compute/virtualMachine/capture/action
        /// * Microsoft.Compute/virtualMachine/restart/action
        /// * Microsoft.Compute/virtualMachine/write
        /// * Microsoft.Compute/virtualMachine/read
        /// * Microsoft.Compute/virtualMachine/delete
        /// Each action should include, in order:
        /// (1) Resource Provider Namespace
        /// (2) Type hierarchy for which the action applies (e.g. server/databases for a SQL
        /// Azure database)
        /// (3) Read, Write, Action or Delete indicating which type applies. If it is a PUT/PATCH
        /// on a collection or named value, Write should be used.
        /// If it is a GET, Read should be used. If it is a DELETE, Delete should be used. If it
        /// is a POST, Action should be used.
        /// As a note: all resource providers would need to include the "{Resource Provider
        /// Namespace}/register/action" operation in their response.
        /// This API is used to register for their service, and should include details about the
        /// operation (e.g. a localized name for the resource provider + any special
        /// considerations like PII release).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>
        /// Gets or sets Origin.
        /// The intended executor of the operation; governs the display of the operation in the
        /// RBAC UX and the audit logs UX.
        /// Default value is "user,system".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscoveryProperties _property;

        /// <summary>ClientDiscovery properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscoveryProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.OperationsDiscoveryProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="OperationsDiscovery" /> instance.</summary>
        public OperationsDiscovery()
        {

        }
    }
    /// Operations discovery class.
    public partial interface IOperationsDiscovery :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Gets or sets the description.
        /// The localized friendly description for the operation, as it should be shown to the
        /// user.
        /// It should be thorough, yet concise – it will be used in tool tips and detailed views.
        /// Prescriptive guidance for namespace:
        /// Read any 'display.provider' resource
        /// Create or Update any 'display.provider' resource
        /// Delete any 'display.provider' resource
        /// Perform any other action on any 'display.provider' resource
        /// Prescriptive guidance for namespace:
        /// Read any 'display.resource' Create or Update any 'display.resource' Delete any
        /// 'display.resource' 'ActionName' any 'display.resources'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the description.
        The localized friendly description for the operation, as it should be shown to the
        user.
        It should be thorough, yet concise – it will be used in tool tips and detailed views.
        Prescriptive guidance for namespace:
        Read any 'display.provider'  resource
        Create or Update any  'display.provider'  resource
        Delete any  'display.provider'  resource
        Perform any other action on any  'display.provider'  resource
        Prescriptive guidance for namespace:
        Read any 'display.resource' Create or Update any  'display.resource' Delete any
         'display.resource' 'ActionName' any 'display.resources'.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>
        /// Gets or sets the operation.
        /// The localized friendly name for the operation, as it should be shown to the user.
        /// It should be concise (to fit in drop downs) but clear (i.e. self-documenting).
        /// It should use Title Casing.
        /// Prescriptive guidance: Read Create or Update Delete 'ActionName'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the operation.
        The localized friendly name for the operation, as it should be shown to the user.
        It should be concise (to fit in drop downs) but clear (i.e. self-documenting).
        It should use Title Casing.
        Prescriptive guidance: Read Create or Update Delete 'ActionName'.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>
        /// Gets or sets the provider.
        /// The localized friendly form of the resource provider name – it is expected to also
        /// include the publisher/company responsible.
        /// It should use Title Casing and begin with "Microsoft" for 1st party services.
        /// e.g. "Microsoft Monitoring Insights" or "Microsoft Compute.".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the provider.
        The localized friendly form of the resource provider name – it is expected to also
        include the publisher/company responsible.
        It should use Title Casing and begin with ""Microsoft"" for 1st party services.
        e.g. ""Microsoft Monitoring Insights"" or ""Microsoft Compute."".",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>
        /// Gets or sets the resource.
        /// The localized friendly form of the resource related to this action/operation – it
        /// should match the public documentation for the resource provider.
        /// It should use Title Casing.
        /// This value should be unique for a particular URL type (e.g. nested types should *not*
        /// reuse their parent’s display.resource field)
        /// e.g. "Virtual Machines" or "Scheduler Job Collections", or "Virtual Machine VM Sizes"
        /// or "Scheduler Jobs".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the resource.
        The localized friendly form of the resource related to this action/operation – it
        should match the public documentation for the resource provider.
        It should use Title Casing.
        This value should be unique for a particular URL type (e.g. nested types should *not*
        reuse their parent’s display.resource field)
        e.g. ""Virtual Machines"" or ""Scheduler Job Collections"", or ""Virtual Machine VM Sizes""
        or ""Scheduler Jobs"".",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>
        /// Gets or sets Name of the API.
        /// The name of the operation being performed on this particular object. It should
        /// match the action name that appears in RBAC / the event service.
        /// Examples of operations include:
        /// * Microsoft.Compute/virtualMachine/capture/action
        /// * Microsoft.Compute/virtualMachine/restart/action
        /// * Microsoft.Compute/virtualMachine/write
        /// * Microsoft.Compute/virtualMachine/read
        /// * Microsoft.Compute/virtualMachine/delete
        /// Each action should include, in order:
        /// (1) Resource Provider Namespace
        /// (2) Type hierarchy for which the action applies (e.g. server/databases for a SQL
        /// Azure database)
        /// (3) Read, Write, Action or Delete indicating which type applies. If it is a PUT/PATCH
        /// on a collection or named value, Write should be used.
        /// If it is a GET, Read should be used. If it is a DELETE, Delete should be used. If it
        /// is a POST, Action should be used.
        /// As a note: all resource providers would need to include the "{Resource Provider
        /// Namespace}/register/action" operation in their response.
        /// This API is used to register for their service, and should include details about the
        /// operation (e.g. a localized name for the resource provider + any special
        /// considerations like PII release).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Name of the API.
        The name of the operation being performed on this particular object. It should
        match the action name that appears in RBAC / the event service.
        Examples of operations include:
        * Microsoft.Compute/virtualMachine/capture/action
        * Microsoft.Compute/virtualMachine/restart/action
        * Microsoft.Compute/virtualMachine/write
        * Microsoft.Compute/virtualMachine/read
        * Microsoft.Compute/virtualMachine/delete
        Each action should include, in order:
        (1) Resource Provider Namespace
        (2) Type hierarchy for which the action applies (e.g. server/databases for a SQL
        Azure database)
        (3) Read, Write, Action or Delete indicating which type applies. If it is a PUT/PATCH
        on a collection or named value, Write should be used.
        If it is a GET, Read should be used. If it is a DELETE, Delete should be used. If it
        is a POST, Action should be used.
        As a note: all resource providers would need to include the ""{Resource Provider
        Namespace}/register/action"" operation in their response.
        This API is used to register for their service, and should include details about the
        operation (e.g. a localized name for the resource provider + any special
        considerations like PII release).",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Gets or sets Origin.
        /// The intended executor of the operation; governs the display of the operation in the
        /// RBAC UX and the audit logs UX.
        /// Default value is "user,system".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets Origin.
        The intended executor of the operation; governs the display of the operation in the
        RBAC UX and the audit logs UX.
        Default value is ""user,system"".",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }
        /// <summary>ClientDiscovery properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ClientDiscovery properties.",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscoveryProperties) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscoveryProperties Property { get; set; }

    }
    /// Operations discovery class.
    internal partial interface IOperationsDiscoveryInternal

    {
        /// <summary>
        /// Contains the localized display information for this particular operation / action. These
        /// value will be used by several clients for
        /// (1) custom role definitions for RBAC;
        /// (2) complex query filters for the event service; and
        /// (3) audit history / records for management operations.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IDisplay Display { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// The localized friendly description for the operation, as it should be shown to the
        /// user.
        /// It should be thorough, yet concise – it will be used in tool tips and detailed views.
        /// Prescriptive guidance for namespace:
        /// Read any 'display.provider' resource
        /// Create or Update any 'display.provider' resource
        /// Delete any 'display.provider' resource
        /// Perform any other action on any 'display.provider' resource
        /// Prescriptive guidance for namespace:
        /// Read any 'display.resource' Create or Update any 'display.resource' Delete any
        /// 'display.resource' 'ActionName' any 'display.resources'.
        /// </summary>
        string DisplayDescription { get; set; }
        /// <summary>
        /// Gets or sets the operation.
        /// The localized friendly name for the operation, as it should be shown to the user.
        /// It should be concise (to fit in drop downs) but clear (i.e. self-documenting).
        /// It should use Title Casing.
        /// Prescriptive guidance: Read Create or Update Delete 'ActionName'.
        /// </summary>
        string DisplayOperation { get; set; }
        /// <summary>
        /// Gets or sets the provider.
        /// The localized friendly form of the resource provider name – it is expected to also
        /// include the publisher/company responsible.
        /// It should use Title Casing and begin with "Microsoft" for 1st party services.
        /// e.g. "Microsoft Monitoring Insights" or "Microsoft Compute.".
        /// </summary>
        string DisplayProvider { get; set; }
        /// <summary>
        /// Gets or sets the resource.
        /// The localized friendly form of the resource related to this action/operation – it
        /// should match the public documentation for the resource provider.
        /// It should use Title Casing.
        /// This value should be unique for a particular URL type (e.g. nested types should *not*
        /// reuse their parent’s display.resource field)
        /// e.g. "Virtual Machines" or "Scheduler Job Collections", or "Virtual Machine VM Sizes"
        /// or "Scheduler Jobs".
        /// </summary>
        string DisplayResource { get; set; }
        /// <summary>
        /// Gets or sets Name of the API.
        /// The name of the operation being performed on this particular object. It should
        /// match the action name that appears in RBAC / the event service.
        /// Examples of operations include:
        /// * Microsoft.Compute/virtualMachine/capture/action
        /// * Microsoft.Compute/virtualMachine/restart/action
        /// * Microsoft.Compute/virtualMachine/write
        /// * Microsoft.Compute/virtualMachine/read
        /// * Microsoft.Compute/virtualMachine/delete
        /// Each action should include, in order:
        /// (1) Resource Provider Namespace
        /// (2) Type hierarchy for which the action applies (e.g. server/databases for a SQL
        /// Azure database)
        /// (3) Read, Write, Action or Delete indicating which type applies. If it is a PUT/PATCH
        /// on a collection or named value, Write should be used.
        /// If it is a GET, Read should be used. If it is a DELETE, Delete should be used. If it
        /// is a POST, Action should be used.
        /// As a note: all resource providers would need to include the "{Resource Provider
        /// Namespace}/register/action" operation in their response.
        /// This API is used to register for their service, and should include details about the
        /// operation (e.g. a localized name for the resource provider + any special
        /// considerations like PII release).
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets Origin.
        /// The intended executor of the operation; governs the display of the operation in the
        /// RBAC UX and the audit logs UX.
        /// Default value is "user,system".
        /// </summary>
        string Origin { get; set; }
        /// <summary>ClientDiscovery properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IOperationsDiscoveryProperties Property { get; set; }

    }
}