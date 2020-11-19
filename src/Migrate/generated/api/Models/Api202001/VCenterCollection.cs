namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of vCenter.</summary>
    public partial class VCenterCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenterCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter[] _value;

        /// <summary>List of vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="VCenterCollection" /> instance.</summary>
        public VCenterCollection()
        {

        }
    }
    /// Collection of vCenter.
    public partial interface IVCenterCollection :
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
        /// <summary>List of vCenter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of vCenter.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter[] Value { get;  }

    }
    /// Collection of vCenter.
    internal partial interface IVCenterCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of vCenter.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVCenter[] Value { get; set; }

    }
}