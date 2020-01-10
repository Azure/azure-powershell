namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Response for ListSubnets API service callRetrieves all subnet that belongs to a virtual network
    /// </summary>
    public partial class SubnetListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] _value;

        /// <summary>The subnets in a virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="SubnetListResult" /> instance.</summary>
        public SubnetListResult()
        {

        }
    }
    /// Response for ListSubnets API service callRetrieves all subnet that belongs to a virtual network
    public partial interface ISubnetListResult :
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
        /// <summary>The subnets in a virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The subnets in a virtual network.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Value { get; set; }

    }
    /// Response for ListSubnets API service callRetrieves all subnet that belongs to a virtual network
    internal partial interface ISubnetListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>The subnets in a virtual network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Value { get; set; }

    }
}