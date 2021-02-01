namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory application information.</summary>
    public partial class Application
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject into a new instance of <see cref="Application" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject instance to deserialize from.</param>
        /// <param name="exclusions"></param>
        internal Application(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject json, global::System.Collections.Generic.HashSet<string> exclusions = null)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __directoryObject = new Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.DirectoryObject(json,new global::System.Collections.Generic.HashSet<string>(){ @"deletionTimestamp",@"objectId",@"objectType",@"allowGuestsSignIn",@"allowPassthroughUsers",@"appId",@"appLogoUrl",@"appPermissions",@"appRoles",@"availableToOtherTenants",@"displayName",@"errorUrl",@"groupMembershipClaims",@"homepage",@"identifierUris",@"informationalUrls",@"isDeviceOnlyAuthSupported",@"keyCredentials",@"knownClientApplications",@"logoutUrl",@"oauth2AllowImplicitFlow",@"oauth2AllowUrlPathMatching",@"oauth2Permissions",@"oauth2RequirePostResponse",@"optionalClaims",@"orgRestrictions",@"passwordCredentials",@"preAuthorizedApplications",@"publicClient",@"publisherDomain",@"replyUrls",@"requiredResourceAccess",@"samlMetadataUrl",@"signInAudience",@"wwwHomepage" });
            {_informationalUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject>("informationalUrls"), out var __jsonInformationalUrls) ? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.InformationalUrl.FromJson(__jsonInformationalUrls) : InformationalUrl;}
            {_optionalClaim = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject>("optionalClaims"), out var __jsonOptionalClaims) ? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OptionalClaims.FromJson(__jsonOptionalClaims) : OptionalClaim;}
            {_allowGuestsSignIn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("allowGuestsSignIn"), out var __jsonAllowGuestsSignIn) ? (bool?)__jsonAllowGuestsSignIn : AllowGuestsSignIn;}
            {_allowPassthroughUser = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("allowPassthroughUsers"), out var __jsonAllowPassthroughUsers) ? (bool?)__jsonAllowPassthroughUsers : AllowPassthroughUser;}
            {_appId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("appId"), out var __jsonAppId) ? (string)__jsonAppId : (string)AppId;}
            {_appLogoUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("appLogoUrl"), out var __jsonAppLogoUrl) ? (string)__jsonAppLogoUrl : (string)AppLogoUrl;}
            {_appPermission = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("appPermissions"), out var __jsonAppPermissions) ? If( __jsonAppPermissions as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AppPermission;}
            {_appRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("appRoles"), out var __jsonAppRoles) ? If( __jsonAppRoles as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IAppRole) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.AppRole.FromJson(__p) )) ))() : null : AppRole;}
            {_availableToOtherTenant = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("availableToOtherTenants"), out var __jsonAvailableToOtherTenants) ? (bool?)__jsonAvailableToOtherTenants : AvailableToOtherTenant;}
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)DisplayName;}
            {_errorUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("errorUrl"), out var __jsonErrorUrl) ? (string)__jsonErrorUrl : (string)ErrorUrl;}
            {_groupMembershipClaim = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("groupMembershipClaims"), out var __jsonGroupMembershipClaims) ? (string)__jsonGroupMembershipClaims : (string)GroupMembershipClaim;}
            {_homepage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("homepage"), out var __jsonHomepage) ? (string)__jsonHomepage : (string)Homepage;}
            {_identifierUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("identifierUris"), out var __jsonIdentifierUris) ? If( __jsonIdentifierUris as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : IdentifierUri;}
            {_isDeviceOnlyAuthSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("isDeviceOnlyAuthSupported"), out var __jsonIsDeviceOnlyAuthSupported) ? (bool?)__jsonIsDeviceOnlyAuthSupported : IsDeviceOnlyAuthSupported;}
            {_keyCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("keyCredentials"), out var __jsonKeyCredentials) ? If( __jsonKeyCredentials as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.KeyCredential.FromJson(__f) )) ))() : null : KeyCredentials;}
            {_knownClientApplication = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("knownClientApplications"), out var __jsonKnownClientApplications) ? If( __jsonKnownClientApplications as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(string) (__a is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString ___z ? (string)(___z.ToString()) : null)) ))() : null : KnownClientApplication;}
            {_logoutUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("logoutUrl"), out var __jsonLogoutUrl) ? (string)__jsonLogoutUrl : (string)LogoutUrl;}
            {_oauth2AllowImplicitFlow = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("oauth2AllowImplicitFlow"), out var __jsonOauth2AllowImplicitFlow) ? (bool?)__jsonOauth2AllowImplicitFlow : Oauth2AllowImplicitFlow;}
            {_oauth2AllowUrlPathMatching = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("oauth2AllowUrlPathMatching"), out var __jsonOauth2AllowUrlPathMatching) ? (bool?)__jsonOauth2AllowUrlPathMatching : Oauth2AllowUrlPathMatching;}
            {_oauth2Permission = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("oauth2Permissions"), out var __jsonOauth2Permissions) ? If( __jsonOauth2Permissions as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2Permission) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.OAuth2Permission.FromJson(___v) )) ))() : null : Oauth2Permission;}
            {_oauth2RequirePostResponse = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("oauth2RequirePostResponse"), out var __jsonOauth2RequirePostResponse) ? (bool?)__jsonOauth2RequirePostResponse : Oauth2RequirePostResponse;}
            {_orgRestriction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("orgRestrictions"), out var __jsonOrgRestrictions) ? If( __jsonOrgRestrictions as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(string) (___q is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString ___p ? (string)(___p.ToString()) : null)) ))() : null : OrgRestriction;}
            {_passwordCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("passwordCredentials"), out var __jsonPasswordCredentials) ? If( __jsonPasswordCredentials as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___m) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___m, (___l)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredential.FromJson(___l) )) ))() : null : PasswordCredentials;}
            {_preAuthorizedApplication = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("preAuthorizedApplications"), out var __jsonPreAuthorizedApplications) ? If( __jsonPreAuthorizedApplications as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___h) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___h, (___g)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplication) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PreAuthorizedApplication.FromJson(___g) )) ))() : null : PreAuthorizedApplication;}
            {_publicClient = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean>("publicClient"), out var __jsonPublicClient) ? (bool?)__jsonPublicClient : PublicClient;}
            {_publisherDomain = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("publisherDomain"), out var __jsonPublisherDomain) ? (string)__jsonPublisherDomain : (string)PublisherDomain;}
            {_replyUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("replyUrls"), out var __jsonReplyUrls) ? If( __jsonReplyUrls as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ___c) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___c, (___b)=>(string) (___b is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString ___a ? (string)(___a.ToString()) : null)) ))() : null : ReplyUrl;}
            {_requiredResourceAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray>("requiredResourceAccess"), out var __jsonRequiredResourceAccess) ? If( __jsonRequiredResourceAccess as Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonArray, out var ____x) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(____x, (____w)=>(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IRequiredResourceAccess) (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.RequiredResourceAccess.FromJson(____w) )) ))() : null : RequiredResourceAccess;}
            {_samlMetadataUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("samlMetadataUrl"), out var __jsonSamlMetadataUrl) ? (string)__jsonSamlMetadataUrl : (string)SamlMetadataUrl;}
            {_signInAudience = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("signInAudience"), out var __jsonSignInAudience) ? (string)__jsonSignInAudience : (string)SignInAudience;}
            {_wwwHomepage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString>("wwwHomepage"), out var __jsonWwwHomepage) ? (string)__jsonWwwHomepage : (string)WwwHomepage;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IApplication FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject json ? new Application(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="Application" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Application" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._informationalUrl ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) this._informationalUrl.ToJson(null,serializationMode) : null, "informationalUrls" ,container.Add );
            AddIf( null != this._optionalClaim ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) this._optionalClaim.ToJson(null,serializationMode) : null, "optionalClaims" ,container.Add );
            AddIf( null != this._allowGuestsSignIn ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._allowGuestsSignIn) : null, "allowGuestsSignIn" ,container.Add );
            AddIf( null != this._allowPassthroughUser ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._allowPassthroughUser) : null, "allowPassthroughUsers" ,container.Add );
            AddIf( null != (((object)this._appId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._appId.ToString()) : null, "appId" ,container.Add );
            AddIf( null != (((object)this._appLogoUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._appLogoUrl.ToString()) : null, "appLogoUrl" ,container.Add );
            if (null != this._appPermission)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __x in this._appPermission )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("appPermissions",__w);
            }
            if (null != this._appRole)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __s in this._appRole )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("appRoles",__r);
            }
            AddIf( null != this._availableToOtherTenant ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._availableToOtherTenant) : null, "availableToOtherTenants" ,container.Add );
            AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            AddIf( null != (((object)this._errorUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._errorUrl.ToString()) : null, "errorUrl" ,container.Add );
            AddIf( null != (((object)this._groupMembershipClaim)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._groupMembershipClaim.ToString()) : null, "groupMembershipClaims" ,container.Add );
            AddIf( null != (((object)this._homepage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._homepage.ToString()) : null, "homepage" ,container.Add );
            if (null != this._identifierUri)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __n in this._identifierUri )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("identifierUris",__m);
            }
            AddIf( null != this._isDeviceOnlyAuthSupported ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._isDeviceOnlyAuthSupported) : null, "isDeviceOnlyAuthSupported" ,container.Add );
            if (null != this._keyCredentials)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __i in this._keyCredentials )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("keyCredentials",__h);
            }
            if (null != this._knownClientApplication)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var __d in this._knownClientApplication )
                {
                    AddIf(null != (((object)__d)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(__d.ToString()) : null ,__c.Add);
                }
                container.Add("knownClientApplications",__c);
            }
            AddIf( null != (((object)this._logoutUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._logoutUrl.ToString()) : null, "logoutUrl" ,container.Add );
            AddIf( null != this._oauth2AllowImplicitFlow ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._oauth2AllowImplicitFlow) : null, "oauth2AllowImplicitFlow" ,container.Add );
            AddIf( null != this._oauth2AllowUrlPathMatching ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._oauth2AllowUrlPathMatching) : null, "oauth2AllowUrlPathMatching" ,container.Add );
            if (null != this._oauth2Permission)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___y in this._oauth2Permission )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("oauth2Permissions",___x);
            }
            AddIf( null != this._oauth2RequirePostResponse ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._oauth2RequirePostResponse) : null, "oauth2RequirePostResponse" ,container.Add );
            if (null != this._orgRestriction)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___t in this._orgRestriction )
                {
                    AddIf(null != (((object)___t)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(___t.ToString()) : null ,___s.Add);
                }
                container.Add("orgRestrictions",___s);
            }
            if (null != this._passwordCredentials)
            {
                var ___n = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___o in this._passwordCredentials )
                {
                    AddIf(___o?.ToJson(null, serializationMode) ,___n.Add);
                }
                container.Add("passwordCredentials",___n);
            }
            if (null != this._preAuthorizedApplication)
            {
                var ___i = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___j in this._preAuthorizedApplication )
                {
                    AddIf(___j?.ToJson(null, serializationMode) ,___i.Add);
                }
                container.Add("preAuthorizedApplications",___i);
            }
            AddIf( null != this._publicClient ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonBoolean((bool)this._publicClient) : null, "publicClient" ,container.Add );
            AddIf( null != (((object)this._publisherDomain)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._publisherDomain.ToString()) : null, "publisherDomain" ,container.Add );
            if (null != this._replyUrl)
            {
                var ___d = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ___e in this._replyUrl )
                {
                    AddIf(null != (((object)___e)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(___e.ToString()) : null ,___d.Add);
                }
                container.Add("replyUrls",___d);
            }
            if (null != this._requiredResourceAccess)
            {
                var ____y = new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.XNodeArray();
                foreach( var ____z in this._requiredResourceAccess )
                {
                    AddIf(____z?.ToJson(null, serializationMode) ,____y.Add);
                }
                container.Add("requiredResourceAccess",____y);
            }
            AddIf( null != (((object)this._samlMetadataUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._samlMetadataUrl.ToString()) : null, "samlMetadataUrl" ,container.Add );
            AddIf( null != (((object)this._signInAudience)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._signInAudience.ToString()) : null, "signInAudience" ,container.Add );
            AddIf( null != (((object)this._wwwHomepage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonString(this._wwwHomepage.ToString()) : null, "wwwHomepage" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}