namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of Hyper-V hosts.</summary>
    public partial class HyperVHostCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHostCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost[] _value;

        /// <summary>List of hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="HyperVHostCollection" /> instance.</summary>
        public HyperVHostCollection()
        {

        }
    }
    /// Collection of Hyper-V hosts.
    public partial interface IHyperVHostCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value of next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>List of hosts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of hosts.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost[] Value { get;  }

    }
    /// Collection of Hyper-V hosts.
    internal partial interface IHyperVHostCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of hosts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVHost[] Value { get; set; }

    }
}