namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters for VpnConnection</summary>
    [System.ComponentModel.TypeConverter(typeof(VpnConnectionPropertiesTypeConverter))]
    public partial class VpnConnectionProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VpnConnectionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VpnConnectionProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VpnConnectionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VpnConnectionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("RemoteVpnSite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSite, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionBandwidth = (int?) content.GetValueForProperty("ConnectionBandwidth",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionBandwidth, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus?) content.GetValueForProperty("ConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EgressBytesTransferred = (long?) content.GetValueForProperty("EgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableBgp = (bool?) content.GetValueForProperty("EnableBgp",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableBgp, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableInternetSecurity = (bool?) content.GetValueForProperty("EnableInternetSecurity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableInternetSecurity, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableRateLimiting = (bool?) content.GetValueForProperty("EnableRateLimiting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableRateLimiting, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IngressBytesTransferred = (long?) content.GetValueForProperty("IngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IpsecPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]) content.GetValueForProperty("IpsecPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IpsecPolicy, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RoutingWeight = (int?) content.GetValueForProperty("RoutingWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RoutingWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).SharedKey = (string) content.GetValueForProperty("SharedKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).SharedKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).UseLocalAzureIPAddress = (bool?) content.GetValueForProperty("UseLocalAzureIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).UseLocalAzureIPAddress, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).VpnConnectionProtocolType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol?) content.GetValueForProperty("VpnConnectionProtocolType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).VpnConnectionProtocolType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSiteId = (string) content.GetValueForProperty("RemoteVpnSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSiteId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnConnectionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VpnConnectionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSite = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("RemoteVpnSite",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSite, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionBandwidth = (int?) content.GetValueForProperty("ConnectionBandwidth",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionBandwidth, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus?) content.GetValueForProperty("ConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ConnectionStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VpnConnectionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EgressBytesTransferred = (long?) content.GetValueForProperty("EgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableBgp = (bool?) content.GetValueForProperty("EnableBgp",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableBgp, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableInternetSecurity = (bool?) content.GetValueForProperty("EnableInternetSecurity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableInternetSecurity, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableRateLimiting = (bool?) content.GetValueForProperty("EnableRateLimiting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).EnableRateLimiting, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IngressBytesTransferred = (long?) content.GetValueForProperty("IngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IpsecPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy[]) content.GetValueForProperty("IpsecPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).IpsecPolicy, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIpsecPolicy>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IpsecPolicyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RoutingWeight = (int?) content.GetValueForProperty("RoutingWeight",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RoutingWeight, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).SharedKey = (string) content.GetValueForProperty("SharedKey",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).SharedKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).UseLocalAzureIPAddress = (bool?) content.GetValueForProperty("UseLocalAzureIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).UseLocalAzureIPAddress, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).VpnConnectionProtocolType = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol?) content.GetValueForProperty("VpnConnectionProtocolType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).VpnConnectionProtocolType, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.VirtualNetworkGatewayConnectionProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSiteId = (string) content.GetValueForProperty("RemoteVpnSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnConnectionPropertiesInternal)this).RemoteVpnSiteId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Parameters for VpnConnection
    [System.ComponentModel.TypeConverter(typeof(VpnConnectionPropertiesTypeConverter))]
    public partial interface IVpnConnectionProperties

    {

    }
}