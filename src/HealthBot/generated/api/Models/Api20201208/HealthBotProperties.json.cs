namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Extensions;

    /// <summary>
    /// The properties of a HealthBot. The Health Bot Service is a cloud platform that empowers developers in Healthcare organizations
    /// to build and deploy their compliant, AI-powered virtual health assistants and health bots, that help them improve processes
    /// and reduce costs.
    /// </summary>
    public partial class HealthBotProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject json ? new HealthBotProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject into a new instance of <see cref="HealthBotProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HealthBotProperties(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_botManagementPortalLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonString>("botManagementPortalLink"), out var __jsonBotManagementPortalLink) ? (string)__jsonBotManagementPortalLink : (string)BotManagementPortalLink;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HealthBotProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HealthBotProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._botManagementPortalLink)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonString(this._botManagementPortalLink.ToString()) : null, "botManagementPortalLink" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}