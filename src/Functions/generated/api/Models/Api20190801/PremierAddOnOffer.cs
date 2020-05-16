namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Premier add-on offer.</summary>
    public partial class PremierAddOnOffer :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOffer,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Legal terms URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LegalTermsUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).LegalTermsUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).LegalTermsUrl = value; }

        /// <summary>Marketplace offer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MarketplaceOffer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).MarketplaceOffer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).MarketplaceOffer = value; }

        /// <summary>Marketplace publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MarketplacePublisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).MarketplacePublisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).MarketplacePublisher = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOfferProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Privacy policy URL.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivacyPolicyUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).PrivacyPolicyUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).PrivacyPolicyUrl = value; }

        /// <summary>Premier add on offer Product.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Product { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Product; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Product = value; }

        /// <summary><code>true</code> if promotion code is required; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? PromoCodeRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).PromoCodeRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).PromoCodeRequired = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferProperties _property;

        /// <summary>PremierAddOnOffer resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOfferProperties()); set => this._property = value; }

        /// <summary>Premier add on offer Quota.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? Quota { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Quota; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Quota = value; }

        /// <summary>Premier add on SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Sku = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Premier add on offer Vendor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Vendor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Vendor; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).Vendor = value; }

        /// <summary>App Service plans this offer is restricted to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions? WebHostingPlanRestriction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).WebHostingPlanRestriction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferPropertiesInternal)Property).WebHostingPlanRestriction = value; }

        /// <summary>Creates an new <see cref="PremierAddOnOffer" /> instance.</summary>
        public PremierAddOnOffer()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Premier add-on offer.
    public partial interface IPremierAddOnOffer :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Premier add-on offer.
    internal partial interface IPremierAddOnOfferInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>PremierAddOnOffer resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferProperties Property { get; set; }
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