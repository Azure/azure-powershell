namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>
    /// Result of query. It contains all columns listed under groupings and aggregation.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(QueryResultTypeConverter))]
    public partial class QueryResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new QueryResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new QueryResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="QueryResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal QueryResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).NextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Column = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn[]) content.GetValueForProperty("Column",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Column, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryColumnTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Row = (string[][]) content.GetValueForProperty("Row",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Row, __y => TypeConverterExtensions.SelectToArray<string[]>(__y, __w => TypeConverterExtensions.SelectToArray<string>(__w, global::System.Convert.ToString)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal QueryResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).NextLink, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Column = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn[]) content.GetValueForProperty("Column",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Column, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryColumn>(__y, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.QueryColumnTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Row = (string[][]) content.GetValueForProperty("Row",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IQueryResultInternal)this).Row, __y => TypeConverterExtensions.SelectToArray<string[]>(__y, __w => TypeConverterExtensions.SelectToArray<string>(__w, global::System.Convert.ToString)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Result of query. It contains all columns listed under groupings and aggregation.
    [System.ComponentModel.TypeConverter(typeof(QueryResultTypeConverter))]
    public partial interface IQueryResult

    {

    }
}