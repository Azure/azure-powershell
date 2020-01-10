namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Response for ListPublicIpPrefixes API service call.</summary>
    public partial class PublicIPPrefixListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefixListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix[] _value;

        /// <summary>A list of public IP prefixes that exists in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PublicIPPrefixListResult" /> instance.</summary>
        public PublicIPPrefixListResult()
        {

        }
    }
    /// Response for ListPublicIpPrefixes API service call.
    public partial interface IPublicIPPrefixListResult :
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
        /// <summary>A list of public IP prefixes that exists in a resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of public IP prefixes that exists in a resource group.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix[] Value { get; set; }

    }
    /// Response for ListPublicIpPrefixes API service call.
    internal partial interface IPublicIPPrefixListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of public IP prefixes that exists in a resource group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPPrefix[] Value { get; set; }

    }
}