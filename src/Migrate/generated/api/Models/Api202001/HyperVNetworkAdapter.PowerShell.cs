namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Second level object represented in responses as part of Machine REST resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVNetworkAdapterTypeConverter))]
    public partial class HyperVNetworkAdapter
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVNetworkAdapter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVNetworkAdapter(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVNetworkAdapter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVNetworkAdapter(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVNetworkAdapter" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapter FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVNetworkAdapter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVNetworkAdapter(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkId = (string) content.GetValueForProperty("NetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).SubnetName = (string) content.GetValueForProperty("SubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).SubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).StaticIPAddress = (string) content.GetValueForProperty("StaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).StaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicType = (string) content.GetValueForProperty("NicType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicId = (string) content.GetValueForProperty("NicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).MacAddress = (string) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).MacAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressList = (string[]) content.GetValueForProperty("IPAddressList",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkName = (string) content.GetValueForProperty("NetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressType = (string) content.GetValueForProperty("IPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVNetworkAdapter"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVNetworkAdapter(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkId = (string) content.GetValueForProperty("NetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).SubnetName = (string) content.GetValueForProperty("SubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).SubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).StaticIPAddress = (string) content.GetValueForProperty("StaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).StaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicType = (string) content.GetValueForProperty("NicType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicId = (string) content.GetValueForProperty("NicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).MacAddress = (string) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).MacAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressList = (string[]) content.GetValueForProperty("IPAddressList",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressList, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkName = (string) content.GetValueForProperty("NetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).NetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressType = (string) content.GetValueForProperty("IPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVNetworkAdapterInternal)this).IPAddressType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Second level object represented in responses as part of Machine REST resource.
    [System.ComponentModel.TypeConverter(typeof(HyperVNetworkAdapterTypeConverter))]
    public partial interface IHyperVNetworkAdapter

    {

    }
}