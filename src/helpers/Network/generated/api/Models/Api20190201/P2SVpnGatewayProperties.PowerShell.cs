namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters for P2SVpnGateway</summary>
    [System.ComponentModel.TypeConverter(typeof(P2SVpnGatewayPropertiesTypeConverter))]
    public partial class P2SVpnGatewayProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new P2SVpnGatewayProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new P2SVpnGatewayProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="P2SVpnGatewayProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal P2SVpnGatewayProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRoute = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("CustomRoute",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRoute, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("P2SVpnServerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHub, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("VpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealth = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth) content.GetValueForProperty("VpnClientConnectionHealth",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealth, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealthTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnGatewayScaleUnit = (int?) content.GetValueForProperty("VpnGatewayScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnGatewayScaleUnit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRouteAddressPrefix = (string[]) content.GetValueForProperty("CustomRouteAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRouteAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfigurationId = (string) content.GetValueForProperty("P2SVpnServerConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHubId = (string) content.GetValueForProperty("VirtualHubId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHubId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPoolAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPoolAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPoolAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthAllocatedIPAddress = (string[]) content.GetValueForProperty("VpnClientConnectionHealthAllocatedIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthAllocatedIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalEgressBytesTransferred = (long?) content.GetValueForProperty("VpnClientConnectionHealthTotalEgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalEgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalIngressBytesTransferred = (long?) content.GetValueForProperty("VpnClientConnectionHealthTotalIngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalIngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthVpnClientConnectionsCount = (int?) content.GetValueForProperty("VpnClientConnectionHealthVpnClientConnectionsCount",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthVpnClientConnectionsCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.P2SVpnGatewayProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal P2SVpnGatewayProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRoute = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("CustomRoute",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRoute, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("P2SVpnServerConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHub = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("VirtualHub",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHub, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace) content.GetValueForProperty("VpnClientAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AddressSpaceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealth = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVpnClientConnectionHealth) content.GetValueForProperty("VpnClientConnectionHealth",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealth, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VpnClientConnectionHealthTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnGatewayScaleUnit = (int?) content.GetValueForProperty("VpnGatewayScaleUnit",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnGatewayScaleUnit, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRouteAddressPrefix = (string[]) content.GetValueForProperty("CustomRouteAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).CustomRouteAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfigurationId = (string) content.GetValueForProperty("P2SVpnServerConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).P2SVpnServerConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHubId = (string) content.GetValueForProperty("VirtualHubId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VirtualHubId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPoolAddressPrefix = (string[]) content.GetValueForProperty("VpnClientAddressPoolAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientAddressPoolAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthAllocatedIPAddress = (string[]) content.GetValueForProperty("VpnClientConnectionHealthAllocatedIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthAllocatedIPAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalEgressBytesTransferred = (long?) content.GetValueForProperty("VpnClientConnectionHealthTotalEgressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalEgressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalIngressBytesTransferred = (long?) content.GetValueForProperty("VpnClientConnectionHealthTotalIngressBytesTransferred",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthTotalIngressBytesTransferred, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthVpnClientConnectionsCount = (int?) content.GetValueForProperty("VpnClientConnectionHealthVpnClientConnectionsCount",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IP2SVpnGatewayPropertiesInternal)this).VpnClientConnectionHealthVpnClientConnectionsCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters for P2SVpnGateway
    [System.ComponentModel.TypeConverter(typeof(P2SVpnGatewayPropertiesTypeConverter))]
    public partial interface IP2SVpnGatewayProperties

    {

    }
}