namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(NetworkConfigurationTypeConverter))]
    public partial class NetworkConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.NetworkConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.NetworkConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.NetworkConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv4Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[]) content.GetValueForProperty("Ipv4Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv4Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv4NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv6Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[]) content.GetValueForProperty("Ipv6Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv6Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv6NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DefaultIpv4Gateway = (string[]) content.GetValueForProperty("DefaultIpv4Gateway",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DefaultIpv4Gateway, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).MacAddress = (string[]) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).MacAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsName = (string[]) content.GetValueForProperty("DnsName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsQuestion = (string[]) content.GetValueForProperty("DnsQuestion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsQuestion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsCanonicalName = (string[]) content.GetValueForProperty("DnsCanonicalName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsCanonicalName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.NetworkConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv4Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface[]) content.GetValueForProperty("Ipv4Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv4Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv4NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv4NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv6Interface = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface[]) content.GetValueForProperty("Ipv6Interface",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).Ipv6Interface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IIpv6NetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.Ipv6NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DefaultIpv4Gateway = (string[]) content.GetValueForProperty("DefaultIpv4Gateway",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DefaultIpv4Gateway, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).MacAddress = (string[]) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).MacAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsName = (string[]) content.GetValueForProperty("DnsName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsQuestion = (string[]) content.GetValueForProperty("DnsQuestion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsQuestion, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsCanonicalName = (string[]) content.GetValueForProperty("DnsCanonicalName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.INetworkConfigurationInternal)this).DnsCanonicalName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(NetworkConfigurationTypeConverter))]
    public partial interface INetworkConfiguration

    {

    }
}