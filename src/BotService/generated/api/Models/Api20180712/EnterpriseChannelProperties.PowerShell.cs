namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.PowerShell;

    /// <summary>The parameters to provide for the Enterprise Channel.</summary>
    [System.ComponentModel.TypeConverter(typeof(EnterpriseChannelPropertiesTypeConverter))]
    public partial class EnterpriseChannelProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EnterpriseChannelProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EnterpriseChannelProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EnterpriseChannelProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).Node = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[]) content.GetValueForProperty("Node",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).Node, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode>(__y, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelNodeTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EnterpriseChannelProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).Node = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[]) content.GetValueForProperty("Node",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal)this).Node, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode>(__y, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.EnterpriseChannelNodeTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EnterpriseChannelProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The parameters to provide for the Enterprise Channel.
    [System.ComponentModel.TypeConverter(typeof(EnterpriseChannelPropertiesTypeConverter))]
    public partial interface IEnterpriseChannelProperties

    {

    }
}