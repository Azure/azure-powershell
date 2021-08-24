namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Extensions;

    /// <summary>The resource provider operation definition.</summary>
    public partial class ResourceProviderOperationDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinitionInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplay _display;

        /// <summary>The resource provider operation details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ResourceProviderOperationDisplay()); set => this._display = value; }

        /// <summary>Description of the resource provider operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Description = value ?? null; }

        /// <summary>Name of the resource provider operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Operation = value ?? null; }

        /// <summary>Name of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Provider = value ?? null; }

        /// <summary>Name of the resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplayInternal)Display).Resource = value ?? null; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinitionInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.ResourceProviderOperationDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The resource provider operation name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ResourceProviderOperationDefinition" /> instance.</summary>
        public ResourceProviderOperationDefinition()
        {

        }
    }
    /// The resource provider operation definition.
    public partial interface IResourceProviderOperationDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IJsonSerializable
    {
        /// <summary>Description of the resource provider operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the resource provider operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Name of the resource provider operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource provider operation.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Name of the resource provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource provider.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Name of the resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource type.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>The resource provider operation name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource provider operation name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The resource provider operation definition.
    internal partial interface IResourceProviderOperationDefinitionInternal

    {
        /// <summary>The resource provider operation details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDisplay Display { get; set; }
        /// <summary>Description of the resource provider operation.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Name of the resource provider operation.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Name of the resource provider.</summary>
        string DisplayProvider { get; set; }
        /// <summary>Name of the resource type.</summary>
        string DisplayResource { get; set; }
        /// <summary>The resource provider operation name.</summary>
        string Name { get; set; }

    }
}