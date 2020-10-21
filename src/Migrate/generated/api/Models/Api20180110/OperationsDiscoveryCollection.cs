namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of ClientDiscovery details.</summary>
    public partial class OperationsDiscoveryCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOperationsDiscoveryCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOperationsDiscoveryCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOperationsDiscovery[] _value;

        /// <summary>The ClientDiscovery details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOperationsDiscovery[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationsDiscoveryCollection" /> instance.</summary>
        public OperationsDiscoveryCollection()
        {

        }
    }
    /// Collection of ClientDiscovery details.
    public partial interface IOperationsDiscoveryCollection :
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
        /// <summary>The ClientDiscovery details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ClientDiscovery details.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOperationsDiscovery) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOperationsDiscovery[] Value { get; set; }

    }
    /// Collection of ClientDiscovery details.
    internal partial interface IOperationsDiscoveryCollectionInternal

    {
        /// <summary>The value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>The ClientDiscovery details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOperationsDiscovery[] Value { get; set; }

    }
}