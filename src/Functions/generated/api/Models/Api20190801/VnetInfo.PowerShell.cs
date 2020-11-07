namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Virtual Network information contract.</summary>
    [System.ComponentModel.TypeConverter(typeof(VnetInfoTypeConverter))]
    public partial class VnetInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VnetInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VnetInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VnetInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VnetInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertBlob = (string) content.GetValueForProperty("CertBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertBlob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertThumbprint = (string) content.GetValueForProperty("CertThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).DnsServer = (string) content.GetValueForProperty("DnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).DnsServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).IsSwift = (bool?) content.GetValueForProperty("IsSwift",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).IsSwift, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).VnetResourceId = (string) content.GetValueForProperty("VnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).VnetResourceId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VnetInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetInfoPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertBlob = (string) content.GetValueForProperty("CertBlob",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertBlob, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertThumbprint = (string) content.GetValueForProperty("CertThumbprint",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).CertThumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).DnsServer = (string) content.GetValueForProperty("DnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).DnsServer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).IsSwift = (bool?) content.GetValueForProperty("IsSwift",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).IsSwift, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).ResyncRequired = (bool?) content.GetValueForProperty("ResyncRequired",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).ResyncRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VnetRouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).VnetResourceId = (string) content.GetValueForProperty("VnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetInfoInternal)this).VnetResourceId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Virtual Network information contract.
    [System.ComponentModel.TypeConverter(typeof(VnetInfoTypeConverter))]
    public partial interface IVnetInfo

    {

    }
}