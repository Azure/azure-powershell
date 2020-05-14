namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Description of an App Service Environment.</summary>
    [System.ComponentModel.TypeConverter(typeof(AppServiceEnvironmentTypeConverter))]
    public partial class AppServiceEnvironment
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceEnvironment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AppServiceEnvironment(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfile) content.GetValueForProperty("VirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedMultiSize = (string) content.GetValueForProperty("AllowedMultiSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedMultiSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedWorkerSize = (string) content.GetValueForProperty("AllowedWorkerSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedWorkerSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ApiManagementAccountId = (string) content.GetValueForProperty("ApiManagementAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ApiManagementAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ClusterSetting = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]) content.GetValueForProperty("ClusterSetting",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ClusterSetting, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseEdition = (string) content.GetValueForProperty("DatabaseEdition",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseEdition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseServiceObjective = (string) content.GetValueForProperty("DatabaseServiceObjective",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseServiceObjective, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DefaultFrontEndScaleFactor = (int?) content.GetValueForProperty("DefaultFrontEndScaleFactor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DefaultFrontEndScaleFactor, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DnsSuffix = (string) content.GetValueForProperty("DnsSuffix",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DnsSuffix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DynamicCacheEnabled = (bool?) content.GetValueForProperty("DynamicCacheEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DynamicCacheEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[]) content.GetValueForProperty("EnvironmentCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentCapacity, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StampCapacityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentIsHealthy = (bool?) content.GetValueForProperty("EnvironmentIsHealthy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentIsHealthy, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentStatus = (string) content.GetValueForProperty("EnvironmentStatus",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).FrontEndScaleFactor = (int?) content.GetValueForProperty("FrontEndScaleFactor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).FrontEndScaleFactor, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).HasLinuxWorker = (bool?) content.GetValueForProperty("HasLinuxWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).HasLinuxWorker, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).InternalLoadBalancingMode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode?) content.GetValueForProperty("InternalLoadBalancingMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).InternalLoadBalancingMode, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).IpsslAddressCount = (int?) content.GetValueForProperty("IpsslAddressCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).IpsslAddressCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastAction = (string) content.GetValueForProperty("LastAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastActionResult = (string) content.GetValueForProperty("LastActionResult",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastActionResult, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MaximumNumberOfMachine = (int?) content.GetValueForProperty("MaximumNumberOfMachine",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MaximumNumberOfMachine, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiRoleCount = (int?) content.GetValueForProperty("MultiRoleCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiRoleCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiSize = (string) content.GetValueForProperty("MultiSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).NetworkAccessControlList = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[]) content.GetValueForProperty("NetworkAccessControlList",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).NetworkAccessControlList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkAccessControlEntryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ResourceGroup = (string) content.GetValueForProperty("ResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultId = (string) content.GetValueForProperty("SslCertKeyVaultId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultSecretName = (string) content.GetValueForProperty("SslCertKeyVaultSecretName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultSecretName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Suspended = (bool?) content.GetValueForProperty("Suspended",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Suspended, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UpgradeDomain = (int?) content.GetValueForProperty("UpgradeDomain",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UpgradeDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UserWhitelistedIPRange = (string[]) content.GetValueForProperty("UserWhitelistedIPRange",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UserWhitelistedIPRange, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VipMapping = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[]) content.GetValueForProperty("VipMapping",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VipMapping, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualIPMappingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetName = (string) content.GetValueForProperty("VnetName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetResourceGroupName = (string) content.GetValueForProperty("VnetResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetSubnetName = (string) content.GetValueForProperty("VnetSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).WorkerPool = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool[]) content.GetValueForProperty("WorkerPool",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).WorkerPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkName = (string) content.GetValueForProperty("VirtualNetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkType = (string) content.GetValueForProperty("VirtualNetworkType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkId = (string) content.GetValueForProperty("VirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkSubnet = (string) content.GetValueForProperty("VirtualNetworkSubnet",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkSubnet, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceEnvironment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AppServiceEnvironment(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetwork = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualNetworkProfile) content.GetValueForProperty("VirtualNetwork",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetwork, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualNetworkProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedMultiSize = (string) content.GetValueForProperty("AllowedMultiSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedMultiSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedWorkerSize = (string) content.GetValueForProperty("AllowedWorkerSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).AllowedWorkerSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ApiManagementAccountId = (string) content.GetValueForProperty("ApiManagementAccountId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ApiManagementAccountId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ClusterSetting = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[]) content.GetValueForProperty("ClusterSetting",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ClusterSetting, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NameValuePairTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseEdition = (string) content.GetValueForProperty("DatabaseEdition",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseEdition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseServiceObjective = (string) content.GetValueForProperty("DatabaseServiceObjective",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DatabaseServiceObjective, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DefaultFrontEndScaleFactor = (int?) content.GetValueForProperty("DefaultFrontEndScaleFactor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DefaultFrontEndScaleFactor, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DnsSuffix = (string) content.GetValueForProperty("DnsSuffix",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DnsSuffix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DynamicCacheEnabled = (bool?) content.GetValueForProperty("DynamicCacheEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).DynamicCacheEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentCapacity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity[]) content.GetValueForProperty("EnvironmentCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentCapacity, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStampCapacity>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StampCapacityTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentIsHealthy = (bool?) content.GetValueForProperty("EnvironmentIsHealthy",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentIsHealthy, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentStatus = (string) content.GetValueForProperty("EnvironmentStatus",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).EnvironmentStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).FrontEndScaleFactor = (int?) content.GetValueForProperty("FrontEndScaleFactor",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).FrontEndScaleFactor, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).HasLinuxWorker = (bool?) content.GetValueForProperty("HasLinuxWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).HasLinuxWorker, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).InternalLoadBalancingMode = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode?) content.GetValueForProperty("InternalLoadBalancingMode",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).InternalLoadBalancingMode, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.InternalLoadBalancingMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).IpsslAddressCount = (int?) content.GetValueForProperty("IpsslAddressCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).IpsslAddressCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastAction = (string) content.GetValueForProperty("LastAction",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastActionResult = (string) content.GetValueForProperty("LastActionResult",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).LastActionResult, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MaximumNumberOfMachine = (int?) content.GetValueForProperty("MaximumNumberOfMachine",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MaximumNumberOfMachine, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiRoleCount = (int?) content.GetValueForProperty("MultiRoleCount",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiRoleCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiSize = (string) content.GetValueForProperty("MultiSize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).MultiSize, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).NetworkAccessControlList = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry[]) content.GetValueForProperty("NetworkAccessControlList",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).NetworkAccessControlList, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INetworkAccessControlEntry>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.NetworkAccessControlEntryTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ResourceGroup = (string) content.GetValueForProperty("ResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).ResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultId = (string) content.GetValueForProperty("SslCertKeyVaultId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultSecretName = (string) content.GetValueForProperty("SslCertKeyVaultSecretName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SslCertKeyVaultSecretName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.HostingEnvironmentStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).SubscriptionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Suspended = (bool?) content.GetValueForProperty("Suspended",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).Suspended, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UpgradeDomain = (int?) content.GetValueForProperty("UpgradeDomain",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UpgradeDomain, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UserWhitelistedIPRange = (string[]) content.GetValueForProperty("UserWhitelistedIPRange",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).UserWhitelistedIPRange, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VipMapping = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping[]) content.GetValueForProperty("VipMapping",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VipMapping, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualIPMapping>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualIPMappingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetName = (string) content.GetValueForProperty("VnetName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetResourceGroupName = (string) content.GetValueForProperty("VnetResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetSubnetName = (string) content.GetValueForProperty("VnetSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VnetSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).WorkerPool = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool[]) content.GetValueForProperty("WorkerPool",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).WorkerPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WorkerPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkName = (string) content.GetValueForProperty("VirtualNetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkType = (string) content.GetValueForProperty("VirtualNetworkType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkId = (string) content.GetValueForProperty("VirtualNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkSubnet = (string) content.GetValueForProperty("VirtualNetworkSubnet",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironmentInternal)this).VirtualNetworkSubnet, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceEnvironment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AppServiceEnvironment(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceEnvironment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AppServiceEnvironment(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AppServiceEnvironment" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceEnvironment FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Description of an App Service Environment.
    [System.ComponentModel.TypeConverter(typeof(AppServiceEnvironmentTypeConverter))]
    public partial interface IAppServiceEnvironment

    {

    }
}