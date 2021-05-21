namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Available operation details.</summary>
    public partial class ClientDiscoveryValueForSingleApi :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApi,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApiInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplay _display;

        /// <summary>Contains the localized display information for this particular operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ClientDiscoveryDisplay()); set => this._display = value; }

        /// <summary>Description of the operation having details of what operation is about.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Description = value ?? null; }

        /// <summary>Operations Name itself.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Operation = value ?? null; }

        /// <summary>Name of the provider for display purposes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Provider = value ?? null; }

        /// <summary>ResourceType for which this Operation can be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal)Display).Resource = value ?? null; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplay Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApiInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ClientDiscoveryDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForProperties Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApiInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ClientDiscoveryForProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ServiceSpecification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForServiceSpecification Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryValueForSingleApiInternal.ServiceSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForPropertiesInternal)Property).ServiceSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForPropertiesInternal)Property).ServiceSpecification = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>
        /// The intended executor of the operation;governs the display of the operation in the RBAC UX and the audit logs UX
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForProperties _property;

        /// <summary>Properties for the given operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ClientDiscoveryForProperties()); set => this._property = value; }

        /// <summary>List of log specifications of this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForLogSpecification[] ServiceSpecificationLogSpecification { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForPropertiesInternal)Property).ServiceSpecificationLogSpecification; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForPropertiesInternal)Property).ServiceSpecificationLogSpecification = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="ClientDiscoveryValueForSingleApi" /> instance.</summary>
        public ClientDiscoveryValueForSingleApi()
        {

        }
    }
    /// Available operation details.
    public partial interface IClientDiscoveryValueForSingleApi :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Description of the operation having details of what operation is about.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the operation having details of what operation is about.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Operations Name itself.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operations Name itself.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Name of the provider for display purposes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the provider for display purposes",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>ResourceType for which this Operation can be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ResourceType for which this Operation can be performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the operation is a data action",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get; set; }
        /// <summary>Name of the Operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Operation.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// The intended executor of the operation;governs the display of the operation in the RBAC UX and the audit logs UX
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The intended executor of the operation;governs the display of the operation in the RBAC UX and the audit logs UX",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }
        /// <summary>List of log specifications of this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of log specifications of this operation.",
        SerializedName = @"logSpecifications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForLogSpecification) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForLogSpecification[] ServiceSpecificationLogSpecification { get; set; }

    }
    /// Available operation details.
    internal partial interface IClientDiscoveryValueForSingleApiInternal

    {
        /// <summary>Contains the localized display information for this particular operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplay Display { get; set; }
        /// <summary>Description of the operation having details of what operation is about.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Operations Name itself.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Name of the provider for display purposes</summary>
        string DisplayProvider { get; set; }
        /// <summary>ResourceType for which this Operation can be performed.</summary>
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        bool? IsDataAction { get; set; }
        /// <summary>Name of the Operation.</summary>
        string Name { get; set; }
        /// <summary>
        /// The intended executor of the operation;governs the display of the operation in the RBAC UX and the audit logs UX
        /// </summary>
        string Origin { get; set; }
        /// <summary>Properties for the given operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForProperties Property { get; set; }
        /// <summary>Operation properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForServiceSpecification ServiceSpecification { get; set; }
        /// <summary>List of log specifications of this operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryForLogSpecification[] ServiceSpecificationLogSpecification { get; set; }

    }
}