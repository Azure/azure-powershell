namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Class representing the Kusto cluster properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(ClusterPropertiesTypeConverter))]
    public partial class ClusterProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ClusterProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration) content.GetValueForProperty("VirtualNetworkConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.VirtualNetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDiskEncryption = (bool?) content.GetValueForProperty("EnableDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDoubleEncryption = (bool?) content.GetValueForProperty("EnableDoubleEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDoubleEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).TrustedExternalTenant = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[]) content.GetValueForProperty("TrustedExternalTenant",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).TrustedExternalTenant, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.TrustedExternalTenantTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationSubnetId = (string) content.GetValueForProperty("VirtualNetworkConfigurationSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationDataManagementPublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationEnginePublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationEnginePublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationEnginePublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ClusterProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.KeyVaultPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtension = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtensionsList) content.GetValueForProperty("LanguageExtension",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtension, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionsListTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscale = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IOptimizedAutoscale) content.GetValueForProperty("OptimizedAutoscale",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscale, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.OptimizedAutoscaleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IVirtualNetworkConfiguration) content.GetValueForProperty("VirtualNetworkConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.VirtualNetworkConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).DataIngestionUri = (string) content.GetValueForProperty("DataIngestionUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).DataIngestionUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDiskEncryption = (bool?) content.GetValueForProperty("EnableDiskEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDiskEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDoubleEncryption = (bool?) content.GetValueForProperty("EnableDoubleEncryption",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableDoubleEncryption, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnablePurge = (bool?) content.GetValueForProperty("EnablePurge",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnablePurge, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableStreamingIngest = (bool?) content.GetValueForProperty("EnableStreamingIngest",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).EnableStreamingIngest, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State?) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.State.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).StateReason = (string) content.GetValueForProperty("StateReason",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).StateReason, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).TrustedExternalTenant = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant[]) content.GetValueForProperty("TrustedExternalTenant",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).TrustedExternalTenant, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ITrustedExternalTenant>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.TrustedExternalTenantTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).Uri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationSubnetId = (string) content.GetValueForProperty("VirtualNetworkConfigurationSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtensionValue = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension[]) content.GetValueForProperty("LanguageExtensionValue",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).LanguageExtensionValue, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ILanguageExtension>(__y, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.LanguageExtensionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleIsEnabled = (bool) content.GetValueForProperty("OptimizedAutoscaleIsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleIsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMinimum = (int) content.GetValueForProperty("OptimizedAutoscaleMinimum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMinimum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleVersion = (int) content.GetValueForProperty("OptimizedAutoscaleVersion",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleVersion, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationDataManagementPublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationDataManagementPublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationEnginePublicIPId = (string) content.GetValueForProperty("VirtualNetworkConfigurationEnginePublicIPId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).VirtualNetworkConfigurationEnginePublicIPId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMaximum = (int) content.GetValueForProperty("OptimizedAutoscaleMaximum",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterPropertiesInternal)this).OptimizedAutoscaleMaximum, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ClusterProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ClusterProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ClusterProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ClusterProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IClusterProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Class representing the Kusto cluster properties.
    [System.ComponentModel.TypeConverter(typeof(ClusterPropertiesTypeConverter))]
    public partial interface IClusterProperties

    {

    }
}