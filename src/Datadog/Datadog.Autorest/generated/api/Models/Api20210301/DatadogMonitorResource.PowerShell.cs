namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(DatadogMonitorResourceTypeConverter))]
    public partial class DatadogMonitorResource
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatadogMonitorResource(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ResourceSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityProperties) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IdentityPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfo = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo) content.GetValueForProperty("UserInfo",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfo, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.UserInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MonitoringStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus?) content.GetValueForProperty("MonitoringStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MonitoringStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApplicationKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApplicationKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApplicationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourceCategory = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories?) content.GetValueForProperty("LiftrResourceCategory",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourceCategory, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourcePreference = (int?) content.GetValueForProperty("LiftrResourcePreference",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourcePreference, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApiKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyName = (string) content.GetValueForProperty("DatadogOrganizationPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoEmailAddress = (string) content.GetValueForProperty("UserInfoEmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoEmailAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoName = (string) content.GetValueForProperty("UserInfoName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyRedirectUri = (string) content.GetValueForProperty("DatadogOrganizationPropertyRedirectUri",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyRedirectUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyId = (string) content.GetValueForProperty("DatadogOrganizationPropertyId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties) content.GetValueForProperty("DatadogOrganizationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationProperty, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoPhoneNumber = (string) content.GetValueForProperty("UserInfoPhoneNumber",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoPhoneNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MarketplaceSubscriptionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus?) content.GetValueForProperty("MarketplaceSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MarketplaceSubscriptionStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingAuthCode = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingAuthCode",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingAuthCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingClientId = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingClientId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyEnterpriseAppId = (string) content.GetValueForProperty("DatadogOrganizationPropertyEnterpriseAppId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyEnterpriseAppId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatadogMonitorResource(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ResourceSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IIdentityProperties) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IdentityPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfo = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IUserInfo) content.GetValueForProperty("UserInfo",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfo, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.UserInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MonitoringStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus?) content.GetValueForProperty("MonitoringStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MonitoringStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApplicationKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApplicationKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApplicationKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourceCategory = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories?) content.GetValueForProperty("LiftrResourceCategory",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourceCategory, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.LiftrResourceCategories.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourcePreference = (int?) content.GetValueForProperty("LiftrResourcePreference",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).LiftrResourcePreference, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApiKey = (string) content.GetValueForProperty("DatadogOrganizationPropertyApiKey",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyName = (string) content.GetValueForProperty("DatadogOrganizationPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoEmailAddress = (string) content.GetValueForProperty("UserInfoEmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoEmailAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoName = (string) content.GetValueForProperty("UserInfoName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyRedirectUri = (string) content.GetValueForProperty("DatadogOrganizationPropertyRedirectUri",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyRedirectUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyId = (string) content.GetValueForProperty("DatadogOrganizationPropertyId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogOrganizationProperties) content.GetValueForProperty("DatadogOrganizationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationProperty, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogOrganizationPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoPhoneNumber = (string) content.GetValueForProperty("UserInfoPhoneNumber",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).UserInfoPhoneNumber, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes?) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).IdentityType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ManagedIdentityTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MarketplaceSubscriptionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus?) content.GetValueForProperty("MarketplaceSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).MarketplaceSubscriptionStatus, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MarketplaceSubscriptionStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.CreatedByType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingAuthCode = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingAuthCode",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingAuthCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingClientId = (string) content.GetValueForProperty("DatadogOrganizationPropertyLinkingClientId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyLinkingClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyEnterpriseAppId = (string) content.GetValueForProperty("DatadogOrganizationPropertyEnterpriseAppId",((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceInternal)this).DatadogOrganizationPropertyEnterpriseAppId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatadogMonitorResource(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResource"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatadogMonitorResource(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatadogMonitorResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResource FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    [System.ComponentModel.TypeConverter(typeof(DatadogMonitorResourceTypeConverter))]
    public partial interface IDatadogMonitorResource

    {

    }
}