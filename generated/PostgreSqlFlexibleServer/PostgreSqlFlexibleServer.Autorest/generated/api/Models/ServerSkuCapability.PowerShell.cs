// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Capabilities in terms of compute.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerSkuCapabilityTypeConverter))]
    public partial class ServerSkuCapability
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerSkuCapability(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerSkuCapability(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerSkuCapability" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ServerSkuCapability" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerSkuCapability(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("VCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).VCore = (int?) content.GetValueForProperty("VCore",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).VCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SupportedIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedIop = (int?) content.GetValueForProperty("SupportedIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SupportedMemoryPerVcoreMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedMemoryPerVcoreMb = (long?) content.GetValueForProperty("SupportedMemoryPerVcoreMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedMemoryPerVcoreMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("SupportedZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedZone = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupportedZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedZone, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SupportedHaMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedHaMode = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupportedHaMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedHaMode, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SupportedFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedFeature = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature>) content.GetValueForProperty("SupportedFeature",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedFeature, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SupportedFeatureTypeConverter.ConvertFrom));
            }
            if (content.Contains("SecurityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SecurityProfile = (string) content.GetValueForProperty("SecurityProfile",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SecurityProfile, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("Reason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Reason = (string) content.GetValueForProperty("Reason",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Reason, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerSkuCapability(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("VCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).VCore = (int?) content.GetValueForProperty("VCore",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).VCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SupportedIop"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedIop = (int?) content.GetValueForProperty("SupportedIop",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedIop, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("SupportedMemoryPerVcoreMb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedMemoryPerVcoreMb = (long?) content.GetValueForProperty("SupportedMemoryPerVcoreMb",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedMemoryPerVcoreMb, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            }
            if (content.Contains("SupportedZone"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedZone = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupportedZone",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedZone, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SupportedHaMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedHaMode = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupportedHaMode",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedHaMode, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("SupportedFeature"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedFeature = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature>) content.GetValueForProperty("SupportedFeature",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SupportedFeature, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ISupportedFeature>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.SupportedFeatureTypeConverter.ConvertFrom));
            }
            if (content.Contains("SecurityProfile"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SecurityProfile = (string) content.GetValueForProperty("SecurityProfile",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapabilityInternal)this).SecurityProfile, global::System.Convert.ToString);
            }
            if (content.Contains("Status"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Status = (string) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Status, global::System.Convert.ToString);
            }
            if (content.Contains("Reason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Reason = (string) content.GetValueForProperty("Reason",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)this).Reason, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Capabilities in terms of compute.
    [System.ComponentModel.TypeConverter(typeof(ServerSkuCapabilityTypeConverter))]
    public partial interface IServerSkuCapability

    {

    }
}