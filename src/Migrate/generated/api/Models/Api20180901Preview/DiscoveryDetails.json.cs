namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Discovery properties that can be published by various ISVs.</summary>
    public partial class DiscoveryDetails
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="DiscoveryDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DiscoveryDetails(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_oSType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("osType"), out var __jsonOSType) ? (string)__jsonOSType : (string)OSType;}
            {_oSName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("osName"), out var __jsonOSName) ? (string)__jsonOSName : (string)OSName;}
            {_oSVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("osVersion"), out var __jsonOSVersion) ? (string)__jsonOSVersion : (string)OSVersion;}
            {_enqueueTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("enqueueTime"), out var __jsonEnqueueTime) ? (string)__jsonEnqueueTime : (string)EnqueueTime;}
            {_solutionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("solutionName"), out var __jsonSolutionName) ? (string)__jsonSolutionName : (string)SolutionName;}
            {_machineId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("machineId"), out var __jsonMachineId) ? (string)__jsonMachineId : (string)MachineId;}
            {_machineManagerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("machineManagerId"), out var __jsonMachineManagerId) ? (string)__jsonMachineManagerId : (string)MachineManagerId;}
            {_fabricType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("fabricType"), out var __jsonFabricType) ? (string)__jsonFabricType : (string)FabricType;}
            {_lastUpdatedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastUpdatedTime"), out var __jsonLastUpdatedTime) ? global::System.DateTime.TryParse((string)__jsonLastUpdatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastUpdatedTimeValue) ? __jsonLastUpdatedTimeValue : LastUpdatedTime : LastUpdatedTime;}
            {_machineName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("machineName"), out var __jsonMachineName) ? (string)__jsonMachineName : (string)MachineName;}
            {_iPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("ipAddresses"), out var __jsonIPAddresses) ? If( __jsonIPAddresses as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : IPAddress;}
            {_fqdn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("fqdn"), out var __jsonFqdn) ? (string)__jsonFqdn : (string)Fqdn;}
            {_biosId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("biosId"), out var __jsonBiosId) ? (string)__jsonBiosId : (string)BiosId;}
            {_macAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("macAddresses"), out var __jsonMacAddresses) ? If( __jsonMacAddresses as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : MacAddress;}
            {_extendedInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("extendedInfo"), out var __jsonExtendedInfo) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DiscoveryDetailsExtendedInfo.FromJson(__jsonExtendedInfo) : ExtendedInfo;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new DiscoveryDetails(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DiscoveryDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DiscoveryDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._oSType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._oSType.ToString()) : null, "osType" ,container.Add );
            AddIf( null != (((object)this._oSName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._oSName.ToString()) : null, "osName" ,container.Add );
            AddIf( null != (((object)this._oSVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._oSVersion.ToString()) : null, "osVersion" ,container.Add );
            AddIf( null != (((object)this._enqueueTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._enqueueTime.ToString()) : null, "enqueueTime" ,container.Add );
            AddIf( null != (((object)this._solutionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._solutionName.ToString()) : null, "solutionName" ,container.Add );
            AddIf( null != (((object)this._machineId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._machineId.ToString()) : null, "machineId" ,container.Add );
            AddIf( null != (((object)this._machineManagerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._machineManagerId.ToString()) : null, "machineManagerId" ,container.Add );
            AddIf( null != (((object)this._fabricType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._fabricType.ToString()) : null, "fabricType" ,container.Add );
            AddIf( null != this._lastUpdatedTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastUpdatedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastUpdatedTime" ,container.Add );
            AddIf( null != (((object)this._machineName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._machineName.ToString()) : null, "machineName" ,container.Add );
            if (null != this._iPAddress)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._iPAddress )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("ipAddresses",__w);
            }
            AddIf( null != (((object)this._fqdn)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._fqdn.ToString()) : null, "fqdn" ,container.Add );
            AddIf( null != (((object)this._biosId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._biosId.ToString()) : null, "biosId" ,container.Add );
            if (null != this._macAddress)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __s in this._macAddress )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("macAddresses",__r);
            }
            AddIf( null != this._extendedInfo ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._extendedInfo.ToJson(null,serializationMode) : null, "extendedInfo" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}