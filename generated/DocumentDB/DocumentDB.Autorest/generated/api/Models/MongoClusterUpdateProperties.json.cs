// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The updatable properties of the MongoCluster.</summary>
    public partial class MongoClusterUpdateProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoClusterUpdateProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject json ? new MongoClusterUpdateProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject into a new instance of <see cref="MongoClusterUpdateProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MongoClusterUpdateProperties(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_administrator = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("administrator"), out var __jsonAdministrator) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AdministratorProperties.FromJson(__jsonAdministrator) : _administrator;}
            {_highAvailability = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("highAvailability"), out var __jsonHighAvailability) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.HighAvailabilityProperties.FromJson(__jsonHighAvailability) : _highAvailability;}
            {_storage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("storage"), out var __jsonStorage) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.StorageProperties.FromJson(__jsonStorage) : _storage;}
            {_sharding = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("sharding"), out var __jsonSharding) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ShardingProperties.FromJson(__jsonSharding) : _sharding;}
            {_compute = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("compute"), out var __jsonCompute) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ComputeProperties.FromJson(__jsonCompute) : _compute;}
            {_backup = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("backup"), out var __jsonBackup) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.BackupProperties.FromJson(__jsonBackup) : _backup;}
            {_dataApi = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("dataApi"), out var __jsonDataApi) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.DataApiProperties.FromJson(__jsonDataApi) : _dataApi;}
            {_authConfig = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("authConfig"), out var __jsonAuthConfig) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.AuthConfigProperties.FromJson(__jsonAuthConfig) : _authConfig;}
            {_encryption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject>("encryption"), out var __jsonEncryption) ? Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.EncryptionProperties.FromJson(__jsonEncryption) : _encryption;}
            {_serverVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString>("serverVersion"), out var __jsonServerVersion) ? (string)__jsonServerVersion : (string)_serverVersion;}
            {_publicNetworkAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString>("publicNetworkAccess"), out var __jsonPublicNetworkAccess) ? (string)__jsonPublicNetworkAccess : (string)_publicNetworkAccess;}
            {_previewFeature = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonArray>("previewFeatures"), out var __jsonPreviewFeatures) ? If( __jsonPreviewFeatures as Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _previewFeature;}
            {_networkBypassMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString>("networkBypassMode"), out var __jsonNetworkBypassMode) ? (string)__jsonNetworkBypassMode : (string)_networkBypassMode;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MongoClusterUpdateProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MongoClusterUpdateProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._administrator ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._administrator.ToJson(null,serializationMode) : null, "administrator" ,container.Add );
            AddIf( null != this._highAvailability ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._highAvailability.ToJson(null,serializationMode) : null, "highAvailability" ,container.Add );
            AddIf( null != this._storage ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._storage.ToJson(null,serializationMode) : null, "storage" ,container.Add );
            AddIf( null != this._sharding ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._sharding.ToJson(null,serializationMode) : null, "sharding" ,container.Add );
            AddIf( null != this._compute ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._compute.ToJson(null,serializationMode) : null, "compute" ,container.Add );
            AddIf( null != this._backup ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._backup.ToJson(null,serializationMode) : null, "backup" ,container.Add );
            AddIf( null != this._dataApi ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._dataApi.ToJson(null,serializationMode) : null, "dataApi" ,container.Add );
            AddIf( null != this._authConfig ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._authConfig.ToJson(null,serializationMode) : null, "authConfig" ,container.Add );
            AddIf( null != this._encryption ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) this._encryption.ToJson(null,serializationMode) : null, "encryption" ,container.Add );
            AddIf( null != (((object)this._serverVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString(this._serverVersion.ToString()) : null, "serverVersion" ,container.Add );
            AddIf( null != (((object)this._publicNetworkAccess)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString(this._publicNetworkAccess.ToString()) : null, "publicNetworkAccess" ,container.Add );
            if (null != this._previewFeature)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.XNodeArray();
                foreach( var __x in this._previewFeature )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("previewFeatures",__w);
            }
            AddIf( null != (((object)this._networkBypassMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Json.JsonString(this._networkBypassMode.ToString()) : null, "networkBypassMode" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}