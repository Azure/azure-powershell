namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Store the fabric details specific to the VMware fabric.</summary>
    public partial class VMwareDetails
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new VMwareDetails(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="VMwareDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="VMwareDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
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
            __fabricSpecificDetails?.ToJson(container, serializationMode);
            AddIf( null != this._agentVersionDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._agentVersionDetail.ToJson(null,serializationMode) : null, "agentVersionDetails" ,container.Add );
            if (null != this._processServer)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._processServer )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("processServers",__w);
            }
            if (null != this._masterTargetServer)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __s in this._masterTargetServer )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("masterTargetServers",__r);
            }
            if (null != this._runAsAccount)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __n in this._runAsAccount )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("runAsAccounts",__m);
            }
            AddIf( null != (((object)this._replicationPairCount)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._replicationPairCount.ToString()) : null, "replicationPairCount" ,container.Add );
            AddIf( null != (((object)this._processServerCount)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._processServerCount.ToString()) : null, "processServerCount" ,container.Add );
            AddIf( null != (((object)this._agentCount)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._agentCount.ToString()) : null, "agentCount" ,container.Add );
            AddIf( null != (((object)this._protectedServer)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._protectedServer.ToString()) : null, "protectedServers" ,container.Add );
            AddIf( null != (((object)this._systemLoad)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._systemLoad.ToString()) : null, "systemLoad" ,container.Add );
            AddIf( null != (((object)this._systemLoadStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._systemLoadStatus.ToString()) : null, "systemLoadStatus" ,container.Add );
            AddIf( null != (((object)this._cpuLoad)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._cpuLoad.ToString()) : null, "cpuLoad" ,container.Add );
            AddIf( null != (((object)this._cpuLoadStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._cpuLoadStatus.ToString()) : null, "cpuLoadStatus" ,container.Add );
            AddIf( null != this._totalMemoryInByte ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((long)this._totalMemoryInByte) : null, "totalMemoryInBytes" ,container.Add );
            AddIf( null != this._availableMemoryInByte ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((long)this._availableMemoryInByte) : null, "availableMemoryInBytes" ,container.Add );
            AddIf( null != (((object)this._memoryUsageStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._memoryUsageStatus.ToString()) : null, "memoryUsageStatus" ,container.Add );
            AddIf( null != this._totalSpaceInByte ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((long)this._totalSpaceInByte) : null, "totalSpaceInBytes" ,container.Add );
            AddIf( null != this._availableSpaceInByte ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((long)this._availableSpaceInByte) : null, "availableSpaceInBytes" ,container.Add );
            AddIf( null != (((object)this._spaceUsageStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._spaceUsageStatus.ToString()) : null, "spaceUsageStatus" ,container.Add );
            AddIf( null != (((object)this._webLoad)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._webLoad.ToString()) : null, "webLoad" ,container.Add );
            AddIf( null != (((object)this._webLoadStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._webLoadStatus.ToString()) : null, "webLoadStatus" ,container.Add );
            AddIf( null != (((object)this._databaseServerLoad)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._databaseServerLoad.ToString()) : null, "databaseServerLoad" ,container.Add );
            AddIf( null != (((object)this._databaseServerLoadStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._databaseServerLoadStatus.ToString()) : null, "databaseServerLoadStatus" ,container.Add );
            AddIf( null != (((object)this._csServiceStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._csServiceStatus.ToString()) : null, "csServiceStatus" ,container.Add );
            AddIf( null != (((object)this._iPAddress)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._iPAddress.ToString()) : null, "ipAddress" ,container.Add );
            AddIf( null != (((object)this._agentVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._agentVersion.ToString()) : null, "agentVersion" ,container.Add );
            AddIf( null != (((object)this._hostName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._hostName.ToString()) : null, "hostName" ,container.Add );
            AddIf( null != this._lastHeartbeat ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastHeartbeat?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastHeartbeat" ,container.Add );
            AddIf( null != (((object)this._versionStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._versionStatus.ToString()) : null, "versionStatus" ,container.Add );
            AddIf( null != this._sslCertExpiryDate ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._sslCertExpiryDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "sslCertExpiryDate" ,container.Add );
            AddIf( null != this._sslCertExpiryRemainingDay ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._sslCertExpiryRemainingDay) : null, "sslCertExpiryRemainingDays" ,container.Add );
            AddIf( null != (((object)this._psTemplateVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._psTemplateVersion.ToString()) : null, "psTemplateVersion" ,container.Add );
            AddIf( null != this._agentExpiryDate ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._agentExpiryDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "agentExpiryDate" ,container.Add );
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="VMwareDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal VMwareDetails(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __fabricSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetails(json);
            {_agentVersionDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("agentVersionDetails"), out var __jsonAgentVersionDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails.FromJson(__jsonAgentVersionDetails) : AgentVersionDetail;}
            {_processServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("processServers"), out var __jsonProcessServers) ? If( __jsonProcessServers as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProcessServer) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProcessServer.FromJson(__u) )) ))() : null : ProcessServer;}
            {_masterTargetServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("masterTargetServers"), out var __jsonMasterTargetServers) ? If( __jsonMasterTargetServers as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IMasterTargetServer) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.MasterTargetServer.FromJson(__p) )) ))() : null : MasterTargetServer;}
            {_runAsAccount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("runAsAccounts"), out var __jsonRunAsAccounts) ? If( __jsonRunAsAccounts as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRunAsAccount) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RunAsAccount.FromJson(__k) )) ))() : null : RunAsAccount;}
            {_replicationPairCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("replicationPairCount"), out var __jsonReplicationPairCount) ? (string)__jsonReplicationPairCount : (string)ReplicationPairCount;}
            {_processServerCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("processServerCount"), out var __jsonProcessServerCount) ? (string)__jsonProcessServerCount : (string)ProcessServerCount;}
            {_agentCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("agentCount"), out var __jsonAgentCount) ? (string)__jsonAgentCount : (string)AgentCount;}
            {_protectedServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("protectedServers"), out var __jsonProtectedServers) ? (string)__jsonProtectedServers : (string)ProtectedServer;}
            {_systemLoad = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("systemLoad"), out var __jsonSystemLoad) ? (string)__jsonSystemLoad : (string)SystemLoad;}
            {_systemLoadStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("systemLoadStatus"), out var __jsonSystemLoadStatus) ? (string)__jsonSystemLoadStatus : (string)SystemLoadStatus;}
            {_cpuLoad = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("cpuLoad"), out var __jsonCpuLoad) ? (string)__jsonCpuLoad : (string)CpuLoad;}
            {_cpuLoadStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("cpuLoadStatus"), out var __jsonCpuLoadStatus) ? (string)__jsonCpuLoadStatus : (string)CpuLoadStatus;}
            {_totalMemoryInByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("totalMemoryInBytes"), out var __jsonTotalMemoryInBytes) ? (long?)__jsonTotalMemoryInBytes : TotalMemoryInByte;}
            {_availableMemoryInByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("availableMemoryInBytes"), out var __jsonAvailableMemoryInBytes) ? (long?)__jsonAvailableMemoryInBytes : AvailableMemoryInByte;}
            {_memoryUsageStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("memoryUsageStatus"), out var __jsonMemoryUsageStatus) ? (string)__jsonMemoryUsageStatus : (string)MemoryUsageStatus;}
            {_totalSpaceInByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("totalSpaceInBytes"), out var __jsonTotalSpaceInBytes) ? (long?)__jsonTotalSpaceInBytes : TotalSpaceInByte;}
            {_availableSpaceInByte = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("availableSpaceInBytes"), out var __jsonAvailableSpaceInBytes) ? (long?)__jsonAvailableSpaceInBytes : AvailableSpaceInByte;}
            {_spaceUsageStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("spaceUsageStatus"), out var __jsonSpaceUsageStatus) ? (string)__jsonSpaceUsageStatus : (string)SpaceUsageStatus;}
            {_webLoad = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("webLoad"), out var __jsonWebLoad) ? (string)__jsonWebLoad : (string)WebLoad;}
            {_webLoadStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("webLoadStatus"), out var __jsonWebLoadStatus) ? (string)__jsonWebLoadStatus : (string)WebLoadStatus;}
            {_databaseServerLoad = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("databaseServerLoad"), out var __jsonDatabaseServerLoad) ? (string)__jsonDatabaseServerLoad : (string)DatabaseServerLoad;}
            {_databaseServerLoadStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("databaseServerLoadStatus"), out var __jsonDatabaseServerLoadStatus) ? (string)__jsonDatabaseServerLoadStatus : (string)DatabaseServerLoadStatus;}
            {_csServiceStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("csServiceStatus"), out var __jsonCsServiceStatus) ? (string)__jsonCsServiceStatus : (string)CsServiceStatus;}
            {_iPAddress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("ipAddress"), out var __jsonIPAddress) ? (string)__jsonIPAddress : (string)IPAddress;}
            {_agentVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("agentVersion"), out var __jsonAgentVersion) ? (string)__jsonAgentVersion : (string)AgentVersion;}
            {_hostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("hostName"), out var __jsonHostName) ? (string)__jsonHostName : (string)HostName;}
            {_lastHeartbeat = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastHeartbeat"), out var __jsonLastHeartbeat) ? global::System.DateTime.TryParse((string)__jsonLastHeartbeat, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastHeartbeatValue) ? __jsonLastHeartbeatValue : LastHeartbeat : LastHeartbeat;}
            {_versionStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("versionStatus"), out var __jsonVersionStatus) ? (string)__jsonVersionStatus : (string)VersionStatus;}
            {_sslCertExpiryDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("sslCertExpiryDate"), out var __jsonSslCertExpiryDate) ? global::System.DateTime.TryParse((string)__jsonSslCertExpiryDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonSslCertExpiryDateValue) ? __jsonSslCertExpiryDateValue : SslCertExpiryDate : SslCertExpiryDate;}
            {_sslCertExpiryRemainingDay = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("sslCertExpiryRemainingDays"), out var __jsonSslCertExpiryRemainingDays) ? (int?)__jsonSslCertExpiryRemainingDays : SslCertExpiryRemainingDay;}
            {_psTemplateVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("psTemplateVersion"), out var __jsonPsTemplateVersion) ? (string)__jsonPsTemplateVersion : (string)PsTemplateVersion;}
            {_agentExpiryDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("agentExpiryDate"), out var __jsonAgentExpiryDate) ? global::System.DateTime.TryParse((string)__jsonAgentExpiryDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonAgentExpiryDateValue) ? __jsonAgentExpiryDateValue : AgentExpiryDate : AgentExpiryDate;}
            AfterFromJson(json);
        }
    }
}