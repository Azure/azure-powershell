// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell;

    /// <summary>Installed data manager for Agriculture solution detail.</summary>
    [System.ComponentModel.TypeConverter(typeof(SolutionTypeConverter))]
    public partial class Solution
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Solution(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Solution(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Solution" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Solution" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Solution(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ApplicationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).ApplicationName = (string) content.GetValueForProperty("ApplicationName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).ApplicationName, global::System.Convert.ToString);
            }
            if (content.Contains("PartnerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PartnerId = (string) content.GetValueForProperty("PartnerId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PartnerId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketPlacePublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).MarketPlacePublisherId = (string) content.GetValueForProperty("MarketPlacePublisherId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).MarketPlacePublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("SaasSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionId = (string) content.GetValueForProperty("SaasSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("SaasSubscriptionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionName = (string) content.GetValueForProperty("SaasSubscriptionName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionName, global::System.Convert.ToString);
            }
            if (content.Contains("PlanId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PlanId = (string) content.GetValueForProperty("PlanId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PlanId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Solution"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Solution(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ApplicationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).ApplicationName = (string) content.GetValueForProperty("ApplicationName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).ApplicationName, global::System.Convert.ToString);
            }
            if (content.Contains("PartnerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PartnerId = (string) content.GetValueForProperty("PartnerId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PartnerId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketPlacePublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).MarketPlacePublisherId = (string) content.GetValueForProperty("MarketPlacePublisherId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).MarketPlacePublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("SaasSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionId = (string) content.GetValueForProperty("SaasSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("SaasSubscriptionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionName = (string) content.GetValueForProperty("SaasSubscriptionName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).SaasSubscriptionName, global::System.Convert.ToString);
            }
            if (content.Contains("PlanId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PlanId = (string) content.GetValueForProperty("PlanId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)this).PlanId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

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
    /// Installed data manager for Agriculture solution detail.
    [System.ComponentModel.TypeConverter(typeof(SolutionTypeConverter))]
    public partial interface ISolution

    {

    }
}