// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>Access token request object</summary>
    public partial class AccessTokenRequest :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenRequest,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenRequestInternal
    {

        /// <summary>Backing field for <see cref="DeviceSku" /> property.</summary>
        private string _deviceSku;

        /// <summary>The device sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string DeviceSku { get => this._deviceSku; set => this._deviceSku = value; }

        /// <summary>Backing field for <see cref="DeviceVersion" /> property.</summary>
        private string _deviceVersion;

        /// <summary>The device sku version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string DeviceVersion { get => this._deviceVersion; set => this._deviceVersion = value; }

        /// <summary>Backing field for <see cref="EdgeMarketPlaceRegion" /> property.</summary>
        private string _edgeMarketPlaceRegion;

        /// <summary>The region where the disk will be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string EdgeMarketPlaceRegion { get => this._edgeMarketPlaceRegion; set => this._edgeMarketPlaceRegion = value; }

        /// <summary>Backing field for <see cref="EgeMarketPlaceResourceId" /> property.</summary>
        private string _egeMarketPlaceResourceId;

        /// <summary>The region where the disk will be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string EgeMarketPlaceResourceId { get => this._egeMarketPlaceResourceId; set => this._egeMarketPlaceResourceId = value; }

        /// <summary>Backing field for <see cref="HypervGeneration" /> property.</summary>
        private string _hypervGeneration;

        /// <summary>The hyperv version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string HypervGeneration { get => this._hypervGeneration; set => this._hypervGeneration = value; }

        /// <summary>Backing field for <see cref="MarketPlaceSku" /> property.</summary>
        private string _marketPlaceSku;

        /// <summary>The marketplace sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string MarketPlaceSku { get => this._marketPlaceSku; set => this._marketPlaceSku = value; }

        /// <summary>Backing field for <see cref="MarketPlaceSkuVersion" /> property.</summary>
        private string _marketPlaceSkuVersion;

        /// <summary>The marketplace sku version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string MarketPlaceSkuVersion { get => this._marketPlaceSkuVersion; set => this._marketPlaceSkuVersion = value; }

        /// <summary>Backing field for <see cref="PublisherName" /> property.</summary>
        private string _publisherName;

        /// <summary>The name of the publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string PublisherName { get => this._publisherName; set => this._publisherName = value; }

        /// <summary>Creates an new <see cref="AccessTokenRequest" /> instance.</summary>
        public AccessTokenRequest()
        {

        }
    }
    /// Access token request object
    public partial interface IAccessTokenRequest :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The device sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The device sku.",
        SerializedName = @"deviceSku",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceSku { get; set; }
        /// <summary>The device sku version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The device sku version.",
        SerializedName = @"deviceVersion",
        PossibleTypes = new [] { typeof(string) })]
        string DeviceVersion { get; set; }
        /// <summary>The region where the disk will be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The region where the disk will be created.",
        SerializedName = @"edgeMarketPlaceRegion",
        PossibleTypes = new [] { typeof(string) })]
        string EdgeMarketPlaceRegion { get; set; }
        /// <summary>The region where the disk will be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The region where the disk will be created.",
        SerializedName = @"egeMarketPlaceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string EgeMarketPlaceResourceId { get; set; }
        /// <summary>The hyperv version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The hyperv version.",
        SerializedName = @"hypervGeneration",
        PossibleTypes = new [] { typeof(string) })]
        string HypervGeneration { get; set; }
        /// <summary>The marketplace sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The marketplace sku.",
        SerializedName = @"marketPlaceSku",
        PossibleTypes = new [] { typeof(string) })]
        string MarketPlaceSku { get; set; }
        /// <summary>The marketplace sku version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The marketplace sku version.",
        SerializedName = @"marketPlaceSkuVersion",
        PossibleTypes = new [] { typeof(string) })]
        string MarketPlaceSkuVersion { get; set; }
        /// <summary>The name of the publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The name of the publisher.",
        SerializedName = @"publisherName",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherName { get; set; }

    }
    /// Access token request object
    internal partial interface IAccessTokenRequestInternal

    {
        /// <summary>The device sku.</summary>
        string DeviceSku { get; set; }
        /// <summary>The device sku version.</summary>
        string DeviceVersion { get; set; }
        /// <summary>The region where the disk will be created.</summary>
        string EdgeMarketPlaceRegion { get; set; }
        /// <summary>The region where the disk will be created.</summary>
        string EgeMarketPlaceResourceId { get; set; }
        /// <summary>The hyperv version.</summary>
        string HypervGeneration { get; set; }
        /// <summary>The marketplace sku.</summary>
        string MarketPlaceSku { get; set; }
        /// <summary>The marketplace sku version.</summary>
        string MarketPlaceSkuVersion { get; set; }
        /// <summary>The name of the publisher.</summary>
        string PublisherName { get; set; }

    }
}