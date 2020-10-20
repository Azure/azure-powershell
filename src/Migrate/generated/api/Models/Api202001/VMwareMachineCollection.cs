namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of VMware machines.</summary>
    public partial class VMwareMachineCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineCollectionInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineCollectionInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachineCollectionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine[] _value;

        /// <summary>List of machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="VMwareMachineCollection" /> instance.</summary>
        public VMwareMachineCollection()
        {

        }
    }
    /// Collection of VMware machines.
    public partial interface IVMwareMachineCollection :
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
        /// <summary>List of machines.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of machines.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine[] Value { get;  }

    }
    /// Collection of VMware machines.
    internal partial interface IVMwareMachineCollectionInternal

    {
        /// <summary>Value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>List of machines.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine[] Value { get; set; }

    }
}