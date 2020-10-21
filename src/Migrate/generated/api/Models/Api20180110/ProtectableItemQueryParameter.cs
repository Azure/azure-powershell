namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Query parameter to enumerate Protectable items.</summary>
    public partial class ProtectableItemQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemQueryParameter,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemQueryParameterInternal
    {

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>State of the Protectable item query filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="ProtectableItemQueryParameter" /> instance.</summary>
        public ProtectableItemQueryParameter()
        {

        }
    }
    /// Query parameter to enumerate Protectable items.
    public partial interface IProtectableItemQueryParameter :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>State of the Protectable item query filter.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"State of the Protectable item query filter.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get; set; }

    }
    /// Query parameter to enumerate Protectable items.
    internal partial interface IProtectableItemQueryParameterInternal

    {
        /// <summary>State of the Protectable item query filter.</summary>
        string State { get; set; }

    }
}