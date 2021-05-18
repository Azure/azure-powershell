namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    public partial class PrivateEndpointConnectionCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateEndpointConnectionCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateEndpointConnectionCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateEndpointConnectionCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResource[] _value;

        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PrivateEndpointConnectionCollection" /> instance.</summary>
        public PrivateEndpointConnectionCollection()
        {

        }
    }
    public partial interface IPrivateEndpointConnectionCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Link to next page of resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Collection of resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResource[] Value { get; set; }

    }
    internal partial interface IPrivateEndpointConnectionCollectionInternal

    {
        /// <summary>Link to next page of resources.</summary>
        string NextLink { get; set; }
        /// <summary>Collection of resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IRemotePrivateEndpointConnectionArmResource[] Value { get; set; }

    }
}