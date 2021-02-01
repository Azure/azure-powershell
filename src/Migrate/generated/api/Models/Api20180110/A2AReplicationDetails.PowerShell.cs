namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>A2A provider specific settings.</summary>
    [System.ComponentModel.TypeConverter(typeof(A2AReplicationDetailsTypeConverter))]
    public partial class A2AReplicationDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal A2AReplicationDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails) content.GetValueForProperty("VMSyncedConfigDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).FabricObjectId = (string) content.GetValueForProperty("FabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).FabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupId = (string) content.GetValueForProperty("MultiVMGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupName = (string) content.GetValueForProperty("MultiVMGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupCreateOption = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption?) content.GetValueForProperty("MultiVMGroupCreateOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupCreateOption, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ManagementId = (string) content.GetValueForProperty("ManagementId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ManagementId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails[]) content.GetValueForProperty("ProtectedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedDiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedManagedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedManagedDiskDetails[]) content.GetValueForProperty("ProtectedManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedManagedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedManagedDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedManagedDiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryBootDiagStorageAccountId = (string) content.GetValueForProperty("RecoveryBootDiagStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryBootDiagStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).PrimaryFabricLocation = (string) content.GetValueForProperty("PrimaryFabricLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).PrimaryFabricLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricLocation = (string) content.GetValueForProperty("RecoveryFabricLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMSize = (string) content.GetValueForProperty("RecoveryAzureVMSize",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMName = (string) content.GetValueForProperty("RecoveryAzureVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureResourceGroupId = (string) content.GetValueForProperty("RecoveryAzureResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryCloudService = (string) content.GetValueForProperty("RecoveryCloudService",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryCloudService, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAvailabilitySet = (string) content.GetValueForProperty("RecoveryAvailabilitySet",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAvailabilitySet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId = (string) content.GetValueForProperty("SelectedRecoveryAzureNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMNic = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[]) content.GetValueForProperty("VMNic",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMNic, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringPercentageCompletion = (int?) content.GetValueForProperty("MonitoringPercentageCompletion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringPercentageCompletion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringJobType = (string) content.GetValueForProperty("MonitoringJobType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringJobType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).IsReplicationAgentUpdateRequired = (bool?) content.GetValueForProperty("IsReplicationAgentUpdateRequired",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).IsReplicationAgentUpdateRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricObjectId = (string) content.GetValueForProperty("RecoveryFabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionState = (string) content.GetValueForProperty("VMProtectionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionStateDescription = (string) content.GetValueForProperty("VMProtectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LifecycleId = (string) content.GetValueForProperty("LifecycleId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LifecycleId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).TestFailoverRecoveryFabricObjectId = (string) content.GetValueForProperty("TestFailoverRecoveryFabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).TestFailoverRecoveryFabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RpoInSecond = (long?) content.GetValueForProperty("RpoInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RpoInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastRpoCalculatedTime = (global::System.DateTime?) content.GetValueForProperty("LastRpoCalculatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastRpoCalculatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailTag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags) content.GetValueForProperty("VMSyncedConfigDetailTag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailTag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetailsTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailRoleAssignment = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[]) content.GetValueForProperty("VMSyncedConfigDetailRoleAssignment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailRoleAssignment, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RoleAssignmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailInputEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[]) content.GetValueForProperty("VMSyncedConfigDetailInputEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailInputEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InputEndpointTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal A2AReplicationDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetails) content.GetValueForProperty("VMSyncedConfigDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).FabricObjectId = (string) content.GetValueForProperty("FabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).FabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupId = (string) content.GetValueForProperty("MultiVMGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupName = (string) content.GetValueForProperty("MultiVMGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupCreateOption = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption?) content.GetValueForProperty("MultiVMGroupCreateOption",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MultiVMGroupCreateOption, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.MultiVMGroupCreateOption.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ManagementId = (string) content.GetValueForProperty("ManagementId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ManagementId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails[]) content.GetValueForProperty("ProtectedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedDiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedManagedDisk = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedManagedDiskDetails[]) content.GetValueForProperty("ProtectedManagedDisk",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).ProtectedManagedDisk, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AProtectedManagedDiskDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AProtectedManagedDiskDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryBootDiagStorageAccountId = (string) content.GetValueForProperty("RecoveryBootDiagStorageAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryBootDiagStorageAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).PrimaryFabricLocation = (string) content.GetValueForProperty("PrimaryFabricLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).PrimaryFabricLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricLocation = (string) content.GetValueForProperty("RecoveryFabricLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMSize = (string) content.GetValueForProperty("RecoveryAzureVMSize",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMName = (string) content.GetValueForProperty("RecoveryAzureVMName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureVMName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureResourceGroupId = (string) content.GetValueForProperty("RecoveryAzureResourceGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAzureResourceGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryCloudService = (string) content.GetValueForProperty("RecoveryCloudService",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryCloudService, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAvailabilitySet = (string) content.GetValueForProperty("RecoveryAvailabilitySet",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryAvailabilitySet, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId = (string) content.GetValueForProperty("SelectedRecoveryAzureNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).SelectedRecoveryAzureNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMNic = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails[]) content.GetValueForProperty("VMNic",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMNic, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringPercentageCompletion = (int?) content.GetValueForProperty("MonitoringPercentageCompletion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringPercentageCompletion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringJobType = (string) content.GetValueForProperty("MonitoringJobType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).MonitoringJobType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastHeartbeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartbeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastHeartbeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).IsReplicationAgentUpdateRequired = (bool?) content.GetValueForProperty("IsReplicationAgentUpdateRequired",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).IsReplicationAgentUpdateRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricObjectId = (string) content.GetValueForProperty("RecoveryFabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RecoveryFabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionState = (string) content.GetValueForProperty("VMProtectionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionStateDescription = (string) content.GetValueForProperty("VMProtectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMProtectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LifecycleId = (string) content.GetValueForProperty("LifecycleId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LifecycleId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).TestFailoverRecoveryFabricObjectId = (string) content.GetValueForProperty("TestFailoverRecoveryFabricObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).TestFailoverRecoveryFabricObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RpoInSecond = (long?) content.GetValueForProperty("RpoInSecond",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).RpoInSecond, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastRpoCalculatedTime = (global::System.DateTime?) content.GetValueForProperty("LastRpoCalculatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).LastRpoCalculatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettingsInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailTag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IAzureToAzureVMSyncedConfigDetailsTags) content.GetValueForProperty("VMSyncedConfigDetailTag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailTag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.AzureToAzureVMSyncedConfigDetailsTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailRoleAssignment = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment[]) content.GetValueForProperty("VMSyncedConfigDetailRoleAssignment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailRoleAssignment, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRoleAssignment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RoleAssignmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailInputEndpoint = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint[]) content.GetValueForProperty("VMSyncedConfigDetailInputEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetailsInternal)this).VMSyncedConfigDetailInputEndpoint, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInputEndpoint>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InputEndpointTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new A2AReplicationDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.A2AReplicationDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new A2AReplicationDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="A2AReplicationDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AReplicationDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A2A provider specific settings.
    [System.ComponentModel.TypeConverter(typeof(A2AReplicationDetailsTypeConverter))]
    public partial interface IA2AReplicationDetails

    {

    }
}