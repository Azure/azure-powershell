namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing a Kusto cluster.</summary>
    [System.ComponentModel.TypeConverter(typeof(ClusterTypeConverter))]
    public partial class Cluster
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Cluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Cluster(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.AzureSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Zone = (string[]) content.GetValueForProperty("Zone",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Zone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration) content.GetValueForProperty("VirtualNetworkConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.VirtualNetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDiskEncryption = (bool?) content.GetValueForProperty("EnableDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDoubleEncryption = (bool?) content.GetValueForProperty("EnableDoubleEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDoubleEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationSubnetId = (string) content.GetValueForProperty("VirtualNetworkConfigurationSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).TrustedExternalTenant = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[]) content.GetValueForProperty("TrustedExternalTenant",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).TrustedExternalTenant, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.TrustedExternalTenantTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationDataManagementPublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationEnginePublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationEnginePublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationEnginePublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Cluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Cluster(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IAzureSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.AzureSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Zone = (string[]) content.GetValueForProperty("Zone",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Zone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration) content.GetValueForProperty("VirtualNetworkConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.VirtualNetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDiskEncryption = (bool?) content.GetValueForProperty("EnableDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDoubleEncryption = (bool?) content.GetValueForProperty("EnableDoubleEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableDoubleEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationSubnetId = (string) content.GetValueForProperty("VirtualNetworkConfigurationSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).TrustedExternalTenant = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[]) content.GetValueForProperty("TrustedExternalTenant",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).TrustedExternalTenant, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.TrustedExternalTenantTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationDataManagementPublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationEnginePublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationEnginePublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).VirtualNetworkConfigurationEnginePublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Cluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Cluster(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.Cluster"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Cluster(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Cluster" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ICluster FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing a Kusto cluster.
    [System.ComponentModel.TypeConverter(typeof(ClusterTypeConverter))]
    public partial interface ICluster

    {

    }
}