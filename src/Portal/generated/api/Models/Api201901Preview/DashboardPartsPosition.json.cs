namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The dashboard's part position.</summary>
    public partial class DashboardPartsPosition
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject into a new instance of <see cref="DashboardPartsPosition" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DashboardPartsPosition(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_colSpan = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber>("colSpan"), out var __jsonColSpan) ? (int)__jsonColSpan : ColSpan;}
            {_metadata = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject>("metadata"), out var __jsonMetadata) ? Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionMetadata.FromJson(__jsonMetadata) : Metadata;}
            {_rowSpan = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber>("rowSpan"), out var __jsonRowSpan) ? (int)__jsonRowSpan : RowSpan;}
            {_x = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber>("x"), out var __jsonX) ? (int)__jsonX : X;}
            {_y = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber>("y"), out var __jsonY) ? (int)__jsonY : Y;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition FromJson(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject json ? new DashboardPartsPosition(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DashboardPartsPosition" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DashboardPartsPosition" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber(this._colSpan), "colSpan" ,container.Add );
            AddIf( null != this._metadata ? (Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode) this._metadata.ToJson(null,serializationMode) : null, "metadata" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber(this._rowSpan), "rowSpan" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber(this._x), "x" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNumber(this._y), "y" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}