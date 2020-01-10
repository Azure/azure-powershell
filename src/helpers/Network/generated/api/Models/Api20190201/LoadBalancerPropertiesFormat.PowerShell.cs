namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of the load balancer.</summary>
    [System.ComponentModel.TypeConverter(typeof(LoadBalancerPropertiesFormatTypeConverter))]
    public partial class LoadBalancerPropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LoadBalancerPropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LoadBalancerPropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LoadBalancerPropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LoadBalancerPropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[]) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).BackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BackendAddressPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration[]) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).FrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FrontendIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool[]) content.GetValueForProperty("InboundNatPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InboundNatPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[]) content.GetValueForProperty("InboundNatRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InboundNatRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).LoadBalancingRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule[]) content.GetValueForProperty("LoadBalancingRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).LoadBalancingRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancingRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).OutboundRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule[]) content.GetValueForProperty("OutboundRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).OutboundRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.OutboundRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).Probe = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe[]) content.GetValueForProperty("Probe",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).Probe, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProbeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancerPropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LoadBalancerPropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[]) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).BackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.BackendAddressPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration[]) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).FrontendIPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FrontendIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool[]) content.GetValueForProperty("InboundNatPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InboundNatPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[]) content.GetValueForProperty("InboundNatRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).InboundNatRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InboundNatRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).LoadBalancingRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule[]) content.GetValueForProperty("LoadBalancingRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).LoadBalancingRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancingRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).OutboundRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule[]) content.GetValueForProperty("OutboundRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).OutboundRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IOutboundRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.OutboundRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).Probe = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe[]) content.GetValueForProperty("Probe",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).Probe, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IProbe>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ProbeTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancerPropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the load balancer.
    [System.ComponentModel.TypeConverter(typeof(LoadBalancerPropertiesFormatTypeConverter))]
    public partial interface ILoadBalancerPropertiesFormat

    {

    }
}