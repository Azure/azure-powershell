namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SiteAuthSettings resource specific properties</summary>
    public partial class SiteAuthSettingsProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteAuthSettingsProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new SiteAuthSettingsProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="SiteAuthSettingsProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SiteAuthSettingsProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_additionalLoginParam = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("additionalLoginParams"), out var __jsonAdditionalLoginParams) ? If( __jsonAdditionalLoginParams as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AdditionalLoginParam;}
            {_allowedAudience = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("allowedAudiences"), out var __jsonAllowedAudiences) ? If( __jsonAllowedAudiences as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : AllowedAudience;}
            {_allowedExternalRedirectUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("allowedExternalRedirectUrls"), out var __jsonAllowedExternalRedirectUrls) ? If( __jsonAllowedExternalRedirectUrls as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : AllowedExternalRedirectUrl;}
            {_clientId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("clientId"), out var __jsonClientId) ? (string)__jsonClientId : (string)ClientId;}
            {_clientSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("clientSecret"), out var __jsonClientSecret) ? (string)__jsonClientSecret : (string)ClientSecret;}
            {_clientSecretCertificateThumbprint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("clientSecretCertificateThumbprint"), out var __jsonClientSecretCertificateThumbprint) ? (string)__jsonClientSecretCertificateThumbprint : (string)ClientSecretCertificateThumbprint;}
            {_defaultProvider = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("defaultProvider"), out var __jsonDefaultProvider) ? (string)__jsonDefaultProvider : (string)DefaultProvider;}
            {_enabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("enabled"), out var __jsonEnabled) ? (bool?)__jsonEnabled : Enabled;}
            {_facebookAppId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("facebookAppId"), out var __jsonFacebookAppId) ? (string)__jsonFacebookAppId : (string)FacebookAppId;}
            {_facebookAppSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("facebookAppSecret"), out var __jsonFacebookAppSecret) ? (string)__jsonFacebookAppSecret : (string)FacebookAppSecret;}
            {_facebookOAuthScope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("facebookOAuthScopes"), out var __jsonFacebookOAuthScopes) ? If( __jsonFacebookOAuthScopes as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(string) (__f is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __e ? (string)(__e.ToString()) : null)) ))() : null : FacebookOAuthScope;}
            {_googleClientId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("googleClientId"), out var __jsonGoogleClientId) ? (string)__jsonGoogleClientId : (string)GoogleClientId;}
            {_googleClientSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("googleClientSecret"), out var __jsonGoogleClientSecret) ? (string)__jsonGoogleClientSecret : (string)GoogleClientSecret;}
            {_googleOAuthScope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("googleOAuthScopes"), out var __jsonGoogleOAuthScopes) ? If( __jsonGoogleOAuthScopes as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(string) (__a is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString ___z ? (string)(___z.ToString()) : null)) ))() : null : GoogleOAuthScope;}
            {_issuer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("issuer"), out var __jsonIssuer) ? (string)__jsonIssuer : (string)Issuer;}
            {_microsoftAccountClientId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("microsoftAccountClientId"), out var __jsonMicrosoftAccountClientId) ? (string)__jsonMicrosoftAccountClientId : (string)MicrosoftAccountClientId;}
            {_microsoftAccountClientSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("microsoftAccountClientSecret"), out var __jsonMicrosoftAccountClientSecret) ? (string)__jsonMicrosoftAccountClientSecret : (string)MicrosoftAccountClientSecret;}
            {_microsoftAccountOAuthScope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("microsoftAccountOAuthScopes"), out var __jsonMicrosoftAccountOAuthScopes) ? If( __jsonMicrosoftAccountOAuthScopes as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(string) (___v is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString ___u ? (string)(___u.ToString()) : null)) ))() : null : MicrosoftAccountOAuthScope;}
            {_runtimeVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("runtimeVersion"), out var __jsonRuntimeVersion) ? (string)__jsonRuntimeVersion : (string)RuntimeVersion;}
            {_tokenRefreshExtensionHour = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("tokenRefreshExtensionHours"), out var __jsonTokenRefreshExtensionHours) ? (double?)__jsonTokenRefreshExtensionHours : TokenRefreshExtensionHour;}
            {_tokenStoreEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("tokenStoreEnabled"), out var __jsonTokenStoreEnabled) ? (bool?)__jsonTokenStoreEnabled : TokenStoreEnabled;}
            {_twitterConsumerKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("twitterConsumerKey"), out var __jsonTwitterConsumerKey) ? (string)__jsonTwitterConsumerKey : (string)TwitterConsumerKey;}
            {_twitterConsumerSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("twitterConsumerSecret"), out var __jsonTwitterConsumerSecret) ? (string)__jsonTwitterConsumerSecret : (string)TwitterConsumerSecret;}
            {_unauthenticatedClientAction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("unauthenticatedClientAction"), out var __jsonUnauthenticatedClientAction) ? (string)__jsonUnauthenticatedClientAction : (string)UnauthenticatedClientAction;}
            {_validateIssuer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("validateIssuer"), out var __jsonValidateIssuer) ? (bool?)__jsonValidateIssuer : ValidateIssuer;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SiteAuthSettingsProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SiteAuthSettingsProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (null != this._additionalLoginParam)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __x in this._additionalLoginParam )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("additionalLoginParams",__w);
            }
            if (null != this._allowedAudience)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __s in this._allowedAudience )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("allowedAudiences",__r);
            }
            if (null != this._allowedExternalRedirectUrl)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __n in this._allowedExternalRedirectUrl )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("allowedExternalRedirectUrls",__m);
            }
            AddIf( null != (((object)this._clientId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._clientId.ToString()) : null, "clientId" ,container.Add );
            AddIf( null != (((object)this._clientSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._clientSecret.ToString()) : null, "clientSecret" ,container.Add );
            AddIf( null != (((object)this._clientSecretCertificateThumbprint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._clientSecretCertificateThumbprint.ToString()) : null, "clientSecretCertificateThumbprint" ,container.Add );
            AddIf( null != (((object)this._defaultProvider)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._defaultProvider.ToString()) : null, "defaultProvider" ,container.Add );
            AddIf( null != this._enabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._enabled) : null, "enabled" ,container.Add );
            AddIf( null != (((object)this._facebookAppId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._facebookAppId.ToString()) : null, "facebookAppId" ,container.Add );
            AddIf( null != (((object)this._facebookAppSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._facebookAppSecret.ToString()) : null, "facebookAppSecret" ,container.Add );
            if (null != this._facebookOAuthScope)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __i in this._facebookOAuthScope )
                {
                    AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                }
                container.Add("facebookOAuthScopes",__h);
            }
            AddIf( null != (((object)this._googleClientId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._googleClientId.ToString()) : null, "googleClientId" ,container.Add );
            AddIf( null != (((object)this._googleClientSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._googleClientSecret.ToString()) : null, "googleClientSecret" ,container.Add );
            if (null != this._googleOAuthScope)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __d in this._googleOAuthScope )
                {
                    AddIf(null != (((object)__d)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__d.ToString()) : null ,__c.Add);
                }
                container.Add("googleOAuthScopes",__c);
            }
            AddIf( null != (((object)this._issuer)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._issuer.ToString()) : null, "issuer" ,container.Add );
            AddIf( null != (((object)this._microsoftAccountClientId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._microsoftAccountClientId.ToString()) : null, "microsoftAccountClientId" ,container.Add );
            AddIf( null != (((object)this._microsoftAccountClientSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._microsoftAccountClientSecret.ToString()) : null, "microsoftAccountClientSecret" ,container.Add );
            if (null != this._microsoftAccountOAuthScope)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var ___y in this._microsoftAccountOAuthScope )
                {
                    AddIf(null != (((object)___y)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(___y.ToString()) : null ,___x.Add);
                }
                container.Add("microsoftAccountOAuthScopes",___x);
            }
            AddIf( null != (((object)this._runtimeVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._runtimeVersion.ToString()) : null, "runtimeVersion" ,container.Add );
            AddIf( null != this._tokenRefreshExtensionHour ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((double)this._tokenRefreshExtensionHour) : null, "tokenRefreshExtensionHours" ,container.Add );
            AddIf( null != this._tokenStoreEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._tokenStoreEnabled) : null, "tokenStoreEnabled" ,container.Add );
            AddIf( null != (((object)this._twitterConsumerKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._twitterConsumerKey.ToString()) : null, "twitterConsumerKey" ,container.Add );
            AddIf( null != (((object)this._twitterConsumerSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._twitterConsumerSecret.ToString()) : null, "twitterConsumerSecret" ,container.Add );
            AddIf( null != (((object)this._unauthenticatedClientAction)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._unauthenticatedClientAction.ToString()) : null, "unauthenticatedClientAction" ,container.Add );
            AddIf( null != this._validateIssuer ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._validateIssuer) : null, "validateIssuer" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}