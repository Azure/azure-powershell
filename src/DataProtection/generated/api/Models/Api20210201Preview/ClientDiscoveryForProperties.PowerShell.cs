namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PowerShell;

    /// <summary>Class to represent shoebox properties in json client discovery.</summary>
    [System.ComponentModel.TypeConverter(typeof(ClientDiscoveryForPropertiesTypeConverter))]
    public partial class ClientDiscoveryForProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ClientDiscoveryForProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecification = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForServiceSpecification) content.GetValueForProperty("ServiceSpecification",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecification, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForServiceSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecificationLogSpecification = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForLogSpecification[]) content.GetValueForProperty("ServiceSpecificationLogSpecification",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecificationLogSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForLogSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForLogSpecificationTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ClientDiscoveryForProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecification = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForServiceSpecification) content.GetValueForProperty("ServiceSpecification",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecification, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForServiceSpecificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecificationLogSpecification = (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForLogSpecification[]) content.GetValueForProperty("ServiceSpecificationLogSpecification",((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForPropertiesInternal)this).ServiceSpecificationLogSpecification, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForLogSpecification>(__y, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForLogSpecificationTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ClientDiscoveryForProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ClientDiscoveryForProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ClientDiscoveryForProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ClientDiscoveryForProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IClientDiscoveryForProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class to represent shoebox properties in json client discovery.
    [System.ComponentModel.TypeConverter(typeof(ClientDiscoveryForPropertiesTypeConverter))]
    public partial interface IClientDiscoveryForProperties

    {

    }
}