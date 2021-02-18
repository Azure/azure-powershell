namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Recovery services provider properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(RecoveryServicesProviderPropertiesTypeConverter))]
    public partial class RecoveryServicesProviderProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryServicesProviderProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RecoveryServicesProviderProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryServicesProviderProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RecoveryServicesProviderProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RecoveryServicesProviderProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryServicesProviderProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RecoveryServicesProviderProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderDetails) content.GetValueForProperty("AuthenticationIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderDetails) content.GetValueForProperty("ResourceAccessIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("ProviderVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricType = (string) content.GetValueForProperty("FabricType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersion = (string) content.GetValueForProperty("ProviderVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ServerVersion = (string) content.GetValueForProperty("ServerVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ServerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionState = (string) content.GetValueForProperty("ProviderVersionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionExpiryDate = (global::System.DateTime?) content.GetValueForProperty("ProviderVersionExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricFriendlyName = (string) content.GetValueForProperty("FabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).LastHeartBeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartBeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).LastHeartBeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ConnectionStatus = (string) content.GetValueForProperty("ConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ConnectionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProtectedItemCount = (int?) content.GetValueForProperty("ProtectedItemCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProtectedItemCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AllowedScenario = (string[]) content.GetValueForProperty("AllowedScenario",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AllowedScenario, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).HealthErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).HealthErrorDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).DraIdentifier = (string) content.GetValueForProperty("DraIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).DraIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailApplicationId = (string) content.GetValueForProperty("ResourceAccessIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailTenantId = (string) content.GetValueForProperty("AuthenticationIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailObjectId = (string) content.GetValueForProperty("AuthenticationIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAudience = (string) content.GetValueForProperty("AuthenticationIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAadAuthority = (string) content.GetValueForProperty("AuthenticationIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailTenantId = (string) content.GetValueForProperty("ResourceAccessIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailApplicationId = (string) content.GetValueForProperty("AuthenticationIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailObjectId = (string) content.GetValueForProperty("ResourceAccessIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAudience = (string) content.GetValueForProperty("ResourceAccessIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAadAuthority = (string) content.GetValueForProperty("ResourceAccessIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailVersion = (string) content.GetValueForProperty("ProviderVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("ProviderVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("ProviderVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RecoveryServicesProviderProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RecoveryServicesProviderProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderDetails) content.GetValueForProperty("AuthenticationIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IIdentityProviderDetails) content.GetValueForProperty("ResourceAccessIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IdentityProviderDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVersionDetails) content.GetValueForProperty("ProviderVersionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VersionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricType = (string) content.GetValueForProperty("FabricType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersion = (string) content.GetValueForProperty("ProviderVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ServerVersion = (string) content.GetValueForProperty("ServerVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ServerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionState = (string) content.GetValueForProperty("ProviderVersionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionExpiryDate = (global::System.DateTime?) content.GetValueForProperty("ProviderVersionExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricFriendlyName = (string) content.GetValueForProperty("FabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).FabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).LastHeartBeat = (global::System.DateTime?) content.GetValueForProperty("LastHeartBeat",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).LastHeartBeat, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ConnectionStatus = (string) content.GetValueForProperty("ConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ConnectionStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProtectedItemCount = (int?) content.GetValueForProperty("ProtectedItemCount",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProtectedItemCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AllowedScenario = (string[]) content.GetValueForProperty("AllowedScenario",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AllowedScenario, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).HealthErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).HealthErrorDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).DraIdentifier = (string) content.GetValueForProperty("DraIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).DraIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailApplicationId = (string) content.GetValueForProperty("ResourceAccessIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailTenantId = (string) content.GetValueForProperty("AuthenticationIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailObjectId = (string) content.GetValueForProperty("AuthenticationIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAudience = (string) content.GetValueForProperty("AuthenticationIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAadAuthority = (string) content.GetValueForProperty("AuthenticationIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailTenantId = (string) content.GetValueForProperty("ResourceAccessIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailApplicationId = (string) content.GetValueForProperty("AuthenticationIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).AuthenticationIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailObjectId = (string) content.GetValueForProperty("ResourceAccessIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAudience = (string) content.GetValueForProperty("ResourceAccessIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAadAuthority = (string) content.GetValueForProperty("ResourceAccessIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ResourceAccessIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailVersion = (string) content.GetValueForProperty("ProviderVersionDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailExpiryDate = (global::System.DateTime?) content.GetValueForProperty("ProviderVersionDetailExpiryDate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailExpiryDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailStatus = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus?) content.GetValueForProperty("ProviderVersionDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRecoveryServicesProviderPropertiesInternal)this).ProviderVersionDetailStatus, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.AgentVersionStatus.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Recovery services provider properties.
    [System.ComponentModel.TypeConverter(typeof(RecoveryServicesProviderPropertiesTypeConverter))]
    public partial interface IRecoveryServicesProviderProperties

    {

    }
}