// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.PowerShell;

    /// <summary>Mapping of installed solutions.</summary>
    [System.ComponentModel.TypeConverter(typeof(InstalledSolutionMapTypeConverter))]
    public partial class InstalledSolutionMap
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InstalledSolutionMap(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InstalledSolutionMap(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InstalledSolutionMap" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="InstalledSolutionMap" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InstalledSolutionMap(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Value"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Value, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SolutionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Key"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Key, global::System.Convert.ToString);
            }
            if (content.Contains("ValueApplicationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueApplicationName = (string) content.GetValueForProperty("ValueApplicationName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueApplicationName, global::System.Convert.ToString);
            }
            if (content.Contains("ValuePartnerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePartnerId = (string) content.GetValueForProperty("ValuePartnerId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePartnerId, global::System.Convert.ToString);
            }
            if (content.Contains("ValueMarketPlacePublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueMarketPlacePublisherId = (string) content.GetValueForProperty("ValueMarketPlacePublisherId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueMarketPlacePublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("ValueSaasSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionId = (string) content.GetValueForProperty("ValueSaasSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ValueSaasSubscriptionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionName = (string) content.GetValueForProperty("ValueSaasSubscriptionName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionName, global::System.Convert.ToString);
            }
            if (content.Contains("ValuePlanId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePlanId = (string) content.GetValueForProperty("ValuePlanId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePlanId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.InstalledSolutionMap"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InstalledSolutionMap(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Value"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Value, Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.SolutionTypeConverter.ConvertFrom);
            }
            if (content.Contains("Key"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).Key, global::System.Convert.ToString);
            }
            if (content.Contains("ValueApplicationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueApplicationName = (string) content.GetValueForProperty("ValueApplicationName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueApplicationName, global::System.Convert.ToString);
            }
            if (content.Contains("ValuePartnerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePartnerId = (string) content.GetValueForProperty("ValuePartnerId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePartnerId, global::System.Convert.ToString);
            }
            if (content.Contains("ValueMarketPlacePublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueMarketPlacePublisherId = (string) content.GetValueForProperty("ValueMarketPlacePublisherId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueMarketPlacePublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("ValueSaasSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionId = (string) content.GetValueForProperty("ValueSaasSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ValueSaasSubscriptionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionName = (string) content.GetValueForProperty("ValueSaasSubscriptionName",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValueSaasSubscriptionName, global::System.Convert.ToString);
            }
            if (content.Contains("ValuePlanId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePlanId = (string) content.GetValueForProperty("ValuePlanId",((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal)this).ValuePlanId, global::System.Convert.ToString);
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
    /// Mapping of installed solutions.
    [System.ComponentModel.TypeConverter(typeof(InstalledSolutionMapTypeConverter))]
    public partial interface IInstalledSolutionMap

    {

    }
}