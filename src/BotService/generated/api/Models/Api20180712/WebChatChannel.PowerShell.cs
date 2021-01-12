namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.PowerShell;

    /// <summary>Web Chat channel definition</summary>
    [System.ComponentModel.TypeConverter(typeof(WebChatChannelTypeConverter))]
    public partial class WebChatChannel
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannel" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannel DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new WebChatChannel(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannel" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannel DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new WebChatChannel(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="WebChatChannel" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannel FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal WebChatChannel(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannelPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).WebChatEmbedCode = (string) content.GetValueForProperty("WebChatEmbedCode",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).WebChatEmbedCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Site = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[]) content.GetValueForProperty("Site",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Site, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite>(__y, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatSiteTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannel"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal WebChatChannel(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatChannelPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).WebChatEmbedCode = (string) content.GetValueForProperty("WebChatEmbedCode",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).WebChatEmbedCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Site = (Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite[]) content.GetValueForProperty("Site",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatChannelInternal)this).Site, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IWebChatSite>(__y, Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.WebChatSiteTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }
    }
    /// Web Chat channel definition
    [System.ComponentModel.TypeConverter(typeof(WebChatChannelTypeConverter))]
    public partial interface IWebChatChannel

    {

    }
}