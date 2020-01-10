namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of the Azure Firewall.</summary>
    [System.ComponentModel.TypeConverter(typeof(AzureFirewallPropertiesFormatTypeConverter))]
    public partial class AzureFirewallPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureFirewallPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ApplicationRuleCollection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection[]) content.GetValueForProperty("ApplicationRuleCollection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ApplicationRuleCollection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallApplicationRuleCollectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NatRuleCollection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection[]) content.GetValueForProperty("NatRuleCollection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NatRuleCollection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallNatRuleCollectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NetworkRuleCollection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection[]) content.GetValueForProperty("NetworkRuleCollection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NetworkRuleCollection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallNetworkRuleCollectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ThreatIntelMode = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode?) content.GetValueForProperty("ThreatIntelMode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ThreatIntelMode, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureFirewallPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ApplicationRuleCollection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection[]) content.GetValueForProperty("ApplicationRuleCollection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ApplicationRuleCollection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallApplicationRuleCollectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NatRuleCollection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection[]) content.GetValueForProperty("NatRuleCollection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NatRuleCollection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallNatRuleCollectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NetworkRuleCollection = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection[]) content.GetValueForProperty("NetworkRuleCollection",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).NetworkRuleCollection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallNetworkRuleCollectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ThreatIntelMode = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode?) content.GetValueForProperty("ThreatIntelMode",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormatInternal)this).ThreatIntelMode, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureFirewallPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.AzureFirewallPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureFirewallPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureFirewallPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the Azure Firewall.
    [System.ComponentModel.TypeConverter(typeof(AzureFirewallPropertiesFormatTypeConverter))]
    public partial interface IAzureFirewallPropertiesFormat

    {

    }
}