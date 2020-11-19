namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of Hyper-V jobs.</summary>
    public partial class HyperVJobCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJobCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJobCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJobCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJob[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJobCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJob[] _value;

        /// <summary>List of jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJob[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="HyperVJobCollection" /> instance.</summary>
        public HyperVJobCollection()
        {

        }
    }
    /// Collection of Hyper-V jobs.
    public partial interface IHyperVJobCollection :
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
        /// <summary>List of jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of jobs.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJob) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJob[] Value { get;  }

    }
    /// Collection of Hyper-V jobs.
    internal partial interface IHyperVJobCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of jobs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVJob[] Value { get; set; }

    }
}