// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    /// <summary>Supercomputer tracked resource</summary>
    [System.ComponentModel.TypeConverter(typeof(SupercomputerTypeConverter))]
    public partial class Supercomputer
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Supercomputer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputer DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Supercomputer(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Supercomputer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputer" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputer DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Supercomputer(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Supercomputer" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Supercomputer" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputer FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Supercomputer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Supercomputer(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemAssignedServiceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SystemSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SystemSku = (string) content.GetValueForProperty("SystemSku",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SystemSku, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("Identities"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identities = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities) content.GetValueForProperty("Identities",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identities, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagementSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagementSubnetId = (string) content.GetValueForProperty("ManagementSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagementSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("OutboundType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).OutboundType = (string) content.GetValueForProperty("OutboundType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).OutboundType, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("DiskEncryptionSetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).DiskEncryptionSetId = (string) content.GetValueForProperty("DiskEncryptionSetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).DiskEncryptionSetId, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityClusterIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityClusterIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityClusterIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityClusterIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityKubeletIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityKubeletIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityKubeletIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityKubeletIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityWorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityWorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) content.GetValueForProperty("IdentityWorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityWorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClusterIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityId = (string) content.GetValueForProperty("ClusterIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityId = (string) content.GetValueForProperty("KubeletIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ClusterIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityPrincipalId = (string) content.GetValueForProperty("ClusterIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityClientId = (string) content.GetValueForProperty("ClusterIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityPrincipalId = (string) content.GetValueForProperty("KubeletIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityClientId = (string) content.GetValueForProperty("KubeletIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityClientId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Supercomputer"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Supercomputer(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemAssignedServiceIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemAssignedServiceIdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SystemSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SystemSku = (string) content.GetValueForProperty("SystemSku",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SystemSku, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("Identities"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identities = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities) content.GetValueForProperty("Identities",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).Identities, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagementSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagementSubnetId = (string) content.GetValueForProperty("ManagementSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagementSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("OutboundType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).OutboundType = (string) content.GetValueForProperty("OutboundType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).OutboundType, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("DiskEncryptionSetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).DiskEncryptionSetId = (string) content.GetValueForProperty("DiskEncryptionSetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).DiskEncryptionSetId, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityClusterIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityClusterIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityClusterIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityClusterIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityKubeletIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityKubeletIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("IdentityKubeletIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityKubeletIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("IdentityWorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityWorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) content.GetValueForProperty("IdentityWorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).IdentityWorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClusterIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityId = (string) content.GetValueForProperty("ClusterIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityId = (string) content.GetValueForProperty("KubeletIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            if (content.Contains("ClusterIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityPrincipalId = (string) content.GetValueForProperty("ClusterIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityClientId = (string) content.GetValueForProperty("ClusterIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).ClusterIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityPrincipalId = (string) content.GetValueForProperty("KubeletIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityClientId = (string) content.GetValueForProperty("KubeletIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerInternal)this).KubeletIdentityClientId, global::System.Convert.ToString);
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
    /// Supercomputer tracked resource
    [System.ComponentModel.TypeConverter(typeof(SupercomputerTypeConverter))]
    public partial interface ISupercomputer

    {

    }
}