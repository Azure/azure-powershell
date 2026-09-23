// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The offer properties</summary>
    public partial class OfferProperties :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferProperties,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ContentUrl" /> property.</summary>
        private string _contentUrl;

        /// <summary>The content url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string ContentUrl { get => this._contentUrl; set => this._contentUrl = value; }

        /// <summary>Backing field for <see cref="ContentVersion" /> property.</summary>
        private string _contentVersion;

        /// <summary>The content version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string ContentVersion { get => this._contentVersion; set => this._contentVersion = value; }

        /// <summary>Backing field for <see cref="MarketplaceSku" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku> _marketplaceSku;

        /// <summary>The marketplace skus</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku> MarketplaceSku { get => this._marketplaceSku; set => this._marketplaceSku = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="OfferContent" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent _offerContent;

        /// <summary>The offer content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent OfferContent { get => (this._offerContent = this._offerContent ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferContent()); set => this._offerContent = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="OfferProperties" /> instance.</summary>
        public OfferProperties()
        {

        }
    }
    /// The offer properties
    public partial interface IOfferProperties :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The content url</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The content url",
        SerializedName = @"contentUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ContentUrl { get; set; }
        /// <summary>The content version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The content version",
        SerializedName = @"contentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ContentVersion { get; set; }
        /// <summary>The marketplace skus</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The marketplace skus",
        SerializedName = @"marketplaceSkus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku> MarketplaceSku { get; set; }
        /// <summary>The offer content</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The offer content",
        SerializedName = @"offerContent",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent) })]
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent OfferContent { get; set; }
        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }

    }
    /// The offer properties
    internal partial interface IOfferPropertiesInternal

    {
        /// <summary>The content url</summary>
        string ContentUrl { get; set; }
        /// <summary>The content version</summary>
        string ContentVersion { get; set; }
        /// <summary>The marketplace skus</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IMarketplaceSku> MarketplaceSku { get; set; }
        /// <summary>The offer content</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent OfferContent { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }

    }
}