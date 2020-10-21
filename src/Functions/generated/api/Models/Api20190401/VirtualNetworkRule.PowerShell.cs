namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Virtual Network rule.</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkRuleTypeConverter))]
    public partial class VirtualNetworkRule
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.VirtualNetworkRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualNetworkRule(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.VirtualNetworkRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualNetworkRule(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualNetworkRule" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRule FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.VirtualNetworkRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualNetworkRule(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).VirtualNetworkResourceId = (string) content.GetValueForProperty("VirtualNetworkResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).VirtualNetworkResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).Action = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action?) content.GetValueForProperty("Action",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).Action, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.VirtualNetworkRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualNetworkRule(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).VirtualNetworkResourceId = (string) content.GetValueForProperty("VirtualNetworkResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).VirtualNetworkResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).Action = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action?) content.GetValueForProperty("Action",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).Action, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Action.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IVirtualNetworkRuleInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.State.CreateFrom);
            AfterDeserializePSObject(content);
        }
    }
    /// Virtual Network rule.
    [System.ComponentModel.TypeConverter(typeof(VirtualNetworkRuleTypeConverter))]
    public partial interface IVirtualNetworkRule

    {

    }
}