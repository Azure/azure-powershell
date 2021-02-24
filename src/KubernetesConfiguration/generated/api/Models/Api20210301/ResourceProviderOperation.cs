namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Supported operation of this resource provider.</summary>
    public partial class ResourceProviderOperation :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperation,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplay _display;

        /// <summary>Display metadata associated with the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ResourceProviderOperationDisplay()); set => this._display = value; }

        /// <summary>Description of this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Description = value; }

        /// <summary>Type of operation: get, read, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Operation = value; }

        /// <summary>Resource provider: Microsoft KubernetesConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Provider = value; }

        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal)Display).Resource = value; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>The flag that indicates whether the operation applies to data plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.ResourceProviderOperationDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for IsDataAction</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationInternal.IsDataAction { get => this._isDataAction; set { {_isDataAction = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name, in format of {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ResourceProviderOperation" /> instance.</summary>
        public ResourceProviderOperation()
        {

        }
    }
    /// Supported operation of this resource provider.
    public partial interface IResourceProviderOperation :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>Description of this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of this operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Type of operation: get, read, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of operation: get, read, delete, etc.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Resource provider: Microsoft KubernetesConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource provider: Microsoft KubernetesConfiguration.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource on which the operation is performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>The flag that indicates whether the operation applies to data plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The flag that indicates whether the operation applies to data plane.",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get;  }
        /// <summary>Operation name, in format of {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation name, in format of {provider}/{resource}/{operation}",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Supported operation of this resource provider.
    internal partial interface IResourceProviderOperationInternal

    {
        /// <summary>Display metadata associated with the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplay Display { get; set; }
        /// <summary>Description of this operation.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Type of operation: get, read, delete, etc.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Resource provider: Microsoft KubernetesConfiguration.</summary>
        string DisplayProvider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        string DisplayResource { get; set; }
        /// <summary>The flag that indicates whether the operation applies to data plane.</summary>
        bool? IsDataAction { get; set; }
        /// <summary>Operation name, in format of {provider}/{resource}/{operation}</summary>
        string Name { get; set; }

    }
}