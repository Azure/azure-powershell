namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Request to add a physical machine as a protectable item in a container.</summary>
    public partial class DiscoverProtectableItemRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestInternal
    {

        /// <summary>The friendly name of the physical machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestPropertiesInternal)Property).FriendlyName = value ?? null; }

        /// <summary>The IP address of the physical machine to be discovered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string IPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestPropertiesInternal)Property).IPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestPropertiesInternal)Property).IPAddress = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiscoverProtectableItemRequestProperties()); set { {_property = value;} } }

        /// <summary>The OS type on the physical machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string OSType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestPropertiesInternal)Property).OSType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestPropertiesInternal)Property).OSType = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestProperties _property;

        /// <summary>The properties of a discover protectable item request.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiscoverProtectableItemRequestProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="DiscoverProtectableItemRequest" /> instance.</summary>
        public DiscoverProtectableItemRequest()
        {

        }
    }
    /// Request to add a physical machine as a protectable item in a container.
    public partial interface IDiscoverProtectableItemRequest :
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
    /// Request to add a physical machine as a protectable item in a container.
    internal partial interface IDiscoverProtectableItemRequestInternal

    {
        /// <summary>The friendly name of the physical machine.</summary>
        string FriendlyName { get; set; }
        /// <summary>The IP address of the physical machine to be discovered.</summary>
        string IPAddress { get; set; }
        /// <summary>The OS type on the physical machine.</summary>
        string OSType { get; set; }
        /// <summary>The properties of a discover protectable item request.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiscoverProtectableItemRequestProperties Property { get; set; }

    }
}