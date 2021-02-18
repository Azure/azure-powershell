namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Hyper V Replica Azure provider specific settings.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVReplicaAzureReplicationDetailsTypeConverter))]
    public partial class HyperVReplicaAzureReplicationDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVReplicaAzureReplicationDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVReplicaAzureReplicationDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVReplicaAzureReplicationDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVReplicaAzureReplicationDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails) content.GetValueForProperty("InitialReplicationDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails) content.GetValueForProperty("OSDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).AzureVMDiskDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[]) content.GetValueForProperty("AzureVMDiskDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).AzureVMDiskDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureVMDiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMName = (string) content.GetValueForProperty("RecoveryAzureVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMSize = (string) content.GetValueForProperty("RecoveryAzureVMSize",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureStorageAccount = (string) content.GetValueForProperty("RecoveryAzureStorageAccount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureStorageAccount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureLogStorageAccountId = (string) content.GetValueForProperty("RecoveryAzureLogStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureLogStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastReplicatedTime = (global::System.DateTime?) content.GetValueForProperty("LastReplicatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastReplicatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RpoInSecond = (long?) content.GetValueForProperty("RpoInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RpoInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastRpoCalculatedTime = (global::System.DateTime?) content.GetValueForProperty("LastRpoCalculatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastRpoCalculatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMId = (string) content.GetValueForProperty("VMId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionState = (string) content.GetValueForProperty("VMProtectionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionStateDescription = (string) content.GetValueForProperty("VMProtectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMNic = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[]) content.GetValueForProperty("VMNic",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMNic, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId = (string) content.GetValueForProperty("SelectedRecoveryAzureNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedSourceNicId = (string) content.GetValueForProperty("SelectedSourceNicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedSourceNicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).Encryption = (string) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).Encryption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMRamSizeInMb = (int?) content.GetValueForProperty("SourceVMRamSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMRamSizeInMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMCpuCount = (int?) content.GetValueForProperty("SourceVMCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).EnableRdpOnTargetOption = (string) content.GetValueForProperty("EnableRdpOnTargetOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).EnableRdpOnTargetOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureResourceGroupId = (string) content.GetValueForProperty("RecoveryAzureResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAvailabilitySetId = (string) content.GetValueForProperty("RecoveryAvailabilitySetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAvailabilitySetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).UseManagedDisk = (string) content.GetValueForProperty("UseManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).UseManagedDisk, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LicenseType = (string) content.GetValueForProperty("LicenseType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LicenseType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOstype = (string) content.GetValueForProperty("OSDetailOstype",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOstype, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailProductType = (string) content.GetValueForProperty("OSDetailProductType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailProductType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsedition = (string) content.GetValueForProperty("OSDetailOsedition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsedition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationType = (string) content.GetValueForProperty("InitialReplicationDetailInitialReplicationType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationProgressPercentage = (string) content.GetValueForProperty("InitialReplicationDetailInitialReplicationProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationProgressPercentage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsversion = (string) content.GetValueForProperty("OSDetailOsversion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsversion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsmajorVersion = (string) content.GetValueForProperty("OSDetailOsmajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsmajorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsminorVersion = (string) content.GetValueForProperty("OSDetailOsminorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsminorVersion, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HyperVReplicaAzureReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVReplicaAzureReplicationDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInitialReplicationDetails) content.GetValueForProperty("InitialReplicationDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InitialReplicationDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails) content.GetValueForProperty("OSDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).AzureVMDiskDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails[]) content.GetValueForProperty("AzureVMDiskDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).AzureVMDiskDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureVMDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureVMDiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMName = (string) content.GetValueForProperty("RecoveryAzureVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMSize = (string) content.GetValueForProperty("RecoveryAzureVMSize",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureVMSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureStorageAccount = (string) content.GetValueForProperty("RecoveryAzureStorageAccount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureStorageAccount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureLogStorageAccountId = (string) content.GetValueForProperty("RecoveryAzureLogStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureLogStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastReplicatedTime = (global::System.DateTime?) content.GetValueForProperty("LastReplicatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastReplicatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RpoInSecond = (long?) content.GetValueForProperty("RpoInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RpoInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastRpoCalculatedTime = (global::System.DateTime?) content.GetValueForProperty("LastRpoCalculatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LastRpoCalculatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMId = (string) content.GetValueForProperty("VMId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionState = (string) content.GetValueForProperty("VMProtectionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionStateDescription = (string) content.GetValueForProperty("VMProtectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMProtectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMNic = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[]) content.GetValueForProperty("VMNic",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).VMNic, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId = (string) content.GetValueForProperty("SelectedRecoveryAzureNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedSourceNicId = (string) content.GetValueForProperty("SelectedSourceNicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SelectedSourceNicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).Encryption = (string) content.GetValueForProperty("Encryption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).Encryption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMRamSizeInMb = (int?) content.GetValueForProperty("SourceVMRamSizeInMb",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMRamSizeInMb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMCpuCount = (int?) content.GetValueForProperty("SourceVMCpuCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).SourceVMCpuCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).EnableRdpOnTargetOption = (string) content.GetValueForProperty("EnableRdpOnTargetOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).EnableRdpOnTargetOption, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureResourceGroupId = (string) content.GetValueForProperty("RecoveryAzureResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAzureResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAvailabilitySetId = (string) content.GetValueForProperty("RecoveryAvailabilitySetId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).RecoveryAvailabilitySetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).UseManagedDisk = (string) content.GetValueForProperty("UseManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).UseManagedDisk, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LicenseType = (string) content.GetValueForProperty("LicenseType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).LicenseType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOstype = (string) content.GetValueForProperty("OSDetailOstype",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOstype, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailProductType = (string) content.GetValueForProperty("OSDetailProductType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailProductType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsedition = (string) content.GetValueForProperty("OSDetailOsedition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsedition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationType = (string) content.GetValueForProperty("InitialReplicationDetailInitialReplicationType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationProgressPercentage = (string) content.GetValueForProperty("InitialReplicationDetailInitialReplicationProgressPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).InitialReplicationDetailInitialReplicationProgressPercentage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsversion = (string) content.GetValueForProperty("OSDetailOsversion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsversion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsmajorVersion = (string) content.GetValueForProperty("OSDetailOsmajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsmajorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsminorVersion = (string) content.GetValueForProperty("OSDetailOsminorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplicaAzureReplicationDetailsInternal)this).OSDetailOsminorVersion, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Hyper V Replica Azure provider specific settings.
    [System.ComponentModel.TypeConverter(typeof(HyperVReplicaAzureReplicationDetailsTypeConverter))]
    public partial interface IHyperVReplicaAzureReplicationDetails

    {

    }
}