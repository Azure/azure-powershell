namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>Desired outbound IP Prefix resources for the cluster load balancer.</summary>
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterLoadBalancerProfileOutboundIPPrefixesTypeConverter))]
    public partial class ManagedClusterLoadBalancerProfileOutboundIPPrefixes
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixes"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ManagedClusterLoadBalancerProfileOutboundIPPrefixes(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixes"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ManagedClusterLoadBalancerProfileOutboundIPPrefixes(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ManagedClusterLoadBalancerProfileOutboundIPPrefixes" />, deserializing the content
        /// from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixes FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixes"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ManagedClusterLoadBalancerProfileOutboundIPPrefixes(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)this).PublicIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("PublicIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)this).PublicIPPrefix, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterLoadBalancerProfileOutboundIPPrefixes"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ManagedClusterLoadBalancerProfileOutboundIPPrefixes(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)this).PublicIPPrefix = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference[]) content.GetValueForProperty("PublicIPPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterLoadBalancerProfileOutboundIPPrefixesInternal)this).PublicIPPrefix, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ResourceReferenceTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Desired outbound IP Prefix resources for the cluster load balancer.
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterLoadBalancerProfileOutboundIPPrefixesTypeConverter))]
    public partial interface IManagedClusterLoadBalancerProfileOutboundIPPrefixes

    {

    }
}