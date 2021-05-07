namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(FilterClauseTypeConverter))]
    public partial class FilterClause
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClause"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FilterClause(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClause"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FilterClause(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClause"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FilterClause(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).Expression = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode) content.GetValueForProperty("Expression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).Expression, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SingleValueNodeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariable = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable) content.GetValueForProperty("RangeVariable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariable, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.RangeVariableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableName = (string) content.GetValueForProperty("RangeVariableName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ExpressionTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("RangeVariableTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableKind = (int?) content.GetValueForProperty("RangeVariableKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableKind, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ItemTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeIsNullable = (bool?) content.GetValueForProperty("ItemTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ExpressionTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceIsNullable = (bool?) content.GetValueForProperty("ExpressionTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("RangeVariableTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceIsNullable = (bool?) content.GetValueForProperty("RangeVariableTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinitionTypeKind = (string) content.GetValueForProperty("ItemTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("ExpressionTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("RangeVariableTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClause"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FilterClause(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).Expression = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode) content.GetValueForProperty("Expression",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).Expression, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.SingleValueNodeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariable = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable) content.GetValueForProperty("RangeVariable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariable, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.RangeVariableTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableName = (string) content.GetValueForProperty("RangeVariableName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("ExpressionTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReference = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("RangeVariableTypeReference",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReference, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableKind = (int?) content.GetValueForProperty("RangeVariableKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableKind, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ItemTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeIsNullable = (bool?) content.GetValueForProperty("ItemTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("ExpressionTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceIsNullable = (bool?) content.GetValueForProperty("ExpressionTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("RangeVariableTypeReferenceDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceIsNullable = (bool?) content.GetValueForProperty("RangeVariableTypeReferenceIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinitionTypeKind = (string) content.GetValueForProperty("ItemTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ItemTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("ExpressionTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).ExpressionTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinitionTypeKind = (string) content.GetValueForProperty("RangeVariableTypeReferenceDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)this).RangeVariableTypeReferenceDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FilterClause" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(FilterClauseTypeConverter))]
    public partial interface IFilterClause

    {

    }
}