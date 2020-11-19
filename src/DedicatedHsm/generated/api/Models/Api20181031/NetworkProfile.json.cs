namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    public partial class NetworkProfile
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkProfile.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkProfile.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkProfile FromJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json ? new NetworkProfile(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject into a new instance of <see cref="NetworkProfile" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal NetworkProfile(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_subnet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject>("subnet"), out var __jsonSubnet) ? Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ApiEntityReference.FromJson(__jsonSubnet) : Subnet;}
            {_networkInterface = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonArray>("networkInterfaces"), out var __jsonNetworkInterfaces) ? If( __jsonNetworkInterfaces as Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.INetworkInterface) (Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.NetworkInterface.FromJson(__u) )) ))() : null : NetworkInterface;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="NetworkProfile" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NetworkProfile" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._subnet ? (Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode) this._subnet.ToJson(null,serializationMode) : null, "subnet" ,container.Add );
            if (null != this._networkInterface)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.XNodeArray();
                foreach( var __x in this._networkInterface )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("networkInterfaces",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}