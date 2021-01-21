namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class TrackedResourceTags
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceTags.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceTags.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api10.ITrackedResourceTags FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json ? new TrackedResourceTags(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="TrackedResourceTags" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="TrackedResourceTags" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.JsonSerializable.ToJson( ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IAssociativeArray<string>)this).AdditionalProperties, container);
            AfterToJson(ref container);
            return container;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject into a new instance of <see cref="TrackedResourceTags" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject instance to deserialize from.</param>
        /// <param name="exclusions"></param>
        internal TrackedResourceTags(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonObject json, global::System.Collections.Generic.HashSet<string> exclusions = null)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.JsonSerializable.FromJson( json, ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IAssociativeArray<string>)this).AdditionalProperties, null ,exclusions );
            AfterFromJson(json);
        }
    }
}