namespace Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Extensions;

    /// <summary>The resource provider operation list.</summary>
    public partial class ResourceProviderOperationList :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationList,
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationListInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URI that can be used to request the next page for list of Azure operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinition[] _value;

        /// <summary>Resource provider operations list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Origin(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinition[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ResourceProviderOperationList" /> instance.</summary>
        public ResourceProviderOperationList()
        {

        }
    }
    /// The resource provider operation list.
    public partial interface IResourceProviderOperationList :
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.IJsonSerializable
    {
        /// <summary>The URI that can be used to request the next page for list of Azure operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI that can be used to request the next page for list of Azure operations.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Resource provider operations list.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource provider operations list.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinition[] Value { get; set; }

    }
    /// The resource provider operation list.
    internal partial interface IResourceProviderOperationListInternal

    {
        /// <summary>The URI that can be used to request the next page for list of Azure operations.</summary>
        string NextLink { get; set; }
        /// <summary>Resource provider operations list.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ChangeAnalysis.Models.Api20210401.IResourceProviderOperationDefinition[] Value { get; set; }

    }
}