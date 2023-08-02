namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>Specifies the linux configuration for update management.</summary>
    [System.ComponentModel.TypeConverter(typeof(OSProfileLinuxConfigurationTypeConverter))]
    public partial class OSProfileLinuxConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.OSProfileLinuxConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OSProfileLinuxConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.OSProfileLinuxConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OSProfileLinuxConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OSProfileLinuxConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.OSProfileLinuxConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OSProfileLinuxConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSetting = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IPatchSettings) content.GetValueForProperty("PatchSetting",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSetting, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.PatchSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingAssessmentMode = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AssessmentModeTypes?) content.GetValueForProperty("PatchSettingAssessmentMode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingAssessmentMode, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AssessmentModeTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingPatchMode = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchModeTypes?) content.GetValueForProperty("PatchSettingPatchMode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingPatchMode, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchModeTypes.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.OSProfileLinuxConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OSProfileLinuxConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSetting = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IPatchSettings) content.GetValueForProperty("PatchSetting",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSetting, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.PatchSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingAssessmentMode = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AssessmentModeTypes?) content.GetValueForProperty("PatchSettingAssessmentMode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingAssessmentMode, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AssessmentModeTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingPatchMode = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchModeTypes?) content.GetValueForProperty("PatchSettingPatchMode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IOSProfileLinuxConfigurationInternal)this).PatchSettingPatchMode, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchModeTypes.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Specifies the linux configuration for update management.
    [System.ComponentModel.TypeConverter(typeof(OSProfileLinuxConfigurationTypeConverter))]
    public partial interface IOSProfileLinuxConfiguration

    {

    }
}