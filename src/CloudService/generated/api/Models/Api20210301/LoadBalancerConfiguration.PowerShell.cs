namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.PowerShell;

    /// <summary>Describes the load balancer configuration.</summary>
    [System.ComponentModel.TypeConverter(typeof(LoadBalancerConfigurationTypeConverter))]
    public partial class LoadBalancerConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LoadBalancerConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LoadBalancerConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LoadBalancerConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LoadBalancerConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration[]) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).FrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfigurationTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LoadBalancerConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfigurationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration[]) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerConfigurationInternal)this).FrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfigurationTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the load balancer configuration.
    [System.ComponentModel.TypeConverter(typeof(LoadBalancerConfigurationTypeConverter))]
    public partial interface ILoadBalancerConfiguration

    {

    }
}