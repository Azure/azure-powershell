namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>A static site.</summary>
    public partial class StaticSite
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSite FromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json ? new StaticSite(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject into a new instance of <see cref="StaticSite" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal StaticSite(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_buildProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("buildProperties"), out var __jsonBuildProperties) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteBuildProperties.FromJson(__jsonBuildProperties) : BuildProperty;}
            {_templateProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject>("templateProperties"), out var __jsonTemplateProperties) ? Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteTemplateOptions.FromJson(__jsonTemplateProperties) : TemplateProperty;}
            {_defaultHostname = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("defaultHostname"), out var __jsonDefaultHostname) ? (string)__jsonDefaultHostname : (string)DefaultHostname;}
            {_repositoryUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("repositoryUrl"), out var __jsonRepositoryUrl) ? (string)__jsonRepositoryUrl : (string)RepositoryUrl;}
            {_branch = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("branch"), out var __jsonBranch) ? (string)__jsonBranch : (string)Branch;}
            {_provider = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("provider"), out var __jsonProvider) ? (string)__jsonProvider : (string)Provider;}
            {_customDomain = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray>("customDomains"), out var __jsonCustomDomains) ? If( __jsonCustomDomains as Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : CustomDomain;}
            {_repositoryToken = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("repositoryToken"), out var __jsonRepositoryToken) ? (string)__jsonRepositoryToken : (string)RepositoryToken;}
            {_privateEndpointConnection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray>("privateEndpointConnections"), out var __jsonPrivateEndpointConnections) ? If( __jsonPrivateEndpointConnections as Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IResponseMessageEnvelopeRemotePrivateEndpointConnection) (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ResponseMessageEnvelopeRemotePrivateEndpointConnection.FromJson(__p) )) ))() : null : PrivateEndpointConnection;}
            {_contentDistributionEndpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("contentDistributionEndpoint"), out var __jsonContentDistributionEndpoint) ? (string)__jsonContentDistributionEndpoint : (string)ContentDistributionEndpoint;}
            {_keyVaultReferenceIdentity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("keyVaultReferenceIdentity"), out var __jsonKeyVaultReferenceIdentity) ? (string)__jsonKeyVaultReferenceIdentity : (string)KeyVaultReferenceIdentity;}
            {_userProvidedFunctionApp = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray>("userProvidedFunctionApps"), out var __jsonUserProvidedFunctionApps) ? If( __jsonUserProvidedFunctionApps as Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IStaticSiteUserProvidedFunctionApp) (Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.StaticSiteUserProvidedFunctionApp.FromJson(__k) )) ))() : null : UserProvidedFunctionApp;}
            {_stagingEnvironmentPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString>("stagingEnvironmentPolicy"), out var __jsonStagingEnvironmentPolicy) ? (string)__jsonStagingEnvironmentPolicy : (string)StagingEnvironmentPolicy;}
            {_allowConfigFileUpdate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonBoolean>("allowConfigFileUpdates"), out var __jsonAllowConfigFileUpdates) ? (bool?)__jsonAllowConfigFileUpdates : AllowConfigFileUpdate;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="StaticSite" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="StaticSite" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._buildProperty ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._buildProperty.ToJson(null,serializationMode) : null, "buildProperties" ,container.Add );
            AddIf( null != this._templateProperty ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) this._templateProperty.ToJson(null,serializationMode) : null, "templateProperties" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._defaultHostname)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._defaultHostname.ToString()) : null, "defaultHostname" ,container.Add );
            }
            AddIf( null != (((object)this._repositoryUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._repositoryUrl.ToString()) : null, "repositoryUrl" ,container.Add );
            AddIf( null != (((object)this._branch)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._branch.ToString()) : null, "branch" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provider)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._provider.ToString()) : null, "provider" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._customDomain)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.XNodeArray();
                    foreach( var __x in this._customDomain )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("customDomains",__w);
                }
            }
            AddIf( null != (((object)this._repositoryToken)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._repositoryToken.ToString()) : null, "repositoryToken" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._privateEndpointConnection)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.XNodeArray();
                    foreach( var __s in this._privateEndpointConnection )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("privateEndpointConnections",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._contentDistributionEndpoint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._contentDistributionEndpoint.ToString()) : null, "contentDistributionEndpoint" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._keyVaultReferenceIdentity)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._keyVaultReferenceIdentity.ToString()) : null, "keyVaultReferenceIdentity" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._userProvidedFunctionApp)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.XNodeArray();
                    foreach( var __n in this._userProvidedFunctionApp )
                    {
                        AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                    }
                    container.Add("userProvidedFunctionApps",__m);
                }
            }
            AddIf( null != (((object)this._stagingEnvironmentPolicy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonString(this._stagingEnvironmentPolicy.ToString()) : null, "stagingEnvironmentPolicy" ,container.Add );
            AddIf( null != this._allowConfigFileUpdate ? (Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonBoolean((bool)this._allowConfigFileUpdate) : null, "allowConfigFileUpdates" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}