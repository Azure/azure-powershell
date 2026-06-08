// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Configuration (also known as server parameter).</summary>
    [System.ComponentModel.TypeConverter(typeof(ConfigurationForUpdateTypeConverter))]
    public partial class ConfigurationForUpdate
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationForUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConfigurationForUpdate(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Value"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Value, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultValue"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DefaultValue = (string) content.GetValueForProperty("DefaultValue",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DefaultValue, global::System.Convert.ToString);
            }
            if (content.Contains("DataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DataType = (string) content.GetValueForProperty("DataType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DataType, global::System.Convert.ToString);
            }
            if (content.Contains("AllowedValue"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).AllowedValue = (string) content.GetValueForProperty("AllowedValue",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).AllowedValue, global::System.Convert.ToString);
            }
            if (content.Contains("Source"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Source = (string) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Source, global::System.Convert.ToString);
            }
            if (content.Contains("IsDynamicConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsDynamicConfig = (bool?) content.GetValueForProperty("IsDynamicConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsDynamicConfig, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("IsReadOnly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsReadOnly = (bool?) content.GetValueForProperty("IsReadOnly",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsReadOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("IsConfigPendingRestart"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsConfigPendingRestart = (bool?) content.GetValueForProperty("IsConfigPendingRestart",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsConfigPendingRestart, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("Unit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Unit, global::System.Convert.ToString);
            }
            if (content.Contains("DocumentationLink"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DocumentationLink = (string) content.GetValueForProperty("DocumentationLink",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DocumentationLink, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationForUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConfigurationForUpdate(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Value"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Value, global::System.Convert.ToString);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("DefaultValue"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DefaultValue = (string) content.GetValueForProperty("DefaultValue",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DefaultValue, global::System.Convert.ToString);
            }
            if (content.Contains("DataType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DataType = (string) content.GetValueForProperty("DataType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DataType, global::System.Convert.ToString);
            }
            if (content.Contains("AllowedValue"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).AllowedValue = (string) content.GetValueForProperty("AllowedValue",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).AllowedValue, global::System.Convert.ToString);
            }
            if (content.Contains("Source"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Source = (string) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Source, global::System.Convert.ToString);
            }
            if (content.Contains("IsDynamicConfig"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsDynamicConfig = (bool?) content.GetValueForProperty("IsDynamicConfig",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsDynamicConfig, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("IsReadOnly"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsReadOnly = (bool?) content.GetValueForProperty("IsReadOnly",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsReadOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("IsConfigPendingRestart"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsConfigPendingRestart = (bool?) content.GetValueForProperty("IsConfigPendingRestart",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).IsConfigPendingRestart, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("Unit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).Unit, global::System.Convert.ToString);
            }
            if (content.Contains("DocumentationLink"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DocumentationLink = (string) content.GetValueForProperty("DocumentationLink",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal)this).DocumentationLink, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationForUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdate"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConfigurationForUpdate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationForUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdate"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConfigurationForUpdate(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConfigurationForUpdate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ConfigurationForUpdate" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Configuration (also known as server parameter).
    [System.ComponentModel.TypeConverter(typeof(ConfigurationForUpdateTypeConverter))]
    public partial interface IConfigurationForUpdate

    {

    }
}