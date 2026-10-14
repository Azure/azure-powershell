// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Capabilities in terms of compute tier.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServerEditionCapabilityTypeConverter))]
    public partial class ServerEditionCapability
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServerEditionCapability(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServerEditionCapability(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServerEditionCapability" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ServerEditionCapability" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServerEditionCapability(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).DefaultSkuName = (string) content.GetValueForProperty("DefaultSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).DefaultSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SupportedStorageEdition"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedStorageEdition = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability>) content.GetValueForProperty("SupportedStorageEdition",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedStorageEdition, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageEditionCapabilityTypeConverter.ConvertFrom));
            }
            if (content.Contains("SupportedServerSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedServerSku = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability>) content.GetValueForProperty("SupportedServerSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedServerSku, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuCapabilityTypeConverter.ConvertFrom));
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
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerEditionCapability"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServerEditionCapability(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultSkuName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).DefaultSkuName = (string) content.GetValueForProperty("DefaultSkuName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).DefaultSkuName, global::System.Convert.ToString);
            }
            if (content.Contains("SupportedStorageEdition"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedStorageEdition = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability>) content.GetValueForProperty("SupportedStorageEdition",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedStorageEdition, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.StorageEditionCapabilityTypeConverter.ConvertFrom));
            }
            if (content.Contains("SupportedServerSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedServerSku = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability>) content.GetValueForProperty("SupportedServerSku",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal)this).SupportedServerSku, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerSkuCapabilityTypeConverter.ConvertFrom));
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
    /// Capabilities in terms of compute tier.
    [System.ComponentModel.TypeConverter(typeof(ServerEditionCapabilityTypeConverter))]
    public partial interface IServerEditionCapability

    {

    }
}