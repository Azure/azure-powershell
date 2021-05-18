namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container group properties</summary>
    public partial class ContainerGroupProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject into a new instance of <see cref="ContainerGroupProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ContainerGroupProperties(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_iPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("ipAddress"), out var __jsonIPAddress) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPAddress.FromJson(__jsonIPAddress) : IPAddress;}
            {_instanceView = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("instanceView"), out var __jsonInstanceView) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupPropertiesInstanceView.FromJson(__jsonInstanceView) : InstanceView;}
            {_diagnostic = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("diagnostics"), out var __jsonDiagnostics) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupDiagnostics.FromJson(__jsonDiagnostics) : Diagnostic;}
            {_networkProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("networkProfile"), out var __jsonNetworkProfile) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupNetworkProfile.FromJson(__jsonNetworkProfile) : NetworkProfile;}
            {_dnsConfig = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("dnsConfig"), out var __jsonDnsConfig) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.DnsConfiguration.FromJson(__jsonDnsConfig) : DnsConfig;}
            {_encryptionProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject>("encryptionProperties"), out var __jsonEncryptionProperties) ? Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EncryptionProperties.FromJson(__jsonEncryptionProperties) : EncryptionProperty;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_container = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("containers"), out var __jsonContainers) ? If( __jsonContainers as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer) (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Container.FromJson(__u) )) ))() : null : Container;}
            {_imageRegistryCredentials = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("imageRegistryCredentials"), out var __jsonImageRegistryCredentials) ? If( __jsonImageRegistryCredentials as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential) (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ImageRegistryCredential.FromJson(__p) )) ))() : null : ImageRegistryCredentials;}
            {_restartPolicy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString>("restartPolicy"), out var __jsonRestartPolicy) ? (string)__jsonRestartPolicy : (string)RestartPolicy;}
            {_oSType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString>("osType"), out var __jsonOSType) ? (string)__jsonOSType : (string)OSType;}
            {_volume = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("volumes"), out var __jsonVolumes) ? If( __jsonVolumes as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume) (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Volume.FromJson(__k) )) ))() : null : Volume;}
            {_sku = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString>("sku"), out var __jsonSku) ? (string)__jsonSku : (string)Sku;}
            {_initContainer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray>("initContainers"), out var __jsonInitContainers) ? If( __jsonInitContainers as Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition) (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.InitContainerDefinition.FromJson(__f) )) ))() : null : InitContainer;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject json ? new ContainerGroupProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ContainerGroupProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ContainerGroupProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._iPAddress ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._iPAddress.ToJson(null,serializationMode) : null, "ipAddress" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._instanceView ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._instanceView.ToJson(null,serializationMode) : null, "instanceView" ,container.Add );
            }
            AddIf( null != this._diagnostic ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._diagnostic.ToJson(null,serializationMode) : null, "diagnostics" ,container.Add );
            AddIf( null != this._networkProfile ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._networkProfile.ToJson(null,serializationMode) : null, "networkProfile" ,container.Add );
            AddIf( null != this._dnsConfig ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._dnsConfig.ToJson(null,serializationMode) : null, "dnsConfig" ,container.Add );
            AddIf( null != this._encryptionProperty ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) this._encryptionProperty.ToJson(null,serializationMode) : null, "encryptionProperties" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (null != this._container)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                foreach( var __x in this._container )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("containers",__w);
            }
            if (null != this._imageRegistryCredentials)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                foreach( var __s in this._imageRegistryCredentials )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("imageRegistryCredentials",__r);
            }
            AddIf( null != (((object)this._restartPolicy)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(this._restartPolicy.ToString()) : null, "restartPolicy" ,container.Add );
            AddIf( null != (((object)this._oSType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(this._oSType.ToString()) : null, "osType" ,container.Add );
            if (null != this._volume)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                foreach( var __n in this._volume )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("volumes",__m);
            }
            AddIf( null != (((object)this._sku)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonString(this._sku.ToString()) : null, "sku" ,container.Add );
            if (null != this._initContainer)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.XNodeArray();
                foreach( var __i in this._initContainer )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("initContainers",__h);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}