namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>VnetInfo resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(VnetInfoPropertiesTypeConverter))]
    public partial class VnetInfoProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VnetInfoProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VnetInfoProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VnetInfoProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VnetInfoProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).VnetResourceId = (string) content.GetValueForProperty("VnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).VnetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertThumbprint = (string) content.GetValueForProperty("CertThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertBlob = (string) content.GetValueForProperty("CertBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertBlob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).DnsServer = (string) content.GetValueForProperty("DnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).DnsServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).IsSwift = (bool?) content.GetValueForProperty("IsSwift",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).IsSwift, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VnetInfoProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).VnetResourceId = (string) content.GetValueForProperty("VnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).VnetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertThumbprint = (string) content.GetValueForProperty("CertThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertBlob = (string) content.GetValueForProperty("CertBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).CertBlob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).DnsServer = (string) content.GetValueForProperty("DnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).DnsServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).IsSwift = (bool?) content.GetValueForProperty("IsSwift",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoPropertiesInternal)this).IsSwift, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }
    }
    /// VnetInfo resource specific properties
    [System.ComponentModel.TypeConverter(typeof(VnetInfoPropertiesTypeConverter))]
    public partial interface IVnetInfoProperties

    {

    }
}