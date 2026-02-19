// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The marketplace sku</summary>
    public partial class MarketplaceSku :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuInternal
    {

        /// <summary>Backing field for <see cref="CatalogPlanId" /> property.</summary>
        private string _catalogPlanId;

        /// <summary>The catalog plan id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string CatalogPlanId { get => this._catalogPlanId; set => this._catalogPlanId = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of marketplace sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="DisplayRank" /> property.</summary>
        private int? _displayRank;

        /// <summary>The display rank of the sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public int? DisplayRank { get => this._displayRank; set => this._displayRank = value; }

        /// <summary>Backing field for <see cref="Generation" /> property.</summary>
        private string _generation;

        /// <summary>The generation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Generation { get => this._generation; set => this._generation = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The marketplace sku id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="LongSummary" /> property.</summary>
        private string _longSummary;

        /// <summary>The long summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string LongSummary { get => this._longSummary; set => this._longSummary = value; }

        /// <summary>Internal Acessors for OperatingSystem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystem Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuInternal.OperatingSystem { get => (this._operatingSystem = this._operatingSystem ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.SkuOperatingSystem()); set { {_operatingSystem = value;} } }

        /// <summary>Backing field for <see cref="OperatingSystem" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystem _operatingSystem;

        /// <summary>The operating system supported</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystem OperatingSystem { get => (this._operatingSystem = this._operatingSystem ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.SkuOperatingSystem()); set => this._operatingSystem = value; }

        /// <summary>The family of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string OperatingSystemFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystemInternal)OperatingSystem).Family; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystemInternal)OperatingSystem).Family = value ?? null; }

        /// <summary>The name of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string OperatingSystemName { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystemInternal)OperatingSystem).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystemInternal)OperatingSystem).Name = value ?? null; }

        /// <summary>The type of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string OperatingSystemType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystemInternal)OperatingSystem).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystemInternal)OperatingSystem).Type = value ?? null; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private string _summary;

        /// <summary>The summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Summary { get => this._summary; set => this._summary = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of marketplace sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion> _version;

        /// <summary>The marketplace sku version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion> Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="MarketplaceSku" /> instance.</summary>
        public MarketplaceSku()
        {

        }
    }
    /// The marketplace sku
    public partial interface IMarketplaceSku :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The catalog plan id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The catalog plan id",
        SerializedName = @"catalogPlanId",
        PossibleTypes = new [] { typeof(string) })]
        string CatalogPlanId { get; set; }
        /// <summary>The description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The description",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The display name of marketplace sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The display name of marketplace sku",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>The display rank of the sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The display rank of the sku",
        SerializedName = @"displayRank",
        PossibleTypes = new [] { typeof(int) })]
        int? DisplayRank { get; set; }
        /// <summary>The generation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The generation",
        SerializedName = @"generation",
        PossibleTypes = new [] { typeof(string) })]
        string Generation { get; set; }
        /// <summary>The marketplace sku id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The marketplace sku id",
        SerializedName = @"marketplaceSkuId",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The long summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The long summary",
        SerializedName = @"longSummary",
        PossibleTypes = new [] { typeof(string) })]
        string LongSummary { get; set; }
        /// <summary>The family of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The family of the operating system",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string OperatingSystemFamily { get; set; }
        /// <summary>The name of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the operating system",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string OperatingSystemName { get; set; }
        /// <summary>The type of the operating system</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of the operating system",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string OperatingSystemType { get; set; }
        /// <summary>The summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The summary",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(string) })]
        string Summary { get; set; }
        /// <summary>The type of marketplace sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of marketplace sku",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>The marketplace sku version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The marketplace sku version",
        SerializedName = @"marketplaceSkuVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion> Version { get; set; }

    }
    /// The marketplace sku
    internal partial interface IMarketplaceSkuInternal

    {
        /// <summary>The catalog plan id</summary>
        string CatalogPlanId { get; set; }
        /// <summary>The description</summary>
        string Description { get; set; }
        /// <summary>The display name of marketplace sku</summary>
        string DisplayName { get; set; }
        /// <summary>The display rank of the sku</summary>
        int? DisplayRank { get; set; }
        /// <summary>The generation</summary>
        string Generation { get; set; }
        /// <summary>The marketplace sku id</summary>
        string Id { get; set; }
        /// <summary>The long summary</summary>
        string LongSummary { get; set; }
        /// <summary>The operating system supported</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ISkuOperatingSystem OperatingSystem { get; set; }
        /// <summary>The family of the operating system</summary>
        string OperatingSystemFamily { get; set; }
        /// <summary>The name of the operating system</summary>
        string OperatingSystemName { get; set; }
        /// <summary>The type of the operating system</summary>
        string OperatingSystemType { get; set; }
        /// <summary>The summary</summary>
        string Summary { get; set; }
        /// <summary>The type of marketplace sku</summary>
        string Type { get; set; }
        /// <summary>The marketplace sku version</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSkuVersion> Version { get; set; }

    }
}