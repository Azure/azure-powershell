namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.PowerShell;

    /// <summary>Bot resource definition</summary>
    [System.ComponentModel.TypeConverter(typeof(BotTypeConverter))]
    public partial class Bot
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Bot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Bot(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind?) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).ConfiguredChannel = (string[]) content.GetValueForProperty("ConfiguredChannel",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).ConfiguredChannel, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).IconUrl = (string) content.GetValueForProperty("IconUrl",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).IconUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Endpoint = (string) content.GetValueForProperty("Endpoint",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Endpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EndpointVersion = (string) content.GetValueForProperty("EndpointVersion",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EndpointVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).MsaAppId = (string) content.GetValueForProperty("MsaAppId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).MsaAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EnabledChannel = (string[]) content.GetValueForProperty("EnabledChannel",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EnabledChannel, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightKey = (string) content.GetValueForProperty("DeveloperAppInsightKey",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApiKey = (string) content.GetValueForProperty("DeveloperAppInsightsApiKey",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApplicationId = (string) content.GetValueForProperty("DeveloperAppInsightsApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisAppId = (string[]) content.GetValueForProperty("LuisAppId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisAppId, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisKey = (string) content.GetValueForProperty("LuisKey",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisKey, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Bot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Bot(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuTier = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier?) content.GetValueForProperty("SkuTier",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).SkuTier, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.SkuTier.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Sku = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISku) content.GetValueForProperty("Sku",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Sku, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Kind = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind?) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Kind, Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.Kind.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IResourceInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).ConfiguredChannel = (string[]) content.GetValueForProperty("ConfiguredChannel",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).ConfiguredChannel, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).IconUrl = (string) content.GetValueForProperty("IconUrl",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).IconUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Endpoint = (string) content.GetValueForProperty("Endpoint",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Endpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EndpointVersion = (string) content.GetValueForProperty("EndpointVersion",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EndpointVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).MsaAppId = (string) content.GetValueForProperty("MsaAppId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).MsaAppId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EnabledChannel = (string[]) content.GetValueForProperty("EnabledChannel",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).EnabledChannel, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightKey = (string) content.GetValueForProperty("DeveloperAppInsightKey",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApiKey = (string) content.GetValueForProperty("DeveloperAppInsightsApiKey",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApiKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApplicationId = (string) content.GetValueForProperty("DeveloperAppInsightsApplicationId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).DeveloperAppInsightsApplicationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisAppId = (string[]) content.GetValueForProperty("LuisAppId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisAppId, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisKey = (string) content.GetValueForProperty("LuisKey",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotInternal)this).LuisKey, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Bot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Bot(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Bot"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Bot(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Bot" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBot FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Bot resource definition
    [System.ComponentModel.TypeConverter(typeof(BotTypeConverter))]
    public partial interface IBot

    {

    }
}