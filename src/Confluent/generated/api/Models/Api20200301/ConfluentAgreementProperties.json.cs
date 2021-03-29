namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Terms properties for Marketplace and Confluent.</summary>
    public partial class ConfluentAgreementProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject into a new instance of <see cref="ConfluentAgreementProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ConfluentAgreementProperties(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_publisher = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("publisher"), out var __jsonPublisher) ? (string)__jsonPublisher : (string)Publisher;}
            {_product = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("product"), out var __jsonProduct) ? (string)__jsonProduct : (string)Product;}
            {_plan = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("plan"), out var __jsonPlan) ? (string)__jsonPlan : (string)Plan;}
            {_licenseTextLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("licenseTextLink"), out var __jsonLicenseTextLink) ? (string)__jsonLicenseTextLink : (string)LicenseTextLink;}
            {_privacyPolicyLink = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("privacyPolicyLink"), out var __jsonPrivacyPolicyLink) ? (string)__jsonPrivacyPolicyLink : (string)PrivacyPolicyLink;}
            {_retrieveDatetime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("retrieveDatetime"), out var __jsonRetrieveDatetime) ? global::System.DateTime.TryParse((string)__jsonRetrieveDatetime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRetrieveDatetimeValue) ? __jsonRetrieveDatetimeValue : RetrieveDatetime : RetrieveDatetime;}
            {_signature = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString>("signature"), out var __jsonSignature) ? (string)__jsonSignature : (string)Signature;}
            {_accepted = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonBoolean>("accepted"), out var __jsonAccepted) ? (bool?)__jsonAccepted : Accepted;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IConfluentAgreementProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject json ? new ConfluentAgreementProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="ConfluentAgreementProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ConfluentAgreementProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._publisher)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._publisher.ToString()) : null, "publisher" ,container.Add );
            AddIf( null != (((object)this._product)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._product.ToString()) : null, "product" ,container.Add );
            AddIf( null != (((object)this._plan)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._plan.ToString()) : null, "plan" ,container.Add );
            AddIf( null != (((object)this._licenseTextLink)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._licenseTextLink.ToString()) : null, "licenseTextLink" ,container.Add );
            AddIf( null != (((object)this._privacyPolicyLink)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._privacyPolicyLink.ToString()) : null, "privacyPolicyLink" ,container.Add );
            AddIf( null != this._retrieveDatetime ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._retrieveDatetime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "retrieveDatetime" ,container.Add );
            AddIf( null != (((object)this._signature)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonString(this._signature.ToString()) : null, "signature" ,container.Add );
            AddIf( null != this._accepted ? (Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Json.JsonBoolean((bool)this._accepted) : null, "accepted" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}