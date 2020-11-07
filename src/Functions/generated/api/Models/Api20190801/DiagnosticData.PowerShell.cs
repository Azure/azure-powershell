namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Set of data with rendering instructions</summary>
    [System.ComponentModel.TypeConverter(typeof(DiagnosticDataTypeConverter))]
    public partial class DiagnosticData
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DiagnosticData(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DiagnosticData(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DiagnosticData(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRendering) content.GetValueForProperty("RenderingProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RenderingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).Table = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject) content.GetValueForProperty("Table",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).Table, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObjectTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType?) content.GetValueForProperty("RenderingPropertyType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyDescription = (string) content.GetValueForProperty("RenderingPropertyDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyTitle = (string) content.GetValueForProperty("RenderingPropertyTitle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyTitle, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableColumn = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[]) content.GetValueForProperty("TableColumn",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableColumn, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseColumnTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableRow = (string[][]) content.GetValueForProperty("TableRow",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableRow, __y => TypeConverterExtensions.SelectToArray<string[]>(__y, __w => TypeConverterExtensions.SelectToArray<string>(__w, global::System.Convert.ToString)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticData"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DiagnosticData(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingProperty = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRendering) content.GetValueForProperty("RenderingProperty",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingProperty, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.RenderingTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).Table = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject) content.GetValueForProperty("Table",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).Table, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObjectTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyType = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType?) content.GetValueForProperty("RenderingPropertyType",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyType, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RenderingType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyDescription = (string) content.GetValueForProperty("RenderingPropertyDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyTitle = (string) content.GetValueForProperty("RenderingPropertyTitle",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).RenderingPropertyTitle, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableColumn = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[]) content.GetValueForProperty("TableColumn",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableColumn, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseColumnTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableRow = (string[][]) content.GetValueForProperty("TableRow",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableRow, __y => TypeConverterExtensions.SelectToArray<string[]>(__y, __w => TypeConverterExtensions.SelectToArray<string>(__w, global::System.Convert.ToString)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDataInternal)this).TableName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DiagnosticData" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticData FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Set of data with rendering instructions
    [System.ComponentModel.TypeConverter(typeof(DiagnosticDataTypeConverter))]
    public partial interface IDiagnosticData

    {

    }
}