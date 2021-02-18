namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Functions host level keys.</summary>
    [System.ComponentModel.TypeConverter(typeof(HostKeysTypeConverter))]
    public partial class HostKeys
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeys"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeys" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeys DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HostKeys(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeys"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeys" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeys DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HostKeys(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HostKeys" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeys FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeys"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HostKeys(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).MasterKey = (string) content.GetValueForProperty("MasterKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).MasterKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).FunctionKey = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys) content.GetValueForProperty("FunctionKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).FunctionKey, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeysFunctionKeysTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).SystemKey = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys) content.GetValueForProperty("SystemKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).SystemKey, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeysSystemKeysTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeys"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HostKeys(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).MasterKey = (string) content.GetValueForProperty("MasterKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).MasterKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).FunctionKey = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysFunctionKeys) content.GetValueForProperty("FunctionKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).FunctionKey, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeysFunctionKeysTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).SystemKey = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysSystemKeys) content.GetValueForProperty("SystemKey",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostKeysInternal)this).SystemKey, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostKeysSystemKeysTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Functions host level keys.
    [System.ComponentModel.TypeConverter(typeof(HostKeysTypeConverter))]
    public partial interface IHostKeys

    {

    }
}