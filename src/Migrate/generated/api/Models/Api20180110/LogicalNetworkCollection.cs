namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>List of logical networks.</summary>
    public partial class LogicalNetworkCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetworkCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetwork[] _value;

        /// <summary>The Logical Networks list details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetwork[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="LogicalNetworkCollection" /> instance.</summary>
        public LogicalNetworkCollection()
        {

        }
    }
    /// List of logical networks.
    public partial interface ILogicalNetworkCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The value of next link.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The Logical Networks list details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Logical Networks list details.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetwork) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetwork[] Value { get; set; }

    }
    /// List of logical networks.
    internal partial interface ILogicalNetworkCollectionInternal

    {
        /// <summary>The value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>The Logical Networks list details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ILogicalNetwork[] Value { get; set; }

    }
}