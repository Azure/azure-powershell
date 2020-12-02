namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of VMware jobs.</summary>
    public partial class VMwareJobCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJob[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJobCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJob[] _value;

        /// <summary>List of jobs.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJob[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="VMwareJobCollection" /> instance.</summary>
        public VMwareJobCollection()
        {

        }
    }
    /// Collection of VMware jobs.
    public partial interface IVMwareJobCollection :
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJob) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJob[] Value { get;  }

    }
    /// Collection of VMware jobs.
    internal partial interface IVMwareJobCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of jobs.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareJob[] Value { get; set; }

    }
}