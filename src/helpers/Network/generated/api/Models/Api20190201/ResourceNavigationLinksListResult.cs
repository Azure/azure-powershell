namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ResourceNavigationLinks_Get operation.</summary>
    public partial class ResourceNavigationLinksListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLinksListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLinksListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] _value;

        /// <summary>The resource navigation links in a subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ResourceNavigationLinksListResult" /> instance.</summary>
        public ResourceNavigationLinksListResult()
        {

        }
    }
    /// Response for ResourceNavigationLinks_Get operation.
    public partial interface IResourceNavigationLinksListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The resource navigation links in a subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource navigation links in a subnet.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] Value { get; set; }

    }
    /// Response for ResourceNavigationLinks_Get operation.
    internal partial interface IResourceNavigationLinksListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>The resource navigation links in a subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceNavigationLink[] Value { get; set; }

    }
}