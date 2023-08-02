namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>
    /// Configurable properties that the user can set locally via the azcmagent config command, or remotely via ARM.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(AgentConfigurationTypeConverter))]
    public partial class AgentConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AgentConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyUrl = (string) content.GetValueForProperty("ProxyUrl",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).IncomingConnectionsPort = (string[]) content.GetValueForProperty("IncomingConnectionsPort",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).IncomingConnectionsPort, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsAllowList = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension[]) content.GetValueForProperty("ExtensionsAllowList",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsAllowList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.ConfigurationExtensionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsBlockList = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension[]) content.GetValueForProperty("ExtensionsBlockList",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsBlockList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.ConfigurationExtensionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyBypass = (string[]) content.GetValueForProperty("ProxyBypass",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyBypass, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsEnabled = (string) content.GetValueForProperty("ExtensionsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsEnabled, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).GuestConfigurationEnabled = (string) content.GetValueForProperty("GuestConfigurationEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).GuestConfigurationEnabled, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ConfigMode = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AgentConfigurationMode?) content.GetValueForProperty("ConfigMode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ConfigMode, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AgentConfigurationMode.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AgentConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyUrl = (string) content.GetValueForProperty("ProxyUrl",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).IncomingConnectionsPort = (string[]) content.GetValueForProperty("IncomingConnectionsPort",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).IncomingConnectionsPort, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsAllowList = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension[]) content.GetValueForProperty("ExtensionsAllowList",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsAllowList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.ConfigurationExtensionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsBlockList = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension[]) content.GetValueForProperty("ExtensionsBlockList",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsBlockList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IConfigurationExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.ConfigurationExtensionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyBypass = (string[]) content.GetValueForProperty("ProxyBypass",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ProxyBypass, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsEnabled = (string) content.GetValueForProperty("ExtensionsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ExtensionsEnabled, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).GuestConfigurationEnabled = (string) content.GetValueForProperty("GuestConfigurationEnabled",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).GuestConfigurationEnabled, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ConfigMode = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AgentConfigurationMode?) content.GetValueForProperty("ConfigMode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfigurationInternal)this).ConfigMode, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AgentConfigurationMode.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AgentConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AgentConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AgentConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AgentConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAgentConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Configurable properties that the user can set locally via the azcmagent config command, or remotely via ARM.
    [System.ComponentModel.TypeConverter(typeof(AgentConfigurationTypeConverter))]
    public partial interface IAgentConfiguration

    {

    }
}