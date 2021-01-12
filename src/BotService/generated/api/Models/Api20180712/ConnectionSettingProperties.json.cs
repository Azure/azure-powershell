namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Properties for a Connection Setting Item</summary>
    public partial class ConnectionSettingProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject into a new instance of <see cref="ConnectionSettingProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ConnectionSettingProperties(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_clientId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("clientId"), out var __jsonClientId) ? (string)__jsonClientId : (string)ClientId;}
            {_settingId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("settingId"), out var __jsonSettingId) ? (string)__jsonSettingId : (string)SettingId;}
            {_clientSecret = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("clientSecret"), out var __jsonClientSecret) ? (string)__jsonClientSecret : (string)ClientSecret;}
            {_scope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("scopes"), out var __jsonScopes) ? (string)__jsonScopes : (string)Scope;}
            {_serviceProviderId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("serviceProviderId"), out var __jsonServiceProviderId) ? (string)__jsonServiceProviderId : (string)ServiceProviderId;}
            {_serviceProviderDisplayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("serviceProviderDisplayName"), out var __jsonServiceProviderDisplayName) ? (string)__jsonServiceProviderDisplayName : (string)ServiceProviderDisplayName;}
            {_parameter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray>("parameters"), out var __jsonParameters) ? If( __jsonParameters as Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter) (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ConnectionSettingParameter.FromJson(__u) )) ))() : null : Parameter;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json ? new ConnectionSettingProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ConnectionSettingProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ConnectionSettingProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._clientId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._clientId.ToString()) : null, "clientId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._settingId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._settingId.ToString()) : null, "settingId" ,container.Add );
            }
            AddIf( null != (((object)this._clientSecret)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._clientSecret.ToString()) : null, "clientSecret" ,container.Add );
            AddIf( null != (((object)this._scope)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._scope.ToString()) : null, "scopes" ,container.Add );
            AddIf( null != (((object)this._serviceProviderId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._serviceProviderId.ToString()) : null, "serviceProviderId" ,container.Add );
            AddIf( null != (((object)this._serviceProviderDisplayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._serviceProviderDisplayName.ToString()) : null, "serviceProviderDisplayName" ,container.Add );
            if (null != this._parameter)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.XNodeArray();
                foreach( var __x in this._parameter )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("parameters",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}