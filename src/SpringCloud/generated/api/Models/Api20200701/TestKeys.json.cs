namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Test keys payload</summary>
    public partial class TestKeys
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITestKeys.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITestKeys.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITestKeys FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json ? new TestKeys(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject into a new instance of <see cref="TestKeys" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal TestKeys(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_primaryKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("primaryKey"), out var __jsonPrimaryKey) ? (string)__jsonPrimaryKey : (string)PrimaryKey;}
            {_secondaryKey = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("secondaryKey"), out var __jsonSecondaryKey) ? (string)__jsonSecondaryKey : (string)SecondaryKey;}
            {_primaryTestEndpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("primaryTestEndpoint"), out var __jsonPrimaryTestEndpoint) ? (string)__jsonPrimaryTestEndpoint : (string)PrimaryTestEndpoint;}
            {_secondaryTestEndpoint = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString>("secondaryTestEndpoint"), out var __jsonSecondaryTestEndpoint) ? (string)__jsonSecondaryTestEndpoint : (string)SecondaryTestEndpoint;}
            {_enabled = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonBoolean>("enabled"), out var __jsonEnabled) ? (bool?)__jsonEnabled : Enabled;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="TestKeys" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="TestKeys" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._primaryKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._primaryKey.ToString()) : null, "primaryKey" ,container.Add );
            AddIf( null != (((object)this._secondaryKey)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._secondaryKey.ToString()) : null, "secondaryKey" ,container.Add );
            AddIf( null != (((object)this._primaryTestEndpoint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._primaryTestEndpoint.ToString()) : null, "primaryTestEndpoint" ,container.Add );
            AddIf( null != (((object)this._secondaryTestEndpoint)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonString(this._secondaryTestEndpoint.ToString()) : null, "secondaryTestEndpoint" ,container.Add );
            AddIf( null != this._enabled ? (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonBoolean((bool)this._enabled) : null, "enabled" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}