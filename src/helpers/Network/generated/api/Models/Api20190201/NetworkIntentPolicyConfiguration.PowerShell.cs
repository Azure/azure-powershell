namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Details of NetworkIntentPolicyConfiguration for PrepareNetworkPoliciesRequest.</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkIntentPolicyConfigurationTypeConverter))]
    public partial class NetworkIntentPolicyConfiguration
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicyConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkIntentPolicyConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicyConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkIntentPolicyConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkIntentPolicyConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicyConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkIntentPolicyConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicy) content.GetValueForProperty("SourceNetworkIntentPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicy, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).NetworkIntentPolicyName = (string) content.GetValueForProperty("NetworkIntentPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).NetworkIntentPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyName = (string) content.GetValueForProperty("SourceNetworkIntentPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyType = (string) content.GetValueForProperty("SourceNetworkIntentPolicyType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyId = (string) content.GetValueForProperty("SourceNetworkIntentPolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyLocation = (string) content.GetValueForProperty("SourceNetworkIntentPolicyLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("SourceNetworkIntentPolicyTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyEtag = (string) content.GetValueForProperty("SourceNetworkIntentPolicyEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyEtag, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicyConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkIntentPolicyConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicy = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicy) content.GetValueForProperty("SourceNetworkIntentPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicy, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkIntentPolicyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).NetworkIntentPolicyName = (string) content.GetValueForProperty("NetworkIntentPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).NetworkIntentPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyName = (string) content.GetValueForProperty("SourceNetworkIntentPolicyName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyType = (string) content.GetValueForProperty("SourceNetworkIntentPolicyType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyId = (string) content.GetValueForProperty("SourceNetworkIntentPolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyLocation = (string) content.GetValueForProperty("SourceNetworkIntentPolicyLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) content.GetValueForProperty("SourceNetworkIntentPolicyTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyEtag = (string) content.GetValueForProperty("SourceNetworkIntentPolicyEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkIntentPolicyConfigurationInternal)this).SourceNetworkIntentPolicyEtag, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Details of NetworkIntentPolicyConfiguration for PrepareNetworkPoliciesRequest.
    [System.ComponentModel.TypeConverter(typeof(NetworkIntentPolicyConfigurationTypeConverter))]
    public partial interface INetworkIntentPolicyConfiguration

    {

    }
}