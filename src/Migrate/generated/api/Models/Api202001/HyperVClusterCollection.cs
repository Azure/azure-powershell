namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of Hyper-V clusters.</summary>
    public partial class HyperVClusterCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVClusterCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster[] _value;

        /// <summary>List of clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="HyperVClusterCollection" /> instance.</summary>
        public HyperVClusterCollection()
        {

        }
    }
    /// Collection of Hyper-V clusters.
    public partial interface IHyperVClusterCollection :
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
        /// <summary>List of clusters.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of clusters.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster[] Value { get;  }

    }
    /// Collection of Hyper-V clusters.
    internal partial interface IHyperVClusterCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of clusters.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVCluster[] Value { get; set; }

    }
}