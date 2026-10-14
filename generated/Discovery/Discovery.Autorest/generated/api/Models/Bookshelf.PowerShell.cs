// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    /// <summary>Bookshelf tracked resource</summary>
    [System.ComponentModel.TypeConverter(typeof(BookshelfTypeConverter))]
    public partial class Bookshelf
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Bookshelf"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Bookshelf(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfPropertiesTypeConverter.ConvertFrom);
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfKeyVaultPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).WorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities) content.GetValueForProperty("WorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).WorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfPropertiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointSubnetId = (string) content.GetValueForProperty("PrivateEndpointSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("SearchSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).SearchSubnetId = (string) content.GetValueForProperty("SearchSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).SearchSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("Uri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Uri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVaultUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyIdentityClientId = (string) content.GetValueForProperty("KeyVaultPropertyIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Bookshelf"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Bookshelf(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfPropertiesTypeConverter.ConvertFrom);
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfKeyVaultPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).WorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPropertiesWorkloadIdentities) content.GetValueForProperty("WorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).WorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.BookshelfPropertiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointSubnetId = (string) content.GetValueForProperty("PrivateEndpointSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).PrivateEndpointSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("SearchSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).SearchSubnetId = (string) content.GetValueForProperty("SearchSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).SearchSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("Uri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Uri = (string) content.GetValueForProperty("Uri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).Uri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVaultUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyIdentityClientId = (string) content.GetValueForProperty("KeyVaultPropertyIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).KeyVaultPropertyIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Bookshelf"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Bookshelf(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Bookshelf"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Bookshelf(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Bookshelf" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Bookshelf" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelf FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Bookshelf tracked resource
    [System.ComponentModel.TypeConverter(typeof(BookshelfTypeConverter))]
    public partial interface IBookshelf

    {

    }
}