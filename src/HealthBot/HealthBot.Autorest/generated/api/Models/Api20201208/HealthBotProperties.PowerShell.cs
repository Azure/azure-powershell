namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208
{
    using Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.PowerShell;

    /// <summary>
    /// The properties of a HealthBot. The Health Bot Service is a cloud platform that empowers developers in Healthcare organizations
    /// to build and deploy their compliant, AI-powered virtual health assistants and health bots, that help them improve processes
    /// and reduce costs.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(HealthBotPropertiesTypeConverter))]
    public partial class HealthBotProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBotProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HealthBotProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBotProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HealthBotProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HealthBotProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBotProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HealthBotProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).BotManagementPortalLink = (string) content.GetValueForProperty("BotManagementPortalLink",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).BotManagementPortalLink, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBotProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HealthBotProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).BotManagementPortalLink = (string) content.GetValueForProperty("BotManagementPortalLink",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal)this).BotManagementPortalLink, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The properties of a HealthBot. The Health Bot Service is a cloud platform that empowers developers in Healthcare organizations
    /// to build and deploy their compliant, AI-powered virtual health assistants and health bots, that help them improve processes
    /// and reduce costs.
    [System.ComponentModel.TypeConverter(typeof(HealthBotPropertiesTypeConverter))]
    public partial interface IHealthBotProperties

    {

    }
}