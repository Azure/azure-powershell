namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>The info w.r.t Agent Upgrade.</summary>
    [System.ComponentModel.TypeConverter(typeof(AgentUpgradeTypeConverter))]
    public partial class AgentUpgrade
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentUpgrade"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AgentUpgrade(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).DesiredVersion = (string) content.GetValueForProperty("DesiredVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).DesiredVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).CorrelationId = (string) content.GetValueForProperty("CorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).CorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).EnableAutomaticUpgrade = (bool?) content.GetValueForProperty("EnableAutomaticUpgrade",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).EnableAutomaticUpgrade, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptTimestamp = (string) content.GetValueForProperty("LastAttemptTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.LastAttemptStatusEnum?) content.GetValueForProperty("LastAttemptStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.LastAttemptStatusEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptMessage = (string) content.GetValueForProperty("LastAttemptMessage",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptMessage, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentUpgrade"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AgentUpgrade(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).DesiredVersion = (string) content.GetValueForProperty("DesiredVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).DesiredVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).CorrelationId = (string) content.GetValueForProperty("CorrelationId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).CorrelationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).EnableAutomaticUpgrade = (bool?) content.GetValueForProperty("EnableAutomaticUpgrade",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).EnableAutomaticUpgrade, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptTimestamp = (string) content.GetValueForProperty("LastAttemptTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptTimestamp, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.LastAttemptStatusEnum?) content.GetValueForProperty("LastAttemptStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.LastAttemptStatusEnum.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptMessage = (string) content.GetValueForProperty("LastAttemptMessage",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgradeInternal)this).LastAttemptMessage, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentUpgrade"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgrade" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgrade DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AgentUpgrade(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentUpgrade"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgrade" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgrade DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AgentUpgrade(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AgentUpgrade" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentUpgrade FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The info w.r.t Agent Upgrade.
    [System.ComponentModel.TypeConverter(typeof(AgentUpgradeTypeConverter))]
    public partial interface IAgentUpgrade

    {

    }
}