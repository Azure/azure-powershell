namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Properties of the virtual network peering.</summary>
    public partial class VirtualNetworkPeeringPropertiesFormat
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormat FromJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json ? new VirtualNetworkPeeringPropertiesFormat(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VirtualNetworkPeeringPropertiesFormat" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VirtualNetworkPeeringPropertiesFormat" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._databricksVirtualNetwork ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._databricksVirtualNetwork.ToJson(null,serializationMode) : null, "databricksVirtualNetwork" ,container.Add );
            AddIf( null != this._databricksAddressSpace ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._databricksAddressSpace.ToJson(null,serializationMode) : null, "databricksAddressSpace" ,container.Add );
            AddIf( null != this._remoteVirtualNetwork ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._remoteVirtualNetwork.ToJson(null,serializationMode) : null, "remoteVirtualNetwork" ,container.Add );
            AddIf( null != this._remoteAddressSpace ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) this._remoteAddressSpace.ToJson(null,serializationMode) : null, "remoteAddressSpace" ,container.Add );
            AddIf( null != this._allowVirtualNetworkAccess ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean((bool)this._allowVirtualNetworkAccess) : null, "allowVirtualNetworkAccess" ,container.Add );
            AddIf( null != this._allowForwardedTraffic ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean((bool)this._allowForwardedTraffic) : null, "allowForwardedTraffic" ,container.Add );
            AddIf( null != this._allowGatewayTransit ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean((bool)this._allowGatewayTransit) : null, "allowGatewayTransit" ,container.Add );
            AddIf( null != this._useRemoteGateway ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean((bool)this._useRemoteGateway) : null, "useRemoteGateways" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._peeringState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._peeringState.ToString()) : null, "peeringState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject into a new instance of <see cref="VirtualNetworkPeeringPropertiesFormat" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VirtualNetworkPeeringPropertiesFormat(Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_databricksVirtualNetwork = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("databricksVirtualNetwork"), out var __jsonDatabricksVirtualNetwork) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork.FromJson(__jsonDatabricksVirtualNetwork) : DatabricksVirtualNetwork;}
            {_databricksAddressSpace = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("databricksAddressSpace"), out var __jsonDatabricksAddressSpace) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpace.FromJson(__jsonDatabricksAddressSpace) : DatabricksAddressSpace;}
            {_remoteVirtualNetwork = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("remoteVirtualNetwork"), out var __jsonRemoteVirtualNetwork) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.VirtualNetworkPeeringPropertiesFormatRemoteVirtualNetwork.FromJson(__jsonRemoteVirtualNetwork) : RemoteVirtualNetwork;}
            {_remoteAddressSpace = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonObject>("remoteAddressSpace"), out var __jsonRemoteAddressSpace) ? Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.AddressSpace.FromJson(__jsonRemoteAddressSpace) : RemoteAddressSpace;}
            {_allowVirtualNetworkAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean>("allowVirtualNetworkAccess"), out var __jsonAllowVirtualNetworkAccess) ? (bool?)__jsonAllowVirtualNetworkAccess : AllowVirtualNetworkAccess;}
            {_allowForwardedTraffic = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean>("allowForwardedTraffic"), out var __jsonAllowForwardedTraffic) ? (bool?)__jsonAllowForwardedTraffic : AllowForwardedTraffic;}
            {_allowGatewayTransit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean>("allowGatewayTransit"), out var __jsonAllowGatewayTransit) ? (bool?)__jsonAllowGatewayTransit : AllowGatewayTransit;}
            {_useRemoteGateway = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonBoolean>("useRemoteGateways"), out var __jsonUseRemoteGateways) ? (bool?)__jsonUseRemoteGateways : UseRemoteGateway;}
            {_peeringState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("peeringState"), out var __jsonPeeringState) ? (string)__jsonPeeringState : (string)PeeringState;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            AfterFromJson(json);
        }
    }
}