namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>
    /// Configuration settings for the Azure App Service Authentication / Authorization feature.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(SiteAuthSettingsTypeConverter))]
    public partial class SiteAuthSettings
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettings" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettings DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SiteAuthSettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettings" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettings DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SiteAuthSettings(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SiteAuthSettings" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettings FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SiteAuthSettings(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientSecret = (string) content.GetValueForProperty("GoogleClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AdditionalLoginParam = (string[]) content.GetValueForProperty("AdditionalLoginParam",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AdditionalLoginParam, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedExternalRedirectUrl = (string[]) content.GetValueForProperty("AllowedExternalRedirectUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedExternalRedirectUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecret = (string) content.GetValueForProperty("ClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecretCertificateThumbprint = (string) content.GetValueForProperty("ClientSecretCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecretCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).DefaultProvider = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider?) content.GetValueForProperty("DefaultProvider",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).DefaultProvider, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Enabled = (bool?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppId = (string) content.GetValueForProperty("FacebookAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppSecret = (string) content.GetValueForProperty("FacebookAppSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookOAuthScope = (string[]) content.GetValueForProperty("FacebookOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientId = (string) content.GetValueForProperty("GoogleClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedAudience = (string[]) content.GetValueForProperty("AllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleOAuthScope = (string[]) content.GetValueForProperty("GoogleOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientId = (string) content.GetValueForProperty("MicrosoftAccountClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientSecret = (string) content.GetValueForProperty("MicrosoftAccountClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountOAuthScope = (string[]) content.GetValueForProperty("MicrosoftAccountOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).RuntimeVersion = (string) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).RuntimeVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenRefreshExtensionHour = (double?) content.GetValueForProperty("TokenRefreshExtensionHour",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenRefreshExtensionHour, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenStoreEnabled = (bool?) content.GetValueForProperty("TokenStoreEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenStoreEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerKey = (string) content.GetValueForProperty("TwitterConsumerKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerSecret = (string) content.GetValueForProperty("TwitterConsumerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).UnauthenticatedClientAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction?) content.GetValueForProperty("UnauthenticatedClientAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).UnauthenticatedClientAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ValidateIssuer = (bool?) content.GetValueForProperty("ValidateIssuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ValidateIssuer, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SiteAuthSettings(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientSecret = (string) content.GetValueForProperty("GoogleClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AdditionalLoginParam = (string[]) content.GetValueForProperty("AdditionalLoginParam",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AdditionalLoginParam, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedExternalRedirectUrl = (string[]) content.GetValueForProperty("AllowedExternalRedirectUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedExternalRedirectUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecret = (string) content.GetValueForProperty("ClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecretCertificateThumbprint = (string) content.GetValueForProperty("ClientSecretCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ClientSecretCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).DefaultProvider = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider?) content.GetValueForProperty("DefaultProvider",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).DefaultProvider, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Enabled = (bool?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppId = (string) content.GetValueForProperty("FacebookAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppSecret = (string) content.GetValueForProperty("FacebookAppSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookAppSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookOAuthScope = (string[]) content.GetValueForProperty("FacebookOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).FacebookOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientId = (string) content.GetValueForProperty("GoogleClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedAudience = (string[]) content.GetValueForProperty("AllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).AllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleOAuthScope = (string[]) content.GetValueForProperty("GoogleOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).GoogleOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientId = (string) content.GetValueForProperty("MicrosoftAccountClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientSecret = (string) content.GetValueForProperty("MicrosoftAccountClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountOAuthScope = (string[]) content.GetValueForProperty("MicrosoftAccountOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).MicrosoftAccountOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).RuntimeVersion = (string) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).RuntimeVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenRefreshExtensionHour = (double?) content.GetValueForProperty("TokenRefreshExtensionHour",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenRefreshExtensionHour, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenStoreEnabled = (bool?) content.GetValueForProperty("TokenStoreEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TokenStoreEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerKey = (string) content.GetValueForProperty("TwitterConsumerKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerSecret = (string) content.GetValueForProperty("TwitterConsumerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).TwitterConsumerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).UnauthenticatedClientAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction?) content.GetValueForProperty("UnauthenticatedClientAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).UnauthenticatedClientAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ValidateIssuer = (bool?) content.GetValueForProperty("ValidateIssuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsInternal)this).ValidateIssuer, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Configuration settings for the Azure App Service Authentication / Authorization feature.
    [System.ComponentModel.TypeConverter(typeof(SiteAuthSettingsTypeConverter))]
    public partial interface ISiteAuthSettings

    {

    }
}