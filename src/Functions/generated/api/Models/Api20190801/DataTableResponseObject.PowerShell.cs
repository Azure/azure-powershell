namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Data Table which defines columns and raw row values</summary>
    [System.ComponentModel.TypeConverter(typeof(DataTableResponseObjectTypeConverter))]
    public partial class DataTableResponseObject
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObject"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DataTableResponseObject(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Column = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[]) content.GetValueForProperty("Column",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Column, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseColumnTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Row = (string[][]) content.GetValueForProperty("Row",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Row, __y => TypeConverterExtensions.SelectToArray<string[]>(__y, __w => TypeConverterExtensions.SelectToArray<string>(__w, global::System.Convert.ToString)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).TableName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObject"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DataTableResponseObject(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Column = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn[]) content.GetValueForProperty("Column",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Column, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseColumn>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseColumnTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Row = (string[][]) content.GetValueForProperty("Row",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).Row, __y => TypeConverterExtensions.SelectToArray<string[]>(__y, __w => TypeConverterExtensions.SelectToArray<string>(__w, global::System.Convert.ToString)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).TableName = (string) content.GetValueForProperty("TableName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObjectInternal)this).TableName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObject"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DataTableResponseObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataTableResponseObject"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DataTableResponseObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DataTableResponseObject" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataTableResponseObject FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Data Table which defines columns and raw row values
    [System.ComponentModel.TypeConverter(typeof(DataTableResponseObjectTypeConverter))]
    public partial interface IDataTableResponseObject

    {

    }
}