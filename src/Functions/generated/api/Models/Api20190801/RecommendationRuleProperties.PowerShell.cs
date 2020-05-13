namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>RecommendationRule resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(RecommendationRulePropertiesTypeConverter))]
    public partial class RecommendationRuleProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationRuleProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RecommendationRuleProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationRuleProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RecommendationRuleProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RecommendationRuleProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRuleProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationRuleProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RecommendationRuleProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ActionName = (string) content.GetValueForProperty("ActionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ActionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).BladeName = (string) content.GetValueForProperty("BladeName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).BladeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).CategoryTag = (string[]) content.GetValueForProperty("CategoryTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).CategoryTag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Channel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels?) content.GetValueForProperty("Channel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Channel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ExtensionName = (string) content.GetValueForProperty("ExtensionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ExtensionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ForwardLink = (string) content.GetValueForProperty("ForwardLink",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ForwardLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).IsDynamic = (bool?) content.GetValueForProperty("IsDynamic",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).IsDynamic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Level = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel?) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Level, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationId = (string) content.GetValueForProperty("RecommendationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationName = (string) content.GetValueForProperty("RecommendationName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationRuleProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RecommendationRuleProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ActionName = (string) content.GetValueForProperty("ActionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ActionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).BladeName = (string) content.GetValueForProperty("BladeName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).BladeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).CategoryTag = (string[]) content.GetValueForProperty("CategoryTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).CategoryTag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Channel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels?) content.GetValueForProperty("Channel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Channel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ExtensionName = (string) content.GetValueForProperty("ExtensionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ExtensionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ForwardLink = (string) content.GetValueForProperty("ForwardLink",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).ForwardLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).IsDynamic = (bool?) content.GetValueForProperty("IsDynamic",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).IsDynamic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Level = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel?) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Level, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationId = (string) content.GetValueForProperty("RecommendationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationName = (string) content.GetValueForProperty("RecommendationName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationRulePropertiesInternal)this).RecommendationName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// RecommendationRule resource specific properties
    [System.ComponentModel.TypeConverter(typeof(RecommendationRulePropertiesTypeConverter))]
    public partial interface IRecommendationRuleProperties

    {

    }
}