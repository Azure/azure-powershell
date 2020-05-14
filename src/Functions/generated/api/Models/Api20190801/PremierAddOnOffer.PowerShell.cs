namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Premier add-on offer.</summary>
    [System.ComponentModel.TypeConverter(typeof(PremierAddOnOfferTypeConverter))]
    public partial class PremierAddOnOffer
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOffer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOffer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOffer DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PremierAddOnOffer(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOffer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOffer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOffer DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PremierAddOnOffer(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PremierAddOnOffer" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOffer FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOffer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PremierAddOnOffer(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOfferPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).LegalTermsUrl = (string) content.GetValueForProperty("LegalTermsUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).LegalTermsUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplaceOffer = (string) content.GetValueForProperty("MarketplaceOffer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplaceOffer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplacePublisher = (string) content.GetValueForProperty("MarketplacePublisher",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplacePublisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PrivacyPolicyUrl = (string) content.GetValueForProperty("PrivacyPolicyUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PrivacyPolicyUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Product = (string) content.GetValueForProperty("Product",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Product, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PromoCodeRequired = (bool?) content.GetValueForProperty("PromoCodeRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PromoCodeRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Quota = (int?) content.GetValueForProperty("Quota",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Quota, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Sku = (string) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Sku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Vendor = (string) content.GetValueForProperty("Vendor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Vendor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).WebHostingPlanRestriction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions?) content.GetValueForProperty("WebHostingPlanRestriction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).WebHostingPlanRestriction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOffer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PremierAddOnOffer(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PremierAddOnOfferPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).LegalTermsUrl = (string) content.GetValueForProperty("LegalTermsUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).LegalTermsUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplaceOffer = (string) content.GetValueForProperty("MarketplaceOffer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplaceOffer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplacePublisher = (string) content.GetValueForProperty("MarketplacePublisher",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).MarketplacePublisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PrivacyPolicyUrl = (string) content.GetValueForProperty("PrivacyPolicyUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PrivacyPolicyUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Product = (string) content.GetValueForProperty("Product",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Product, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PromoCodeRequired = (bool?) content.GetValueForProperty("PromoCodeRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).PromoCodeRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Quota = (int?) content.GetValueForProperty("Quota",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Quota, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Sku = (string) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Sku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Vendor = (string) content.GetValueForProperty("Vendor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).Vendor, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).WebHostingPlanRestriction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions?) content.GetValueForProperty("WebHostingPlanRestriction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPremierAddOnOfferInternal)this).WebHostingPlanRestriction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AppServicePlanRestrictions.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Premier add-on offer.
    [System.ComponentModel.TypeConverter(typeof(PremierAddOnOfferTypeConverter))]
    public partial interface IPremierAddOnOffer

    {

    }
}