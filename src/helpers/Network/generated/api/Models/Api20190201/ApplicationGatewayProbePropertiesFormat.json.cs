namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of probe of an application gateway.</summary>
    public partial class ApplicationGatewayProbePropertiesFormat
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="ApplicationGatewayProbePropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ApplicationGatewayProbePropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_match = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("match"), out var __jsonMatch) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayProbeHealthResponseMatch.FromJson(__jsonMatch) : Match;}
            {_path = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("path"), out var __jsonPath) ? (string)__jsonPath : (string)Path;}
            {_host = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("host"), out var __jsonHost) ? (string)__jsonHost : (string)Host;}
            {_interval = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("interval"), out var __jsonInterval) ? (int?)__jsonInterval : Interval;}
            {_minServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("minServers"), out var __jsonMinServers) ? (int?)__jsonMinServers : MinServer;}
            {_pickHostNameFromBackendHttpSetting = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean>("pickHostNameFromBackendHttpSettings"), out var __jsonPickHostNameFromBackendHttpSettings) ? (bool?)__jsonPickHostNameFromBackendHttpSettings : PickHostNameFromBackendHttpSetting;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_timeout = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("timeout"), out var __jsonTimeout) ? (int?)__jsonTimeout : Timeout;}
            {_unhealthyThreshold = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("unhealthyThreshold"), out var __jsonUnhealthyThreshold) ? (int?)__jsonUnhealthyThreshold : UnhealthyThreshold;}
            {_protocol = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("protocol"), out var __jsonProtocol) ? (string)__jsonProtocol : (string)Protocol;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbePropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbePropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayProbePropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new ApplicationGatewayProbePropertiesFormat(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ApplicationGatewayProbePropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ApplicationGatewayProbePropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"
        /// />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._match ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._match.ToJson(null,serializationMode) : null, "match" ,container.Add );
            AddIf( null != (((object)this._path)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._path.ToString()) : null, "path" ,container.Add );
            AddIf( null != (((object)this._host)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._host.ToString()) : null, "host" ,container.Add );
            AddIf( null != this._interval ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._interval) : null, "interval" ,container.Add );
            AddIf( null != this._minServer ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._minServer) : null, "minServers" ,container.Add );
            AddIf( null != this._pickHostNameFromBackendHttpSetting ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonBoolean((bool)this._pickHostNameFromBackendHttpSetting) : null, "pickHostNameFromBackendHttpSettings" ,container.Add );
            AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            AddIf( null != this._timeout ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._timeout) : null, "timeout" ,container.Add );
            AddIf( null != this._unhealthyThreshold ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._unhealthyThreshold) : null, "unhealthyThreshold" ,container.Add );
            AddIf( null != (((object)this._protocol)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._protocol.ToString()) : null, "protocol" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}