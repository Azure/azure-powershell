// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Capability for the Azure Database for PostgreSQL flexible server.</summary>
    public partial class Capability
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject into a new instance of <see cref="Capability" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Capability(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __capabilityBase = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.CapabilityBase(json);
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)_name;}
            {_supportedServerEdition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("supportedServerEditions"), out var __jsonSupportedServerEditions) ? If( __jsonSupportedServerEditions as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability) (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerEditionCapability.FromJson(__u) )) ))() : null : _supportedServerEdition;}
            {_supportedServerVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("supportedServerVersions"), out var __jsonSupportedServerVersions) ? If( __jsonSupportedServerVersions as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerVersionCapability) (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerVersionCapability.FromJson(__p) )) ))() : null : _supportedServerVersion;}
            {_supportedFeature = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("supportedFeatures"), out var __jsonSupportedFeatures) ? If( __jsonSupportedFeatures as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature) (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SupportedFeature.FromJson(__k) )) ))() : null : _supportedFeature;}
            {_fastProvisioningSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("fastProvisioningSupported"), out var __jsonFastProvisioningSupported) ? (string)__jsonFastProvisioningSupported : (string)_fastProvisioningSupported;}
            {_supportedFastProvisioningEdition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("supportedFastProvisioningEditions"), out var __jsonSupportedFastProvisioningEditions) ? If( __jsonSupportedFastProvisioningEditions as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFastProvisioningEditionCapability) (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FastProvisioningEditionCapability.FromJson(__f) )) ))() : null : _supportedFastProvisioningEdition;}
            {_geoBackupSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("geoBackupSupported"), out var __jsonGeoBackupSupported) ? (string)__jsonGeoBackupSupported : (string)_geoBackupSupported;}
            {_zoneRedundantHaSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("zoneRedundantHaSupported"), out var __jsonZoneRedundantHaSupported) ? (string)__jsonZoneRedundantHaSupported : (string)_zoneRedundantHaSupported;}
            {_zoneRedundantHaAndGeoBackupSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("zoneRedundantHaAndGeoBackupSupported"), out var __jsonZoneRedundantHaAndGeoBackupSupported) ? (string)__jsonZoneRedundantHaAndGeoBackupSupported : (string)_zoneRedundantHaAndGeoBackupSupported;}
            {_storageAutoGrowthSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("storageAutoGrowthSupported"), out var __jsonStorageAutoGrowthSupported) ? (string)__jsonStorageAutoGrowthSupported : (string)_storageAutoGrowthSupported;}
            {_onlineResizeSupported = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("onlineResizeSupported"), out var __jsonOnlineResizeSupported) ? (string)__jsonOnlineResizeSupported : (string)_onlineResizeSupported;}
            {_restricted = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("restricted"), out var __jsonRestricted) ? (string)__jsonRestricted : (string)_restricted;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapability.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapability.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapability FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json ? new Capability(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="Capability" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Capability" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            __capabilityBase?.ToJson(container, serializationMode);
            AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._supportedServerEdition)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.XNodeArray();
                    foreach( var __x in this._supportedServerEdition )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("supportedServerEditions",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._supportedServerVersion)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.XNodeArray();
                    foreach( var __s in this._supportedServerVersion )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("supportedServerVersions",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._supportedFeature)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.XNodeArray();
                    foreach( var __n in this._supportedFeature )
                    {
                        AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                    }
                    container.Add("supportedFeatures",__m);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._fastProvisioningSupported)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._fastProvisioningSupported.ToString()) : null, "fastProvisioningSupported" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                if (null != this._supportedFastProvisioningEdition)
                {
                    var __h = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.XNodeArray();
                    foreach( var __i in this._supportedFastProvisioningEdition )
                    {
                        AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                    }
                    container.Add("supportedFastProvisioningEditions",__h);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._geoBackupSupported)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._geoBackupSupported.ToString()) : null, "geoBackupSupported" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._zoneRedundantHaSupported)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._zoneRedundantHaSupported.ToString()) : null, "zoneRedundantHaSupported" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._zoneRedundantHaAndGeoBackupSupported)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._zoneRedundantHaAndGeoBackupSupported.ToString()) : null, "zoneRedundantHaAndGeoBackupSupported" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._storageAutoGrowthSupported)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._storageAutoGrowthSupported.ToString()) : null, "storageAutoGrowthSupported" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._onlineResizeSupported)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._onlineResizeSupported.ToString()) : null, "onlineResizeSupported" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._restricted)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._restricted.ToString()) : null, "restricted" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}