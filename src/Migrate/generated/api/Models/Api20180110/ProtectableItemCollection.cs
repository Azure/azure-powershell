namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Protectable item collection.</summary>
    public partial class ProtectableItemCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The value of next link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItem[] _value;

        /// <summary>The Protectable item details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItem[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ProtectableItemCollection" /> instance.</summary>
        public ProtectableItemCollection()
        {

        }
    }
    /// Protectable item collection.
    public partial interface IProtectableItemCollection :
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
        /// <summary>The Protectable item details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Protectable item details.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItem) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItem[] Value { get; set; }

    }
    /// Protectable item collection.
    internal partial interface IProtectableItemCollectionInternal

    {
        /// <summary>The value of next link.</summary>
        string NextLink { get; set; }
        /// <summary>The Protectable item details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItem[] Value { get; set; }

    }
}