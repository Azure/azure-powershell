namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto cluster properties.</summary>
    public partial class ClusterProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject into a new instance of <see cref="ClusterProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ClusterProperties(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_keyVaultProperty = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject>("keyVaultProperties"), out var __jsonKeyVaultProperties) ? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.KeyVaultProperties.FromJson(__jsonKeyVaultProperties) : KeyVaultProperty;}
            {_languageExtension = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject>("languageExtensions"), out var __jsonLanguageExtensions) ? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.LanguageExtensionsList.FromJson(__jsonLanguageExtensions) : LanguageExtension;}
            {_optimizedAutoscale = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject>("optimizedAutoscale"), out var __jsonOptimizedAutoscale) ? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.OptimizedAutoscale.FromJson(__jsonOptimizedAutoscale) : OptimizedAutoscale;}
            {_virtualNetworkConfiguration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject>("virtualNetworkConfiguration"), out var __jsonVirtualNetworkConfiguration) ? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.VirtualNetworkConfiguration.FromJson(__jsonVirtualNetworkConfiguration) : VirtualNetworkConfiguration;}
            {_dataIngestionUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("dataIngestionUri"), out var __jsonDataIngestionUri) ? (string)__jsonDataIngestionUri : (string)DataIngestionUri;}
            {_enableDiskEncryption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonBoolean>("enableDiskEncryption"), out var __jsonEnableDiskEncryption) ? (bool?)__jsonEnableDiskEncryption : EnableDiskEncryption;}
            {_enablePurge = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonBoolean>("enablePurge"), out var __jsonEnablePurge) ? (bool?)__jsonEnablePurge : EnablePurge;}
            {_enableStreamingIngest = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonBoolean>("enableStreamingIngest"), out var __jsonEnableStreamingIngest) ? (bool?)__jsonEnableStreamingIngest : EnableStreamingIngest;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            {_stateReason = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("stateReason"), out var __jsonStateReason) ? (string)__jsonStateReason : (string)StateReason;}
            {_trustedExternalTenant = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray>("trustedExternalTenants"), out var __jsonTrustedExternalTenants) ? If( __jsonTrustedExternalTenants as Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ITrustedExternalTenant[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.ITrustedExternalTenant) (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.TrustedExternalTenant.FromJson(__u) )) ))() : null : TrustedExternalTenant;}
            {_uri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString>("uri"), out var __jsonUri) ? (string)__jsonUri : (string)Uri;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IClusterProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject json ? new ClusterProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ClusterProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ClusterProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._keyVaultProperty ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) this._keyVaultProperty.ToJson(null,serializationMode) : null, "keyVaultProperties" ,container.Add );
            AddIf( null != this._languageExtension ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) this._languageExtension.ToJson(null,serializationMode) : null, "languageExtensions" ,container.Add );
            AddIf( null != this._optimizedAutoscale ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) this._optimizedAutoscale.ToJson(null,serializationMode) : null, "optimizedAutoscale" ,container.Add );
            AddIf( null != this._virtualNetworkConfiguration ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) this._virtualNetworkConfiguration.ToJson(null,serializationMode) : null, "virtualNetworkConfiguration" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._dataIngestionUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._dataIngestionUri.ToString()) : null, "dataIngestionUri" ,container.Add );
            }
            AddIf( null != this._enableDiskEncryption ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonBoolean((bool)this._enableDiskEncryption) : null, "enableDiskEncryption" ,container.Add );
            AddIf( null != this._enablePurge ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonBoolean((bool)this._enablePurge) : null, "enablePurge" ,container.Add );
            AddIf( null != this._enableStreamingIngest ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonBoolean((bool)this._enableStreamingIngest) : null, "enableStreamingIngest" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._stateReason)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._stateReason.ToString()) : null, "stateReason" ,container.Add );
            }
            if (null != this._trustedExternalTenant)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.XNodeArray();
                foreach( var __x in this._trustedExternalTenant )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("trustedExternalTenants",__w);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._uri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonString(this._uri.ToString()) : null, "uri" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}