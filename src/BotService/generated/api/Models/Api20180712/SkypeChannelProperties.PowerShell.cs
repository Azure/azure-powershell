namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.PowerShell;

    /// <summary>The parameters to provide for the Microsoft Teams channel.</summary>
    [System.ComponentModel.TypeConverter(typeof(SkypeChannelPropertiesTypeConverter))]
    public partial class SkypeChannelProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkypeChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SkypeChannelProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkypeChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SkypeChannelProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SkypeChannelProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkypeChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SkypeChannelProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMessaging = (bool?) content.GetValueForProperty("EnableMessaging",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMessaging, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMediaCard = (bool?) content.GetValueForProperty("EnableMediaCard",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMediaCard, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableVideo = (bool?) content.GetValueForProperty("EnableVideo",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableVideo, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableCalling = (bool?) content.GetValueForProperty("EnableCalling",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableCalling, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableScreenSharing = (bool?) content.GetValueForProperty("EnableScreenSharing",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableScreenSharing, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableGroup = (bool?) content.GetValueForProperty("EnableGroup",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableGroup, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).GroupsMode = (string) content.GetValueForProperty("GroupsMode",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).GroupsMode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).CallingWebHook = (string) content.GetValueForProperty("CallingWebHook",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).CallingWebHook, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).IsEnabled = (bool) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SkypeChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SkypeChannelProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMessaging = (bool?) content.GetValueForProperty("EnableMessaging",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMessaging, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMediaCard = (bool?) content.GetValueForProperty("EnableMediaCard",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableMediaCard, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableVideo = (bool?) content.GetValueForProperty("EnableVideo",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableVideo, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableCalling = (bool?) content.GetValueForProperty("EnableCalling",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableCalling, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableScreenSharing = (bool?) content.GetValueForProperty("EnableScreenSharing",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableScreenSharing, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableGroup = (bool?) content.GetValueForProperty("EnableGroup",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).EnableGroup, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).GroupsMode = (string) content.GetValueForProperty("GroupsMode",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).GroupsMode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).CallingWebHook = (string) content.GetValueForProperty("CallingWebHook",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).CallingWebHook, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).IsEnabled = (bool) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISkypeChannelPropertiesInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The parameters to provide for the Microsoft Teams channel.
    [System.ComponentModel.TypeConverter(typeof(SkypeChannelPropertiesTypeConverter))]
    public partial interface ISkypeChannelProperties

    {

    }
}