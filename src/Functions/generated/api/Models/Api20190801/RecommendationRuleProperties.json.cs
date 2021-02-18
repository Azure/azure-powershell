namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>RecommendationRule resource specific properties</summary>
    public partial class RecommendationRuleProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new RecommendationRuleProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="RecommendationRuleProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecommendationRuleProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_recommendationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("recommendationName"), out var __jsonRecommendationName) ? (string)__jsonRecommendationName : (string)RecommendationName;}
            {_displayName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("displayName"), out var __jsonDisplayName) ? (string)__jsonDisplayName : (string)DisplayName;}
            {_message = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("message"), out var __jsonMessage) ? (string)__jsonMessage : (string)Message;}
            {_recommendationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("recommendationId"), out var __jsonRecommendationId) ? (string)__jsonRecommendationId : (string)RecommendationId;}
            {_description = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("description"), out var __jsonDescription) ? (string)__jsonDescription : (string)Description;}
            {_actionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("actionName"), out var __jsonActionName) ? (string)__jsonActionName : (string)ActionName;}
            {_level = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("level"), out var __jsonLevel) ? (string)__jsonLevel : (string)Level;}
            {_channel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("channels"), out var __jsonChannels) ? (string)__jsonChannels : (string)Channel;}
            {_categoryTag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("categoryTags"), out var __jsonCategoryTags) ? If( __jsonCategoryTags as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : CategoryTag;}
            {_isDynamic = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("isDynamic"), out var __jsonIsDynamic) ? (bool?)__jsonIsDynamic : IsDynamic;}
            {_extensionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("extensionName"), out var __jsonExtensionName) ? (string)__jsonExtensionName : (string)ExtensionName;}
            {_bladeName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("bladeName"), out var __jsonBladeName) ? (string)__jsonBladeName : (string)BladeName;}
            {_forwardLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("forwardLink"), out var __jsonForwardLink) ? (string)__jsonForwardLink : (string)ForwardLink;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecommendationRuleProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecommendationRuleProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._recommendationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._recommendationName.ToString()) : null, "recommendationName" ,container.Add );
            AddIf( null != (((object)this._displayName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._displayName.ToString()) : null, "displayName" ,container.Add );
            AddIf( null != (((object)this._message)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._message.ToString()) : null, "message" ,container.Add );
            AddIf( null != (((object)this._recommendationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._recommendationId.ToString()) : null, "recommendationId" ,container.Add );
            AddIf( null != (((object)this._description)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._description.ToString()) : null, "description" ,container.Add );
            AddIf( null != (((object)this._actionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._actionName.ToString()) : null, "actionName" ,container.Add );
            AddIf( null != (((object)this._level)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._level.ToString()) : null, "level" ,container.Add );
            AddIf( null != (((object)this._channel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._channel.ToString()) : null, "channels" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._categoryTag)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __x in this._categoryTag )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("categoryTags",__w);
                }
            }
            AddIf( null != this._isDynamic ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._isDynamic) : null, "isDynamic" ,container.Add );
            AddIf( null != (((object)this._extensionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._extensionName.ToString()) : null, "extensionName" ,container.Add );
            AddIf( null != (((object)this._bladeName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._bladeName.ToString()) : null, "bladeName" ,container.Add );
            AddIf( null != (((object)this._forwardLink)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._forwardLink.ToString()) : null, "forwardLink" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}