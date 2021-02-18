namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Service network profile payload</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkProfileTypeConverter))]
    public partial class NetworkProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileOutboundIPs) content.GetValueForProperty("OutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIP, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfileOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeSubnetId = (string) content.GetValueForProperty("ServiceRuntimeSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppSubnetId = (string) content.GetValueForProperty("AppSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceCidr = (string) content.GetValueForProperty("ServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeNetworkResourceGroup = (string) content.GetValueForProperty("ServiceRuntimeNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppNetworkResourceGroup = (string) content.GetValueForProperty("AppNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIPPublicIP = (string[]) content.GetValueForProperty("OutboundIPPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIPPublicIP, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileOutboundIPs) content.GetValueForProperty("OutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIP, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfileOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeSubnetId = (string) content.GetValueForProperty("ServiceRuntimeSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppSubnetId = (string) content.GetValueForProperty("AppSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceCidr = (string) content.GetValueForProperty("ServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeNetworkResourceGroup = (string) content.GetValueForProperty("ServiceRuntimeNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).ServiceRuntimeNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppNetworkResourceGroup = (string) content.GetValueForProperty("AppNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).AppNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIPPublicIP = (string[]) content.GetValueForProperty("OutboundIPPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileInternal)this).OutboundIPPublicIP, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Service network profile payload
    [System.ComponentModel.TypeConverter(typeof(NetworkProfileTypeConverter))]
    public partial interface INetworkProfile

    {

    }
}