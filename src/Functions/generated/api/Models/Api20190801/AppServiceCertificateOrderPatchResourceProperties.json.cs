namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>AppServiceCertificateOrderPatchResource resource specific properties</summary>
    public partial class AppServiceCertificateOrderPatchResourceProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject into a new instance of <see cref="AppServiceCertificateOrderPatchResourceProperties"
        /// />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AppServiceCertificateOrderPatchResourceProperties(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_intermediate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("intermediate"), out var __jsonIntermediate) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails.FromJson(__jsonIntermediate) : Intermediate;}
            {_root = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("root"), out var __jsonRoot) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails.FromJson(__jsonRoot) : Root;}
            {_signedCertificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("signedCertificate"), out var __jsonSignedCertificate) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails.FromJson(__jsonSignedCertificate) : SignedCertificate;}
            {_appServiceCertificateNotRenewableReason = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray>("appServiceCertificateNotRenewableReasons"), out var __jsonAppServiceCertificateNotRenewableReasons) ? If( __jsonAppServiceCertificateNotRenewableReasons as Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<string[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : AppServiceCertificateNotRenewableReason;}
            {_autoRenew = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("autoRenew"), out var __jsonAutoRenew) ? (bool?)__jsonAutoRenew : AutoRenew;}
            {_certificate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject>("certificates"), out var __jsonCertificates) ? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificateOrderPatchResourcePropertiesCertificates.FromJson(__jsonCertificates) : Certificate;}
            {_csr = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("csr"), out var __jsonCsr) ? (string)__jsonCsr : (string)Csr;}
            {_distinguishedName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("distinguishedName"), out var __jsonDistinguishedName) ? (string)__jsonDistinguishedName : (string)DistinguishedName;}
            {_domainVerificationToken = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("domainVerificationToken"), out var __jsonDomainVerificationToken) ? (string)__jsonDomainVerificationToken : (string)DomainVerificationToken;}
            {_expirationTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("expirationTime"), out var __jsonExpirationTime) ? global::System.DateTime.TryParse((string)__jsonExpirationTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonExpirationTimeValue) ? __jsonExpirationTimeValue : ExpirationTime : ExpirationTime;}
            {_isPrivateKeyExternal = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean>("isPrivateKeyExternal"), out var __jsonIsPrivateKeyExternal) ? (bool?)__jsonIsPrivateKeyExternal : IsPrivateKeyExternal;}
            {_keySize = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("keySize"), out var __jsonKeySize) ? (int?)__jsonKeySize : KeySize;}
            {_lastCertificateIssuanceTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("lastCertificateIssuanceTime"), out var __jsonLastCertificateIssuanceTime) ? global::System.DateTime.TryParse((string)__jsonLastCertificateIssuanceTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastCertificateIssuanceTimeValue) ? __jsonLastCertificateIssuanceTimeValue : LastCertificateIssuanceTime : LastCertificateIssuanceTime;}
            {_nextAutoRenewalTimeStamp = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("nextAutoRenewalTimeStamp"), out var __jsonNextAutoRenewalTimeStamp) ? global::System.DateTime.TryParse((string)__jsonNextAutoRenewalTimeStamp, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonNextAutoRenewalTimeStampValue) ? __jsonNextAutoRenewalTimeStampValue : NextAutoRenewalTimeStamp : NextAutoRenewalTimeStamp;}
            {_productType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("productType"), out var __jsonProductType) ? (string)__jsonProductType : (string)ProductType;}
            {_provisioningState = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("provisioningState"), out var __jsonProvisioningState) ? (string)__jsonProvisioningState : (string)ProvisioningState;}
            {_serialNumber = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("serialNumber"), out var __jsonSerialNumber) ? (string)__jsonSerialNumber : (string)SerialNumber;}
            {_status = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString>("status"), out var __jsonStatus) ? (string)__jsonStatus : (string)Status;}
            {_validityInYear = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber>("validityInYears"), out var __jsonValidityInYears) ? (int?)__jsonValidityInYears : ValidityInYear;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject json ? new AppServiceCertificateOrderPatchResourceProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AppServiceCertificateOrderPatchResourceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AppServiceCertificateOrderPatchResourceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode"
        /// />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._intermediate ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._intermediate.ToJson(null,serializationMode) : null, "intermediate" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._root ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._root.ToJson(null,serializationMode) : null, "root" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._signedCertificate ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._signedCertificate.ToJson(null,serializationMode) : null, "signedCertificate" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                if (null != this._appServiceCertificateNotRenewableReason)
                {
                    var __w = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.XNodeArray();
                    foreach( var __x in this._appServiceCertificateNotRenewableReason )
                    {
                        AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                    }
                    container.Add("appServiceCertificateNotRenewableReasons",__w);
                }
            }
            AddIf( null != this._autoRenew ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._autoRenew) : null, "autoRenew" ,container.Add );
            AddIf( null != this._certificate ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) this._certificate.ToJson(null,serializationMode) : null, "certificates" ,container.Add );
            AddIf( null != (((object)this._csr)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._csr.ToString()) : null, "csr" ,container.Add );
            AddIf( null != (((object)this._distinguishedName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._distinguishedName.ToString()) : null, "distinguishedName" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._domainVerificationToken)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._domainVerificationToken.ToString()) : null, "domainVerificationToken" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._expirationTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._expirationTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "expirationTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._isPrivateKeyExternal ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonBoolean((bool)this._isPrivateKeyExternal) : null, "isPrivateKeyExternal" ,container.Add );
            }
            AddIf( null != this._keySize ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._keySize) : null, "keySize" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastCertificateIssuanceTime ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._lastCertificateIssuanceTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastCertificateIssuanceTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._nextAutoRenewalTimeStamp ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._nextAutoRenewalTimeStamp?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "nextAutoRenewalTimeStamp" ,container.Add );
            }
            AddIf( null != (((object)this._productType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._productType.ToString()) : null, "productType" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._provisioningState)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._provisioningState.ToString()) : null, "provisioningState" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._serialNumber)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._serialNumber.ToString()) : null, "serialNumber" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._status)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonString(this._status.ToString()) : null, "status" ,container.Add );
            }
            AddIf( null != this._validityInYear ? (Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNumber((int)this._validityInYear) : null, "validityInYears" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}