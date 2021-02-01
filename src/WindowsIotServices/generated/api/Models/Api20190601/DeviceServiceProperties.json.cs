namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>The properties of a Windows IoT Device Service.</summary>
    public partial class DeviceServiceProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject into a new instance of <see cref="DeviceServiceProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DeviceServiceProperties(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_note = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString>("notes"), out var __jsonNotes) ? (string)__jsonNotes : (string)Note;}
            {_startDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString>("startDate"), out var __jsonStartDate) ? global::System.DateTime.TryParse((string)__jsonStartDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartDateValue) ? __jsonStartDateValue : StartDate : StartDate;}
            {_quantity = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNumber>("quantity"), out var __jsonQuantity) ? (long?)__jsonQuantity : Quantity;}
            {_billingDomainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString>("billingDomainName"), out var __jsonBillingDomainName) ? (string)__jsonBillingDomainName : (string)BillingDomainName;}
            {_adminDomainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString>("adminDomainName"), out var __jsonAdminDomainName) ? (string)__jsonAdminDomainName : (string)AdminDomainName;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IDeviceServiceProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject json ? new DeviceServiceProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DeviceServiceProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DeviceServiceProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._note)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString(this._note.ToString()) : null, "notes" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._startDate ? (Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString(this._startDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "startDate" ,container.Add );
            }
            AddIf( null != this._quantity ? (Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNumber((long)this._quantity) : null, "quantity" ,container.Add );
            AddIf( null != (((object)this._billingDomainName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString(this._billingDomainName.ToString()) : null, "billingDomainName" ,container.Add );
            AddIf( null != (((object)this._adminDomainName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonString(this._adminDomainName.ToString()) : null, "adminDomainName" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}