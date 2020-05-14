namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Configuration of an App Service app.</summary>
    public partial class SiteConfig
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new SiteConfig(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="SiteConfig" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SiteConfig(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_apiDefinition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("apiDefinition"), out var __jsonApiDefinition) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApiDefinitionInfo.FromJson(__jsonApiDefinition) : ApiDefinition;}
            {_apiManagementConfig = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("apiManagementConfig"), out var __jsonApiManagementConfig) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApiManagementConfig.FromJson(__jsonApiManagementConfig) : ApiManagementConfig;}
            {_autoHealRule = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("autoHealRules"), out var __jsonAutoHealRules) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealRules.FromJson(__jsonAutoHealRules) : AutoHealRule;}
            {_cor = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("cors"), out var __jsonCors) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CorsSettings.FromJson(__jsonCors) : Cor;}
            {_experiment = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("experiments"), out var __jsonExperiments) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Experiments.FromJson(__jsonExperiments) : Experiment;}
            {_limit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("limits"), out var __jsonLimits) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLimits.FromJson(__jsonLimits) : Limit;}
            {_machineKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("machineKey"), out var __jsonMachineKey) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteMachineKey.FromJson(__jsonMachineKey) : MachineKey;}
            {_push = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("push"), out var __jsonPush) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PushSettings.FromJson(__jsonPush) : Push;}
            {_alwaysOn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("alwaysOn"), out var __jsonAlwaysOn) ? (bool?)__jsonAlwaysOn : AlwaysOn;}
            {_appCommandLine = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("appCommandLine"), out var __jsonAppCommandLine) ? (string)__jsonAppCommandLine : (string)AppCommandLine;}
            {_appSetting = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("appSettings"), out var __jsonAppSettings) ? If( __jsonAppSettings as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePair.FromJson(__u) )) ))() : null : AppSetting;}
            {_autoHealEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("autoHealEnabled"), out var __jsonAutoHealEnabled) ? (bool?)__jsonAutoHealEnabled : AutoHealEnabled;}
            {_autoSwapSlotName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("autoSwapSlotName"), out var __jsonAutoSwapSlotName) ? (string)__jsonAutoSwapSlotName : (string)AutoSwapSlotName;}
            {_connectionString = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("connectionStrings"), out var __jsonConnectionStrings) ? If( __jsonConnectionStrings as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ConnStringInfo.FromJson(__p) )) ))() : null : ConnectionString;}
            {_defaultDocument = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("defaultDocuments"), out var __jsonDefaultDocuments) ? If( __jsonDefaultDocuments as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : DefaultDocument;}
            {_detailedErrorLoggingEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("detailedErrorLoggingEnabled"), out var __jsonDetailedErrorLoggingEnabled) ? (bool?)__jsonDetailedErrorLoggingEnabled : DetailedErrorLoggingEnabled;}
            {_documentRoot = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("documentRoot"), out var __jsonDocumentRoot) ? (string)__jsonDocumentRoot : (string)DocumentRoot;}
            {_ftpsState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("ftpsState"), out var __jsonFtpsState) ? (string)__jsonFtpsState : (string)FtpsState;}
            {_handlerMapping = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("handlerMappings"), out var __jsonHandlerMappings) ? If( __jsonHandlerMappings as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HandlerMapping.FromJson(__f) )) ))() : null : HandlerMapping;}
            {_healthCheckPath = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("healthCheckPath"), out var __jsonHealthCheckPath) ? (string)__jsonHealthCheckPath : (string)HealthCheckPath;}
            {_http20Enabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("http20Enabled"), out var __jsonHttp20Enabled) ? (bool?)__jsonHttp20Enabled : Http20Enabled;}
            {_httpLoggingEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("httpLoggingEnabled"), out var __jsonHttpLoggingEnabled) ? (bool?)__jsonHttpLoggingEnabled : HttpLoggingEnabled;}
            {_iPSecurityRestriction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("ipSecurityRestrictions"), out var __jsonIPSecurityRestrictions) ? If( __jsonIPSecurityRestrictions as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPSecurityRestriction.FromJson(__a) )) ))() : null : IPSecurityRestriction;}
            {_javaContainer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("javaContainer"), out var __jsonJavaContainer) ? (string)__jsonJavaContainer : (string)JavaContainer;}
            {_javaContainerVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("javaContainerVersion"), out var __jsonJavaContainerVersion) ? (string)__jsonJavaContainerVersion : (string)JavaContainerVersion;}
            {_javaVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("javaVersion"), out var __jsonJavaVersion) ? (string)__jsonJavaVersion : (string)JavaVersion;}
            {_linuxFxVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("linuxFxVersion"), out var __jsonLinuxFxVersion) ? (string)__jsonLinuxFxVersion : (string)LinuxFxVersion;}
            {_loadBalancing = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("loadBalancing"), out var __jsonLoadBalancing) ? (string)__jsonLoadBalancing : (string)LoadBalancing;}
            {_localMySqlEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("localMySqlEnabled"), out var __jsonLocalMySqlEnabled) ? (bool?)__jsonLocalMySqlEnabled : LocalMySqlEnabled;}
            {_logsDirectorySizeLimit = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("logsDirectorySizeLimit"), out var __jsonLogsDirectorySizeLimit) ? (int?)__jsonLogsDirectorySizeLimit : LogsDirectorySizeLimit;}
            {_managedPipelineMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("managedPipelineMode"), out var __jsonManagedPipelineMode) ? (string)__jsonManagedPipelineMode : (string)ManagedPipelineMode;}
            {_managedServiceIdentityId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("managedServiceIdentityId"), out var __jsonManagedServiceIdentityId) ? (int?)__jsonManagedServiceIdentityId : ManagedServiceIdentityId;}
            {_minTlsVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("minTlsVersion"), out var __jsonMinTlsVersion) ? (string)__jsonMinTlsVersion : (string)MinTlsVersion;}
            {_netFrameworkVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("netFrameworkVersion"), out var __jsonNetFrameworkVersion) ? (string)__jsonNetFrameworkVersion : (string)NetFrameworkVersion;}
            {_nodeVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("nodeVersion"), out var __jsonNodeVersion) ? (string)__jsonNodeVersion : (string)NodeVersion;}
            {_numberOfWorker = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("numberOfWorkers"), out var __jsonNumberOfWorkers) ? (int?)__jsonNumberOfWorkers : NumberOfWorker;}
            {_phpVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("phpVersion"), out var __jsonPhpVersion) ? (string)__jsonPhpVersion : (string)PhpVersion;}
            {_powerShellVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("powerShellVersion"), out var __jsonPowerShellVersion) ? (string)__jsonPowerShellVersion : (string)PowerShellVersion;}
            {_preWarmedInstanceCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("preWarmedInstanceCount"), out var __jsonPreWarmedInstanceCount) ? (int?)__jsonPreWarmedInstanceCount : PreWarmedInstanceCount;}
            {_publishingUsername = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("publishingUsername"), out var __jsonPublishingUsername) ? (string)__jsonPublishingUsername : (string)PublishingUsername;}
            {_pythonVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("pythonVersion"), out var __jsonPythonVersion) ? (string)__jsonPythonVersion : (string)PythonVersion;}
            {_remoteDebuggingEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("remoteDebuggingEnabled"), out var __jsonRemoteDebuggingEnabled) ? (bool?)__jsonRemoteDebuggingEnabled : RemoteDebuggingEnabled;}
            {_remoteDebuggingVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("remoteDebuggingVersion"), out var __jsonRemoteDebuggingVersion) ? (string)__jsonRemoteDebuggingVersion : (string)RemoteDebuggingVersion;}
            {_requestTracingEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("requestTracingEnabled"), out var __jsonRequestTracingEnabled) ? (bool?)__jsonRequestTracingEnabled : RequestTracingEnabled;}
            {_requestTracingExpirationTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("requestTracingExpirationTime"), out var __jsonRequestTracingExpirationTime) ? global::System.DateTime.TryParse((string)__jsonRequestTracingExpirationTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRequestTracingExpirationTimeValue) ? __jsonRequestTracingExpirationTimeValue : RequestTracingExpirationTime : RequestTracingExpirationTime;}
            {_scmIPSecurityRestriction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("scmIpSecurityRestrictions"), out var __jsonScmIPSecurityRestrictions) ? If( __jsonScmIPSecurityRestrictions as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPSecurityRestriction.FromJson(___v) )) ))() : null : ScmIPSecurityRestriction;}
            {_scmIPSecurityRestrictionsUseMain = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("scmIpSecurityRestrictionsUseMain"), out var __jsonScmIPSecurityRestrictionsUseMain) ? (bool?)__jsonScmIPSecurityRestrictionsUseMain : ScmIPSecurityRestrictionsUseMain;}
            {_scmType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("scmType"), out var __jsonScmType) ? (string)__jsonScmType : (string)ScmType;}
            {_tracingOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("tracingOptions"), out var __jsonTracingOptions) ? (string)__jsonTracingOptions : (string)TracingOption;}
            {_use32BitWorkerProcess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("use32BitWorkerProcess"), out var __jsonUse32BitWorkerProcess) ? (bool?)__jsonUse32BitWorkerProcess : Use32BitWorkerProcess;}
            {_virtualApplication = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("virtualApplications"), out var __jsonVirtualApplications) ? If( __jsonVirtualApplications as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualApplication.FromJson(___q) )) ))() : null : VirtualApplication;}
            {_vnetName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("vnetName"), out var __jsonVnetName) ? (string)__jsonVnetName : (string)VnetName;}
            {_webSocketsEnabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("webSocketsEnabled"), out var __jsonWebSocketsEnabled) ? (bool?)__jsonWebSocketsEnabled : WebSocketsEnabled;}
            {_windowsFxVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("windowsFxVersion"), out var __jsonWindowsFxVersion) ? (string)__jsonWindowsFxVersion : (string)WindowsFxVersion;}
            {_xManagedServiceIdentityId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("xManagedServiceIdentityId"), out var __jsonXManagedServiceIdentityId) ? (int?)__jsonXManagedServiceIdentityId : XManagedServiceIdentityId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SiteConfig" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SiteConfig" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._apiDefinition ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._apiDefinition.ToJson(null,serializationMode) : null, "apiDefinition" ,container.Add );
            AddIf( null != this._apiManagementConfig ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._apiManagementConfig.ToJson(null,serializationMode) : null, "apiManagementConfig" ,container.Add );
            AddIf( null != this._autoHealRule ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._autoHealRule.ToJson(null,serializationMode) : null, "autoHealRules" ,container.Add );
            AddIf( null != this._cor ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._cor.ToJson(null,serializationMode) : null, "cors" ,container.Add );
            AddIf( null != this._experiment ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._experiment.ToJson(null,serializationMode) : null, "experiments" ,container.Add );
            AddIf( null != this._limit ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._limit.ToJson(null,serializationMode) : null, "limits" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._machineKey ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._machineKey.ToJson(null,serializationMode) : null, "machineKey" ,container.Add );
            }
            AddIf( null != this._push ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._push.ToJson(null,serializationMode) : null, "push" ,container.Add );
            AddIf( null != this._alwaysOn ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._alwaysOn) : null, "alwaysOn" ,container.Add );
            AddIf( null != (((object)this._appCommandLine)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._appCommandLine.ToString()) : null, "appCommandLine" ,container.Add );
            if (null != this._appSetting)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __x in this._appSetting )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("appSettings",__w);
            }
            AddIf( null != this._autoHealEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._autoHealEnabled) : null, "autoHealEnabled" ,container.Add );
            AddIf( null != (((object)this._autoSwapSlotName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._autoSwapSlotName.ToString()) : null, "autoSwapSlotName" ,container.Add );
            if (null != this._connectionString)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __s in this._connectionString )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("connectionStrings",__r);
            }
            if (null != this._defaultDocument)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __n in this._defaultDocument )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("defaultDocuments",__m);
            }
            AddIf( null != this._detailedErrorLoggingEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._detailedErrorLoggingEnabled) : null, "detailedErrorLoggingEnabled" ,container.Add );
            AddIf( null != (((object)this._documentRoot)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._documentRoot.ToString()) : null, "documentRoot" ,container.Add );
            AddIf( null != (((object)this._ftpsState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._ftpsState.ToString()) : null, "ftpsState" ,container.Add );
            if (null != this._handlerMapping)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __i in this._handlerMapping )
                {
                    AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                }
                container.Add("handlerMappings",__h);
            }
            AddIf( null != (((object)this._healthCheckPath)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._healthCheckPath.ToString()) : null, "healthCheckPath" ,container.Add );
            AddIf( null != this._http20Enabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._http20Enabled) : null, "http20Enabled" ,container.Add );
            AddIf( null != this._httpLoggingEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._httpLoggingEnabled) : null, "httpLoggingEnabled" ,container.Add );
            if (null != this._iPSecurityRestriction)
            {
                var __c = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var __d in this._iPSecurityRestriction )
                {
                    AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                }
                container.Add("ipSecurityRestrictions",__c);
            }
            AddIf( null != (((object)this._javaContainer)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._javaContainer.ToString()) : null, "javaContainer" ,container.Add );
            AddIf( null != (((object)this._javaContainerVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._javaContainerVersion.ToString()) : null, "javaContainerVersion" ,container.Add );
            AddIf( null != (((object)this._javaVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._javaVersion.ToString()) : null, "javaVersion" ,container.Add );
            AddIf( null != (((object)this._linuxFxVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._linuxFxVersion.ToString()) : null, "linuxFxVersion" ,container.Add );
            AddIf( null != (((object)this._loadBalancing)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._loadBalancing.ToString()) : null, "loadBalancing" ,container.Add );
            AddIf( null != this._localMySqlEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._localMySqlEnabled) : null, "localMySqlEnabled" ,container.Add );
            AddIf( null != this._logsDirectorySizeLimit ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._logsDirectorySizeLimit) : null, "logsDirectorySizeLimit" ,container.Add );
            AddIf( null != (((object)this._managedPipelineMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._managedPipelineMode.ToString()) : null, "managedPipelineMode" ,container.Add );
            AddIf( null != this._managedServiceIdentityId ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._managedServiceIdentityId) : null, "managedServiceIdentityId" ,container.Add );
            AddIf( null != (((object)this._minTlsVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._minTlsVersion.ToString()) : null, "minTlsVersion" ,container.Add );
            AddIf( null != (((object)this._netFrameworkVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._netFrameworkVersion.ToString()) : null, "netFrameworkVersion" ,container.Add );
            AddIf( null != (((object)this._nodeVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._nodeVersion.ToString()) : null, "nodeVersion" ,container.Add );
            AddIf( null != this._numberOfWorker ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._numberOfWorker) : null, "numberOfWorkers" ,container.Add );
            AddIf( null != (((object)this._phpVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._phpVersion.ToString()) : null, "phpVersion" ,container.Add );
            AddIf( null != (((object)this._powerShellVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._powerShellVersion.ToString()) : null, "powerShellVersion" ,container.Add );
            AddIf( null != this._preWarmedInstanceCount ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._preWarmedInstanceCount) : null, "preWarmedInstanceCount" ,container.Add );
            AddIf( null != (((object)this._publishingUsername)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._publishingUsername.ToString()) : null, "publishingUsername" ,container.Add );
            AddIf( null != (((object)this._pythonVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._pythonVersion.ToString()) : null, "pythonVersion" ,container.Add );
            AddIf( null != this._remoteDebuggingEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._remoteDebuggingEnabled) : null, "remoteDebuggingEnabled" ,container.Add );
            AddIf( null != (((object)this._remoteDebuggingVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._remoteDebuggingVersion.ToString()) : null, "remoteDebuggingVersion" ,container.Add );
            AddIf( null != this._requestTracingEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._requestTracingEnabled) : null, "requestTracingEnabled" ,container.Add );
            AddIf( null != this._requestTracingExpirationTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._requestTracingExpirationTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "requestTracingExpirationTime" ,container.Add );
            if (null != this._scmIPSecurityRestriction)
            {
                var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var ___y in this._scmIPSecurityRestriction )
                {
                    AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                }
                container.Add("scmIpSecurityRestrictions",___x);
            }
            AddIf( null != this._scmIPSecurityRestrictionsUseMain ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._scmIPSecurityRestrictionsUseMain) : null, "scmIpSecurityRestrictionsUseMain" ,container.Add );
            AddIf( null != (((object)this._scmType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._scmType.ToString()) : null, "scmType" ,container.Add );
            AddIf( null != (((object)this._tracingOption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._tracingOption.ToString()) : null, "tracingOptions" ,container.Add );
            AddIf( null != this._use32BitWorkerProcess ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._use32BitWorkerProcess) : null, "use32BitWorkerProcess" ,container.Add );
            if (null != this._virtualApplication)
            {
                var ___s = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                foreach( var ___t in this._virtualApplication )
                {
                    AddIf(___t?.ToJson(null, serializationMode) ,___s.Add);
                }
                container.Add("virtualApplications",___s);
            }
            AddIf( null != (((object)this._vnetName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._vnetName.ToString()) : null, "vnetName" ,container.Add );
            AddIf( null != this._webSocketsEnabled ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._webSocketsEnabled) : null, "webSocketsEnabled" ,container.Add );
            AddIf( null != (((object)this._windowsFxVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._windowsFxVersion.ToString()) : null, "windowsFxVersion" ,container.Add );
            AddIf( null != this._xManagedServiceIdentityId ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._xManagedServiceIdentityId) : null, "xManagedServiceIdentityId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}