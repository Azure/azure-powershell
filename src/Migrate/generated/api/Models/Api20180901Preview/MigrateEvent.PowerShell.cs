namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>MigrateEvent REST resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrateEventTypeConverter))]
    public partial class MigrateEvent
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateEvent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEvent" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEvent DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MigrateEvent(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateEvent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEvent" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEvent DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MigrateEvent(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MigrateEvent" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEvent FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateEvent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MigrateEvent(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateEventPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Recommendation = (string) content.GetValueForProperty("Recommendation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Recommendation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).PossibleCaus = (string) content.GetValueForProperty("PossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).PossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Solution = (string) content.GetValueForProperty("Solution",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Solution, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ClientRequestId = (string) content.GetValueForProperty("ClientRequestId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ClientRequestId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateEvent"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MigrateEvent(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrateEventPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).InstanceType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorCode = (string) content.GetValueForProperty("ErrorCode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorMessage = (string) content.GetValueForProperty("ErrorMessage",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ErrorMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Recommendation = (string) content.GetValueForProperty("Recommendation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Recommendation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).PossibleCaus = (string) content.GetValueForProperty("PossibleCaus",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).PossibleCaus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Solution = (string) content.GetValueForProperty("Solution",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).Solution, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ClientRequestId = (string) content.GetValueForProperty("ClientRequestId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrateEventInternal)this).ClientRequestId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// MigrateEvent REST resource.
    [System.ComponentModel.TypeConverter(typeof(MigrateEventTypeConverter))]
    public partial interface IMigrateEvent

    {

    }
}