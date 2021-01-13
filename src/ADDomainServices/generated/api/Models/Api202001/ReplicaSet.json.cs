namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Replica Set Definition</summary>
    public partial class ReplicaSet
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json ? new ReplicaSet(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject into a new instance of <see cref="ReplicaSet" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ReplicaSet(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("replicaSetId"), out var __jsonReplicaSetId) ? (string)__jsonReplicaSetId : (string)Id;}
            {_location = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("location"), out var __jsonLocation) ? (string)__jsonLocation : (string)Location;}
            {_vnetSiteId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("vnetSiteId"), out var __jsonVnetSiteId) ? (string)__jsonVnetSiteId : (string)VnetSiteId;}
            {_subnetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("subnetId"), out var __jsonSubnetId) ? (string)__jsonSubnetId : (string)SubnetId;}
            {_domainControllerIPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonArray>("domainControllerIpAddress"), out var __jsonDomainControllerIPAddress) ? If( __jsonDomainControllerIPAddress as Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : DomainControllerIPAddress;}
            {_externalAccessIPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("externalAccessIpAddress"), out var __jsonExternalAccessIPAddress) ? (string)__jsonExternalAccessIPAddress : (string)ExternalAccessIPAddress;}
            {_serviceStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("serviceStatus"), out var __jsonServiceStatus) ? (string)__jsonServiceStatus : (string)ServiceStatus;}
            {_healthLastEvaluated = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("healthLastEvaluated"), out var __jsonHealthLastEvaluated) ? global::System.DateTime.TryParse((string)__jsonHealthLastEvaluated, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonHealthLastEvaluatedValue) ? __jsonHealthLastEvaluatedValue : HealthLastEvaluated : HealthLastEvaluated;}
            {_healthMonitor = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonArray>("healthMonitors"), out var __jsonHealthMonitors) ? If( __jsonHealthMonitors as Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor) (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.HealthMonitor.FromJson(__p) )) ))() : null : HealthMonitor;}
            {_healthAlert = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonArray>("healthAlerts"), out var __jsonHealthAlerts) ? If( __jsonHealthAlerts as Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert) (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.HealthAlert.FromJson(__k) )) ))() : null : HealthAlert;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ReplicaSet" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ReplicaSet" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._id.ToString()) : null, "replicaSetId" ,container.Add );
            }
            AddIf( null != (((object)this._location)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._location.ToString()) : null, "location" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._vnetSiteId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._vnetSiteId.ToString()) : null, "vnetSiteId" ,container.Add );
            }
            AddIf( null != (((object)this._subnetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._subnetId.ToString()) : null, "subnetId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._domainControllerIPAddress)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.XNodeArray();
                    foreach( var __x in this._domainControllerIPAddress )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("domainControllerIpAddress",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._externalAccessIPAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._externalAccessIPAddress.ToString()) : null, "externalAccessIpAddress" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._serviceStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._serviceStatus.ToString()) : null, "serviceStatus" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._healthLastEvaluated ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._healthLastEvaluated?.ToString(@"R",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "healthLastEvaluated" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._healthMonitor)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.XNodeArray();
                    foreach( var __s in this._healthMonitor )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("healthMonitors",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._healthAlert)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.XNodeArray();
                    foreach( var __n in this._healthAlert )
                    {
                        AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                    }
                    container.Add("healthAlerts",__m);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}