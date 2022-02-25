namespace Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701
{
    using Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.PowerShell;

    /// <summary>Account resource</summary>
    [System.ComponentModel.TypeConverter(typeof(AccountTypeConverter))]
    public partial class Account
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.Account"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Account(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.AccountPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.AccountSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.LastModifiedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.LastModifiedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnector = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ICloudConnectors) content.GetValueForProperty("CloudConnector",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnector, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.CloudConnectorsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResource = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IManagedResources) content.GetValueForProperty("ManagedResource",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResource, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ManagedResourcesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Endpoint = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountEndpoints) content.GetValueForProperty("Endpoint",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Endpoint, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.AccountEndpointsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedAt = (global::System.DateTime?) content.GetValueForProperty("CreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedBy = (string) content.GetValueForProperty("CreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedByObjectId = (string) content.GetValueForProperty("CreatedByObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedByObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroupName = (string) content.GetValueForProperty("ManagedResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IPrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceStorageAccount = (string) content.GetValueForProperty("ManagedResourceStorageAccount",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceStorageAccount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnectorAwsExternalId = (string) content.GetValueForProperty("CloudConnectorAwsExternalId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnectorAwsExternalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointCatalog = (string) content.GetValueForProperty("EndpointCatalog",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointCatalog, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointGuardian = (string) content.GetValueForProperty("EndpointGuardian",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointGuardian, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointScan = (string) content.GetValueForProperty("EndpointScan",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointScan, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceEventHubNamespace = (string) content.GetValueForProperty("ManagedResourceEventHubNamespace",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceEventHubNamespace, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.Account"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Account(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.AccountPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.AccountSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.LastModifiedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.LastModifiedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnector = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ICloudConnectors) content.GetValueForProperty("CloudConnector",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnector, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.CloudConnectorsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResource = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IManagedResources) content.GetValueForProperty("ManagedResource",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResource, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ManagedResourcesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Endpoint = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountEndpoints) content.GetValueForProperty("Endpoint",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).Endpoint, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.AccountEndpointsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedAt = (global::System.DateTime?) content.GetValueForProperty("CreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedBy = (string) content.GetValueForProperty("CreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedByObjectId = (string) content.GetValueForProperty("CreatedByObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CreatedByObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroupName = (string) content.GetValueForProperty("ManagedResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroupName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PrivateEndpointConnection = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IPrivateEndpointConnection[]) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PublicNetworkAccess = (Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess?) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).PublicNetworkAccess, Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceStorageAccount = (string) content.GetValueForProperty("ManagedResourceStorageAccount",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceStorageAccount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuCapacity = (int?) content.GetValueForProperty("SkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).SkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnectorAwsExternalId = (string) content.GetValueForProperty("CloudConnectorAwsExternalId",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).CloudConnectorAwsExternalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointCatalog = (string) content.GetValueForProperty("EndpointCatalog",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointCatalog, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointGuardian = (string) content.GetValueForProperty("EndpointGuardian",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointGuardian, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointScan = (string) content.GetValueForProperty("EndpointScan",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).EndpointScan, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceEventHubNamespace = (string) content.GetValueForProperty("ManagedResourceEventHubNamespace",((Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountInternal)this).ManagedResourceEventHubNamespace, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.Account"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Account(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.Account"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Account(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Account" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Account resource
    [System.ComponentModel.TypeConverter(typeof(AccountTypeConverter))]
    public partial interface IAccount

    {

    }
}