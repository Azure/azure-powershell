namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory service principal information.</summary>
    public partial class ServicePrincipal
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject json ? new ServicePrincipal(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject into a new instance of <see cref="ServicePrincipal" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject instance to deserialize from.</param>
        /// <param name="exclusions"></param>
        internal ServicePrincipal(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject json, global::System.Collections.Generic.HashSet<string> exclusions = null)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __directoryObject = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.DirectoryObject(json,new global::System.Collections.Generic.HashSet<string>(){ @"deletionTimestamp",@"objectId",@"objectType",@"accountEnabled",@"alternativeNames",@"appDisplayName",@"appId",@"appOwnerTenantId",@"appRoleAssignmentRequired",@"appRoles",@"displayName",@"errorUrl",@"homepage",@"keyCredentials",@"logoutUrl",@"oauth2Permissions",@"passwordCredentials",@"preferredTokenSigningKeyThumbprint",@"publisherName",@"replyUrls",@"samlMetadataUrl",@"servicePrincipalNames",@"servicePrincipalType",@"tags" });
            {_accountEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("accountEnabled"), out var __jsonAccountEnabled) ? (bool?)__jsonAccountEnabled : AccountEnabled;}
            {_alternativeName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("alternativeNames"), out var __jsonAlternativeNames) ? If( __jsonAlternativeNames as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AlternativeName;}
            {_appDisplayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("appDisplayName"), out var __jsonAppDisplayName) ? (string)__jsonAppDisplayName : (string)AppDisplayName;}
            {_appId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("appId"), out var __jsonAppId) ? (string)__jsonAppId : (string)AppId;}
            {_appOwnerTenantId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("appOwnerTenantId"), out var __jsonAppOwnerTenantId) ? (string)__jsonAppOwnerTenantId : (string)AppOwnerTenantId;}
            {_appRoleAssignmentRequired = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("appRoleAssignmentRequired"), out var __jsonAppRoleAssignmentRequired) ? (bool?)__jsonAppRoleAssignmentRequired : AppRoleAssignmentRequired;}
            {_appRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("appRoles"), out var __jsonAppRoles) ? If( __jsonAppRoles as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRole.FromJson(__p) )) ))() : null : AppRole;}
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)DisplayName;}
            {_errorUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("errorUrl"), out var __jsonErrorUrl) ? (string)__jsonErrorUrl : (string)ErrorUrl;}
            {_homepage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("homepage"), out var __jsonHomepage) ? (string)__jsonHomepage : (string)Homepage;}
            {_keyCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("keyCredentials"), out var __jsonKeyCredentials) ? If( __jsonKeyCredentials as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredential.FromJson(__k) )) ))() : null : KeyCredentials;}
            {_logoutUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("logoutUrl"), out var __jsonLogoutUrl) ? (string)__jsonLogoutUrl : (string)LogoutUrl;}
            {_oauth2Permission = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("oauth2Permissions"), out var __jsonOauth2Permissions) ? If( __jsonOauth2Permissions as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2Permission.FromJson(__f) )) ))() : null : Oauth2Permission;}
            {_passwordCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("passwordCredentials"), out var __jsonPasswordCredentials) ? If( __jsonPasswordCredentials as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredential.FromJson(__a) )) ))() : null : PasswordCredentials;}
            {_preferredTokenSigningKeyThumbprint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("preferredTokenSigningKeyThumbprint"), out var __jsonPreferredTokenSigningKeyThumbprint) ? (string)__jsonPreferredTokenSigningKeyThumbprint : (string)PreferredTokenSigningKeyThumbprint;}
            {_publisherName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("publisherName"), out var __jsonPublisherName) ? (string)__jsonPublisherName : (string)PublisherName;}
            {_replyUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("replyUrls"), out var __jsonReplyUrls) ? If( __jsonReplyUrls as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(string) (___v is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString ___u ? (string)(___u.ToString()) : null)) ))() : null : ReplyUrl;}
            {_samlMetadataUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("samlMetadataUrl"), out var __jsonSamlMetadataUrl) ? (string)__jsonSamlMetadataUrl : (string)SamlMetadataUrl;}
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("servicePrincipalNames"), out var __jsonServicePrincipalNames) ? If( __jsonServicePrincipalNames as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(string) (___q is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString ___p ? (string)(___p.ToString()) : null)) ))() : null : Name;}
            {_type = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("servicePrincipalType"), out var __jsonServicePrincipalType) ? (string)__jsonServicePrincipalType : (string)Type;}
            {_tag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("tags"), out var __jsonTags) ? If( __jsonTags as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___m) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___m, (___l)=>(string) (___l is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString ___k ? (string)(___k.ToString()) : null)) ))() : null : Tag;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ServicePrincipal" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ServicePrincipal" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __directoryObject?.ToJson(container, serializationMode);
            AddIf( null != this._accountEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._accountEnabled) : null, "accountEnabled" ,container.Add );
            if (null != this._alternativeName)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __x in this._alternativeName )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("alternativeNames",__w);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._appDisplayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._appDisplayName.ToString()) : null, "appDisplayName" ,container.Add );
            }
            AddIf( null != (((object)this._appId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._appId.ToString()) : null, "appId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._appOwnerTenantId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._appOwnerTenantId.ToString()) : null, "appOwnerTenantId" ,container.Add );
            }
            AddIf( null != this._appRoleAssignmentRequired ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._appRoleAssignmentRequired) : null, "appRoleAssignmentRequired" ,container.Add );
            if (null != this._appRole)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __s in this._appRole )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("appRoles",__r);
            }
            AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            AddIf( null != (((object)this._errorUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._errorUrl.ToString()) : null, "errorUrl" ,container.Add );
            AddIf( null != (((object)this._homepage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._homepage.ToString()) : null, "homepage" ,container.Add );
            if (null != this._keyCredentials)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __n in this._keyCredentials )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("keyCredentials",__m);
            }
            AddIf( null != (((object)this._logoutUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._logoutUrl.ToString()) : null, "logoutUrl" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._oauth2Permission)
                {
                    var __h = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                    foreach( var __i in this._oauth2Permission )
                    {
                        AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                    }
                    container.Add("oauth2Permissions",__h);
                }
            }
            if (null != this._passwordCredentials)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __d in this._passwordCredentials )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("passwordCredentials",__c);
            }
            AddIf( null != (((object)this._preferredTokenSigningKeyThumbprint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._preferredTokenSigningKeyThumbprint.ToString()) : null, "preferredTokenSigningKeyThumbprint" ,container.Add );
            AddIf( null != (((object)this._publisherName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._publisherName.ToString()) : null, "publisherName" ,container.Add );
            if (null != this._replyUrl)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___y in this._replyUrl )
                {
                    AddIf(null != (((object)___y)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(___y.ToString()) : null ,___x.Add);
                }
                container.Add("replyUrls",___x);
            }
            AddIf( null != (((object)this._samlMetadataUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._samlMetadataUrl.ToString()) : null, "samlMetadataUrl" ,container.Add );
            if (null != this._name)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___t in this._name )
                {
                    AddIf(null != (((object)___t)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(___t.ToString()) : null ,___s.Add);
                }
                container.Add("servicePrincipalNames",___s);
            }
            AddIf( null != (((object)this._type)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._type.ToString()) : null, "servicePrincipalType" ,container.Add );
            if (null != this._tag)
            {
                var ___n = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___o in this._tag )
                {
                    AddIf(null != (((object)___o)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(___o.ToString()) : null ,___n.Add);
                }
                container.Add("tags",___n);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}