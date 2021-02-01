namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Recommendation resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(RecommendationPropertiesTypeConverter))]
    public partial class RecommendationProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new RecommendationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new RecommendationProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="RecommendationProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal RecommendationProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CreationTime = (global::System.DateTime?) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CreationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RecommendationId = (string) content.GetValueForProperty("RecommendationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RecommendationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceScope = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType?) content.GetValueForProperty("ResourceScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceScope, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RuleName = (string) content.GetValueForProperty("RuleName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Level = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel?) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Level, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Channel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels?) content.GetValueForProperty("Channel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Channel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CategoryTag = (string[]) content.GetValueForProperty("CategoryTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CategoryTag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ActionName = (string) content.GetValueForProperty("ActionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ActionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Enabled = (int?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Enabled, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).State = (string[]) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).State, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NextNotificationTime = (global::System.DateTime?) content.GetValueForProperty("NextNotificationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NextNotificationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotificationExpirationTime = (global::System.DateTime?) content.GetValueForProperty("NotificationExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotificationExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotifiedTime = (global::System.DateTime?) content.GetValueForProperty("NotifiedTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotifiedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Score = (double?) content.GetValueForProperty("Score",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Score, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).IsDynamic = (bool?) content.GetValueForProperty("IsDynamic",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).IsDynamic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ExtensionName = (string) content.GetValueForProperty("ExtensionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ExtensionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).BladeName = (string) content.GetValueForProperty("BladeName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).BladeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ForwardLink = (string) content.GetValueForProperty("ForwardLink",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ForwardLink, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal RecommendationProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CreationTime = (global::System.DateTime?) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CreationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RecommendationId = (string) content.GetValueForProperty("RecommendationId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RecommendationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceId = (string) content.GetValueForProperty("ResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceScope = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType?) content.GetValueForProperty("ResourceScope",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ResourceScope, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ResourceScopeType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RuleName = (string) content.GetValueForProperty("RuleName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).RuleName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Level = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel?) content.GetValueForProperty("Level",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Level, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.NotificationLevel.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Channel = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels?) content.GetValueForProperty("Channel",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Channel, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.Channels.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CategoryTag = (string[]) content.GetValueForProperty("CategoryTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).CategoryTag, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ActionName = (string) content.GetValueForProperty("ActionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ActionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Enabled = (int?) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Enabled, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).State = (string[]) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).State, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).StartTime = (global::System.DateTime?) content.GetValueForProperty("StartTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).StartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).EndTime = (global::System.DateTime?) content.GetValueForProperty("EndTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).EndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NextNotificationTime = (global::System.DateTime?) content.GetValueForProperty("NextNotificationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NextNotificationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotificationExpirationTime = (global::System.DateTime?) content.GetValueForProperty("NotificationExpirationTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotificationExpirationTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotifiedTime = (global::System.DateTime?) content.GetValueForProperty("NotifiedTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).NotifiedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Score = (double?) content.GetValueForProperty("Score",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).Score, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).IsDynamic = (bool?) content.GetValueForProperty("IsDynamic",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).IsDynamic, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ExtensionName = (string) content.GetValueForProperty("ExtensionName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ExtensionName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).BladeName = (string) content.GetValueForProperty("BladeName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).BladeName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ForwardLink = (string) content.GetValueForProperty("ForwardLink",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRecommendationPropertiesInternal)this).ForwardLink, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Recommendation resource specific properties
    [System.ComponentModel.TypeConverter(typeof(RecommendationPropertiesTypeConverter))]
    public partial interface IRecommendationProperties

    {

    }
}