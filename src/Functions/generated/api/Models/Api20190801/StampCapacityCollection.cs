namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Collection of stamp capacities.</summary>
    public partial class StampCapacityCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacityCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] _value;

        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="StampCapacityCollection" /> instance.</summary>
        public StampCapacityCollection()
        {

        }
    }
    /// Collection of stamp capacities.
    public partial interface IStampCapacityCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Link to next page of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Link to next page of resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>Collection of resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Collection of resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] Value { get; set; }

    }
    /// Collection of stamp capacities.
    internal partial interface IStampCapacityCollectionInternal

    {
        /// <summary>Link to next page of resources.</summary>
        string NextLink { get; set; }
        /// <summary>Collection of resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[] Value { get; set; }

    }
}