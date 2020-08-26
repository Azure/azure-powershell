namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing an update to a Kusto cluster.</summary>
    [System.ComponentModel.TypeConverter(typeof(ClusterUpdateTypeConverter))]
    public partial class ClusterUpdate
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ClusterUpdate(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.AzureSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterUpdateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration) content.GetValueForProperty("VirtualNetworkConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.VirtualNetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDiskEncryption = (bool?) content.GetValueForProperty("EnableDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDoubleEncryption = (bool?) content.GetValueForProperty("EnableDoubleEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDoubleEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationSubnetId = (string) content.GetValueForProperty("VirtualNetworkConfigurationSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).TrustedExternalTenant = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[]) content.GetValueForProperty("TrustedExternalTenant",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).TrustedExternalTenant, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.TrustedExternalTenantTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationDataManagementPublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationEnginePublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationEnginePublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationEnginePublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ClusterUpdate(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.AzureSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterUpdateTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration) content.GetValueForProperty("VirtualNetworkConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.VirtualNetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDiskEncryption = (bool?) content.GetValueForProperty("EnableDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDoubleEncryption = (bool?) content.GetValueForProperty("EnableDoubleEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableDoubleEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationSubnetId = (string) content.GetValueForProperty("VirtualNetworkConfigurationSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).TrustedExternalTenant = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[]) content.GetValueForProperty("TrustedExternalTenant",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).TrustedExternalTenant, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.TrustedExternalTenantTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationDataManagementPublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationEnginePublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationEnginePublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).VirtualNetworkConfigurationEnginePublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdateInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdate DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ClusterUpdate(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterUpdate"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdate" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdate DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ClusterUpdate(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ClusterUpdate" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterUpdate FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing an update to a Kusto cluster.
    [System.ComponentModel.TypeConverter(typeof(ClusterUpdateTypeConverter))]
    public partial interface IClusterUpdate

    {

    }
}