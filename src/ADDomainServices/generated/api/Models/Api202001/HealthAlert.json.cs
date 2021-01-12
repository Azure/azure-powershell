namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Health Alert Description</summary>
    public partial class HealthAlert
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json ? new HealthAlert(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject into a new instance of <see cref="HealthAlert" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal HealthAlert(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)Id;}
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)Name;}
            {_issue = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("issue"), out var __jsonIssue) ? (string)__jsonIssue : (string)Issue;}
            {_severity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("severity"), out var __jsonSeverity) ? (string)__jsonSeverity : (string)Severity;}
            {_raised = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("raised"), out var __jsonRaised) ? global::System.DateTime.TryParse((string)__jsonRaised, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRaisedValue) ? __jsonRaisedValue : Raised : Raised;}
            {_lastDetected = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("lastDetected"), out var __jsonLastDetected) ? global::System.DateTime.TryParse((string)__jsonLastDetected, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonLastDetectedValue) ? __jsonLastDetectedValue : LastDetected : LastDetected;}
            {_resolutionUri = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("resolutionUri"), out var __jsonResolutionUri) ? (string)__jsonResolutionUri : (string)ResolutionUri;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="HealthAlert" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="HealthAlert" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._issue)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._issue.ToString()) : null, "issue" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._severity)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._severity.ToString()) : null, "severity" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._raised ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._raised?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "raised" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._lastDetected ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._lastDetected?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "lastDetected" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._resolutionUri)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._resolutionUri.ToString()) : null, "resolutionUri" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}