namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>SiteAuthSettings resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(SiteAuthSettingsPropertiesTypeConverter))]
    public partial class SiteAuthSettingsProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SiteAuthSettingsProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SiteAuthSettingsProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SiteAuthSettingsProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SiteAuthSettingsProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Enabled = (bool?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).RuntimeVersion = (string) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).RuntimeVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).UnauthenticatedClientAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction?) content.GetValueForProperty("UnauthenticatedClientAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).UnauthenticatedClientAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenStoreEnabled = (bool?) content.GetValueForProperty("TokenStoreEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenStoreEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedExternalRedirectUrl = (string[]) content.GetValueForProperty("AllowedExternalRedirectUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedExternalRedirectUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).DefaultProvider = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider?) content.GetValueForProperty("DefaultProvider",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).DefaultProvider, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenRefreshExtensionHour = (double?) content.GetValueForProperty("TokenRefreshExtensionHour",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenRefreshExtensionHour, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecret = (string) content.GetValueForProperty("ClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecretCertificateThumbprint = (string) content.GetValueForProperty("ClientSecretCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecretCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ValidateIssuer = (bool?) content.GetValueForProperty("ValidateIssuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ValidateIssuer, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedAudience = (string[]) content.GetValueForProperty("AllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AdditionalLoginParam = (string[]) content.GetValueForProperty("AdditionalLoginParam",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AdditionalLoginParam, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientId = (string) content.GetValueForProperty("GoogleClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientSecret = (string) content.GetValueForProperty("GoogleClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleOAuthScope = (string[]) content.GetValueForProperty("GoogleOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppId = (string) content.GetValueForProperty("FacebookAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppSecret = (string) content.GetValueForProperty("FacebookAppSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookOAuthScope = (string[]) content.GetValueForProperty("FacebookOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerKey = (string) content.GetValueForProperty("TwitterConsumerKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerSecret = (string) content.GetValueForProperty("TwitterConsumerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientId = (string) content.GetValueForProperty("MicrosoftAccountClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientSecret = (string) content.GetValueForProperty("MicrosoftAccountClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountOAuthScope = (string[]) content.GetValueForProperty("MicrosoftAccountOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteAuthSettingsProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SiteAuthSettingsProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Enabled = (bool?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).RuntimeVersion = (string) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).RuntimeVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).UnauthenticatedClientAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction?) content.GetValueForProperty("UnauthenticatedClientAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).UnauthenticatedClientAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UnauthenticatedClientAction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenStoreEnabled = (bool?) content.GetValueForProperty("TokenStoreEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenStoreEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedExternalRedirectUrl = (string[]) content.GetValueForProperty("AllowedExternalRedirectUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedExternalRedirectUrl, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).DefaultProvider = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider?) content.GetValueForProperty("DefaultProvider",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).DefaultProvider, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.BuiltInAuthenticationProvider.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenRefreshExtensionHour = (double?) content.GetValueForProperty("TokenRefreshExtensionHour",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TokenRefreshExtensionHour, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecret = (string) content.GetValueForProperty("ClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecretCertificateThumbprint = (string) content.GetValueForProperty("ClientSecretCertificateThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ClientSecretCertificateThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ValidateIssuer = (bool?) content.GetValueForProperty("ValidateIssuer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).ValidateIssuer, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedAudience = (string[]) content.GetValueForProperty("AllowedAudience",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AllowedAudience, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AdditionalLoginParam = (string[]) content.GetValueForProperty("AdditionalLoginParam",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).AdditionalLoginParam, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientId = (string) content.GetValueForProperty("GoogleClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientSecret = (string) content.GetValueForProperty("GoogleClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleOAuthScope = (string[]) content.GetValueForProperty("GoogleOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).GoogleOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppId = (string) content.GetValueForProperty("FacebookAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppSecret = (string) content.GetValueForProperty("FacebookAppSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookAppSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookOAuthScope = (string[]) content.GetValueForProperty("FacebookOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).FacebookOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerKey = (string) content.GetValueForProperty("TwitterConsumerKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerSecret = (string) content.GetValueForProperty("TwitterConsumerSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).TwitterConsumerSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientId = (string) content.GetValueForProperty("MicrosoftAccountClientId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientSecret = (string) content.GetValueForProperty("MicrosoftAccountClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountOAuthScope = (string[]) content.GetValueForProperty("MicrosoftAccountOAuthScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsPropertiesInternal)this).MicrosoftAccountOAuthScope, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// SiteAuthSettings resource specific properties
    [System.ComponentModel.TypeConverter(typeof(SiteAuthSettingsPropertiesTypeConverter))]
    public partial interface ISiteAuthSettingsProperties

    {

    }
}