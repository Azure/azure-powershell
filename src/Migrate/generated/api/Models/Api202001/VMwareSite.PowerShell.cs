namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Site REST Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(VMwareSiteTypeConverter))]
    public partial class VMwareSite
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VMwareSite(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VMwareSite(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VMwareSite" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VMwareSite(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareSiteTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties) content.GetValueForProperty("ServicePrincipalIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteSpnPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServiceEndpoint = (string) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServiceEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).DiscoverySolutionId = (string) content.GetValueForProperty("DiscoverySolutionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).DiscoverySolutionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ApplianceName = (string) content.GetValueForProperty("ApplianceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ApplianceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties) content.GetValueForProperty("AgentDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteAgentPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailRawCertData = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailRawCertData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailRawCertData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailTenantId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailObjectId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultId = (string) content.GetValueForProperty("AgentDetailKeyVaultId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailApplicationId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailId = (string) content.GetValueForProperty("AgentDetailId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailVersion = (string) content.GetValueForProperty("AgentDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailLastHeartBeatUtc = (global::System.DateTime?) content.GetValueForProperty("AgentDetailLastHeartBeatUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailLastHeartBeatUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultUri = (string) content.GetValueForProperty("AgentDetailKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAudience = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAudience, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VMwareSite(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareSiteTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties) content.GetValueForProperty("ServicePrincipalIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteSpnPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServiceEndpoint = (string) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServiceEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).DiscoverySolutionId = (string) content.GetValueForProperty("DiscoverySolutionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).DiscoverySolutionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ApplianceName = (string) content.GetValueForProperty("ApplianceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ApplianceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties) content.GetValueForProperty("AgentDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteAgentPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailRawCertData = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailRawCertData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailRawCertData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailTenantId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailObjectId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultId = (string) content.GetValueForProperty("AgentDetailKeyVaultId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailApplicationId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailId = (string) content.GetValueForProperty("AgentDetailId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailVersion = (string) content.GetValueForProperty("AgentDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailLastHeartBeatUtc = (global::System.DateTime?) content.GetValueForProperty("AgentDetailLastHeartBeatUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailLastHeartBeatUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultUri = (string) content.GetValueForProperty("AgentDetailKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).AgentDetailKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAudience = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteInternal)this).ServicePrincipalIdentityDetailAudience, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Site REST Resource.
    [System.ComponentModel.TypeConverter(typeof(VMwareSiteTypeConverter))]
    public partial interface IVMwareSite

    {

    }
}