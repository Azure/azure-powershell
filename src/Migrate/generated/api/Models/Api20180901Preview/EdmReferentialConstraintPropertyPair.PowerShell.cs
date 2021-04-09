namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(EdmReferentialConstraintPropertyPairTypeConverter))]
    public partial class EdmReferentialConstraintPropertyPair
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.EdmReferentialConstraintPropertyPair"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EdmReferentialConstraintPropertyPair(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.EdmReferentialConstraintPropertyPair"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EdmReferentialConstraintPropertyPair(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.EdmReferentialConstraintPropertyPair"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EdmReferentialConstraintPropertyPair(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentProperty = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty) content.GetValueForProperty("DependentProperty",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentProperty, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalProperty = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty) content.GetValueForProperty("PrincipalProperty",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalProperty, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("DependentPropertyType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDefaultValueString = (string) content.GetValueForProperty("DependentPropertyDefaultValueString",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDefaultValueString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyKind = (string) content.GetValueForProperty("DependentPropertyKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDeclaringType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType) content.GetValueForProperty("DependentPropertyDeclaringType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDeclaringType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuredTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyName = (string) content.GetValueForProperty("DependentPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("PrincipalPropertyType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDefaultValueString = (string) content.GetValueForProperty("PrincipalPropertyDefaultValueString",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDefaultValueString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyKind = (string) content.GetValueForProperty("PrincipalPropertyKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDeclaringType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType) content.GetValueForProperty("PrincipalPropertyDeclaringType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDeclaringType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuredTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyName = (string) content.GetValueForProperty("PrincipalPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("DependentPropertyTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeIsNullable = (bool?) content.GetValueForProperty("DependentPropertyTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("PrincipalPropertyTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeIsNullable = (bool?) content.GetValueForProperty("PrincipalPropertyTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinitionTypeKind = (string) content.GetValueForProperty("DependentPropertyTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinitionTypeKind = (string) content.GetValueForProperty("PrincipalPropertyTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.EdmReferentialConstraintPropertyPair"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EdmReferentialConstraintPropertyPair(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentProperty = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty) content.GetValueForProperty("DependentProperty",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentProperty, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalProperty = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty) content.GetValueForProperty("PrincipalProperty",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalProperty, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("DependentPropertyType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDefaultValueString = (string) content.GetValueForProperty("DependentPropertyDefaultValueString",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDefaultValueString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyKind = (string) content.GetValueForProperty("DependentPropertyKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDeclaringType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType) content.GetValueForProperty("DependentPropertyDeclaringType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyDeclaringType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuredTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyName = (string) content.GetValueForProperty("DependentPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference) content.GetValueForProperty("PrincipalPropertyType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReferenceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDefaultValueString = (string) content.GetValueForProperty("PrincipalPropertyDefaultValueString",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDefaultValueString, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyKind = (string) content.GetValueForProperty("PrincipalPropertyKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDeclaringType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType) content.GetValueForProperty("PrincipalPropertyDeclaringType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyDeclaringType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuredTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyName = (string) content.GetValueForProperty("PrincipalPropertyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("DependentPropertyTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeIsNullable = (bool?) content.GetValueForProperty("DependentPropertyTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinition = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("PrincipalPropertyTypeDefinition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinition, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeIsNullable = (bool?) content.GetValueForProperty("PrincipalPropertyTypeIsNullable",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeIsNullable, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinitionTypeKind = (string) content.GetValueForProperty("DependentPropertyTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).DependentPropertyTypeDefinitionTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinitionTypeKind = (string) content.GetValueForProperty("PrincipalPropertyTypeDefinitionTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal)this).PrincipalPropertyTypeDefinitionTypeKind, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EdmReferentialConstraintPropertyPair" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(EdmReferentialConstraintPropertyPairTypeConverter))]
    public partial interface IEdmReferentialConstraintPropertyPair

    {

    }
}