namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.PowerShell;

    /// <summary>Bot channel resource definition</summary>
    [System.ComponentModel.TypeConverter(typeof(BotChannelTypeConverter))]
    public partial class BotChannel
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BotChannel(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ChannelTypeConverter.ConvertFrom);
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
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).ChannelName = (string) content.GetValueForProperty("ChannelName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).ChannelName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BotChannel(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ChannelTypeConverter.ConvertFrom);
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
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).ChannelName = (string) content.GetValueForProperty("ChannelName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannelInternal)this).ChannelName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BotChannel(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.BotChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BotChannel(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BotChannel" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IBotChannel FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Bot channel resource definition
    [System.ComponentModel.TypeConverter(typeof(BotChannelTypeConverter))]
    public partial interface IBotChannel

    {

    }
}