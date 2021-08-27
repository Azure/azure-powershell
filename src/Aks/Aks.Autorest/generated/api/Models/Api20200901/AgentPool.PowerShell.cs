namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>Agent Pool.</summary>
    [System.ComponentModel.TypeConverter(typeof(AgentPoolTypeConverter))]
    public partial class AgentPool
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPool"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AgentPool(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerState = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState) content.GetValueForProperty("PowerState",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerState, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PowerStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OrchestratorVersion = (string) content.GetValueForProperty("OrchestratorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OrchestratorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VMSize = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes?) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VMSize, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskSizeGb = (int?) content.GetValueForProperty("OSDiskSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType?) content.GetValueForProperty("OSDiskType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VnetSubnetId = (string) content.GetValueForProperty("VnetSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VnetSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxPod = (int?) content.GetValueForProperty("MaxPod",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxPod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSetting = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings) content.GetValueForProperty("UpgradeSetting",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSetting, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolUpgradeSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxCount = (int?) content.GetValueForProperty("MaxCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MinCount = (int?) content.GetValueForProperty("MinCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MinCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableAutoScaling = (bool?) content.GetValueForProperty("EnableAutoScaling",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableAutoScaling, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PropertiesType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType?) content.GetValueForProperty("PropertiesType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PropertiesType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Mode = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode?) content.GetValueForProperty("Mode",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Mode, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Count = (int?) content.GetValueForProperty("Count",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Count, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeImageVersion = (string) content.GetValueForProperty("NodeImageVersion",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeImageVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).AvailabilityZone = (string[]) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).AvailabilityZone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableNodePublicIP = (bool?) content.GetValueForProperty("EnableNodePublicIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableNodePublicIP, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetPriority = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority?) content.GetValueForProperty("ScaleSetPriority",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetPriority, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetEvictionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy?) content.GetValueForProperty("ScaleSetEvictionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetEvictionPolicy, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).SpotMaxPrice = (float?) content.GetValueForProperty("SpotMaxPrice",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).SpotMaxPrice, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeLabel = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels) content.GetValueForProperty("NodeLabel",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeLabel, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesNodeLabelsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeTaint = (string[]) content.GetValueForProperty("NodeTaint",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeTaint, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProximityPlacementGroupId = (string) content.GetValueForProperty("ProximityPlacementGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProximityPlacementGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerStateCode = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code?) content.GetValueForProperty("PowerStateCode",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerStateCode, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSettingMaxSurge = (string) content.GetValueForProperty("UpgradeSettingMaxSurge",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSettingMaxSurge, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPool"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AgentPool(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfileProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ISubResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerState = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPowerState) content.GetValueForProperty("PowerState",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerState, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.PowerStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OrchestratorVersion = (string) content.GetValueForProperty("OrchestratorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OrchestratorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VMSize = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes?) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VMSize, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskSizeGb = (int?) content.GetValueForProperty("OSDiskSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType?) content.GetValueForProperty("OSDiskType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).OSDiskType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSDiskType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VnetSubnetId = (string) content.GetValueForProperty("VnetSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).VnetSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxPod = (int?) content.GetValueForProperty("MaxPod",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxPod, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSetting = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolUpgradeSettings) content.GetValueForProperty("UpgradeSetting",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSetting, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPoolUpgradeSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxCount = (int?) content.GetValueForProperty("MaxCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MaxCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MinCount = (int?) content.GetValueForProperty("MinCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).MinCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableAutoScaling = (bool?) content.GetValueForProperty("EnableAutoScaling",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableAutoScaling, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PropertiesType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType?) content.GetValueForProperty("PropertiesType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PropertiesType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Mode = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode?) content.GetValueForProperty("Mode",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Mode, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.AgentPoolMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Count = (int?) content.GetValueForProperty("Count",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Count, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeImageVersion = (string) content.GetValueForProperty("NodeImageVersion",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeImageVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).AvailabilityZone = (string[]) content.GetValueForProperty("AvailabilityZone",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).AvailabilityZone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableNodePublicIP = (bool?) content.GetValueForProperty("EnableNodePublicIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).EnableNodePublicIP, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetPriority = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority?) content.GetValueForProperty("ScaleSetPriority",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetPriority, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetPriority.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetEvictionPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy?) content.GetValueForProperty("ScaleSetEvictionPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ScaleSetEvictionPolicy, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ScaleSetEvictionPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).SpotMaxPrice = (float?) content.GetValueForProperty("SpotMaxPrice",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).SpotMaxPrice, (__y)=> (float) global::System.Convert.ChangeType(__y, typeof(float)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeLabel = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAgentPoolProfilePropertiesNodeLabels) content.GetValueForProperty("NodeLabel",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeLabel, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAgentPoolProfilePropertiesNodeLabelsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeTaint = (string[]) content.GetValueForProperty("NodeTaint",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).NodeTaint, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProximityPlacementGroupId = (string) content.GetValueForProperty("ProximityPlacementGroupId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).ProximityPlacementGroupId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerStateCode = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code?) content.GetValueForProperty("PowerStateCode",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).PowerStateCode, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Code.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSettingMaxSurge = (string) content.GetValueForProperty("UpgradeSettingMaxSurge",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPoolInternal)this).UpgradeSettingMaxSurge, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPool"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AgentPool(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AgentPool"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AgentPool(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AgentPool" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAgentPool FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Agent Pool.
    [System.ComponentModel.TypeConverter(typeof(AgentPoolTypeConverter))]
    public partial interface IAgentPool

    {

    }
}