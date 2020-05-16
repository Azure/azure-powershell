namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>PremierAddOnOffer resource specific properties</summary>
    public partial class PremierAddOnOfferProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal
    {

        /// <summary>Backing field for <see cref="LegalTermsUrl" /> property.</summary>
        private string _legalTermsUrl;

        /// <summary>Legal terms URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LegalTermsUrl { get => this._legalTermsUrl; set => this._legalTermsUrl = value; }

        /// <summary>Backing field for <see cref="MarketplaceOffer" /> property.</summary>
        private string _marketplaceOffer;

        /// <summary>Marketplace offer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MarketplaceOffer { get => this._marketplaceOffer; set => this._marketplaceOffer = value; }

        /// <summary>Backing field for <see cref="MarketplacePublisher" /> property.</summary>
        private string _marketplacePublisher;

        /// <summary>Marketplace publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string MarketplacePublisher { get => this._marketplacePublisher; set => this._marketplacePublisher = value; }

        /// <summary>Backing field for <see cref="PrivacyPolicyUrl" /> property.</summary>
        private string _privacyPolicyUrl;

        /// <summary>Privacy policy URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PrivacyPolicyUrl { get => this._privacyPolicyUrl; set => this._privacyPolicyUrl = value; }

        /// <summary>Backing field for <see cref="Product" /> property.</summary>
        private string _product;

        /// <summary>Premier add on offer Product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Product { get => this._product; set => this._product = value; }

        /// <summary>Backing field for <see cref="PromoCodeRequired" /> property.</summary>
        private bool? _promoCodeRequired;

        /// <summary><code>true</code> if promotion code is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? PromoCodeRequired { get => this._promoCodeRequired; set => this._promoCodeRequired = value; }

        /// <summary>Backing field for <see cref="Quota" /> property.</summary>
        private int? _quota;

        /// <summary>Premier add on offer Quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Quota { get => this._quota; set => this._quota = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private string _sku;

        /// <summary>Premier add on SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Backing field for <see cref="Vendor" /> property.</summary>
        private string _vendor;

        /// <summary>Premier add on offer Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Vendor { get => this._vendor; set => this._vendor = value; }

        /// <summary>Backing field for <see cref="WebHostingPlanRestriction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions? _webHostingPlanRestriction;

        /// <summary>App Service plans this offer is restricted to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions? WebHostingPlanRestriction { get => this._webHostingPlanRestriction; set => this._webHostingPlanRestriction = value; }

        /// <summary>Creates an new <see cref="PremierAddOnOfferProperties" /> instance.</summary>
        public PremierAddOnOfferProperties()
        {

        }
    }
    /// PremierAddOnOffer resource specific properties
    public partial interface IPremierAddOnOfferProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Legal terms URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Legal terms URL.",
        SerializedName = @"legalTermsUrl",
        PossibleTypes = new [] { typeof(string) })]
        string LegalTermsUrl { get; set; }
        /// <summary>Marketplace offer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Marketplace offer.",
        SerializedName = @"marketplaceOffer",
        PossibleTypes = new [] { typeof(string) })]
        string MarketplaceOffer { get; set; }
        /// <summary>Marketplace publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Marketplace publisher.",
        SerializedName = @"marketplacePublisher",
        PossibleTypes = new [] { typeof(string) })]
        string MarketplacePublisher { get; set; }
        /// <summary>Privacy policy URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Privacy policy URL.",
        SerializedName = @"privacyPolicyUrl",
        PossibleTypes = new [] { typeof(string) })]
        string PrivacyPolicyUrl { get; set; }
        /// <summary>Premier add on offer Product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on offer Product.",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        string Product { get; set; }
        /// <summary><code>true</code> if promotion code is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if promotion code is required; otherwise, <code>false</code>.",
        SerializedName = @"promoCodeRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PromoCodeRequired { get; set; }
        /// <summary>Premier add on offer Quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on offer Quota.",
        SerializedName = @"quota",
        PossibleTypes = new [] { typeof(int) })]
        int? Quota { get; set; }
        /// <summary>Premier add on SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on SKU.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        string Sku { get; set; }
        /// <summary>Premier add on offer Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Premier add on offer Vendor.",
        SerializedName = @"vendor",
        PossibleTypes = new [] { typeof(string) })]
        string Vendor { get; set; }
        /// <summary>App Service plans this offer is restricted to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service plans this offer is restricted to.",
        SerializedName = @"webHostingPlanRestrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions? WebHostingPlanRestriction { get; set; }

    }
    /// PremierAddOnOffer resource specific properties
    internal partial interface IPremierAddOnOfferPropertiesInternal

    {
        /// <summary>Legal terms URL.</summary>
        string LegalTermsUrl { get; set; }
        /// <summary>Marketplace offer.</summary>
        string MarketplaceOffer { get; set; }
        /// <summary>Marketplace publisher.</summary>
        string MarketplacePublisher { get; set; }
        /// <summary>Privacy policy URL.</summary>
        string PrivacyPolicyUrl { get; set; }
        /// <summary>Premier add on offer Product.</summary>
        string Product { get; set; }
        /// <summary><code>true</code> if promotion code is required; otherwise, <code>false</code>.</summary>
        bool? PromoCodeRequired { get; set; }
        /// <summary>Premier add on offer Quota.</summary>
        int? Quota { get; set; }
        /// <summary>Premier add on SKU.</summary>
        string Sku { get; set; }
        /// <summary>Premier add on offer Vendor.</summary>
        string Vendor { get; set; }
        /// <summary>App Service plans this offer is restricted to.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions? WebHostingPlanRestriction { get; set; }

    }
}