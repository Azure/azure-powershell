namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of SiteHealthSummary.</summary>
    public partial class SiteHealthSummaryCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummaryCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary[] _value;

        /// <summary>List of SiteHealthSummary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="SiteHealthSummaryCollection" /> instance.</summary>
        public SiteHealthSummaryCollection()
        {

        }
    }
    /// Collection of SiteHealthSummary.
    public partial interface ISiteHealthSummaryCollection :
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
        /// <summary>List of SiteHealthSummary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of SiteHealthSummary.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary[] Value { get;  }

    }
    /// Collection of SiteHealthSummary.
    internal partial interface ISiteHealthSummaryCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of SiteHealthSummary.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteHealthSummary[] Value { get; set; }

    }
}