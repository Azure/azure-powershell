namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>An array of available delegations.</summary>
    public partial class AvailableDelegationsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegationsResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegationsResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegationsResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegation[] _value;

        /// <summary>An array of available delegations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegation[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="AvailableDelegationsResult" /> instance.</summary>
        public AvailableDelegationsResult()
        {

        }
    }
    /// An array of available delegations.
    public partial interface IAvailableDelegationsResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>An array of available delegations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of available delegations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegation[] Value { get; set; }

    }
    /// An array of available delegations.
    internal partial interface IAvailableDelegationsResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>An array of available delegations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegation[] Value { get; set; }

    }
}