namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Config server git properties payload</summary>
    [System.ComponentModel.TypeConverter(typeof(ConfigServerPropertiesTypeConverter))]
    public partial class ConfigServerProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConfigServerProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServer = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerSettings) content.GetValueForProperty("ConfigServer",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServer, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServerGitProperty = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitProperty) content.GetValueForProperty("ConfigServerGitProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServerGitProperty, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerGitPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyRepository = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository[]) content.GetValueForProperty("GitPropertyRepository",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyRepository, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.GitPatternRepositoryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUri = (string) content.GetValueForProperty("GitPropertyUri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyLabel = (string) content.GetValueForProperty("GitPropertyLabel",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertySearchPath = (string[]) content.GetValueForProperty("GitPropertySearchPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertySearchPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUsername = (string) content.GetValueForProperty("GitPropertyUsername",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPassword = (string) content.GetValueForProperty("GitPropertyPassword",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKey = (string) content.GetValueForProperty("GitPropertyHostKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPrivateKey = (string) content.GetValueForProperty("GitPropertyPrivateKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPrivateKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKeyAlgorithm = (string) content.GetValueForProperty("GitPropertyHostKeyAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKeyAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyStrictHostKeyChecking = (bool?) content.GetValueForProperty("GitPropertyStrictHostKeyChecking",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyStrictHostKeyChecking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConfigServerProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServer = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerSettings) content.GetValueForProperty("ConfigServer",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServer, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServerGitProperty = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerGitProperty) content.GetValueForProperty("ConfigServerGitProperty",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).ConfigServerGitProperty, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerGitPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyRepository = (Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository[]) content.GetValueForProperty("GitPropertyRepository",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyRepository, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IGitPatternRepository>(__y, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.GitPatternRepositoryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUri = (string) content.GetValueForProperty("GitPropertyUri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyLabel = (string) content.GetValueForProperty("GitPropertyLabel",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertySearchPath = (string[]) content.GetValueForProperty("GitPropertySearchPath",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertySearchPath, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUsername = (string) content.GetValueForProperty("GitPropertyUsername",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPassword = (string) content.GetValueForProperty("GitPropertyPassword",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKey = (string) content.GetValueForProperty("GitPropertyHostKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPrivateKey = (string) content.GetValueForProperty("GitPropertyPrivateKey",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyPrivateKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKeyAlgorithm = (string) content.GetValueForProperty("GitPropertyHostKeyAlgorithm",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyHostKeyAlgorithm, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyStrictHostKeyChecking = (bool?) content.GetValueForProperty("GitPropertyStrictHostKeyChecking",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerPropertiesInternal)this).GitPropertyStrictHostKeyChecking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConfigServerProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ConfigServerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConfigServerProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConfigServerProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IConfigServerProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Config server git properties payload
    [System.ComponentModel.TypeConverter(typeof(ConfigServerPropertiesTypeConverter))]
    public partial interface IConfigServerProperties

    {

    }
}