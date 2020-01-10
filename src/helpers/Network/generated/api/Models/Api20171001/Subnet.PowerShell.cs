namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Subnet in a virtual network resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(SubnetTypeConverter))]
    public partial class Subnet
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Subnet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Subnet(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Subnet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Subnet(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Subnet" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Subnet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Subnet(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTable = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTable) content.GetValueForProperty("RouteTable",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTable, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteTableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Nsg = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup) content.GetValueForProperty("Nsg",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Nsg, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).AddressPrefix = (string) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).AddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceNavigationLink = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink[]) content.GetValueForProperty("ResourceNavigationLink",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceNavigationLink, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceNavigationLinkTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ServiceEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat[]) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ServiceEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ServiceEndpointPropertiesFormatTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableEtag = (string) content.GetValueForProperty("RouteTableEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgEtag = (string) content.GetValueForProperty("NsgEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgLocation = (string) content.GetValueForProperty("NsgLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("NsgTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat) content.GetValueForProperty("NsgProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgName = (string) content.GetValueForProperty("NsgName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgType = (string) content.GetValueForProperty("NsgType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgId = (string) content.GetValueForProperty("NsgId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableType = (string) content.GetValueForProperty("RouteTableType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableId = (string) content.GetValueForProperty("RouteTableId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableLocation = (string) content.GetValueForProperty("RouteTableLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("RouteTableTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTablePropertiesFormat) content.GetValueForProperty("RouteTableProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteTablePropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableName = (string) content.GetValueForProperty("RouteTableName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesProvisioningState = (string) content.GetValueForProperty("NsgPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).SecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("SecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).SecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesSubnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[]) content.GetValueForProperty("RouteTablePropertiesSubnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesSubnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DefaultSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("DefaultSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DefaultSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DisableBgpRoutePropagation = (bool?) content.GetValueForProperty("DisableBgpRoutePropagation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DisableBgpRoutePropagation, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesProvisioningState = (string) content.GetValueForProperty("RouteTablePropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesSubnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[]) content.GetValueForProperty("NsgPropertiesSubnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesSubnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Subnet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Subnet(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTable = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTable) content.GetValueForProperty("RouteTable",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTable, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteTableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Nsg = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup) content.GetValueForProperty("Nsg",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Nsg, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).AddressPrefix = (string) content.GetValueForProperty("AddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).AddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceNavigationLink = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink[]) content.GetValueForProperty("ResourceNavigationLink",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceNavigationLink, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceNavigationLink>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceNavigationLinkTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ServiceEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat[]) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ServiceEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IServiceEndpointPropertiesFormat>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ServiceEndpointPropertiesFormatTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableEtag = (string) content.GetValueForProperty("RouteTableEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgEtag = (string) content.GetValueForProperty("NsgEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgLocation = (string) content.GetValueForProperty("NsgLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("NsgTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat) content.GetValueForProperty("NsgProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgName = (string) content.GetValueForProperty("NsgName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgType = (string) content.GetValueForProperty("NsgType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgId = (string) content.GetValueForProperty("NsgId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableType = (string) content.GetValueForProperty("RouteTableType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableId = (string) content.GetValueForProperty("RouteTableId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableLocation = (string) content.GetValueForProperty("RouteTableLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("RouteTableTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteTablePropertiesFormat) content.GetValueForProperty("RouteTableProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteTablePropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableName = (string) content.GetValueForProperty("RouteTableName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesProvisioningState = (string) content.GetValueForProperty("NsgPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).SecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("SecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).SecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesSubnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[]) content.GetValueForProperty("RouteTablePropertiesSubnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesSubnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DefaultSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("DefaultSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DefaultSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DisableBgpRoutePropagation = (bool?) content.GetValueForProperty("DisableBgpRoutePropagation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).DisableBgpRoutePropagation, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesProvisioningState = (string) content.GetValueForProperty("RouteTablePropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).RouteTablePropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Route = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute[]) content.GetValueForProperty("Route",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).Route, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRoute>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesSubnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[]) content.GetValueForProperty("NsgPropertiesSubnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnetInternal)this).NsgPropertiesSubnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Subnet in a virtual network resource.
    [System.ComponentModel.TypeConverter(typeof(SubnetTypeConverter))]
    public partial interface ISubnet

    {

    }
}