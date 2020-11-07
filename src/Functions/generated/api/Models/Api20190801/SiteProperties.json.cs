namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Site resource specific properties</summary>
    public partial class SiteProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new SiteProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="SiteProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SiteProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_cloningInfo = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("cloningInfo"), out var __jsonCloningInfo) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfo.FromJson(__jsonCloningInfo) : CloningInfo;}
            {_hostingEnvironmentProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("hostingEnvironmentProfile"), out var __jsonHostingEnvironmentProfile) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfile.FromJson(__jsonHostingEnvironmentProfile) : HostingEnvironmentProfile;}
            {_slotSwapStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("slotSwapStatus"), out var __jsonSlotSwapStatus) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlotSwapStatus.FromJson(__jsonSlotSwapStatus) : SlotSwapStatus;}
            {_availabilityState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("availabilityState"), out var __jsonAvailabilityState) ? (string)__jsonAvailabilityState : (string)AvailabilityState;}
            {_clientAffinityEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("clientAffinityEnabled"), out var __jsonClientAffinityEnabled) ? (bool?)__jsonClientAffinityEnabled : ClientAffinityEnabled;}
            {_clientCertEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("clientCertEnabled"), out var __jsonClientCertEnabled) ? (bool?)__jsonClientCertEnabled : ClientCertEnabled;}
            {_clientCertExclusionPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("clientCertExclusionPaths"), out var __jsonClientCertExclusionPaths) ? (string)__jsonClientCertExclusionPaths : (string)ClientCertExclusionPath;}
            {_containerSize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("containerSize"), out var __jsonContainerSize) ? (int?)__jsonContainerSize : ContainerSize;}
            {_dailyMemoryTimeQuota = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("dailyMemoryTimeQuota"), out var __jsonDailyMemoryTimeQuota) ? (int?)__jsonDailyMemoryTimeQuota : DailyMemoryTimeQuota;}
            {_defaultHostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("defaultHostName"), out var __jsonDefaultHostName) ? (string)__jsonDefaultHostName : (string)DefaultHostName;}
            {_enabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("enabled"), out var __jsonEnabled) ? (bool?)__jsonEnabled : Enabled;}
            {_enabledHostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("enabledHostNames"), out var __jsonEnabledHostNames) ? If( __jsonEnabledHostNames as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : EnabledHostName;}
            {_hostNameSslState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("hostNameSslStates"), out var __jsonHostNameSslStates) ? If( __jsonHostNameSslStates as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameSslState.FromJson(__p) )) ))() : null : HostNameSslState;}
            {_hostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("hostNames"), out var __jsonHostNames) ? If( __jsonHostNames as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : HostName;}
            {_hostNamesDisabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("hostNamesDisabled"), out var __jsonHostNamesDisabled) ? (bool?)__jsonHostNamesDisabled : HostNamesDisabled;}
            {_httpsOnly = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("httpsOnly"), out var __jsonHttpsOnly) ? (bool?)__jsonHttpsOnly : HttpsOnly;}
            {_hyperV = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("hyperV"), out var __jsonHyperV) ? (bool?)__jsonHyperV : HyperV;}
            {_inProgressOperationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("inProgressOperationId"), out var __jsonInProgressOperationId) ? (string)__jsonInProgressOperationId : (string)InProgressOperationId;}
            {_isDefaultContainer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("isDefaultContainer"), out var __jsonIsDefaultContainer) ? (bool?)__jsonIsDefaultContainer : IsDefaultContainer;}
            {_isXenon = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("isXenon"), out var __jsonIsXenon) ? (bool?)__jsonIsXenon : IsXenon;}
            {_lastModifiedTimeUtc = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("lastModifiedTimeUtc"), out var __jsonLastModifiedTimeUtc) ? global::System.DateTime.TryParse((string)__jsonLastModifiedTimeUtc, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastModifiedTimeUtcValue) ? __jsonLastModifiedTimeUtcValue : LastModifiedTimeUtc : LastModifiedTimeUtc;}
            {_maxNumberOfWorker = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("maxNumberOfWorkers"), out var __jsonMaxNumberOfWorkers) ? (int?)__jsonMaxNumberOfWorkers : MaxNumberOfWorker;}
            {_outboundIPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("outboundIpAddresses"), out var __jsonOutboundIPAddresses) ? (string)__jsonOutboundIPAddresses : (string)OutboundIPAddress;}
            {_possibleOutboundIPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("possibleOutboundIpAddresses"), out var __jsonPossibleOutboundIPAddresses) ? (string)__jsonPossibleOutboundIPAddresses : (string)PossibleOutboundIPAddress;}
            {_redundancyMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("redundancyMode"), out var __jsonRedundancyMode) ? (string)__jsonRedundancyMode : (string)RedundancyMode;}
            {_repositorySiteName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("repositorySiteName"), out var __jsonRepositorySiteName) ? (string)__jsonRepositorySiteName : (string)RepositorySiteName;}
            {_reserved = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("reserved"), out var __jsonReserved) ? (bool?)__jsonReserved : Reserved;}
            {_resourceGroup = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("resourceGroup"), out var __jsonResourceGroup) ? (string)__jsonResourceGroup : (string)ResourceGroup;}
            {_scmSiteAlsoStopped = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("scmSiteAlsoStopped"), out var __jsonScmSiteAlsoStopped) ? (bool?)__jsonScmSiteAlsoStopped : ScmSiteAlsoStopped;}
            {_serverFarmId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("serverFarmId"), out var __jsonServerFarmId) ? (string)__jsonServerFarmId : (string)ServerFarmId;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            {_suspendedTill = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("suspendedTill"), out var __jsonSuspendedTill) ? global::System.DateTime.TryParse((string)__jsonSuspendedTill, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonSuspendedTillValue) ? __jsonSuspendedTillValue : SuspendedTill : SuspendedTill;}
            {_targetSwapSlot = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("targetSwapSlot"), out var __jsonTargetSwapSlot) ? (string)__jsonTargetSwapSlot : (string)TargetSwapSlot;}
            {_trafficManagerHostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("trafficManagerHostNames"), out var __jsonTrafficManagerHostNames) ? If( __jsonTrafficManagerHostNames as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(string) (__f is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __e ? (string)(__e.ToString()) : null)) ))() : null : TrafficManagerHostName;}
            {_usageState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("usageState"), out var __jsonUsageState) ? (string)__jsonUsageState : (string)UsageState;}
            {_siteConfig = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("siteConfig"), out var __jsonSiteConfig) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteConfig.FromJson(__jsonSiteConfig) : SiteConfig;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SiteProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SiteProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._cloningInfo ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._cloningInfo.ToJson(null,serializationMode) : null, "cloningInfo" ,container.Add );
            AddIf( null != this._hostingEnvironmentProfile ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._hostingEnvironmentProfile.ToJson(null,serializationMode) : null, "hostingEnvironmentProfile" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._slotSwapStatus ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._slotSwapStatus.ToJson(null,serializationMode) : null, "slotSwapStatus" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._availabilityState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._availabilityState.ToString()) : null, "availabilityState" ,container.Add );
            }
            AddIf( null != this._clientAffinityEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._clientAffinityEnabled) : null, "clientAffinityEnabled" ,container.Add );
            AddIf( null != this._clientCertEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._clientCertEnabled) : null, "clientCertEnabled" ,container.Add );
            AddIf( null != (((object)this._clientCertExclusionPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._clientCertExclusionPath.ToString()) : null, "clientCertExclusionPaths" ,container.Add );
            AddIf( null != this._containerSize ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._containerSize) : null, "containerSize" ,container.Add );
            AddIf( null != this._dailyMemoryTimeQuota ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._dailyMemoryTimeQuota) : null, "dailyMemoryTimeQuota" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._defaultHostName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._defaultHostName.ToString()) : null, "defaultHostName" ,container.Add );
            }
            AddIf( null != this._enabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._enabled) : null, "enabled" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._enabledHostName)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __x in this._enabledHostName )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("enabledHostNames",__w);
                }
            }
            if (null != this._hostNameSslState)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __s in this._hostNameSslState )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("hostNameSslStates",__r);
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._hostName)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __n in this._hostName )
                    {
                        AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                    }
                    container.Add("hostNames",__m);
                }
            }
            AddIf( null != this._hostNamesDisabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._hostNamesDisabled) : null, "hostNamesDisabled" ,container.Add );
            AddIf( null != this._httpsOnly ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._httpsOnly) : null, "httpsOnly" ,container.Add );
            AddIf( null != this._hyperV ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._hyperV) : null, "hyperV" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._inProgressOperationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._inProgressOperationId.ToString()) : null, "inProgressOperationId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._isDefaultContainer ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._isDefaultContainer) : null, "isDefaultContainer" ,container.Add );
            }
            AddIf( null != this._isXenon ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._isXenon) : null, "isXenon" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastModifiedTimeUtc ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._lastModifiedTimeUtc?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastModifiedTimeUtc" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._maxNumberOfWorker ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._maxNumberOfWorker) : null, "maxNumberOfWorkers" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._outboundIPAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._outboundIPAddress.ToString()) : null, "outboundIpAddresses" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._possibleOutboundIPAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._possibleOutboundIPAddress.ToString()) : null, "possibleOutboundIpAddresses" ,container.Add );
            }
            AddIf( null != (((object)this._redundancyMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._redundancyMode.ToString()) : null, "redundancyMode" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._repositorySiteName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._repositorySiteName.ToString()) : null, "repositorySiteName" ,container.Add );
            }
            AddIf( null != this._reserved ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._reserved) : null, "reserved" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._resourceGroup)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._resourceGroup.ToString()) : null, "resourceGroup" ,container.Add );
            }
            AddIf( null != this._scmSiteAlsoStopped ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._scmSiteAlsoStopped) : null, "scmSiteAlsoStopped" ,container.Add );
            AddIf( null != (((object)this._serverFarmId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._serverFarmId.ToString()) : null, "serverFarmId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._suspendedTill ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._suspendedTill?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "suspendedTill" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._targetSwapSlot)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._targetSwapSlot.ToString()) : null, "targetSwapSlot" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._trafficManagerHostName)
                {
                    var __h = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __i in this._trafficManagerHostName )
                    {
                        AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                    }
                    container.Add("trafficManagerHostNames",__h);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._usageState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._usageState.ToString()) : null, "usageState" ,container.Add );
            }
            AddIf( null != this._siteConfig ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._siteConfig.ToJson(null,serializationMode) : null, "siteConfig" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}