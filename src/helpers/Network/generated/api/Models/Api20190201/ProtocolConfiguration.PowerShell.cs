namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Configuration of the protocol.</summary>
    [System.ComponentModel.TypeConverter(typeof(ProtocolConfigurationTypeConverter))]
    public partial class ProtocolConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProtocolConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProtocolConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProtocolConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ProtocolConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration) content.GetValueForProperty("HttpConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod?) content.GetValueForProperty("HttpConfigurationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationHeader = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[]) content.GetValueForProperty("HttpConfigurationHeader",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationHeader, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpHeaderTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationValidStatusCode = (int[]) content.GetValueForProperty("HttpConfigurationValidStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationValidStatusCode, __y => TypeConverterExtensions.SelectToArray<int>(__y, (__w)=> (int) global::System.Convert.ChangeType(__w, typeof(int))));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProtocolConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ProtocolConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpConfiguration) content.GetValueForProperty("HttpConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod?) content.GetValueForProperty("HttpConfigurationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.HttpMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationHeader = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader[]) content.GetValueForProperty("HttpConfigurationHeader",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationHeader, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IHttpHeader>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.HttpHeaderTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationValidStatusCode = (int[]) content.GetValueForProperty("HttpConfigurationValidStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProtocolConfigurationInternal)this).HttpConfigurationValidStatusCode, __y => TypeConverterExtensions.SelectToArray<int>(__y, (__w)=> (int) global::System.Convert.ChangeType(__w, typeof(int))));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Configuration of the protocol.
    [System.ComponentModel.TypeConverter(typeof(ProtocolConfigurationTypeConverter))]
    public partial interface IProtocolConfiguration

    {

    }
}