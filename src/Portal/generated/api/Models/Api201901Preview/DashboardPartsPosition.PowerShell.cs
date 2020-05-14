namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.PowerShell;

    /// <summary>The dashboard's part position.</summary>
    [System.ComponentModel.TypeConverter(typeof(DashboardPartsPositionTypeConverter))]
    public partial class DashboardPartsPosition
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPosition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DashboardPartsPosition(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).ColSpan = (int) content.GetValueForProperty("ColSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).ColSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).RowSpan = (int) content.GetValueForProperty("RowSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).RowSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).X = (int) content.GetValueForProperty("X",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).X, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Y = (int) content.GetValueForProperty("Y",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Y, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPosition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DashboardPartsPosition(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).ColSpan = (int) content.GetValueForProperty("ColSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).ColSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionMetadataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).RowSpan = (int) content.GetValueForProperty("RowSpan",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).RowSpan, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).X = (int) content.GetValueForProperty("X",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).X, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Y = (int) content.GetValueForProperty("Y",((Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal)this).Y, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPosition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DashboardPartsPosition(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPosition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DashboardPartsPosition(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DashboardPartsPosition" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The dashboard's part position.
    [System.ComponentModel.TypeConverter(typeof(DashboardPartsPositionTypeConverter))]
    public partial interface IDashboardPartsPosition

    {

    }
}