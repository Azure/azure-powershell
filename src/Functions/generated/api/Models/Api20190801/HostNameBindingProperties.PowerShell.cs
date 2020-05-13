namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>HostNameBinding resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(HostNameBindingPropertiesTypeConverter))]
    public partial class HostNameBindingProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameBindingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HostNameBindingProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameBindingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HostNameBindingProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HostNameBindingProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameBindingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HostNameBindingProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceName = (string) content.GetValueForProperty("AzureResourceName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType?) content.GetValueForProperty("AzureResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).CustomHostNameDnsRecordType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType?) content.GetValueForProperty("CustomHostNameDnsRecordType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).CustomHostNameDnsRecordType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).DomainId = (string) content.GetValueForProperty("DomainId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).DomainId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).HostNameType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType?) content.GetValueForProperty("HostNameType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).HostNameType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SiteName = (string) content.GetValueForProperty("SiteName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SslState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState?) content.GetValueForProperty("SslState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SslState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).VirtualIP = (string) content.GetValueForProperty("VirtualIP",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).VirtualIP, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostNameBindingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HostNameBindingProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceName = (string) content.GetValueForProperty("AzureResourceName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType?) content.GetValueForProperty("AzureResourceType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).AzureResourceType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AzureResourceType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).CustomHostNameDnsRecordType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType?) content.GetValueForProperty("CustomHostNameDnsRecordType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).CustomHostNameDnsRecordType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CustomHostNameDnsRecordType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).DomainId = (string) content.GetValueForProperty("DomainId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).DomainId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).HostNameType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType?) content.GetValueForProperty("HostNameType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).HostNameType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostNameType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SiteName = (string) content.GetValueForProperty("SiteName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SslState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState?) content.GetValueForProperty("SslState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).SslState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SslState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).VirtualIP = (string) content.GetValueForProperty("VirtualIP",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameBindingPropertiesInternal)this).VirtualIP, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// HostNameBinding resource specific properties
    [System.ComponentModel.TypeConverter(typeof(HostNameBindingPropertiesTypeConverter))]
    public partial interface IHostNameBindingProperties

    {

    }
}