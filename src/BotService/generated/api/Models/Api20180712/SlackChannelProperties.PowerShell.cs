namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.PowerShell;

    /// <summary>The parameters to provide for the Slack channel.</summary>
    [System.ComponentModel.TypeConverter(typeof(SlackChannelPropertiesTypeConverter))]
    public partial class SlackChannelProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SlackChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SlackChannelProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SlackChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SlackChannelProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SlackChannelProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SlackChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SlackChannelProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientSecret = (string) content.GetValueForProperty("ClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).VerificationToken = (string) content.GetValueForProperty("VerificationToken",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).VerificationToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LandingPageUrl = (string) content.GetValueForProperty("LandingPageUrl",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LandingPageUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RedirectAction = (string) content.GetValueForProperty("RedirectAction",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RedirectAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LastSubmissionId = (string) content.GetValueForProperty("LastSubmissionId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LastSubmissionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RegisterBeforeOAuthFlow = (bool?) content.GetValueForProperty("RegisterBeforeOAuthFlow",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RegisterBeforeOAuthFlow, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsValidated = (bool?) content.GetValueForProperty("IsValidated",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsValidated, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsEnabled = (bool) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.SlackChannelProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SlackChannelProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientId = (string) content.GetValueForProperty("ClientId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientSecret = (string) content.GetValueForProperty("ClientSecret",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).ClientSecret, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).VerificationToken = (string) content.GetValueForProperty("VerificationToken",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).VerificationToken, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LandingPageUrl = (string) content.GetValueForProperty("LandingPageUrl",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LandingPageUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RedirectAction = (string) content.GetValueForProperty("RedirectAction",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RedirectAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LastSubmissionId = (string) content.GetValueForProperty("LastSubmissionId",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).LastSubmissionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RegisterBeforeOAuthFlow = (bool?) content.GetValueForProperty("RegisterBeforeOAuthFlow",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).RegisterBeforeOAuthFlow, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsValidated = (bool?) content.GetValueForProperty("IsValidated",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsValidated, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsEnabled = (bool) content.GetValueForProperty("IsEnabled",((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ISlackChannelPropertiesInternal)this).IsEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The parameters to provide for the Slack channel.
    [System.ComponentModel.TypeConverter(typeof(SlackChannelPropertiesTypeConverter))]
    public partial interface ISlackChannelProperties

    {

    }
}