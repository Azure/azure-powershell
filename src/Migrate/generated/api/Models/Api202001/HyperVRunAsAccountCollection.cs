namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of Hyper-V run as accounts.</summary>
    public partial class HyperVRunAsAccountCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccount[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccountCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccount[] _value;

        /// <summary>List of run as accounts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccount[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="HyperVRunAsAccountCollection" /> instance.</summary>
        public HyperVRunAsAccountCollection()
        {

        }
    }
    /// Collection of Hyper-V run as accounts.
    public partial interface IHyperVRunAsAccountCollection :
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
        /// <summary>List of run as accounts.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of run as accounts.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccount) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccount[] Value { get;  }

    }
    /// Collection of Hyper-V run as accounts.
    internal partial interface IHyperVRunAsAccountCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of run as accounts.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVRunAsAccount[] Value { get; set; }

    }
}