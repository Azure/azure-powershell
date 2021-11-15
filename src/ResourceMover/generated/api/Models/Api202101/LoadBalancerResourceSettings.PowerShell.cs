namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PowerShell;

    /// <summary>Defines the load balancer resource settings.</summary>
    [System.ComponentModel.TypeConverter(typeof(LoadBalancerResourceSettingsTypeConverter))]
    public partial class LoadBalancerResourceSettings
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LoadBalancerResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettings DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LoadBalancerResourceSettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LoadBalancerResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettings DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LoadBalancerResourceSettings(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LoadBalancerResourceSettings" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettings FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LoadBalancerResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LoadBalancerResourceSettings(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Sku = (string) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Sku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbFrontendIpconfigurationResourceSettings[]) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).FrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbFrontendIpconfigurationResourceSettings>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LbFrontendIpconfigurationResourceSettingsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbBackendAddressPoolResourceSettings[]) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).BackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbBackendAddressPoolResourceSettings>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LbBackendAddressPoolResourceSettingsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Zone = (string) content.GetValueForProperty("Zone",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Zone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).TargetResourceName = (string) content.GetValueForProperty("TargetResourceName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).TargetResourceName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LoadBalancerResourceSettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LoadBalancerResourceSettings(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Sku = (string) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Sku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbFrontendIpconfigurationResourceSettings[]) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).FrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbFrontendIpconfigurationResourceSettings>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LbFrontendIpconfigurationResourceSettingsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbBackendAddressPoolResourceSettings[]) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).BackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbBackendAddressPoolResourceSettings>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.LbBackendAddressPoolResourceSettingsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Zone = (string) content.GetValueForProperty("Zone",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerResourceSettingsInternal)this).Zone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).ResourceType = (string) content.GetValueForProperty("ResourceType",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).ResourceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).TargetResourceName = (string) content.GetValueForProperty("TargetResourceName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettingsInternal)this).TargetResourceName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Defines the load balancer resource settings.
    [System.ComponentModel.TypeConverter(typeof(LoadBalancerResourceSettingsTypeConverter))]
    public partial interface ILoadBalancerResourceSettings

    {

    }
}