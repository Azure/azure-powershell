// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    /// <summary>Supercomputer properties</summary>
    [System.ComponentModel.TypeConverter(typeof(SupercomputerPropertiesTypeConverter))]
    public partial class SupercomputerProperties
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SupercomputerProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SupercomputerProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SupercomputerProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="SupercomputerProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SupercomputerProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagementSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagementSubnetId = (string) content.GetValueForProperty("ManagementSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagementSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("OutboundType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).OutboundType = (string) content.GetValueForProperty("OutboundType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).OutboundType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SystemSku = (string) content.GetValueForProperty("SystemSku",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SystemSku, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("DiskEncryptionSetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).DiskEncryptionSetId = (string) content.GetValueForProperty("DiskEncryptionSetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).DiskEncryptionSetId, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityClusterIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityClusterIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityClusterIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityClusterIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityKubeletIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityKubeletIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityKubeletIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityKubeletIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityWorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityWorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) content.GetValueForProperty("IdentityWorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityWorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClusterIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityId = (string) content.GetValueForProperty("ClusterIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityId = (string) content.GetValueForProperty("KubeletIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ClusterIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityPrincipalId = (string) content.GetValueForProperty("ClusterIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityClientId = (string) content.GetValueForProperty("ClusterIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityPrincipalId = (string) content.GetValueForProperty("KubeletIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityClientId = (string) content.GetValueForProperty("KubeletIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityClientId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SupercomputerProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagementSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagementSubnetId = (string) content.GetValueForProperty("ManagementSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagementSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("OutboundType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).OutboundType = (string) content.GetValueForProperty("OutboundType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).OutboundType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SystemSku = (string) content.GetValueForProperty("SystemSku",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).SystemSku, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("DiskEncryptionSetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).DiskEncryptionSetId = (string) content.GetValueForProperty("DiskEncryptionSetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).DiskEncryptionSetId, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityClusterIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityClusterIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityClusterIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityClusterIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityKubeletIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityKubeletIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityKubeletIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityKubeletIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityWorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityWorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) content.GetValueForProperty("IdentityWorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).IdentityWorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClusterIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityId = (string) content.GetValueForProperty("ClusterIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityId = (string) content.GetValueForProperty("KubeletIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ClusterIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityPrincipalId = (string) content.GetValueForProperty("ClusterIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityClientId = (string) content.GetValueForProperty("ClusterIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).ClusterIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityPrincipalId = (string) content.GetValueForProperty("KubeletIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityClientId = (string) content.GetValueForProperty("KubeletIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerPropertiesInternal)this).KubeletIdentityClientId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// Supercomputer properties
    [System.ComponentModel.TypeConverter(typeof(SupercomputerPropertiesTypeConverter))]
    public partial interface ISupercomputerProperties

    {

    }
}