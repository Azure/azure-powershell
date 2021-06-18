namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PowerShell;

    /// <summary>Security Rule data model for Network Security Groups.</summary>
    [System.ComponentModel.TypeConverter(typeof(NsgSecurityRuleTypeConverter))]
    public partial class NsgSecurityRule
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NsgSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NsgSecurityRule(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NsgSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NsgSecurityRule(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NsgSecurityRule" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRule FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NsgSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NsgSecurityRule(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Access = (string) content.GetValueForProperty("Access",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Access, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationAddressPrefix = (string) content.GetValueForProperty("DestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationPortRange = (string) content.GetValueForProperty("DestinationPortRange",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationPortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Direction = (string) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Direction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Protocol = (string) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Protocol, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourceAddressPrefix = (string) content.GetValueForProperty("SourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourceAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourcePortRange = (string) content.GetValueForProperty("SourcePortRange",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourcePortRange, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NsgSecurityRule"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NsgSecurityRule(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Access = (string) content.GetValueForProperty("Access",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Access, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationAddressPrefix = (string) content.GetValueForProperty("DestinationAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationPortRange = (string) content.GetValueForProperty("DestinationPortRange",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).DestinationPortRange, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Direction = (string) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Direction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Protocol = (string) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).Protocol, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourceAddressPrefix = (string) content.GetValueForProperty("SourceAddressPrefix",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourceAddressPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourcePortRange = (string) content.GetValueForProperty("SourcePortRange",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgSecurityRuleInternal)this).SourcePortRange, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Security Rule data model for Network Security Groups.
    [System.ComponentModel.TypeConverter(typeof(NsgSecurityRuleTypeConverter))]
    public partial interface INsgSecurityRule

    {

    }
}