namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication protected item custom data details.</summary>
    public partial class ReplicationProtectedItemProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new ReplicationProtectedItemProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="ReplicationProtectedItemProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ReplicationProtectedItemProperties(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_currentScenario = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("currentScenario"), out var __jsonCurrentScenario) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentScenarioDetails.FromJson(__jsonCurrentScenario) : CurrentScenario;}
            {_providerSpecificDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("providerSpecificDetails"), out var __jsonProviderSpecificDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettings.FromJson(__jsonProviderSpecificDetails) : ProviderSpecificDetail;}
            {_friendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("friendlyName"), out var __jsonFriendlyName) ? (string)__jsonFriendlyName : (string)FriendlyName;}
            {_protectedItemType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("protectedItemType"), out var __jsonProtectedItemType) ? (string)__jsonProtectedItemType : (string)ProtectedItemType;}
            {_protectableItemId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("protectableItemId"), out var __jsonProtectableItemId) ? (string)__jsonProtectableItemId : (string)ProtectableItemId;}
            {_recoveryServicesProviderId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryServicesProviderId"), out var __jsonRecoveryServicesProviderId) ? (string)__jsonRecoveryServicesProviderId : (string)RecoveryServicesProviderId;}
            {_primaryFabricFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("primaryFabricFriendlyName"), out var __jsonPrimaryFabricFriendlyName) ? (string)__jsonPrimaryFabricFriendlyName : (string)PrimaryFabricFriendlyName;}
            {_primaryFabricProvider = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("primaryFabricProvider"), out var __jsonPrimaryFabricProvider) ? (string)__jsonPrimaryFabricProvider : (string)PrimaryFabricProvider;}
            {_recoveryFabricFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryFabricFriendlyName"), out var __jsonRecoveryFabricFriendlyName) ? (string)__jsonRecoveryFabricFriendlyName : (string)RecoveryFabricFriendlyName;}
            {_recoveryFabricId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryFabricId"), out var __jsonRecoveryFabricId) ? (string)__jsonRecoveryFabricId : (string)RecoveryFabricId;}
            {_primaryProtectionContainerFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("primaryProtectionContainerFriendlyName"), out var __jsonPrimaryProtectionContainerFriendlyName) ? (string)__jsonPrimaryProtectionContainerFriendlyName : (string)PrimaryProtectionContainerFriendlyName;}
            {_recoveryProtectionContainerFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryProtectionContainerFriendlyName"), out var __jsonRecoveryProtectionContainerFriendlyName) ? (string)__jsonRecoveryProtectionContainerFriendlyName : (string)RecoveryProtectionContainerFriendlyName;}
            {_protectionState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("protectionState"), out var __jsonProtectionState) ? (string)__jsonProtectionState : (string)ProtectionState;}
            {_protectionStateDescription = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("protectionStateDescription"), out var __jsonProtectionStateDescription) ? (string)__jsonProtectionStateDescription : (string)ProtectionStateDescription;}
            {_activeLocation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("activeLocation"), out var __jsonActiveLocation) ? (string)__jsonActiveLocation : (string)ActiveLocation;}
            {_testFailoverState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("testFailoverState"), out var __jsonTestFailoverState) ? (string)__jsonTestFailoverState : (string)TestFailoverState;}
            {_testFailoverStateDescription = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("testFailoverStateDescription"), out var __jsonTestFailoverStateDescription) ? (string)__jsonTestFailoverStateDescription : (string)TestFailoverStateDescription;}
            {_allowedOperation = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("allowedOperations"), out var __jsonAllowedOperations) ? If( __jsonAllowedOperations as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AllowedOperation;}
            {_replicationHealth = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("replicationHealth"), out var __jsonReplicationHealth) ? (string)__jsonReplicationHealth : (string)ReplicationHealth;}
            {_failoverHealth = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("failoverHealth"), out var __jsonFailoverHealth) ? (string)__jsonFailoverHealth : (string)FailoverHealth;}
            {_healthError = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("healthErrors"), out var __jsonHealthErrors) ? If( __jsonHealthErrors as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthError.FromJson(__p) )) ))() : null : HealthError;}
            {_policyId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("policyId"), out var __jsonPolicyId) ? (string)__jsonPolicyId : (string)PolicyId;}
            {_policyFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("policyFriendlyName"), out var __jsonPolicyFriendlyName) ? (string)__jsonPolicyFriendlyName : (string)PolicyFriendlyName;}
            {_lastSuccessfulFailoverTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastSuccessfulFailoverTime"), out var __jsonLastSuccessfulFailoverTime) ? global::System.DateTime.TryParse((string)__jsonLastSuccessfulFailoverTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastSuccessfulFailoverTimeValue) ? __jsonLastSuccessfulFailoverTimeValue : LastSuccessfulFailoverTime : LastSuccessfulFailoverTime;}
            {_lastSuccessfulTestFailoverTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastSuccessfulTestFailoverTime"), out var __jsonLastSuccessfulTestFailoverTime) ? global::System.DateTime.TryParse((string)__jsonLastSuccessfulTestFailoverTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastSuccessfulTestFailoverTimeValue) ? __jsonLastSuccessfulTestFailoverTimeValue : LastSuccessfulTestFailoverTime : LastSuccessfulTestFailoverTime;}
            {_failoverRecoveryPointId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("failoverRecoveryPointId"), out var __jsonFailoverRecoveryPointId) ? (string)__jsonFailoverRecoveryPointId : (string)FailoverRecoveryPointId;}
            {_recoveryContainerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryContainerId"), out var __jsonRecoveryContainerId) ? (string)__jsonRecoveryContainerId : (string)RecoveryContainerId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ReplicationProtectedItemProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ReplicationProtectedItemProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._currentScenario ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._currentScenario.ToJson(null,serializationMode) : null, "currentScenario" ,container.Add );
            AddIf( null != this._providerSpecificDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._providerSpecificDetail.ToJson(null,serializationMode) : null, "providerSpecificDetails" ,container.Add );
            AddIf( null != (((object)this._friendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._friendlyName.ToString()) : null, "friendlyName" ,container.Add );
            AddIf( null != (((object)this._protectedItemType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._protectedItemType.ToString()) : null, "protectedItemType" ,container.Add );
            AddIf( null != (((object)this._protectableItemId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._protectableItemId.ToString()) : null, "protectableItemId" ,container.Add );
            AddIf( null != (((object)this._recoveryServicesProviderId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryServicesProviderId.ToString()) : null, "recoveryServicesProviderId" ,container.Add );
            AddIf( null != (((object)this._primaryFabricFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._primaryFabricFriendlyName.ToString()) : null, "primaryFabricFriendlyName" ,container.Add );
            AddIf( null != (((object)this._primaryFabricProvider)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._primaryFabricProvider.ToString()) : null, "primaryFabricProvider" ,container.Add );
            AddIf( null != (((object)this._recoveryFabricFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryFabricFriendlyName.ToString()) : null, "recoveryFabricFriendlyName" ,container.Add );
            AddIf( null != (((object)this._recoveryFabricId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryFabricId.ToString()) : null, "recoveryFabricId" ,container.Add );
            AddIf( null != (((object)this._primaryProtectionContainerFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._primaryProtectionContainerFriendlyName.ToString()) : null, "primaryProtectionContainerFriendlyName" ,container.Add );
            AddIf( null != (((object)this._recoveryProtectionContainerFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryProtectionContainerFriendlyName.ToString()) : null, "recoveryProtectionContainerFriendlyName" ,container.Add );
            AddIf( null != (((object)this._protectionState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._protectionState.ToString()) : null, "protectionState" ,container.Add );
            AddIf( null != (((object)this._protectionStateDescription)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._protectionStateDescription.ToString()) : null, "protectionStateDescription" ,container.Add );
            AddIf( null != (((object)this._activeLocation)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._activeLocation.ToString()) : null, "activeLocation" ,container.Add );
            AddIf( null != (((object)this._testFailoverState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._testFailoverState.ToString()) : null, "testFailoverState" ,container.Add );
            AddIf( null != (((object)this._testFailoverStateDescription)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._testFailoverStateDescription.ToString()) : null, "testFailoverStateDescription" ,container.Add );
            if (null != this._allowedOperation)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._allowedOperation )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("allowedOperations",__w);
            }
            AddIf( null != (((object)this._replicationHealth)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._replicationHealth.ToString()) : null, "replicationHealth" ,container.Add );
            AddIf( null != (((object)this._failoverHealth)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._failoverHealth.ToString()) : null, "failoverHealth" ,container.Add );
            if (null != this._healthError)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __s in this._healthError )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("healthErrors",__r);
            }
            AddIf( null != (((object)this._policyId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._policyId.ToString()) : null, "policyId" ,container.Add );
            AddIf( null != (((object)this._policyFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._policyFriendlyName.ToString()) : null, "policyFriendlyName" ,container.Add );
            AddIf( null != this._lastSuccessfulFailoverTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastSuccessfulFailoverTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastSuccessfulFailoverTime" ,container.Add );
            AddIf( null != this._lastSuccessfulTestFailoverTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastSuccessfulTestFailoverTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastSuccessfulTestFailoverTime" ,container.Add );
            AddIf( null != (((object)this._failoverRecoveryPointId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._failoverRecoveryPointId.ToString()) : null, "failoverRecoveryPointId" ,container.Add );
            AddIf( null != (((object)this._recoveryContainerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryContainerId.ToString()) : null, "recoveryContainerId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}