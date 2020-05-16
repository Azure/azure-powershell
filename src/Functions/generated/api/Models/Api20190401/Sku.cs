namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The SKU of the storage account.</summary>
    public partial class Sku :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISku,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal
    {

        /// <summary>Backing field for <see cref="Capability" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] _capability;

        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] Capability { get => this._capability; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? _kind;

        /// <summary>Indicates the type of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get => this._kind; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string[] _location;

        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Location { get => this._location; }

        /// <summary>Internal Acessors for Capability</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal.Capability { get => this._capability; set { {_capability = value;} } }

        /// <summary>Internal Acessors for Kind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal.Kind { get => this._kind; set { {_kind = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for ResourceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal.ResourceType { get => this._resourceType; set { {_resourceType = value;} } }

        /// <summary>Internal Acessors for Tier</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuInternal.Tier { get => this._tier; set { {_tier = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName _name;

        /// <summary>
        /// Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was
        /// called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; }

        /// <summary>Backing field for <see cref="Restriction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[] _restriction;

        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[] Restriction { get => this._restriction; set => this._restriction = value; }

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? _tier;

        /// <summary>Gets the SKU tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? Tier { get => this._tier; }

        /// <summary>Creates an new <see cref="Sku" /> instance.</summary>
        public Sku()
        {

        }
    }
    /// The SKU of the storage account.
    public partial interface ISku :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.",
        SerializedName = @"capabilities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] Capability { get;  }
        /// <summary>Indicates the type of storage account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates the type of storage account.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get;  }
        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.).",
        SerializedName = @"locations",
        PossibleTypes = new [] { typeof(string) })]
        string[] Location { get;  }
        /// <summary>
        /// Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was
        /// called accountType.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName Name { get; set; }
        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the resource, usually it is 'storageAccounts'.",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get;  }
        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.",
        SerializedName = @"restrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[] Restriction { get; set; }
        /// <summary>Gets the SKU tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the SKU tier. This is based on the SKU name.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? Tier { get;  }

    }
    /// The SKU of the storage account.
    internal partial interface ISkuInternal

    {
        /// <summary>
        /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ISkuCapability[] Capability { get; set; }
        /// <summary>Indicates the type of storage account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Kind? Kind { get; set; }
        /// <summary>
        /// The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US,
        /// East US, Southeast Asia, etc.).
        /// </summary>
        string[] Location { get; set; }
        /// <summary>
        /// Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was
        /// called accountType.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuName Name { get; set; }
        /// <summary>The type of the resource, usually it is 'storageAccounts'.</summary>
        string ResourceType { get; set; }
        /// <summary>
        /// The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction[] Restriction { get; set; }
        /// <summary>Gets the SKU tier. This is based on the SKU name.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuTier? Tier { get; set; }

    }
}