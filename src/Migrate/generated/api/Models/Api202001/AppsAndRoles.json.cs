namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>AppsAndRoles in the guest virtual machine.</summary>
    public partial class AppsAndRoles
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="AppsAndRoles" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AppsAndRoles(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_application = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("applications"), out var __jsonApplications) ? If( __jsonApplications as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Application.FromJson(__u) )) ))() : null : Application;}
            {_webApplication = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("webApplications"), out var __jsonWebApplications) ? If( __jsonWebApplications as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.WebApplication.FromJson(__p) )) ))() : null : WebApplication;}
            {_feature = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("features"), out var __jsonFeatures) ? If( __jsonFeatures as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Feature.FromJson(__k) )) ))() : null : Feature;}
            {_sqlServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("sqlServers"), out var __jsonSqlServers) ? If( __jsonSqlServers as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__g, (__f)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SqlServer.FromJson(__f) )) ))() : null : SqlServer;}
            {_sharePointServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("sharePointServers"), out var __jsonSharePointServers) ? If( __jsonSharePointServers as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __b) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__b, (__a)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SharePointServer.FromJson(__a) )) ))() : null : SharePointServer;}
            {_systemCenter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("systemCenters"), out var __jsonSystemCenters) ? If( __jsonSystemCenters as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var ___w) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___w, (___v)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SystemCenter.FromJson(___v) )) ))() : null : SystemCenter;}
            {_bizTalkServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("bizTalkServers"), out var __jsonBizTalkServers) ? If( __jsonBizTalkServers as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var ___r) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___r, (___q)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.BizTalkServer.FromJson(___q) )) ))() : null : BizTalkServer;}
            {_exchangeServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("exchangeServers"), out var __jsonExchangeServers) ? If( __jsonExchangeServers as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var ___m) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___m, (___l)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ExchangeServer.FromJson(___l) )) ))() : null : ExchangeServer;}
            {_otherDatabase = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("otherDatabases"), out var __jsonOtherDatabases) ? If( __jsonOtherDatabases as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var ___h) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(___h, (___g)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.OtherDatabase.FromJson(___g) )) ))() : null : OtherDatabase;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new AppsAndRoles(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AppsAndRoles" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AppsAndRoles" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._application)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var __x in this._application )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("applications",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._webApplication)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var __s in this._webApplication )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("webApplications",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._feature)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var __n in this._feature )
                    {
                        AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                    }
                    container.Add("features",__m);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._sqlServer)
                {
                    var __h = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var __i in this._sqlServer )
                    {
                        AddIf(__i?.ToJson(null, serializationMode) ,__h.Add);
                    }
                    container.Add("sqlServers",__h);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._sharePointServer)
                {
                    var __c = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var __d in this._sharePointServer )
                    {
                        AddIf(__d?.ToJson(null, serializationMode) ,__c.Add);
                    }
                    container.Add("sharePointServers",__c);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._systemCenter)
                {
                    var ___x = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var ___y in this._systemCenter )
                    {
                        AddIf(___y?.ToJson(null, serializationMode) ,___x.Add);
                    }
                    container.Add("systemCenters",___x);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._bizTalkServer)
                {
                    var ___s = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var ___t in this._bizTalkServer )
                    {
                        AddIf(___t?.ToJson(null, serializationMode) ,___s.Add);
                    }
                    container.Add("bizTalkServers",___s);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._exchangeServer)
                {
                    var ___n = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var ___o in this._exchangeServer )
                    {
                        AddIf(___o?.ToJson(null, serializationMode) ,___n.Add);
                    }
                    container.Add("exchangeServers",___n);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._otherDatabase)
                {
                    var ___i = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                    foreach( var ___j in this._otherDatabase )
                    {
                        AddIf(___j?.ToJson(null, serializationMode) ,___i.Add);
                    }
                    container.Add("otherDatabases",___i);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}