// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The billing period</summary>
    public partial class BillingPeriod
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject into a new instance of <see cref="BillingPeriod" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal BillingPeriod(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_core = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber>("cores"), out var __jsonCores) ? (int)__jsonCores : _core;}
            {_pricingModel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("pricingModel"), out var __jsonPricingModel) ? (string)__jsonPricingModel : (string)_pricingModel;}
            {_startDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("startDate"), out var __jsonStartDate) ? global::System.DateTime.TryParse((string)__jsonStartDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonStartDateValue) ? __jsonStartDateValue : _startDate : _startDate;}
            {_endDate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString>("endDate"), out var __jsonEndDate) ? global::System.DateTime.TryParse((string)__jsonEndDate, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonEndDateValue) ? __jsonEndDateValue : _endDate : _endDate;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject json ? new BillingPeriod(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="BillingPeriod" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="BillingPeriod" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNumber(this._core), "cores" ,container.Add );
            AddIf( null != (((object)this._pricingModel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._pricingModel.ToString()) : null, "pricingModel" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._startDate ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._startDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "startDate" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._endDate ? (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonString(this._endDate?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "endDate" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}