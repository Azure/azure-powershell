namespace Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Extensions;

    /// <summary>Display metadata associated with the operation.</summary>
    public partial class ResourceProviderOperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Models.Api20210301.IResourceProviderOperationDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>Type of operation: get, read, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; set => this._operation = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>Resource provider: Microsoft KubernetesConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Creates an new <see cref="ResourceProviderOperationDisplay" /> instance.</summary>
        public ResourceProviderOperationDisplay()
        {

        }
    }
    /// Display metadata associated with the operation.
    public partial interface IResourceProviderOperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>Description of this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of this operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Type of operation: get, read, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of operation: get, read, delete, etc.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get; set; }
        /// <summary>Resource provider: Microsoft KubernetesConfiguration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource provider: Microsoft KubernetesConfiguration.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.KubernetesConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource on which the operation is performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get; set; }

    }
    /// Display metadata associated with the operation.
    internal partial interface IResourceProviderOperationDisplayInternal

    {
        /// <summary>Description of this operation.</summary>
        string Description { get; set; }
        /// <summary>Type of operation: get, read, delete, etc.</summary>
        string Operation { get; set; }
        /// <summary>Resource provider: Microsoft KubernetesConfiguration.</summary>
        string Provider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        string Resource { get; set; }

    }
}