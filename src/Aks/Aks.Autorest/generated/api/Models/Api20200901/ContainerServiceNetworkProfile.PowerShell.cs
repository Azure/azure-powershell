namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>Profile of network configuration.</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerServiceNetworkProfileTypeConverter))]
    public partial class ContainerServiceNetworkProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceNetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerServiceNetworkProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile) content.GetValueForProperty("LoadBalancerProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfile, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPlugin = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin?) content.GetValueForProperty("NetworkPlugin",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPlugin, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy?) content.GetValueForProperty("NetworkPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPolicy, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkMode = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode?) content.GetValueForProperty("NetworkMode",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkMode, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).PodCidr = (string) content.GetValueForProperty("PodCidr",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).PodCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ServiceCidr = (string) content.GetValueForProperty("ServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DnsServiceIP = (string) content.GetValueForProperty("DnsServiceIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DnsServiceIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DockerBridgeCidr = (string) content.GetValueForProperty("DockerBridgeCidr",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DockerBridgeCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType?) content.GetValueForProperty("OutboundType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerSku = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku?) content.GetValueForProperty("LoadBalancerSku",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerSku, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileManagedOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs) content.GetValueForProperty("LoadBalancerProfileManagedOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileManagedOutboundIP, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileManagedOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes) content.GetValueForProperty("LoadBalancerProfileOutboundIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIPPrefix, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs) content.GetValueForProperty("LoadBalancerProfileOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIP, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileEffectiveOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("LoadBalancerProfileEffectiveOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileEffectiveOutboundIP, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileAllocatedOutboundPort = (int?) content.GetValueForProperty("LoadBalancerProfileAllocatedOutboundPort",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileAllocatedOutboundPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileIdleTimeoutInMinute = (int?) content.GetValueForProperty("LoadBalancerProfileIdleTimeoutInMinute",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileIdleTimeoutInMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ManagedOutboundIPCount = (int?) content.GetValueForProperty("ManagedOutboundIPCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ManagedOutboundIPCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPrefixPublicIpprefix = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("OutboundIPPrefixPublicIpprefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPrefixPublicIpprefix, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPublicIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("OutboundIPPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPublicIP, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceNetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerServiceNetworkProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfile) content.GetValueForProperty("LoadBalancerProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfile, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPlugin = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin?) content.GetValueForProperty("NetworkPlugin",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPlugin, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPlugin.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy?) content.GetValueForProperty("NetworkPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkPolicy, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkPolicy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkMode = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode?) content.GetValueForProperty("NetworkMode",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).NetworkMode, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.NetworkMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).PodCidr = (string) content.GetValueForProperty("PodCidr",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).PodCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ServiceCidr = (string) content.GetValueForProperty("ServiceCidr",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ServiceCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DnsServiceIP = (string) content.GetValueForProperty("DnsServiceIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DnsServiceIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DockerBridgeCidr = (string) content.GetValueForProperty("DockerBridgeCidr",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).DockerBridgeCidr, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType?) content.GetValueForProperty("OutboundType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OutboundType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerSku = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku?) content.GetValueForProperty("LoadBalancerSku",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerSku, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.LoadBalancerSku.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileManagedOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileManagedOutboundIPs) content.GetValueForProperty("LoadBalancerProfileManagedOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileManagedOutboundIP, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileManagedOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes) content.GetValueForProperty("LoadBalancerProfileOutboundIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIPPrefix, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPs) content.GetValueForProperty("LoadBalancerProfileOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileOutboundIP, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileEffectiveOutboundIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("LoadBalancerProfileEffectiveOutboundIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileEffectiveOutboundIP, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileAllocatedOutboundPort = (int?) content.GetValueForProperty("LoadBalancerProfileAllocatedOutboundPort",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileAllocatedOutboundPort, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileIdleTimeoutInMinute = (int?) content.GetValueForProperty("LoadBalancerProfileIdleTimeoutInMinute",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).LoadBalancerProfileIdleTimeoutInMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ManagedOutboundIPCount = (int?) content.GetValueForProperty("ManagedOutboundIPCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).ManagedOutboundIPCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPrefixPublicIpprefix = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("OutboundIPPrefixPublicIpprefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPrefixPublicIpprefix, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPublicIP = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("OutboundIPPublicIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfileInternal)this).OutboundIPPublicIP, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceNetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerServiceNetworkProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceNetworkProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerServiceNetworkProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerServiceNetworkProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceNetworkProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Profile of network configuration.
    [System.ComponentModel.TypeConverter(typeof(ContainerServiceNetworkProfileTypeConverter))]
    public partial interface IContainerServiceNetworkProfile

    {

    }
}