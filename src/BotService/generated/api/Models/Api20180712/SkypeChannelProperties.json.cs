namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Microsoft Teams channel.</summary>
    public partial class SkypeChannelProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json ? new SkypeChannelProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject into a new instance of <see cref="SkypeChannelProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SkypeChannelProperties(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_enableMessaging = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("enableMessaging"), out var __jsonEnableMessaging) ? (bool?)__jsonEnableMessaging : EnableMessaging;}
            {_enableMediaCard = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("enableMediaCards"), out var __jsonEnableMediaCards) ? (bool?)__jsonEnableMediaCards : EnableMediaCard;}
            {_enableVideo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("enableVideo"), out var __jsonEnableVideo) ? (bool?)__jsonEnableVideo : EnableVideo;}
            {_enableCalling = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("enableCalling"), out var __jsonEnableCalling) ? (bool?)__jsonEnableCalling : EnableCalling;}
            {_enableScreenSharing = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("enableScreenSharing"), out var __jsonEnableScreenSharing) ? (bool?)__jsonEnableScreenSharing : EnableScreenSharing;}
            {_enableGroup = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("enableGroups"), out var __jsonEnableGroups) ? (bool?)__jsonEnableGroups : EnableGroup;}
            {_groupsMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("groupsMode"), out var __jsonGroupsMode) ? (string)__jsonGroupsMode : (string)GroupsMode;}
            {_callingWebHook = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString>("callingWebHook"), out var __jsonCallingWebHook) ? (string)__jsonCallingWebHook : (string)CallingWebHook;}
            {_isEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean>("isEnabled"), out var __jsonIsEnabled) ? (bool)__jsonIsEnabled : IsEnabled;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SkypeChannelProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SkypeChannelProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._enableMessaging ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean((bool)this._enableMessaging) : null, "enableMessaging" ,container.Add );
            AddIf( null != this._enableMediaCard ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean((bool)this._enableMediaCard) : null, "enableMediaCards" ,container.Add );
            AddIf( null != this._enableVideo ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean((bool)this._enableVideo) : null, "enableVideo" ,container.Add );
            AddIf( null != this._enableCalling ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean((bool)this._enableCalling) : null, "enableCalling" ,container.Add );
            AddIf( null != this._enableScreenSharing ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean((bool)this._enableScreenSharing) : null, "enableScreenSharing" ,container.Add );
            AddIf( null != this._enableGroup ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean((bool)this._enableGroup) : null, "enableGroups" ,container.Add );
            AddIf( null != (((object)this._groupsMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._groupsMode.ToString()) : null, "groupsMode" ,container.Add );
            AddIf( null != (((object)this._callingWebHook)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonString(this._callingWebHook.ToString()) : null, "callingWebHook" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonBoolean(this._isEnabled), "isEnabled" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}