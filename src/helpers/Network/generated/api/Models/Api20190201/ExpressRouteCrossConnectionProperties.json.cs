namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ExpressRouteCrossConnection.</summary>
    public partial class ExpressRouteCrossConnectionProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject into a new instance of <see cref="ExpressRouteCrossConnectionProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ExpressRouteCrossConnectionProperties(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_expressRouteCircuit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject>("expressRouteCircuit"), out var __jsonExpressRouteCircuit) ? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCircuitReference.FromJson(__jsonExpressRouteCircuit) : ExpressRouteCircuit;}
            {_bandwidthInMbps = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("bandwidthInMbps"), out var __jsonBandwidthInMbps) ? (int?)__jsonBandwidthInMbps : BandwidthInMbps;}
            {_peeringLocation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("peeringLocation"), out var __jsonPeeringLocation) ? (string)__jsonPeeringLocation : (string)PeeringLocation;}
            {_peering = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray>("peerings"), out var __jsonPeerings) ? If( __jsonPeerings as Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering) (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ExpressRouteCrossConnectionPeering.FromJson(__u) )) ))() : null : Peering;}
            {_primaryAzurePort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("primaryAzurePort"), out var __jsonPrimaryAzurePort) ? (string)__jsonPrimaryAzurePort : (string)PrimaryAzurePort;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_sTag = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber>("sTag"), out var __jsonSTag) ? (int?)__jsonSTag : STag;}
            {_secondaryAzurePort = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("secondaryAzurePort"), out var __jsonSecondaryAzurePort) ? (string)__jsonSecondaryAzurePort : (string)SecondaryAzurePort;}
            {_serviceProviderNote = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("serviceProviderNotes"), out var __jsonServiceProviderNotes) ? (string)__jsonServiceProviderNotes : (string)ServiceProviderNote;}
            {_serviceProviderProvisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString>("serviceProviderProvisioningState"), out var __jsonServiceProviderProvisioningState) ? (string)__jsonServiceProviderProvisioningState : (string)ServiceProviderProvisioningState;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject json ? new ExpressRouteCrossConnectionProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ExpressRouteCrossConnectionProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ExpressRouteCrossConnectionProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._expressRouteCircuit ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) this._expressRouteCircuit.ToJson(null,serializationMode) : null, "expressRouteCircuit" ,container.Add );
            AddIf( null != this._bandwidthInMbps ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._bandwidthInMbps) : null, "bandwidthInMbps" ,container.Add );
            AddIf( null != (((object)this._peeringLocation)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._peeringLocation.ToString()) : null, "peeringLocation" ,container.Add );
            if (null != this._peering)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.XNodeArray();
                foreach( var __x in this._peering )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("peerings",__w);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._primaryAzurePort)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._primaryAzurePort.ToString()) : null, "primaryAzurePort" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._sTag ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNumber((int)this._sTag) : null, "sTag" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._secondaryAzurePort)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._secondaryAzurePort.ToString()) : null, "secondaryAzurePort" ,container.Add );
            }
            AddIf( null != (((object)this._serviceProviderNote)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._serviceProviderNote.ToString()) : null, "serviceProviderNotes" ,container.Add );
            AddIf( null != (((object)this._serviceProviderProvisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonString(this._serviceProviderProvisioningState.ToString()) : null, "serviceProviderProvisioningState" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}