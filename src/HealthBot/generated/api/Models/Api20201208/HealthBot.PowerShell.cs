namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208
{
    using Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.PowerShell;

    /// <summary>HealthBot resource definition</summary>
    [System.ComponentModel.TypeConverter(typeof(HealthBotTypeConverter))]
    public partial class HealthBot
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HealthBot(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HealthBot(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HealthBot" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBot FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HealthBot(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBotPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).BotManagementPortalLink = (string) content.GetValueForProperty("BotManagementPortalLink",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).BotManagementPortalLink, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HealthBot(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.HealthBotPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedByType = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType?) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataCreatedByType, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedByType = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType?) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedByType, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.SystemDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.TrackedResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).BotManagementPortalLink = (string) content.GetValueForProperty("BotManagementPortalLink",((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotInternal)this).BotManagementPortalLink, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// HealthBot resource definition
    [System.ComponentModel.TypeConverter(typeof(HealthBotTypeConverter))]
    public partial interface IHealthBot

    {

    }
}