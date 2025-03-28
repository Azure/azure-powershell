// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Data Manager for Agriculture solution.</summary>
    public partial class DataManagerForAgricultureSolution
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject into a new instance of <see cref="DataManagerForAgricultureSolution" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DataManagerForAgricultureSolution(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_marketPlaceOfferDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject>("marketPlaceOfferDetails"), out var __jsonMarketPlaceOfferDetails) ? Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.MarketPlaceOfferDetails.FromJson(__jsonMarketPlaceOfferDetails) : _marketPlaceOfferDetail;}
            {_partnerId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("partnerId"), out var __jsonPartnerId) ? (string)__jsonPartnerId : (string)_partnerId;}
            {_solutionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("solutionId"), out var __jsonSolutionId) ? (string)__jsonSolutionId : (string)_solutionId;}
            {_partnerTenantId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("partnerTenantId"), out var __jsonPartnerTenantId) ? (string)__jsonPartnerTenantId : (string)_partnerTenantId;}
            {_dataAccessScope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonArray>("dataAccessScopes"), out var __jsonDataAccessScopes) ? If( __jsonDataAccessScopes as Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _dataAccessScope;}
            {_saasApplicationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("saasApplicationId"), out var __jsonSaasApplicationId) ? (string)__jsonSaasApplicationId : (string)_saasApplicationId;}
            {_accessAzureDataManagerForAgricultureApplicationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("accessAzureDataManagerForAgricultureApplicationId"), out var __jsonAccessAzureDataManagerForAgricultureApplicationId) ? (string)__jsonAccessAzureDataManagerForAgricultureApplicationId : (string)_accessAzureDataManagerForAgricultureApplicationId;}
            {_accessAzureDataManagerForAgricultureApplicationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString>("accessAzureDataManagerForAgricultureApplicationName"), out var __jsonAccessAzureDataManagerForAgricultureApplicationName) ? (string)__jsonAccessAzureDataManagerForAgricultureApplicationName : (string)_accessAzureDataManagerForAgricultureApplicationName;}
            {_isValidateInput = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonBoolean>("isValidateInput"), out var __jsonIsValidateInput) ? (bool)__jsonIsValidateInput : _isValidateInput;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject json ? new DataManagerForAgricultureSolution(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DataManagerForAgricultureSolution" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DataManagerForAgricultureSolution" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._marketPlaceOfferDetail ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) this._marketPlaceOfferDetail.ToJson(null,serializationMode) : null, "marketPlaceOfferDetails" ,container.Add );
            AddIf( null != (((object)this._partnerId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._partnerId.ToString()) : null, "partnerId" ,container.Add );
            AddIf( null != (((object)this._solutionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._solutionId.ToString()) : null, "solutionId" ,container.Add );
            AddIf( null != (((object)this._partnerTenantId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._partnerTenantId.ToString()) : null, "partnerTenantId" ,container.Add );
            if (null != this._dataAccessScope)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.XNodeArray();
                foreach( var __x in this._dataAccessScope )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("dataAccessScopes",__w);
            }
            AddIf( null != (((object)this._saasApplicationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._saasApplicationId.ToString()) : null, "saasApplicationId" ,container.Add );
            AddIf( null != (((object)this._accessAzureDataManagerForAgricultureApplicationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._accessAzureDataManagerForAgricultureApplicationId.ToString()) : null, "accessAzureDataManagerForAgricultureApplicationId" ,container.Add );
            AddIf( null != (((object)this._accessAzureDataManagerForAgricultureApplicationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonString(this._accessAzureDataManagerForAgricultureApplicationName.ToString()) : null, "accessAzureDataManagerForAgricultureApplicationName" ,container.Add );
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonBoolean(this._isValidateInput), "isValidateInput" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}