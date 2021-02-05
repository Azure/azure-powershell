namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>A class that describes the properties of the CommunicationService.</summary>
    public partial class CommunicationServiceProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject into a new instance of <see cref="CommunicationServiceProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal CommunicationServiceProperties(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_hostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("hostName"), out var __jsonHostName) ? (string)__jsonHostName : (string)HostName;}
            {_dataLocation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("dataLocation"), out var __jsonDataLocation) ? (string)__jsonDataLocation : (string)DataLocation;}
            {_notificationHubId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("notificationHubId"), out var __jsonNotificationHubId) ? (string)__jsonNotificationHubId : (string)NotificationHubId;}
            {_version = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("version"), out var __jsonVersion) ? (string)__jsonVersion : (string)Version;}
            {_immutableResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString>("immutableResourceId"), out var __jsonImmutableResourceId) ? (string)__jsonImmutableResourceId : (string)ImmutableResourceId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject json ? new CommunicationServiceProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="CommunicationServiceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="CommunicationServiceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._hostName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._hostName.ToString()) : null, "hostName" ,container.Add );
            }
            AddIf( null != (((object)this._dataLocation)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._dataLocation.ToString()) : null, "dataLocation" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._notificationHubId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._notificationHubId.ToString()) : null, "notificationHubId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._version)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._version.ToString()) : null, "version" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._immutableResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Json.JsonString(this._immutableResourceId.ToString()) : null, "immutableResourceId" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}