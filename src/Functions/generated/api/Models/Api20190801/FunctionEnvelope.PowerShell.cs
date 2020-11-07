namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Function information.</summary>
    [System.ComponentModel.TypeConverter(typeof(FunctionEnvelopeTypeConverter))]
    public partial class FunctionEnvelope
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelope"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelope" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelope DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FunctionEnvelope(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelope"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelope" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelope DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FunctionEnvelope(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FunctionEnvelope" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelope FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelope"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FunctionEnvelope(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelopePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).IsDisabled = (bool?) content.GetValueForProperty("IsDisabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).IsDisabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelopePropertiesConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).File = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles) content.GetValueForProperty("File",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).File, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelopePropertiesFilesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).FunctionAppId = (string) content.GetValueForProperty("FunctionAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).FunctionAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).InvokeUrlTemplate = (string) content.GetValueForProperty("InvokeUrlTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).InvokeUrlTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ConfigHref = (string) content.GetValueForProperty("ConfigHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ConfigHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptHref = (string) content.GetValueForProperty("ScriptHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptRootPathHref = (string) content.GetValueForProperty("ScriptRootPathHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptRootPathHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).SecretsFileHref = (string) content.GetValueForProperty("SecretsFileHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).SecretsFileHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestData = (string) content.GetValueForProperty("TestData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestDataHref = (string) content.GetValueForProperty("TestDataHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestDataHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Language = (string) content.GetValueForProperty("Language",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Language, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelope"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FunctionEnvelope(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelopePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).IsDisabled = (bool?) content.GetValueForProperty("IsDisabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).IsDisabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelopePropertiesConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).File = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles) content.GetValueForProperty("File",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).File, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.FunctionEnvelopePropertiesFilesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).FunctionAppId = (string) content.GetValueForProperty("FunctionAppId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).FunctionAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).InvokeUrlTemplate = (string) content.GetValueForProperty("InvokeUrlTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).InvokeUrlTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ConfigHref = (string) content.GetValueForProperty("ConfigHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ConfigHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptHref = (string) content.GetValueForProperty("ScriptHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptRootPathHref = (string) content.GetValueForProperty("ScriptRootPathHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).ScriptRootPathHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).SecretsFileHref = (string) content.GetValueForProperty("SecretsFileHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).SecretsFileHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestData = (string) content.GetValueForProperty("TestData",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestDataHref = (string) content.GetValueForProperty("TestDataHref",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).TestDataHref, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Language = (string) content.GetValueForProperty("Language",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopeInternal)this).Language, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Function information.
    [System.ComponentModel.TypeConverter(typeof(FunctionEnvelopeTypeConverter))]
    public partial interface IFunctionEnvelope

    {

    }
}