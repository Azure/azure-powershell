namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Single Host fabric provider specific VM settings.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVVirtualMachineDetailsTypeConverter))]
    public partial class HyperVVirtualMachineDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVVirtualMachineDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVVirtualMachineDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVVirtualMachineDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVVirtualMachineDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVVirtualMachineDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVVirtualMachineDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVVirtualMachineDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails) content.GetValueForProperty("OSDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).SourceItemId = (string) content.GetValueForProperty("SourceItemId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).SourceItemId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).Generation = (string) content.GetValueForProperty("Generation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).Generation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).DiskDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[]) content.GetValueForProperty("DiskDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).DiskDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasPhysicalDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus?) content.GetValueForProperty("HasPhysicalDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasPhysicalDisk, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasFibreChannelAdapter = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus?) content.GetValueForProperty("HasFibreChannelAdapter",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasFibreChannelAdapter, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasSharedVhd = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus?) content.GetValueForProperty("HasSharedVhd",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasSharedVhd, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOstype = (string) content.GetValueForProperty("OSDetailOstype",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOstype, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailProductType = (string) content.GetValueForProperty("OSDetailProductType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailProductType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsedition = (string) content.GetValueForProperty("OSDetailOsedition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsedition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsversion = (string) content.GetValueForProperty("OSDetailOsversion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsversion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsmajorVersion = (string) content.GetValueForProperty("OSDetailOsmajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsmajorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsminorVersion = (string) content.GetValueForProperty("OSDetailOsminorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsminorVersion, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVVirtualMachineDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVVirtualMachineDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails) content.GetValueForProperty("OSDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).SourceItemId = (string) content.GetValueForProperty("SourceItemId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).SourceItemId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).Generation = (string) content.GetValueForProperty("Generation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).Generation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).DiskDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails[]) content.GetValueForProperty("DiskDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).DiskDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.DiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasPhysicalDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus?) content.GetValueForProperty("HasPhysicalDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasPhysicalDisk, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasFibreChannelAdapter = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus?) content.GetValueForProperty("HasFibreChannelAdapter",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasFibreChannelAdapter, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasSharedVhd = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus?) content.GetValueForProperty("HasSharedVhd",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).HasSharedVhd, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.PresenceStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOstype = (string) content.GetValueForProperty("OSDetailOstype",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOstype, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailProductType = (string) content.GetValueForProperty("OSDetailProductType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailProductType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsedition = (string) content.GetValueForProperty("OSDetailOsedition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsedition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsversion = (string) content.GetValueForProperty("OSDetailOsversion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsversion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsmajorVersion = (string) content.GetValueForProperty("OSDetailOsmajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsmajorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsminorVersion = (string) content.GetValueForProperty("OSDetailOsminorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVVirtualMachineDetailsInternal)this).OSDetailOsminorVersion, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Single Host fabric provider specific VM settings.
    [System.ComponentModel.TypeConverter(typeof(HyperVVirtualMachineDetailsTypeConverter))]
    public partial interface IHyperVVirtualMachineDetails

    {

    }
}