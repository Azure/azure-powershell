// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell;

    /// <summary>Data Manager for Agriculture solution.</summary>
    [System.ComponentModel.TypeConverter(typeof(DataManagerForAgricultureSolutionTypeConverter))]
    public partial class DataManagerForAgricultureSolution
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataManagerForAgricultureSolution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DataManagerForAgricultureSolution(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MarketPlaceOfferDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetail = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetails) content.GetValueForProperty("MarketPlaceOfferDetail",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetail, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.MarketPlaceOfferDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("PartnerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerId = (string) content.GetValueForProperty("PartnerId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerId, global::System.Convert.ToString);
            }
            if (content.Contains("SolutionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SolutionId = (string) content.GetValueForProperty("SolutionId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SolutionId, global::System.Convert.ToString);
            }
            if (content.Contains("PartnerTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerTenantId = (string) content.GetValueForProperty("PartnerTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataAccessScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).DataAccessScope = (System.Collections.Generic.List<string>) content.GetValueForProperty("DataAccessScope",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).DataAccessScope, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SaasApplicationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SaasApplicationId = (string) content.GetValueForProperty("SaasApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SaasApplicationId, global::System.Convert.ToString);
            }
            if (content.Contains("AccessAzureDataManagerForAgricultureApplicationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationId = (string) content.GetValueForProperty("AccessAzureDataManagerForAgricultureApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationId, global::System.Convert.ToString);
            }
            if (content.Contains("AccessAzureDataManagerForAgricultureApplicationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationName = (string) content.GetValueForProperty("AccessAzureDataManagerForAgricultureApplicationName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationName, global::System.Convert.ToString);
            }
            if (content.Contains("IsValidateInput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).IsValidateInput = (bool) content.GetValueForProperty("IsValidateInput",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).IsValidateInput, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("MarketPlaceOfferDetailSaasOfferId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailSaasOfferId = (string) content.GetValueForProperty("MarketPlaceOfferDetailSaasOfferId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailSaasOfferId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketPlaceOfferDetailPublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailPublisherId = (string) content.GetValueForProperty("MarketPlaceOfferDetailPublisherId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailPublisherId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataManagerForAgricultureSolution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DataManagerForAgricultureSolution(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MarketPlaceOfferDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetail = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetails) content.GetValueForProperty("MarketPlaceOfferDetail",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetail, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.MarketPlaceOfferDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("PartnerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerId = (string) content.GetValueForProperty("PartnerId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerId, global::System.Convert.ToString);
            }
            if (content.Contains("SolutionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SolutionId = (string) content.GetValueForProperty("SolutionId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SolutionId, global::System.Convert.ToString);
            }
            if (content.Contains("PartnerTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerTenantId = (string) content.GetValueForProperty("PartnerTenantId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).PartnerTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("DataAccessScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).DataAccessScope = (System.Collections.Generic.List<string>) content.GetValueForProperty("DataAccessScope",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).DataAccessScope, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SaasApplicationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SaasApplicationId = (string) content.GetValueForProperty("SaasApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).SaasApplicationId, global::System.Convert.ToString);
            }
            if (content.Contains("AccessAzureDataManagerForAgricultureApplicationId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationId = (string) content.GetValueForProperty("AccessAzureDataManagerForAgricultureApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationId, global::System.Convert.ToString);
            }
            if (content.Contains("AccessAzureDataManagerForAgricultureApplicationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationName = (string) content.GetValueForProperty("AccessAzureDataManagerForAgricultureApplicationName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).AccessAzureDataManagerForAgricultureApplicationName, global::System.Convert.ToString);
            }
            if (content.Contains("IsValidateInput"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).IsValidateInput = (bool) content.GetValueForProperty("IsValidateInput",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).IsValidateInput, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("MarketPlaceOfferDetailSaasOfferId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailSaasOfferId = (string) content.GetValueForProperty("MarketPlaceOfferDetailSaasOfferId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailSaasOfferId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketPlaceOfferDetailPublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailPublisherId = (string) content.GetValueForProperty("MarketPlaceOfferDetailPublisherId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal)this).MarketPlaceOfferDetailPublisherId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataManagerForAgricultureSolution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DataManagerForAgricultureSolution(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.DataManagerForAgricultureSolution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DataManagerForAgricultureSolution(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataManagerForAgricultureSolution" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="DataManagerForAgricultureSolution" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Data Manager for Agriculture solution.
    [System.ComponentModel.TypeConverter(typeof(DataManagerForAgricultureSolutionTypeConverter))]
    public partial interface IDataManagerForAgricultureSolution

    {

    }
}