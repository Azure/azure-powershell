namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>VpnClientConnectionHealth properties</summary>
    [System.ComponentModel.TypeConverter(typeof(VpnClientConnectionHealthTypeConverter))]
    public partial class VpnClientConnectionHealth
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealth"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VpnClientConnectionHealth(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealth"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VpnClientConnectionHealth(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VpnClientConnectionHealth" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealth"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VpnClientConnectionHealth(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).AllocatedIPAddress = (string[]) content.GetValueForProperty("AllocatedIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).AllocatedIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalEgressBytesTransferred = (long?) content.GetValueForProperty("TotalEgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalEgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalIngressBytesTransferred = (long?) content.GetValueForProperty("TotalIngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalIngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).VpnClientConnectionsCount = (int?) content.GetValueForProperty("VpnClientConnectionsCount",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).VpnClientConnectionsCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealth"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VpnClientConnectionHealth(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).AllocatedIPAddress = (string[]) content.GetValueForProperty("AllocatedIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).AllocatedIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalEgressBytesTransferred = (long?) content.GetValueForProperty("TotalEgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalEgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalIngressBytesTransferred = (long?) content.GetValueForProperty("TotalIngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).TotalIngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).VpnClientConnectionsCount = (int?) content.GetValueForProperty("VpnClientConnectionsCount",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealthInternal)this).VpnClientConnectionsCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }
    }
    /// VpnClientConnectionHealth properties
    [System.ComponentModel.TypeConverter(typeof(VpnClientConnectionHealthTypeConverter))]
    public partial interface IVpnClientConnectionHealth

    {

    }
}