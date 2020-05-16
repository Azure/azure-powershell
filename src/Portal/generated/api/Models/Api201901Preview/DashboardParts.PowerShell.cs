namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.PowerShell;

    /// <summary>A dashboard part.</summary>
    [System.ComponentModel.TypeConverter(typeof(DashboardPartsTypeConverter))]
    public partial class DashboardParts
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardParts"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DashboardParts(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Position = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition) content.GetValueForProperty("Position",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Position, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionColSpan = (int) content.GetValueForProperty("PositionColSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionColSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionMetadata = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata) content.GetValueForProperty("PositionMetadata",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionMetadata, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionRowSpan = (int) content.GetValueForProperty("PositionRowSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionRowSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionX = (int) content.GetValueForProperty("PositionX",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionX, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionY = (int) content.GetValueForProperty("PositionY",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionY, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardParts"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DashboardParts(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Position = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition) content.GetValueForProperty("Position",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Position, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionColSpan = (int) content.GetValueForProperty("PositionColSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionColSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionMetadata = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata) content.GetValueForProperty("PositionMetadata",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionMetadata, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionRowSpan = (int) content.GetValueForProperty("PositionRowSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionRowSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionX = (int) content.GetValueForProperty("PositionX",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionX, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionY = (int) content.GetValueForProperty("PositionY",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsInternal)this).PositionY, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardParts"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardParts" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardParts DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DashboardParts(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardParts"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardParts" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardParts DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DashboardParts(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DashboardParts" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardParts FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A dashboard part.
    [System.ComponentModel.TypeConverter(typeof(DashboardPartsTypeConverter))]
    public partial interface IDashboardParts

    {

    }
}