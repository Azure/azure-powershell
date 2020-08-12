namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The properties of a configuration store.</summary>
    public partial class ConfigurationStoreProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject into a new instance of <see cref="ConfigurationStoreProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ConfigurationStoreProperties(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_encryption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject>("encryption"), out var __jsonEncryption) ? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.EncryptionProperties.FromJson(__jsonEncryption) : Encryption;}
            {_creationDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("creationDate"), out var __jsonCreationDate) ? global::System.DateTime.TryParse((string)__jsonCreationDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreationDateValue) ? __jsonCreationDateValue : CreationDate : CreationDate;}
            {_endpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("endpoint"), out var __jsonEndpoint) ? (string)__jsonEndpoint : (string)Endpoint;}
            {_privateEndpointConnection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonArray>("privateEndpointConnections"), out var __jsonPrivateEndpointConnections) ? If( __jsonPrivateEndpointConnections as Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionReference[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IPrivateEndpointConnectionReference) (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.PrivateEndpointConnectionReference.FromJson(__u) )) ))() : null : PrivateEndpointConnection;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_publicNetworkAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString>("publicNetworkAccess"), out var __jsonPublicNetworkAccess) ? (string)__jsonPublicNetworkAccess : (string)PublicNetworkAccess;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject json ? new ConfigurationStoreProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ConfigurationStoreProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ConfigurationStoreProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._encryption ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) this._encryption.ToJson(null,serializationMode) : null, "encryption" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._creationDate ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._creationDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "creationDate" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._endpoint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._endpoint.ToString()) : null, "endpoint" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._privateEndpointConnection)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.XNodeArray();
                    foreach( var __x in this._privateEndpointConnection )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("privateEndpointConnections",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            AddIf( null != (((object)this._publicNetworkAccess)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonString(this._publicNetworkAccess.ToString()) : null, "publicNetworkAccess" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}