namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Network rule set</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkRuleSetTypeConverter))]
    public partial class NetworkRuleSet
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkRuleSet(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkRuleSet(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkRuleSet" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSet FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkRuleSet(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).Bypass = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass?) content.GetValueForProperty("Bypass",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).Bypass, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).VirtualNetworkRule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[]) content.GetValueForProperty("VirtualNetworkRule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).VirtualNetworkRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.VirtualNetworkRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).IPRule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[]) content.GetValueForProperty("IPRule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).IPRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IPRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).DefaultAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction) content.GetValueForProperty("DefaultAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).DefaultAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.NetworkRuleSet"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkRuleSet(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).Bypass = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass?) content.GetValueForProperty("Bypass",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).Bypass, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Bypass.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).VirtualNetworkRule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule[]) content.GetValueForProperty("VirtualNetworkRule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).VirtualNetworkRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.VirtualNetworkRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).IPRule = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule[]) content.GetValueForProperty("IPRule",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).IPRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IIPRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IPRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).DefaultAction = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction) content.GetValueForProperty("DefaultAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.INetworkRuleSetInternal)this).DefaultAction, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.DefaultAction.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Network rule set
    [System.ComponentModel.TypeConverter(typeof(NetworkRuleSetTypeConverter))]
    public partial interface INetworkRuleSet

    {

    }
}