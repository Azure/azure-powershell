namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>
    /// Details of a REST API operation, returned from the Resource Provider Operations API
    /// </summary>
    public partial class Operation :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperation,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal
    {

        /// <summary>Backing field for <see cref="ActionType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ActionType? _actionType;

        /// <summary>
        /// Enum. Indicates the action type. "Internal" refers to actions that are for internal only APIs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ActionType? ActionType { get => this._actionType; }

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplay _display;

        /// <summary>Localized display information for this particular operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.OperationDisplay()); set => this._display = value; }

        /// <summary>
        /// The short, localized friendly description of the operation; suitable for tool tips and detailed views.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Description; }

        /// <summary>
        /// The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine",
        /// "Restart Virtual Machine".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Operation; }

        /// <summary>
        /// The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Provider; }

        /// <summary>
        /// The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Resource; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>
        /// Whether the operation applies to data-plane. This is "true" for data-plane operations and "false" for ARM/control-plane
        /// operations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; }

        /// <summary>Internal Acessors for ActionType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ActionType? Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.ActionType { get => this._actionType; set { {_actionType = value;} } }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for DisplayDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Description = value; }

        /// <summary>Internal Acessors for DisplayOperation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Operation = value; }

        /// <summary>Internal Acessors for DisplayProvider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Provider = value; }

        /// <summary>Internal Acessors for DisplayResource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for IsDataAction</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.IsDataAction { get => this._isDataAction; set { {_isDataAction = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Origin</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Origin? Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationInternal.Origin { get => this._origin; set { {_origin = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the operation, as per Resource-Based Access Control (RBAC). Examples: "Microsoft.Compute/virtualMachines/write",
        /// "Microsoft.Compute/virtualMachines/capture/action"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Origin? _origin;

        /// <summary>
        /// The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is
        /// "user,system"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Origin? Origin { get => this._origin; }

        /// <summary>Creates an new <see cref="Operation" /> instance.</summary>
        public Operation()
        {

        }
    }
    /// Details of a REST API operation, returned from the Resource Provider Operations API
    public partial interface IOperation :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Enum. Indicates the action type. "Internal" refers to actions that are for internal only APIs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Enum. Indicates the action type. ""Internal"" refers to actions that are for internal only APIs.",
        SerializedName = @"actionType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ActionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ActionType? ActionType { get;  }
        /// <summary>
        /// The short, localized friendly description of the operation; suitable for tool tips and detailed views.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The short, localized friendly description of the operation; suitable for tool tips and detailed views.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get;  }
        /// <summary>
        /// The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine",
        /// "Restart Virtual Machine".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The concise, localized friendly name for the operation; suitable for dropdowns. E.g. ""Create or Update Virtual Machine"", ""Restart Virtual Machine"".",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get;  }
        /// <summary>
        /// The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly form of the resource provider name, e.g. ""Microsoft Monitoring Insights"" or ""Microsoft Compute"".",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get;  }
        /// <summary>
        /// The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly name of the resource type related to this operation. E.g. ""Virtual Machines"" or ""Job Schedule Collections"".",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get;  }
        /// <summary>
        /// Whether the operation applies to data-plane. This is "true" for data-plane operations and "false" for ARM/control-plane
        /// operations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Whether the operation applies to data-plane. This is ""true"" for data-plane operations and ""false"" for ARM/control-plane operations.",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get;  }
        /// <summary>
        /// The name of the operation, as per Resource-Based Access Control (RBAC). Examples: "Microsoft.Compute/virtualMachines/write",
        /// "Microsoft.Compute/virtualMachines/capture/action"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the operation, as per Resource-Based Access Control (RBAC). Examples: ""Microsoft.Compute/virtualMachines/write"", ""Microsoft.Compute/virtualMachines/capture/action""",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is
        /// "user,system"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is ""user,system""",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Origin) })]
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Origin? Origin { get;  }

    }
    /// Details of a REST API operation, returned from the Resource Provider Operations API
    internal partial interface IOperationInternal

    {
        /// <summary>
        /// Enum. Indicates the action type. "Internal" refers to actions that are for internal only APIs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.ActionType? ActionType { get; set; }
        /// <summary>Localized display information for this particular operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplay Display { get; set; }
        /// <summary>
        /// The short, localized friendly description of the operation; suitable for tool tips and detailed views.
        /// </summary>
        string DisplayDescription { get; set; }
        /// <summary>
        /// The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine",
        /// "Restart Virtual Machine".
        /// </summary>
        string DisplayOperation { get; set; }
        /// <summary>
        /// The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
        /// </summary>
        string DisplayProvider { get; set; }
        /// <summary>
        /// The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
        /// </summary>
        string DisplayResource { get; set; }
        /// <summary>
        /// Whether the operation applies to data-plane. This is "true" for data-plane operations and "false" for ARM/control-plane
        /// operations.
        /// </summary>
        bool? IsDataAction { get; set; }
        /// <summary>
        /// The name of the operation, as per Resource-Based Access Control (RBAC). Examples: "Microsoft.Compute/virtualMachines/write",
        /// "Microsoft.Compute/virtualMachines/capture/action"
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// The intended executor of the operation; as in Resource Based Access Control (RBAC) and audit logs UX. Default value is
        /// "user,system"
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.Origin? Origin { get; set; }

    }
}