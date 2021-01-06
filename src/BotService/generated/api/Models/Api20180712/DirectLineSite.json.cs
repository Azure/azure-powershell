namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>A site for the Direct Line channel</summary>
    public partial class DirectLineSite
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject into a new instance of <see cref="DirectLineSite" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DirectLineSite(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_siteId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("siteId"), out var __jsonSiteId) ? (string)__jsonSiteId : (string)SiteId;}
            {_siteName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("siteName"), out var __jsonSiteName) ? (string)__jsonSiteName : (string)SiteName;}
            {_key = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("key"), out var __jsonKey) ? (string)__jsonKey : (string)Key;}
            {_key2 = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("key2"), out var __jsonKey2) ? (string)__jsonKey2 : (string)Key2;}
            {_isEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("isEnabled"), out var __jsonIsEnabled) ? (bool)__jsonIsEnabled : IsEnabled;}
            {_isV1Enabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("isV1Enabled"), out var __jsonIsV1Enabled) ? (bool)__jsonIsV1Enabled : IsV1Enabled;}
            {_isV3Enabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("isV3Enabled"), out var __jsonIsV3Enabled) ? (bool)__jsonIsV3Enabled : IsV3Enabled;}
            {_isSecureSiteEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("isSecureSiteEnabled"), out var __jsonIsSecureSiteEnabled) ? (bool?)__jsonIsSecureSiteEnabled : IsSecureSiteEnabled;}
            {_trustedOrigin = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray>("trustedOrigins"), out var __jsonTrustedOrigins) ? If( __jsonTrustedOrigins as Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : TrustedOrigin;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json ? new DirectLineSite(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DirectLineSite" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DirectLineSite" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._siteId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._siteId.ToString()) : null, "siteId" ,container.Add );
            }
            AddIf( null != (((object)this._siteName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._siteName.ToString()) : null, "siteName" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._key)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._key.ToString()) : null, "key" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._key2)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._key2.ToString()) : null, "key2" ,container.Add );
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean(this._isEnabled), "isEnabled" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean(this._isV1Enabled), "isV1Enabled" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean(this._isV3Enabled), "isV3Enabled" ,container.Add );
            AddIf( null != this._isSecureSiteEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean((bool)this._isSecureSiteEnabled) : null, "isSecureSiteEnabled" ,container.Add );
            if (null != this._trustedOrigin)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.XNodeArray();
                foreach( var __x in this._trustedOrigin )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("trustedOrigins",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}