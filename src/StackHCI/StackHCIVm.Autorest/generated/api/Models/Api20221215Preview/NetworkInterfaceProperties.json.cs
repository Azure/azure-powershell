namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Properties under the network interface resource</summary>
    public partial class NetworkInterfaceProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.INetworkInterfaceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json ? new NetworkInterfaceProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject into a new instance of <see cref="NetworkInterfaceProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal NetworkInterfaceProperties(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_dnsSetting = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("dnsSettings"), out var __jsonDnsSettings) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.InterfaceDnsSettings.FromJson(__jsonDnsSettings) : DnsSetting;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject>("status"), out var __jsonStatus) ? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.NetworkInterfaceStatus.FromJson(__jsonStatus) : Status;}
            {_iPConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonArray>("ipConfigurations"), out var __jsonIPConfigurations) ? If( __jsonIPConfigurations as Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPConfiguration) (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPConfiguration.FromJson(__u) )) ))() : null : IPConfiguration;}
            {_macAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("macAddress"), out var __jsonMacAddress) ? (string)__jsonMacAddress : (string)MacAddress;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="NetworkInterfaceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NetworkInterfaceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._dnsSetting ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._dnsSetting.ToJson(null,serializationMode) : null, "dnsSettings" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._status ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) this._status.ToJson(null,serializationMode) : null, "status" ,container.Add );
            }
            if (null != this._iPConfiguration)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.XNodeArray();
                foreach( var __x in this._iPConfiguration )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("ipConfigurations",__w);
            }
            AddIf( null != (((object)this._macAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._macAddress.ToString()) : null, "macAddress" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}