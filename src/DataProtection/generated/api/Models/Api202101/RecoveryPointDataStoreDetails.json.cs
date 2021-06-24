namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>RecoveryPoint datastore details</summary>
    public partial class RecoveryPointDataStoreDetails
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new RecoveryPointDataStoreDetails(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="RecoveryPointDataStoreDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal RecoveryPointDataStoreDetails(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_creationTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("creationTime"), out var __jsonCreationTime) ? global::System.DateTime.TryParse((string)__jsonCreationTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonCreationTimeValue) ? __jsonCreationTimeValue : CreationTime : CreationTime;}
            {_expiryTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("expiryTime"), out var __jsonExpiryTime) ? global::System.DateTime.TryParse((string)__jsonExpiryTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonExpiryTimeValue) ? __jsonExpiryTimeValue : ExpiryTime : ExpiryTime;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)Id;}
            {_metaData = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("metaData"), out var __jsonMetaData) ? (string)__jsonMetaData : (string)MetaData;}
            {_state = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("state"), out var __jsonState) ? (string)__jsonState : (string)State;}
            {_type = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("type"), out var __jsonType) ? (string)__jsonType : (string)Type;}
            {_visible = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonBoolean>("visible"), out var __jsonVisible) ? (bool?)__jsonVisible : Visible;}
            {_rehydrationExpiryTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("rehydrationExpiryTime"), out var __jsonRehydrationExpiryTime) ? global::System.DateTime.TryParse((string)__jsonRehydrationExpiryTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRehydrationExpiryTimeValue) ? __jsonRehydrationExpiryTimeValue : RehydrationExpiryTime : RehydrationExpiryTime;}
            {_rehydrationStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("rehydrationStatus"), out var __jsonRehydrationStatus) ? (string)__jsonRehydrationStatus : (string)RehydrationStatus;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="RecoveryPointDataStoreDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="RecoveryPointDataStoreDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._creationTime ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._creationTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "creationTime" ,container.Add );
            AddIf( null != this._expiryTime ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._expiryTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "expiryTime" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AddIf( null != (((object)this._metaData)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._metaData.ToString()) : null, "metaData" ,container.Add );
            AddIf( null != (((object)this._state)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._state.ToString()) : null, "state" ,container.Add );
            AddIf( null != (((object)this._type)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._type.ToString()) : null, "type" ,container.Add );
            AddIf( null != this._visible ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonBoolean((bool)this._visible) : null, "visible" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._rehydrationExpiryTime ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._rehydrationExpiryTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "rehydrationExpiryTime" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._rehydrationStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._rehydrationStatus.ToString()) : null, "rehydrationStatus" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}