namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Discover protectable item properties.</summary>
    public partial class DiscoverProtectableItemRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The friendly name of the physical machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The IP address of the physical machine to be discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>The OS type on the physical machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>
        /// Creates an new <see cref="DiscoverProtectableItemRequestProperties" /> instance.
        /// </summary>
        public DiscoverProtectableItemRequestProperties()
        {

        }
    }
    /// Discover protectable item properties.
    public partial interface IDiscoverProtectableItemRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The friendly name of the physical machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The friendly name of the physical machine.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The IP address of the physical machine to be discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address of the physical machine to be discovered.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The OS type on the physical machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The OS type on the physical machine.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        string OSType { get; set; }

    }
    /// Discover protectable item properties.
    internal partial interface IDiscoverProtectableItemRequestPropertiesInternal

    {
        /// <summary>The friendly name of the physical machine.</summary>
        string FriendlyName { get; set; }
        /// <summary>The IP address of the physical machine to be discovered.</summary>
        string IPAddress { get; set; }
        /// <summary>The OS type on the physical machine.</summary>
        string OSType { get; set; }

    }
}