namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>The properties of a server.</summary>
    public partial class ServerProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json ? new ServerProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject into a new instance of <see cref="ServerProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ServerProperties(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_storageProfile = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject>("storageProfile"), out var __jsonStorageProfile) ? Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.StorageProfile.FromJson(__jsonStorageProfile) : StorageProfile;}
            {_administratorLogin = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("administratorLogin"), out var __jsonAdministratorLogin) ? (string)__jsonAdministratorLogin : (string)AdministratorLogin;}
            {_version = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("version"), out var __jsonVersion) ? (string)__jsonVersion : (string)Version;}
            {_sslEnforcement = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("sslEnforcement"), out var __jsonSslEnforcement) ? (string)__jsonSslEnforcement : (string)SslEnforcement;}
            {_minimalTlsVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("minimalTlsVersion"), out var __jsonMinimalTlsVersion) ? (string)__jsonMinimalTlsVersion : (string)MinimalTlsVersion;}
            {_byokEnforcement = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("byokEnforcement"), out var __jsonByokEnforcement) ? (string)__jsonByokEnforcement : (string)ByokEnforcement;}
            {_infrastructureEncryption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("infrastructureEncryption"), out var __jsonInfrastructureEncryption) ? (string)__jsonInfrastructureEncryption : (string)InfrastructureEncryption;}
            {_userVisibleState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("userVisibleState"), out var __jsonUserVisibleState) ? (string)__jsonUserVisibleState : (string)UserVisibleState;}
            {_fullyQualifiedDomainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("fullyQualifiedDomainName"), out var __jsonFullyQualifiedDomainName) ? (string)__jsonFullyQualifiedDomainName : (string)FullyQualifiedDomainName;}
            {_earliestRestoreDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("earliestRestoreDate"), out var __jsonEarliestRestoreDate) ? global::System.DateTime.TryParse((string)__jsonEarliestRestoreDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEarliestRestoreDateValue) ? __jsonEarliestRestoreDateValue : EarliestRestoreDate : EarliestRestoreDate;}
            {_replicationRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("replicationRole"), out var __jsonReplicationRole) ? (string)__jsonReplicationRole : (string)ReplicationRole;}
            {_masterServerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("masterServerId"), out var __jsonMasterServerId) ? (string)__jsonMasterServerId : (string)MasterServerId;}
            {_replicaCapacity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber>("replicaCapacity"), out var __jsonReplicaCapacity) ? (int?)__jsonReplicaCapacity : ReplicaCapacity;}
            {_publicNetworkAccess = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("publicNetworkAccess"), out var __jsonPublicNetworkAccess) ? (string)__jsonPublicNetworkAccess : (string)PublicNetworkAccess;}
            {_privateEndpointConnection = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonArray>("privateEndpointConnections"), out var __jsonPrivateEndpointConnections) ? If( __jsonPrivateEndpointConnections as Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerPrivateEndpointConnection) (Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.ServerPrivateEndpointConnection.FromJson(__u) )) ))() : null : PrivateEndpointConnection;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ServerProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ServerProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._storageProfile ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) this._storageProfile.ToJson(null,serializationMode) : null, "storageProfile" ,container.Add );
            AddIf( null != (((object)this._administratorLogin)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._administratorLogin.ToString()) : null, "administratorLogin" ,container.Add );
            AddIf( null != (((object)this._version)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._version.ToString()) : null, "version" ,container.Add );
            AddIf( null != (((object)this._sslEnforcement)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._sslEnforcement.ToString()) : null, "sslEnforcement" ,container.Add );
            AddIf( null != (((object)this._minimalTlsVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._minimalTlsVersion.ToString()) : null, "minimalTlsVersion" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._byokEnforcement)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._byokEnforcement.ToString()) : null, "byokEnforcement" ,container.Add );
            }
            AddIf( null != (((object)this._infrastructureEncryption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._infrastructureEncryption.ToString()) : null, "infrastructureEncryption" ,container.Add );
            AddIf( null != (((object)this._userVisibleState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._userVisibleState.ToString()) : null, "userVisibleState" ,container.Add );
            AddIf( null != (((object)this._fullyQualifiedDomainName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._fullyQualifiedDomainName.ToString()) : null, "fullyQualifiedDomainName" ,container.Add );
            AddIf( null != this._earliestRestoreDate ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._earliestRestoreDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "earliestRestoreDate" ,container.Add );
            AddIf( null != (((object)this._replicationRole)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._replicationRole.ToString()) : null, "replicationRole" ,container.Add );
            AddIf( null != (((object)this._masterServerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._masterServerId.ToString()) : null, "masterServerId" ,container.Add );
            AddIf( null != this._replicaCapacity ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber((int)this._replicaCapacity) : null, "replicaCapacity" ,container.Add );
            AddIf( null != (((object)this._publicNetworkAccess)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._publicNetworkAccess.ToString()) : null, "publicNetworkAccess" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._privateEndpointConnection)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.XNodeArray();
                    foreach( var __x in this._privateEndpointConnection )
                    {
                        AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                    }
                    container.Add("privateEndpointConnections",__w);
                }
            }
            AfterToJson(ref container);
            return container;
        }
    }
}