namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>InMageAzureV2 specific provider input.</summary>
    [System.ComponentModel.TypeConverter(typeof(InMageReprotectInputTypeConverter))]
    public partial class InMageReprotectInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageReprotectInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InMageReprotectInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageReprotectInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InMageReprotectInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InMageReprotectInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageReprotectInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InMageReprotectInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInput) content.GetValueForProperty("DiskExclusionInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageDiskExclusionInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).MasterTargetId = (string) content.GetValueForProperty("MasterTargetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).MasterTargetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProcessServerId = (string) content.GetValueForProperty("ProcessServerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProcessServerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RetentionDrive = (string) content.GetValueForProperty("RetentionDrive",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RetentionDrive, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DatastoreName = (string) content.GetValueForProperty("DatastoreName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DatastoreName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProfileId = (string) content.GetValueForProperty("ProfileId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DisksToInclude = (string[]) content.GetValueForProperty("DisksToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DisksToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputVolumeOption = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[]) content.GetValueForProperty("DiskExclusionInputVolumeOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputVolumeOption, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageVolumeExclusionOptionsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputDiskSignatureOption = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[]) content.GetValueForProperty("DiskExclusionInputDiskSignatureOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputDiskSignatureOption, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageDiskSignatureExclusionOptionsTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageReprotectInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InMageReprotectInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInput = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskExclusionInput) content.GetValueForProperty("DiskExclusionInput",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInput, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageDiskExclusionInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).MasterTargetId = (string) content.GetValueForProperty("MasterTargetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).MasterTargetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProcessServerId = (string) content.GetValueForProperty("ProcessServerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProcessServerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RetentionDrive = (string) content.GetValueForProperty("RetentionDrive",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RetentionDrive, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RunAsAccountId = (string) content.GetValueForProperty("RunAsAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).RunAsAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DatastoreName = (string) content.GetValueForProperty("DatastoreName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DatastoreName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProfileId = (string) content.GetValueForProperty("ProfileId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).ProfileId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DisksToInclude = (string[]) content.GetValueForProperty("DisksToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DisksToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReverseReplicationProviderSpecificInputInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputVolumeOption = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions[]) content.GetValueForProperty("DiskExclusionInputVolumeOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputVolumeOption, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageVolumeExclusionOptions>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageVolumeExclusionOptionsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputDiskSignatureOption = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions[]) content.GetValueForProperty("DiskExclusionInputDiskSignatureOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageReprotectInputInternal)this).DiskExclusionInputDiskSignatureOption, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageDiskSignatureExclusionOptions>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageDiskSignatureExclusionOptionsTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// InMageAzureV2 specific provider input.
    [System.ComponentModel.TypeConverter(typeof(InMageReprotectInputTypeConverter))]
    public partial interface IInMageReprotectInput

    {

    }
}