namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.PowerShell;

    /// <summary>A site for the Direct Line channel</summary>
    [System.ComponentModel.TypeConverter(typeof(DirectLineSiteTypeConverter))]
    public partial class DirectLineSite
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.DirectLineSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DirectLineSite(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.DirectLineSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DirectLineSite(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.DirectLineSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DirectLineSite(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteId = (string) content.GetValueForProperty("SiteId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteName = (string) content.GetValueForProperty("SiteName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key2 = (string) content.GetValueForProperty("Key2",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsEnabled = (bool) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV1Enabled = (bool) content.GetValueForProperty("IsV1Enabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV1Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV3Enabled = (bool) content.GetValueForProperty("IsV3Enabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV3Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsSecureSiteEnabled = (bool?) content.GetValueForProperty("IsSecureSiteEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsSecureSiteEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).TrustedOrigin = (string[]) content.GetValueForProperty("TrustedOrigin",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).TrustedOrigin, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.DirectLineSite"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DirectLineSite(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteId = (string) content.GetValueForProperty("SiteId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteName = (string) content.GetValueForProperty("SiteName",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).SiteName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key = (string) content.GetValueForProperty("Key",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key2 = (string) content.GetValueForProperty("Key2",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).Key2, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsEnabled = (bool) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV1Enabled = (bool) content.GetValueForProperty("IsV1Enabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV1Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV3Enabled = (bool) content.GetValueForProperty("IsV3Enabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsV3Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsSecureSiteEnabled = (bool?) content.GetValueForProperty("IsSecureSiteEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).IsSecureSiteEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).TrustedOrigin = (string[]) content.GetValueForProperty("TrustedOrigin",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSiteInternal)this).TrustedOrigin, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DirectLineSite" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A site for the Direct Line channel
    [System.ComponentModel.TypeConverter(typeof(DirectLineSiteTypeConverter))]
    public partial interface IDirectLineSite

    {

    }
}