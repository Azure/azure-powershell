namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Network security rule.</summary>
    [System.ComponentModel.TypeConverter(typeof(SecurityRuleTypeConverter))]
    public partial class SecurityRule
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SecurityRule(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SecurityRule(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SecurityRule" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SecurityRule(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRulePropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRulePropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationAddressPrefix = (string) content.GetValueForProperty("DestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationAddressPrefixes = (string[]) content.GetValueForProperty("PropertiesDestinationAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[]) content.GetValueForProperty("DestinationApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationPortRange = (string) content.GetValueForProperty("DestinationPortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationPortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationPortRanges = (string[]) content.GetValueForProperty("PropertiesDestinationPortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationPortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Direction = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Direction, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Access = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess) content.GetValueForProperty("Access",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Access, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceAddressPrefix = (string) content.GetValueForProperty("SourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourceAddressPrefixes = (string[]) content.GetValueForProperty("PropertiesSourceAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourceAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[]) content.GetValueForProperty("SourceApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourcePortRange = (string) content.GetValueForProperty("SourcePortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourcePortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourcePortRanges = (string[]) content.GetValueForProperty("PropertiesSourcePortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourcePortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SecurityRule(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRulePropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRulePropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationAddressPrefix = (string) content.GetValueForProperty("DestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationAddressPrefixes = (string[]) content.GetValueForProperty("PropertiesDestinationAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[]) content.GetValueForProperty("DestinationApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationPortRange = (string) content.GetValueForProperty("DestinationPortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).DestinationPortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationPortRanges = (string[]) content.GetValueForProperty("PropertiesDestinationPortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesDestinationPortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Direction = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Direction, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Access = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess) content.GetValueForProperty("Access",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Access, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceAddressPrefix = (string) content.GetValueForProperty("SourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourceAddressPrefixes = (string[]) content.GetValueForProperty("PropertiesSourceAddressPrefixes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourceAddressPrefixes, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[]) content.GetValueForProperty("SourceApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourceApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourcePortRange = (string) content.GetValueForProperty("SourcePortRange",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).SourcePortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourcePortRanges = (string[]) content.GetValueForProperty("PropertiesSourcePortRanges",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).PropertiesSourcePortRanges, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Network security rule.
    [System.ComponentModel.TypeConverter(typeof(SecurityRuleTypeConverter))]
    public partial interface ISecurityRule

    {

    }
}