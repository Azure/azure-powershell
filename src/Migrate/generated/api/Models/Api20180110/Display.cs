namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>
    /// Contains the localized display information for this particular operation / action. These value will be used by several
    /// clients for (1) custom role definitions for RBAC; (2) complex query filters for the event service; and (3) audit history
    /// / records for management operations.
    /// </summary>
    public partial class Display :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>
        /// The description. The localized friendly description for the operation, as it should be shown to the user. It should be
        /// thorough, yet concise – it will be used in tool tips and detailed views. Prescriptive guidance for namespaces: Read any
        /// 'display.provider' resource Create or Update any 'display.provider' resource Delete any 'display.provider' resource Perform
        /// any other action on any 'display.provider' resource Prescriptive guidance for namespaces: Read any 'display.resource'
        /// Create or Update any 'display.resource' Delete any 'display.resource' 'ActionName' any 'display.resources'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>
        /// The operation. The localized friendly name for the operation, as it should be shown to the user. It should be concise
        /// (to fit in drop downs) but clear (i.e. self-documenting). It should use Title Casing. Prescriptive guidance: Read Create
        /// or Update Delete 'ActionName'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; set => this._operation = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>
        /// The provider. The localized friendly form of the resource provider name – it is expected to also include the publisher/company
        /// responsible. It should use Title Casing and begin with "Microsoft" for 1st party services. e.g. "Microsoft Monitoring
        /// Insights" or "Microsoft Compute."
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>
        /// The resource. The localized friendly form of the resource related to this action/operation – it should match the public
        /// documentation for the resource provider. It should use Title Casing. This value should be unique for a particular URL
        /// type (e.g. nested types should *not* reuse their parent’s display.resource field). e.g. "Virtual Machines" or "Scheduler
        /// Job Collections", or "Virtual Machine VM Sizes" or "Scheduler Jobs"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Creates an new <see cref="Display" /> instance.</summary>
        public Display()
        {

        }
    }
    /// Contains the localized display information for this particular operation / action. These value will be used by several
    /// clients for (1) custom role definitions for RBAC; (2) complex query filters for the event service; and (3) audit history
    /// / records for management operations.
    public partial interface IDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The description. The localized friendly description for the operation, as it should be shown to the user. It should be
        /// thorough, yet concise – it will be used in tool tips and detailed views. Prescriptive guidance for namespaces: Read any
        /// 'display.provider' resource Create or Update any 'display.provider' resource Delete any 'display.provider' resource Perform
        /// any other action on any 'display.provider' resource Prescriptive guidance for namespaces: Read any 'display.resource'
        /// Create or Update any 'display.resource' Delete any 'display.resource' 'ActionName' any 'display.resources'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description. The localized friendly description for the operation, as it should be shown to the user. It should be thorough, yet concise – it will be used in tool tips and detailed views. Prescriptive guidance for namespaces: Read any 'display.provider' resource Create or Update any 'display.provider' resource Delete any 'display.provider' resource Perform any other action on any 'display.provider' resource Prescriptive guidance for namespaces: Read any 'display.resource' Create or Update any 'display.resource' Delete any 'display.resource' 'ActionName' any 'display.resources'",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>
        /// The operation. The localized friendly name for the operation, as it should be shown to the user. It should be concise
        /// (to fit in drop downs) but clear (i.e. self-documenting). It should use Title Casing. Prescriptive guidance: Read Create
        /// or Update Delete 'ActionName'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The operation. The localized friendly name for the operation, as it should be shown to the user. It should be concise (to fit in drop downs) but clear (i.e. self-documenting). It should use Title Casing. Prescriptive guidance: Read Create or Update Delete 'ActionName'",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get; set; }
        /// <summary>
        /// The provider. The localized friendly form of the resource provider name – it is expected to also include the publisher/company
        /// responsible. It should use Title Casing and begin with "Microsoft" for 1st party services. e.g. "Microsoft Monitoring
        /// Insights" or "Microsoft Compute."
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provider. The localized friendly form of the resource provider name – it is expected to also include the publisher/company responsible. It should use Title Casing and begin with ""Microsoft"" for 1st party services. e.g. ""Microsoft Monitoring Insights"" or ""Microsoft Compute.""",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }
        /// <summary>
        /// The resource. The localized friendly form of the resource related to this action/operation – it should match the public
        /// documentation for the resource provider. It should use Title Casing. This value should be unique for a particular URL
        /// type (e.g. nested types should *not* reuse their parent’s display.resource field). e.g. "Virtual Machines" or "Scheduler
        /// Job Collections", or "Virtual Machine VM Sizes" or "Scheduler Jobs"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource. The localized friendly form of the resource related to this action/operation – it should match the public documentation for the resource provider. It should use Title Casing. This value should be unique for a particular URL type (e.g. nested types should *not* reuse their parent’s display.resource field). e.g. ""Virtual Machines"" or ""Scheduler Job Collections"", or ""Virtual Machine VM Sizes"" or ""Scheduler Jobs""",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get; set; }

    }
    /// Contains the localized display information for this particular operation / action. These value will be used by several
    /// clients for (1) custom role definitions for RBAC; (2) complex query filters for the event service; and (3) audit history
    /// / records for management operations.
    internal partial interface IDisplayInternal

    {
        /// <summary>
        /// The description. The localized friendly description for the operation, as it should be shown to the user. It should be
        /// thorough, yet concise – it will be used in tool tips and detailed views. Prescriptive guidance for namespaces: Read any
        /// 'display.provider' resource Create or Update any 'display.provider' resource Delete any 'display.provider' resource Perform
        /// any other action on any 'display.provider' resource Prescriptive guidance for namespaces: Read any 'display.resource'
        /// Create or Update any 'display.resource' Delete any 'display.resource' 'ActionName' any 'display.resources'
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// The operation. The localized friendly name for the operation, as it should be shown to the user. It should be concise
        /// (to fit in drop downs) but clear (i.e. self-documenting). It should use Title Casing. Prescriptive guidance: Read Create
        /// or Update Delete 'ActionName'
        /// </summary>
        string Operation { get; set; }
        /// <summary>
        /// The provider. The localized friendly form of the resource provider name – it is expected to also include the publisher/company
        /// responsible. It should use Title Casing and begin with "Microsoft" for 1st party services. e.g. "Microsoft Monitoring
        /// Insights" or "Microsoft Compute."
        /// </summary>
        string Provider { get; set; }
        /// <summary>
        /// The resource. The localized friendly form of the resource related to this action/operation – it should match the public
        /// documentation for the resource provider. It should use Title Casing. This value should be unique for a particular URL
        /// type (e.g. nested types should *not* reuse their parent’s display.resource field). e.g. "Virtual Machines" or "Scheduler
        /// Job Collections", or "Virtual Machine VM Sizes" or "Scheduler Jobs"
        /// </summary>
        string Resource { get; set; }

    }
}