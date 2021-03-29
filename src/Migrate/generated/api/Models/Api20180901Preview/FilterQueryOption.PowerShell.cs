namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(FilterQueryOptionTypeConverter))]
    public partial class FilterQueryOption
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FilterQueryOption(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FilterQueryOption(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FilterQueryOption(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClause = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause) content.GetValueForProperty("FilterClause",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClause, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClauseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Validator = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) content.GetValueForProperty("Validator",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Validator, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RawValue = (string) content.GetValueForProperty("RawValue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RawValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Context = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext) content.GetValueForProperty("Context",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Context, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryContextTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseRangeVariable = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable) content.GetValueForProperty("FilterClauseRangeVariable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseRangeVariable, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.RangeVariableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseExpression = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode) content.GetValueForProperty("FilterClauseExpression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseExpression, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SingleValueNodeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseItemType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("FilterClauseItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseItemType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableName = (string) content.GetValueForProperty("RangeVariableName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ExpressionTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("RangeVariableTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableKind = (int?) content.GetValueForProperty("RangeVariableKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableKind, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ItemTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeIsNullable = (bool?) content.GetValueForProperty("ItemTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ExpressionTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceIsNullable = (bool?) content.GetValueForProperty("ExpressionTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("RangeVariableTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceIsNullable = (bool?) content.GetValueForProperty("RangeVariableTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinitionTypeKind = (string) content.GetValueForProperty("ItemTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("ExpressionTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("RangeVariableTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOption"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FilterQueryOption(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClause = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause) content.GetValueForProperty("FilterClause",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClause, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClauseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Validator = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) content.GetValueForProperty("Validator",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Validator, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RawValue = (string) content.GetValueForProperty("RawValue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RawValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Context = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext) content.GetValueForProperty("Context",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).Context, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryContextTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseRangeVariable = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable) content.GetValueForProperty("FilterClauseRangeVariable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseRangeVariable, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.RangeVariableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseExpression = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode) content.GetValueForProperty("FilterClauseExpression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseExpression, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SingleValueNodeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseItemType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("FilterClauseItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).FilterClauseItemType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableName = (string) content.GetValueForProperty("RangeVariableName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ExpressionTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("RangeVariableTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableKind = (int?) content.GetValueForProperty("RangeVariableKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableKind, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ItemTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeIsNullable = (bool?) content.GetValueForProperty("ItemTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ExpressionTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceIsNullable = (bool?) content.GetValueForProperty("ExpressionTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("RangeVariableTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceIsNullable = (bool?) content.GetValueForProperty("RangeVariableTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinitionTypeKind = (string) content.GetValueForProperty("ItemTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ItemTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("ExpressionTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).ExpressionTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("RangeVariableTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)this).RangeVariableTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FilterQueryOption" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(FilterQueryOptionTypeConverter))]
    public partial interface IFilterQueryOption

    {

    }
}