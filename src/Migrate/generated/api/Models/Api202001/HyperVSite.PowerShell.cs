namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Site REST Resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(HyperVSiteTypeConverter))]
    public partial class HyperVSite
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSite DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HyperVSite(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSite DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HyperVSite(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HyperVSite" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSite FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HyperVSite(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVSiteTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties) content.GetValueForProperty("ServicePrincipalIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteSpnPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties) content.GetValueForProperty("AgentDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteAgentPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServiceEndpoint = (string) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServiceEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).DiscoverySolutionId = (string) content.GetValueForProperty("DiscoverySolutionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).DiscoverySolutionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ApplianceName = (string) content.GetValueForProperty("ApplianceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ApplianceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailTenantId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailApplicationId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailObjectId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAudience = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailRawCertData = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailRawCertData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailRawCertData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailId = (string) content.GetValueForProperty("AgentDetailId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailVersion = (string) content.GetValueForProperty("AgentDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailLastHeartBeatUtc = (global::System.DateTime?) content.GetValueForProperty("AgentDetailLastHeartBeatUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailLastHeartBeatUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultUri = (string) content.GetValueForProperty("AgentDetailKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultId = (string) content.GetValueForProperty("AgentDetailKeyVaultId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HyperVSite(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SitePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.HyperVSiteTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ETag = (string) content.GetValueForProperty("ETag",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ETag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteSpnProperties) content.GetValueForProperty("ServicePrincipalIdentityDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteSpnPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISiteAgentProperties) content.GetValueForProperty("AgentDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.SiteAgentPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServiceEndpoint = (string) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServiceEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).DiscoverySolutionId = (string) content.GetValueForProperty("DiscoverySolutionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).DiscoverySolutionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ApplianceName = (string) content.GetValueForProperty("ApplianceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ApplianceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailTenantId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailTenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailApplicationId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailObjectId = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAudience = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAudience",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAudience, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailAadAuthority",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailAadAuthority, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailRawCertData = (string) content.GetValueForProperty("ServicePrincipalIdentityDetailRawCertData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).ServicePrincipalIdentityDetailRawCertData, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailId = (string) content.GetValueForProperty("AgentDetailId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailVersion = (string) content.GetValueForProperty("AgentDetailVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailLastHeartBeatUtc = (global::System.DateTime?) content.GetValueForProperty("AgentDetailLastHeartBeatUtc",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailLastHeartBeatUtc, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultUri = (string) content.GetValueForProperty("AgentDetailKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultUri, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultId = (string) content.GetValueForProperty("AgentDetailKeyVaultId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHyperVSiteInternal)this).AgentDetailKeyVaultId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Site REST Resource.
    [System.ComponentModel.TypeConverter(typeof(HyperVSiteTypeConverter))]
    public partial interface IHyperVSite

    {

    }
}