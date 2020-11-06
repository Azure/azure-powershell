namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Service properties payload</summary>
    [System.ComponentModel.TypeConverter(typeof(ClusterResourcePropertiesTypeConverter))]
    public partial class ClusterResourceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ClusterResourceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).Version = (int?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).Version, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ServiceId = (string) content.GetValueForProperty("ServiceId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ServiceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr = (string) content.GetValueForProperty("NetworkProfileServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileOutboundIPs) content.GetValueForProperty("NetworkProfileOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileOutboundIP, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfileOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId = (string) content.GetValueForProperty("NetworkProfileAppSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileAppNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).OutboundIPPublicIP = (string[]) content.GetValueForProperty("OutboundIPPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).OutboundIPPublicIP, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ClusterResourceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfile = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfile) content.GetValueForProperty("NetworkProfile",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfile, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).Version = (int?) content.GetValueForProperty("Version",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).Version, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ServiceId = (string) content.GetValueForProperty("ServiceId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).ServiceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr = (string) content.GetValueForProperty("NetworkProfileServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INetworkProfileOutboundIPs) content.GetValueForProperty("NetworkProfileOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileOutboundIP, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.NetworkProfileOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId = (string) content.GetValueForProperty("NetworkProfileAppSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileServiceRuntimeNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileServiceRuntimeNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup = (string) content.GetValueForProperty("NetworkProfileAppNetworkResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).NetworkProfileAppNetworkResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).OutboundIPPublicIP = (string[]) content.GetValueForProperty("OutboundIPPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourcePropertiesInternal)this).OutboundIPPublicIP, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ClusterResourceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ClusterResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourceProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ClusterResourceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ClusterResourceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IClusterResourceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Service properties payload
    [System.ComponentModel.TypeConverter(typeof(ClusterResourcePropertiesTypeConverter))]
    public partial interface IClusterResourceProperties

    {

    }
}