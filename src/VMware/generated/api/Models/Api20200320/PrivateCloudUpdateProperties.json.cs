namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The properties of a private cloud resource that may be updated</summary>
    public partial class PrivateCloudUpdateProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdateProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdateProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudUpdateProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json ? new PrivateCloudUpdateProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject into a new instance of <see cref="PrivateCloudUpdateProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal PrivateCloudUpdateProperties(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_managementCluster = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject>("managementCluster"), out var __jsonManagementCluster) ? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ManagementCluster.FromJson(__jsonManagementCluster) : ManagementCluster;}
            {_internet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString>("internet"), out var __jsonInternet) ? (string)__jsonInternet : (string)Internet;}
            {_identitySource = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonArray>("identitySources"), out var __jsonIdentitySources) ? If( __jsonIdentitySources as Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource) (Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IdentitySource.FromJson(__u) )) ))() : null : IdentitySource;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="PrivateCloudUpdateProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="PrivateCloudUpdateProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._managementCluster ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) this._managementCluster.ToJson(null,serializationMode) : null, "managementCluster" ,container.Add );
            AddIf( null != (((object)this._internet)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonString(this._internet.ToString()) : null, "internet" ,container.Add );
            if (null != this._identitySource)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.XNodeArray();
                foreach( var __x in this._identitySource )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("identitySources",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}