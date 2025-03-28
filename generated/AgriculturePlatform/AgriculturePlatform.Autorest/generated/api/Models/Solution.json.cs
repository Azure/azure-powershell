// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Installed data manager for Agriculture solution detail.</summary>
    public partial class Solution
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject json ? new Solution(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject into a new instance of <see cref="Solution" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal Solution(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_applicationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("applicationName"), out var __jsonApplicationName) ? (string)__jsonApplicationName : (string)_applicationName;}
            {_partnerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("partnerId"), out var __jsonPartnerId) ? (string)__jsonPartnerId : (string)_partnerId;}
            {_marketPlacePublisherId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("marketPlacePublisherId"), out var __jsonMarketPlacePublisherId) ? (string)__jsonMarketPlacePublisherId : (string)_marketPlacePublisherId;}
            {_saasSubscriptionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("saasSubscriptionId"), out var __jsonSaasSubscriptionId) ? (string)__jsonSaasSubscriptionId : (string)_saasSubscriptionId;}
            {_saasSubscriptionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("saasSubscriptionName"), out var __jsonSaasSubscriptionName) ? (string)__jsonSaasSubscriptionName : (string)_saasSubscriptionName;}
            {_planId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("planId"), out var __jsonPlanId) ? (string)__jsonPlanId : (string)_planId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="Solution" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="Solution" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._applicationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._applicationName.ToString()) : null, "applicationName" ,container.Add );
            AddIf( null != (((object)this._partnerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._partnerId.ToString()) : null, "partnerId" ,container.Add );
            AddIf( null != (((object)this._marketPlacePublisherId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._marketPlacePublisherId.ToString()) : null, "marketPlacePublisherId" ,container.Add );
            AddIf( null != (((object)this._saasSubscriptionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._saasSubscriptionId.ToString()) : null, "saasSubscriptionId" ,container.Add );
            AddIf( null != (((object)this._saasSubscriptionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._saasSubscriptionName.ToString()) : null, "saasSubscriptionName" ,container.Add );
            AddIf( null != (((object)this._planId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._planId.ToString()) : null, "planId" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}