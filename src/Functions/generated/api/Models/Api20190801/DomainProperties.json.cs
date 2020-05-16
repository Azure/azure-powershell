namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Domain resource specific properties</summary>
    public partial class DomainProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="DomainProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DomainProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_consent = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("consent"), out var __jsonConsent) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DomainPurchaseConsent.FromJson(__jsonConsent) : Consent;}
            {_contactAdmin = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("contactAdmin"), out var __jsonContactAdmin) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact.FromJson(__jsonContactAdmin) : ContactAdmin;}
            {_contactBilling = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("contactBilling"), out var __jsonContactBilling) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact.FromJson(__jsonContactBilling) : ContactBilling;}
            {_contactRegistrant = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("contactRegistrant"), out var __jsonContactRegistrant) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact.FromJson(__jsonContactRegistrant) : ContactRegistrant;}
            {_contactTech = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("contactTech"), out var __jsonContactTech) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Contact.FromJson(__jsonContactTech) : ContactTech;}
            {_authCode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("authCode"), out var __jsonAuthCode) ? (string)__jsonAuthCode : (string)AuthCode;}
            {_autoRenew = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("autoRenew"), out var __jsonAutoRenew) ? (bool?)__jsonAutoRenew : AutoRenew;}
            {_createdTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("createdTime"), out var __jsonCreatedTime) ? global::System.DateTime.TryParse((string)__jsonCreatedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreatedTimeValue) ? __jsonCreatedTimeValue : CreatedTime : CreatedTime;}
            {_dnsType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("dnsType"), out var __jsonDnsType) ? (string)__jsonDnsType : (string)DnsType;}
            {_dnsZoneId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("dnsZoneId"), out var __jsonDnsZoneId) ? (string)__jsonDnsZoneId : (string)DnsZoneId;}
            {_domainNotRenewableReason = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("domainNotRenewableReasons"), out var __jsonDomainNotRenewableReasons) ? If( __jsonDomainNotRenewableReasons as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : DomainNotRenewableReason;}
            {_expirationTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("expirationTime"), out var __jsonExpirationTime) ? global::System.DateTime.TryParse((string)__jsonExpirationTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonExpirationTimeValue) ? __jsonExpirationTimeValue : ExpirationTime : ExpirationTime;}
            {_lastRenewedTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("lastRenewedTime"), out var __jsonLastRenewedTime) ? global::System.DateTime.TryParse((string)__jsonLastRenewedTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastRenewedTimeValue) ? __jsonLastRenewedTimeValue : LastRenewedTime : LastRenewedTime;}
            {_managedHostName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("managedHostNames"), out var __jsonManagedHostNames) ? If( __jsonManagedHostNames as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostName) (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostName.FromJson(__p) )) ))() : null : ManagedHostName;}
            {_nameServer = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("nameServers"), out var __jsonNameServers) ? If( __jsonNameServers as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : NameServer;}
            {_privacy = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("privacy"), out var __jsonPrivacy) ? (bool?)__jsonPrivacy : Privacy;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_readyForDnsRecordManagement = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("readyForDnsRecordManagement"), out var __jsonReadyForDnsRecordManagement) ? (bool?)__jsonReadyForDnsRecordManagement : ReadyForDnsRecordManagement;}
            {_registrationStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("registrationStatus"), out var __jsonRegistrationStatus) ? (string)__jsonRegistrationStatus : (string)RegistrationStatus;}
            {_targetDnsType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("targetDnsType"), out var __jsonTargetDnsType) ? (string)__jsonTargetDnsType : (string)TargetDnsType;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDomainProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new DomainProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DomainProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DomainProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._consent ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._consent.ToJson(null,serializationMode) : null, "consent" ,container.Add );
            AddIf( null != this._contactAdmin ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._contactAdmin.ToJson(null,serializationMode) : null, "contactAdmin" ,container.Add );
            AddIf( null != this._contactBilling ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._contactBilling.ToJson(null,serializationMode) : null, "contactBilling" ,container.Add );
            AddIf( null != this._contactRegistrant ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._contactRegistrant.ToJson(null,serializationMode) : null, "contactRegistrant" ,container.Add );
            AddIf( null != this._contactTech ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._contactTech.ToJson(null,serializationMode) : null, "contactTech" ,container.Add );
            AddIf( null != (((object)this._authCode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._authCode.ToString()) : null, "authCode" ,container.Add );
            AddIf( null != this._autoRenew ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._autoRenew) : null, "autoRenew" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._createdTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._createdTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "createdTime" ,container.Add );
            }
            AddIf( null != (((object)this._dnsType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._dnsType.ToString()) : null, "dnsType" ,container.Add );
            AddIf( null != (((object)this._dnsZoneId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._dnsZoneId.ToString()) : null, "dnsZoneId" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._domainNotRenewableReason)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __x in this._domainNotRenewableReason )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("domainNotRenewableReasons",__w);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._expirationTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._expirationTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "expirationTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastRenewedTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._lastRenewedTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastRenewedTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._managedHostName)
                {
                    var __r = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __s in this._managedHostName )
                    {
                        AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                    }
                    container.Add("managedHostNames",__r);
                }
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._nameServer)
                {
                    var __m = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __n in this._nameServer )
                    {
                        AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                    }
                    container.Add("nameServers",__m);
                }
            }
            AddIf( null != this._privacy ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._privacy) : null, "privacy" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._readyForDnsRecordManagement ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._readyForDnsRecordManagement) : null, "readyForDnsRecordManagement" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._registrationStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._registrationStatus.ToString()) : null, "registrationStatus" ,container.Add );
            }
            AddIf( null != (((object)this._targetDnsType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._targetDnsType.ToString()) : null, "targetDnsType" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}