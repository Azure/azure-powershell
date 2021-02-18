namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Bot.</summary>
    public partial class BotProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject into a new instance of <see cref="BotProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal BotProperties(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)DisplayName;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_iconUrl = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("iconUrl"), out var __jsonIconUrl) ? (string)__jsonIconUrl : (string)IconUrl;}
            {_endpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("endpoint"), out var __jsonEndpoint) ? (string)__jsonEndpoint : (string)Endpoint;}
            {_endpointVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("endpointVersion"), out var __jsonEndpointVersion) ? (string)__jsonEndpointVersion : (string)EndpointVersion;}
            {_msaAppId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("msaAppId"), out var __jsonMsaAppId) ? (string)__jsonMsaAppId : (string)MsaAppId;}
            {_configuredChannel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray>("configuredChannels"), out var __jsonConfiguredChannels) ? If( __jsonConfiguredChannels as Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : ConfiguredChannel;}
            {_enabledChannel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray>("enabledChannels"), out var __jsonEnabledChannels) ? If( __jsonEnabledChannels as Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : EnabledChannel;}
            {_developerAppInsightKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("developerAppInsightKey"), out var __jsonDeveloperAppInsightKey) ? (string)__jsonDeveloperAppInsightKey : (string)DeveloperAppInsightKey;}
            {_developerAppInsightsApiKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("developerAppInsightsApiKey"), out var __jsonDeveloperAppInsightsApiKey) ? (string)__jsonDeveloperAppInsightsApiKey : (string)DeveloperAppInsightsApiKey;}
            {_developerAppInsightsApplicationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("developerAppInsightsApplicationId"), out var __jsonDeveloperAppInsightsApplicationId) ? (string)__jsonDeveloperAppInsightsApplicationId : (string)DeveloperAppInsightsApplicationId;}
            {_luisAppId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray>("luisAppIds"), out var __jsonLuisAppIds) ? If( __jsonLuisAppIds as Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : LuisAppId;}
            {_luisKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("luisKey"), out var __jsonLuisKey) ? (string)__jsonLuisKey : (string)LuisKey;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json ? new BotProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="BotProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="BotProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._iconUrl)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._iconUrl.ToString()) : null, "iconUrl" ,container.Add );
            AddIf( null != (((object)this._endpoint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._endpoint.ToString()) : null, "endpoint" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._endpointVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._endpointVersion.ToString()) : null, "endpointVersion" ,container.Add );
            }
            AddIf( null != (((object)this._msaAppId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._msaAppId.ToString()) : null, "msaAppId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._configuredChannel)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.XNodeArray();
                    foreach( var __x in this._configuredChannel )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("configuredChannels",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._enabledChannel)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.XNodeArray();
                    foreach( var __s in this._enabledChannel )
                    {
                        AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                    }
                    container.Add("enabledChannels",__r);
                }
            }
            AddIf( null != (((object)this._developerAppInsightKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._developerAppInsightKey.ToString()) : null, "developerAppInsightKey" ,container.Add );
            AddIf( null != (((object)this._developerAppInsightsApiKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._developerAppInsightsApiKey.ToString()) : null, "developerAppInsightsApiKey" ,container.Add );
            AddIf( null != (((object)this._developerAppInsightsApplicationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._developerAppInsightsApplicationId.ToString()) : null, "developerAppInsightsApplicationId" ,container.Add );
            if (null != this._luisAppId)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.XNodeArray();
                foreach( var __n in this._luisAppId )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("luisAppIds",__m);
            }
            AddIf( null != (((object)this._luisKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._luisKey.ToString()) : null, "luisKey" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}