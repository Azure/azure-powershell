namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Contains IPv6 peering config.</summary>
    [System.ComponentModel.TypeConverter(typeof(Ipv6ExpressRouteCircuitPeeringConfigTypeConverter))]
    public partial class Ipv6ExpressRouteCircuitPeeringConfig
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Ipv6ExpressRouteCircuitPeeringConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfig"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfig DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Ipv6ExpressRouteCircuitPeeringConfig(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Ipv6ExpressRouteCircuitPeeringConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfig"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfig DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Ipv6ExpressRouteCircuitPeeringConfig(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Ipv6ExpressRouteCircuitPeeringConfig" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfig FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Ipv6ExpressRouteCircuitPeeringConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Ipv6ExpressRouteCircuitPeeringConfig(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfig = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringConfig) content.GetValueForProperty("MicrosoftPeeringConfig",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfig, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilter = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilter) content.GetValueForProperty("RouteFilter",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilter, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).PrimaryPeerAddressPrefix = (string) content.GetValueForProperty("PrimaryPeerAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).PrimaryPeerAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).SecondaryPeerAddressPrefix = (string) content.GetValueForProperty("SecondaryPeerAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).SecondaryPeerAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterEtag = (string) content.GetValueForProperty("RouteFilterEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterId = (string) content.GetValueForProperty("RouteFilterId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefixesState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?) content.GetValueForProperty("MicrosoftPeeringConfigAdvertisedPublicPrefixesState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefixesState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigCustomerAsn = (int?) content.GetValueForProperty("MicrosoftPeeringConfigCustomerAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigCustomerAsn, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigLegacyMode = (int?) content.GetValueForProperty("MicrosoftPeeringConfigLegacyMode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigLegacyMode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigRoutingRegistryName = (string) content.GetValueForProperty("MicrosoftPeeringConfigRoutingRegistryName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigRoutingRegistryName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterName = (string) content.GetValueForProperty("RouteFilterName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterType = (string) content.GetValueForProperty("RouteFilterType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefix = (string[]) content.GetValueForProperty("MicrosoftPeeringConfigAdvertisedPublicPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterLocation = (string) content.GetValueForProperty("RouteFilterLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("RouteFilterTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat) content.GetValueForProperty("RouteFilterProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedCommunity = (string[]) content.GetValueForProperty("MicrosoftPeeringConfigAdvertisedCommunity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedCommunity, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Peering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[]) content.GetValueForProperty("Peering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Peering, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Rule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[]) content.GetValueForProperty("Rule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Rule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterRuleTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Ipv6ExpressRouteCircuitPeeringConfig"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Ipv6ExpressRouteCircuitPeeringConfig(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfig = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeeringConfig) content.GetValueForProperty("MicrosoftPeeringConfig",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfig, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilter = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilter) content.GetValueForProperty("RouteFilter",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilter, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).PrimaryPeerAddressPrefix = (string) content.GetValueForProperty("PrimaryPeerAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).PrimaryPeerAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).SecondaryPeerAddressPrefix = (string) content.GetValueForProperty("SecondaryPeerAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).SecondaryPeerAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterEtag = (string) content.GetValueForProperty("RouteFilterEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterId = (string) content.GetValueForProperty("RouteFilterId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefixesState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?) content.GetValueForProperty("MicrosoftPeeringConfigAdvertisedPublicPrefixesState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefixesState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigCustomerAsn = (int?) content.GetValueForProperty("MicrosoftPeeringConfigCustomerAsn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigCustomerAsn, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigLegacyMode = (int?) content.GetValueForProperty("MicrosoftPeeringConfigLegacyMode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigLegacyMode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigRoutingRegistryName = (string) content.GetValueForProperty("MicrosoftPeeringConfigRoutingRegistryName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigRoutingRegistryName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterName = (string) content.GetValueForProperty("RouteFilterName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterType = (string) content.GetValueForProperty("RouteFilterType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefix = (string[]) content.GetValueForProperty("MicrosoftPeeringConfigAdvertisedPublicPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedPublicPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterLocation = (string) content.GetValueForProperty("RouteFilterLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("RouteFilterTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterPropertiesFormat) content.GetValueForProperty("RouteFilterProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).RouteFilterProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedCommunity = (string[]) content.GetValueForProperty("MicrosoftPeeringConfigAdvertisedCommunity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).MicrosoftPeeringConfigAdvertisedCommunity, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Peering = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[]) content.GetValueForProperty("Peering",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Peering, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitPeeringTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Rule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule[]) content.GetValueForProperty("Rule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIpv6ExpressRouteCircuitPeeringConfigInternal)this).Rule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IRouteFilterRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.RouteFilterRuleTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Contains IPv6 peering config.
    [System.ComponentModel.TypeConverter(typeof(Ipv6ExpressRouteCircuitPeeringConfigTypeConverter))]
    public partial interface IIpv6ExpressRouteCircuitPeeringConfig

    {

    }
}