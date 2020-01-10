namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>A web application firewall rule set.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayFirewallRuleSetTypeConverter))]
    public partial class ApplicationGatewayFirewallRuleSet
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationGatewayFirewallRuleSet(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleSetPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup[]) content.GetValueForProperty("RuleGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetType = (string) content.GetValueForProperty("RuleSetType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetVersion = (string) content.GetValueForProperty("RuleSetVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetVersion, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationGatewayFirewallRuleSet(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleSetPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup[]) content.GetValueForProperty("RuleGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetType = (string) content.GetValueForProperty("RuleSetType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetVersion = (string) content.GetValueForProperty("RuleSetVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSetInternal)this).RuleSetVersion, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSet"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSet DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationGatewayFirewallRuleSet(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayFirewallRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSet"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSet DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationGatewayFirewallRuleSet(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationGatewayFirewallRuleSet" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayFirewallRuleSet FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A web application firewall rule set.
    [System.ComponentModel.TypeConverter(typeof(ApplicationGatewayFirewallRuleSetTypeConverter))]
    public partial interface IApplicationGatewayFirewallRuleSet

    {

    }
}