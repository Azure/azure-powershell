namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ODataQueryOptions1TypeConverter))]
    public partial class ODataQueryOptions1
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryOptions1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1 DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ODataQueryOptions1(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryOptions1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1 DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ODataQueryOptions1(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ODataQueryOptions1" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1 FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryOptions1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ODataQueryOptions1(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).Filter = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption) content.GetValueForProperty("Filter",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).Filter, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClause = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause) content.GetValueForProperty("FilterClause",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClause, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClauseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterValidator = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) content.GetValueForProperty("FilterValidator",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterValidator, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterRawValue = (string) content.GetValueForProperty("FilterRawValue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterRawValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterContext = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext) content.GetValueForProperty("FilterContext",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterContext, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryContextTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseRangeVariable = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable) content.GetValueForProperty("FilterClauseRangeVariable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseRangeVariable, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.RangeVariableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseExpression = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode) content.GetValueForProperty("FilterClauseExpression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseExpression, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SingleValueNodeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseItemType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("FilterClauseItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseItemType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableName = (string) content.GetValueForProperty("RangeVariableName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ExpressionTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("RangeVariableTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableKind = (int?) content.GetValueForProperty("RangeVariableKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableKind, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ItemTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeIsNullable = (bool?) content.GetValueForProperty("ItemTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ExpressionTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceIsNullable = (bool?) content.GetValueForProperty("ExpressionTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("RangeVariableTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceIsNullable = (bool?) content.GetValueForProperty("RangeVariableTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinitionTypeKind = (string) content.GetValueForProperty("ItemTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("ExpressionTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("RangeVariableTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryOptions1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ODataQueryOptions1(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).Filter = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption) content.GetValueForProperty("Filter",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).Filter, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOptionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClause = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause) content.GetValueForProperty("FilterClause",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClause, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClauseTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterValidator = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) content.GetValueForProperty("FilterValidator",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterValidator, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterRawValue = (string) content.GetValueForProperty("FilterRawValue",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterRawValue, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterContext = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext) content.GetValueForProperty("FilterContext",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterContext, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryContextTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseRangeVariable = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable) content.GetValueForProperty("FilterClauseRangeVariable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseRangeVariable, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.RangeVariableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseExpression = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode) content.GetValueForProperty("FilterClauseExpression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseExpression, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SingleValueNodeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseItemType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("FilterClauseItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).FilterClauseItemType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableName = (string) content.GetValueForProperty("RangeVariableName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ExpressionTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("RangeVariableTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableKind = (int?) content.GetValueForProperty("RangeVariableKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableKind, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ItemTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeIsNullable = (bool?) content.GetValueForProperty("ItemTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ExpressionTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceIsNullable = (bool?) content.GetValueForProperty("ExpressionTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("RangeVariableTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceIsNullable = (bool?) content.GetValueForProperty("RangeVariableTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinitionTypeKind = (string) content.GetValueForProperty("ItemTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ItemTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("ExpressionTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).ExpressionTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("RangeVariableTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal)this).RangeVariableTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ODataQueryOptions1TypeConverter))]
    public partial interface IODataQueryOptions1

    {

    }
}