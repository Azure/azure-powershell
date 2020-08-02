namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The definition of a configuration store operation.</summary>
    public partial class OperationDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplay _display;

        /// <summary>The display information for the configuration store operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.OperationDefinitionDisplay()); set => this._display = value; }

        /// <summary>The description for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Description = value; }

        /// <summary>The operation that users can perform.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Operation = value; }

        /// <summary>The resource provider name: Microsoft App Configuration."</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Provider; }

        /// <summary>The resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplay Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.OperationDefinitionDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for DisplayProvider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionInternal.DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplayInternal)Display).Provider = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="OperationDefinition" /> instance.</summary>
        public OperationDefinition()
        {

        }
    }
    /// The definition of a configuration store operation.
    public partial interface IOperationDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The description for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description for the operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>The operation that users can perform.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The operation that users can perform.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>The resource provider name: Microsoft App Configuration."</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource provider name: Microsoft App Configuration.""",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get;  }
        /// <summary>The resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource on which the operation is performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation name: {provider}/{resource}/{operation}.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The definition of a configuration store operation.
    internal partial interface IOperationDefinitionInternal

    {
        /// <summary>The display information for the configuration store operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IOperationDefinitionDisplay Display { get; set; }
        /// <summary>The description for the operation.</summary>
        string DisplayDescription { get; set; }
        /// <summary>The operation that users can perform.</summary>
        string DisplayOperation { get; set; }
        /// <summary>The resource provider name: Microsoft App Configuration."</summary>
        string DisplayProvider { get; set; }
        /// <summary>The resource on which the operation is performed.</summary>
        string DisplayResource { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        string Name { get; set; }

    }
}