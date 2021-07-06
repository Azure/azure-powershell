namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>Tables that will be included and excluded in the follower database</summary>
    [System.ComponentModel.TypeConverter(typeof(TableLevelSharingPropertiesTypeConverter))]
    public partial class TableLevelSharingProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.TableLevelSharingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new TableLevelSharingProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.TableLevelSharingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new TableLevelSharingProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TableLevelSharingProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.TableLevelSharingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal TableLevelSharingProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToInclude = (string[]) content.GetValueForProperty("TablesToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToExclude = (string[]) content.GetValueForProperty("TablesToExclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToExclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToInclude = (string[]) content.GetValueForProperty("ExternalTablesToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToExclude = (string[]) content.GetValueForProperty("ExternalTablesToExclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToExclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToInclude = (string[]) content.GetValueForProperty("MaterializedViewsToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToExclude = (string[]) content.GetValueForProperty("MaterializedViewsToExclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToExclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.TableLevelSharingProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal TableLevelSharingProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToInclude = (string[]) content.GetValueForProperty("TablesToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToExclude = (string[]) content.GetValueForProperty("TablesToExclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).TablesToExclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToInclude = (string[]) content.GetValueForProperty("ExternalTablesToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToExclude = (string[]) content.GetValueForProperty("ExternalTablesToExclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).ExternalTablesToExclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToInclude = (string[]) content.GetValueForProperty("MaterializedViewsToInclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToInclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToExclude = (string[]) content.GetValueForProperty("MaterializedViewsToExclude",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal)this).MaterializedViewsToExclude, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Tables that will be included and excluded in the follower database
    [System.ComponentModel.TypeConverter(typeof(TableLevelSharingPropertiesTypeConverter))]
    public partial interface ITableLevelSharingProperties

    {

    }
}