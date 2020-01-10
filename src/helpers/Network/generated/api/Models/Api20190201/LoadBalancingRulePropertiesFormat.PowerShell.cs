namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Properties of the load balancer.</summary>
    [System.ComponentModel.TypeConverter(typeof(LoadBalancingRulePropertiesFormatTypeConverter))]
    public partial class LoadBalancingRulePropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancingRulePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new LoadBalancingRulePropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancingRulePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new LoadBalancingRulePropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="LoadBalancingRulePropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancingRulePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal LoadBalancingRulePropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Probe = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("Probe",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Probe, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendPort = (int?) content.GetValueForProperty("BackendPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).DisableOutboundSnat = (bool?) content.GetValueForProperty("DisableOutboundSnat",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).DisableOutboundSnat, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableFloatingIP = (bool?) content.GetValueForProperty("EnableFloatingIP",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableFloatingIP, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableTcpReset = (bool?) content.GetValueForProperty("EnableTcpReset",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableTcpReset, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendPort = (int) content.GetValueForProperty("FrontendPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).LoadDistribution = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution?) content.GetValueForProperty("LoadDistribution",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).LoadDistribution, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPoolId = (string) content.GetValueForProperty("BackendAddressPoolId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPoolId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfigurationId = (string) content.GetValueForProperty("FrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProbeId = (string) content.GetValueForProperty("ProbeId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProbeId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.LoadBalancingRulePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal LoadBalancingRulePropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("BackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPool, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("FrontendIPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Probe = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) content.GetValueForProperty("Probe",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Probe, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendPort = (int?) content.GetValueForProperty("BackendPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).DisableOutboundSnat = (bool?) content.GetValueForProperty("DisableOutboundSnat",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).DisableOutboundSnat, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableFloatingIP = (bool?) content.GetValueForProperty("EnableFloatingIP",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableFloatingIP, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableTcpReset = (bool?) content.GetValueForProperty("EnableTcpReset",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).EnableTcpReset, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendPort = (int) content.GetValueForProperty("FrontendPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).LoadDistribution = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution?) content.GetValueForProperty("LoadDistribution",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).LoadDistribution, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.LoadDistribution.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPoolId = (string) content.GetValueForProperty("BackendAddressPoolId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).BackendAddressPoolId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfigurationId = (string) content.GetValueForProperty("FrontendIPConfigurationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).FrontendIPConfigurationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProbeId = (string) content.GetValueForProperty("ProbeId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ILoadBalancingRulePropertiesFormatInternal)this).ProbeId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the load balancer.
    [System.ComponentModel.TypeConverter(typeof(LoadBalancingRulePropertiesFormatTypeConverter))]
    public partial interface ILoadBalancingRulePropertiesFormat

    {

    }
}