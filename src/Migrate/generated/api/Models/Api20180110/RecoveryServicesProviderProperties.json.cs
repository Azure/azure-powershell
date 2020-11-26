namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Recovery services provider properties.</summary>
    public partial class RecoveryServicesProviderProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new RecoveryServicesProviderProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="RecoveryServicesProviderProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecoveryServicesProviderProperties(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_authenticationIdentityDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("authenticationIdentityDetails"), out var __jsonAuthenticationIdentityDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderDetails.FromJson(__jsonAuthenticationIdentityDetails) : AuthenticationIdentityDetail;}
            {_resourceAccessIdentityDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("resourceAccessIdentityDetails"), out var __jsonResourceAccessIdentityDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderDetails.FromJson(__jsonResourceAccessIdentityDetails) : ResourceAccessIdentityDetail;}
            {_providerVersionDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject>("providerVersionDetails"), out var __jsonProviderVersionDetails) ? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetails.FromJson(__jsonProviderVersionDetails) : ProviderVersionDetail;}
            {_fabricType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("fabricType"), out var __jsonFabricType) ? (string)__jsonFabricType : (string)FabricType;}
            {_friendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("friendlyName"), out var __jsonFriendlyName) ? (string)__jsonFriendlyName : (string)FriendlyName;}
            {_providerVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("providerVersion"), out var __jsonProviderVersion) ? (string)__jsonProviderVersion : (string)ProviderVersion;}
            {_serverVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("serverVersion"), out var __jsonServerVersion) ? (string)__jsonServerVersion : (string)ServerVersion;}
            {_providerVersionState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("providerVersionState"), out var __jsonProviderVersionState) ? (string)__jsonProviderVersionState : (string)ProviderVersionState;}
            {_providerVersionExpiryDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("providerVersionExpiryDate"), out var __jsonProviderVersionExpiryDate) ? global::System.DateTime.TryParse((string)__jsonProviderVersionExpiryDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonProviderVersionExpiryDateValue) ? __jsonProviderVersionExpiryDateValue : ProviderVersionExpiryDate : ProviderVersionExpiryDate;}
            {_fabricFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("fabricFriendlyName"), out var __jsonFabricFriendlyName) ? (string)__jsonFabricFriendlyName : (string)FabricFriendlyName;}
            {_lastHeartBeat = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("lastHeartBeat"), out var __jsonLastHeartBeat) ? global::System.DateTime.TryParse((string)__jsonLastHeartBeat, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastHeartBeatValue) ? __jsonLastHeartBeatValue : LastHeartBeat : LastHeartBeat;}
            {_connectionStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("connectionStatus"), out var __jsonConnectionStatus) ? (string)__jsonConnectionStatus : (string)ConnectionStatus;}
            {_protectedItemCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber>("protectedItemCount"), out var __jsonProtectedItemCount) ? (int?)__jsonProtectedItemCount : ProtectedItemCount;}
            {_allowedScenario = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("allowedScenarios"), out var __jsonAllowedScenarios) ? If( __jsonAllowedScenarios as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AllowedScenario;}
            {_healthErrorDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray>("healthErrorDetails"), out var __jsonHealthErrorDetails) ? If( __jsonHealthErrorDetails as Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError) (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthError.FromJson(__p) )) ))() : null : HealthErrorDetail;}
            {_draIdentifier = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("draIdentifier"), out var __jsonDraIdentifier) ? (string)__jsonDraIdentifier : (string)DraIdentifier;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecoveryServicesProviderProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecoveryServicesProviderProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._authenticationIdentityDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._authenticationIdentityDetail.ToJson(null,serializationMode) : null, "authenticationIdentityDetails" ,container.Add );
            AddIf( null != this._resourceAccessIdentityDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._resourceAccessIdentityDetail.ToJson(null,serializationMode) : null, "resourceAccessIdentityDetails" ,container.Add );
            AddIf( null != this._providerVersionDetail ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) this._providerVersionDetail.ToJson(null,serializationMode) : null, "providerVersionDetails" ,container.Add );
            AddIf( null != (((object)this._fabricType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._fabricType.ToString()) : null, "fabricType" ,container.Add );
            AddIf( null != (((object)this._friendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._friendlyName.ToString()) : null, "friendlyName" ,container.Add );
            AddIf( null != (((object)this._providerVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._providerVersion.ToString()) : null, "providerVersion" ,container.Add );
            AddIf( null != (((object)this._serverVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._serverVersion.ToString()) : null, "serverVersion" ,container.Add );
            AddIf( null != (((object)this._providerVersionState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._providerVersionState.ToString()) : null, "providerVersionState" ,container.Add );
            AddIf( null != this._providerVersionExpiryDate ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._providerVersionExpiryDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "providerVersionExpiryDate" ,container.Add );
            AddIf( null != (((object)this._fabricFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._fabricFriendlyName.ToString()) : null, "fabricFriendlyName" ,container.Add );
            AddIf( null != this._lastHeartBeat ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._lastHeartBeat?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastHeartBeat" ,container.Add );
            AddIf( null != (((object)this._connectionStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._connectionStatus.ToString()) : null, "connectionStatus" ,container.Add );
            AddIf( null != this._protectedItemCount ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNumber((int)this._protectedItemCount) : null, "protectedItemCount" ,container.Add );
            if (null != this._allowedScenario)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __x in this._allowedScenario )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("allowedScenarios",__w);
            }
            if (null != this._healthErrorDetail)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.XNodeArray();
                foreach( var __s in this._healthErrorDetail )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("healthErrorDetails",__r);
            }
            AddIf( null != (((object)this._draIdentifier)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._draIdentifier.ToString()) : null, "draIdentifier" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}