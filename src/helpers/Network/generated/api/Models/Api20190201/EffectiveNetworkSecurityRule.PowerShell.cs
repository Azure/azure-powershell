namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Effective network security rules.</summary>
    [System.ComponentModel.TypeConverter(typeof(EffectiveNetworkSecurityRuleTypeConverter))]
    public partial class EffectiveNetworkSecurityRule
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EffectiveNetworkSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EffectiveNetworkSecurityRule(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EffectiveNetworkSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EffectiveNetworkSecurityRule(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EffectiveNetworkSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EffectiveNetworkSecurityRule(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Access = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess?) content.GetValueForProperty("Access",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Access, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefix = (string) content.GetValueForProperty("DestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefixes = (string[]) content.GetValueForProperty("DestinationAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRange = (string) content.GetValueForProperty("DestinationPortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRanges = (string[]) content.GetValueForProperty("DestinationPortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Direction = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection?) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Direction, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedDestinationAddressPrefix = (string[]) content.GetValueForProperty("ExpandedDestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedDestinationAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedSourceAddressPrefix = (string[]) content.GetValueForProperty("ExpandedSourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedSourceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefix = (string) content.GetValueForProperty("SourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefixes = (string[]) content.GetValueForProperty("SourceAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRange = (string) content.GetValueForProperty("SourcePortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRanges = (string[]) content.GetValueForProperty("SourcePortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EffectiveNetworkSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EffectiveNetworkSecurityRule(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Access = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess?) content.GetValueForProperty("Access",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Access, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefix = (string) content.GetValueForProperty("DestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefixes = (string[]) content.GetValueForProperty("DestinationAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRange = (string) content.GetValueForProperty("DestinationPortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRanges = (string[]) content.GetValueForProperty("DestinationPortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).DestinationPortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Direction = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection?) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Direction, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedDestinationAddressPrefix = (string[]) content.GetValueForProperty("ExpandedDestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedDestinationAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedSourceAddressPrefix = (string[]) content.GetValueForProperty("ExpandedSourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).ExpandedSourceAddressPrefix, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefix = (string) content.GetValueForProperty("SourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefixes = (string[]) content.GetValueForProperty("SourceAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourceAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRange = (string) content.GetValueForProperty("SourcePortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRanges = (string[]) content.GetValueForProperty("SourcePortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).SourcePortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRuleInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EffectiveSecurityRuleProtocol.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EffectiveNetworkSecurityRule" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Effective network security rules.
    [System.ComponentModel.TypeConverter(typeof(EffectiveNetworkSecurityRuleTypeConverter))]
    public partial interface IEffectiveNetworkSecurityRule

    {

    }
}