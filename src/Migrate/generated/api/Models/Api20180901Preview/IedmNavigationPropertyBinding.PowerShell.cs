namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(IedmNavigationPropertyBindingTypeConverter))]
    public partial class IedmNavigationPropertyBinding
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBinding"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new IedmNavigationPropertyBinding(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBinding"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new IedmNavigationPropertyBinding(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="IedmNavigationPropertyBinding" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBinding"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal IedmNavigationPropertyBinding(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Target = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSource) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Target, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpressionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).NavigationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationProperty) content.GetValueForProperty("NavigationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).NavigationProperty, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path1 = (string) content.GetValueForProperty("Path1",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPath = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression) content.GetValueForProperty("TargetPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPath, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpressionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("TargetType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetNavigationPropertyBinding = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[]) content.GetValueForProperty("TargetNavigationPropertyBinding",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetNavigationPropertyBinding, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBindingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetName = (string) content.GetValueForProperty("TargetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).IedmPathExpressionPath = (string) content.GetValueForProperty("IedmPathExpressionPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).IedmPathExpressionPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).PathSegment = (string[]) content.GetValueForProperty("PathSegment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).PathSegment, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathSegment = (string[]) content.GetValueForProperty("TargetPathSegment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathSegment, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathExpressionKind = (string) content.GetValueForProperty("TargetPathExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TypeKind = (string) content.GetValueForProperty("TypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TypeKind, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBinding"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal IedmNavigationPropertyBinding(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Target = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSource) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Target, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpressionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).NavigationProperty = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationProperty) content.GetValueForProperty("NavigationProperty",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).NavigationProperty, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path1 = (string) content.GetValueForProperty("Path1",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).Path1, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPath = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression) content.GetValueForProperty("TargetPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPath, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpressionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("TargetType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetNavigationPropertyBinding = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[]) content.GetValueForProperty("TargetNavigationPropertyBinding",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetNavigationPropertyBinding, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBindingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetName = (string) content.GetValueForProperty("TargetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).IedmPathExpressionPath = (string) content.GetValueForProperty("IedmPathExpressionPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).IedmPathExpressionPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).PathSegment = (string[]) content.GetValueForProperty("PathSegment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).PathSegment, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).ExpressionKind = (string) content.GetValueForProperty("ExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).ExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathSegment = (string[]) content.GetValueForProperty("TargetPathSegment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathSegment, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathExpressionKind = (string) content.GetValueForProperty("TargetPathExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TargetPathExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TypeKind = (string) content.GetValueForProperty("TypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBindingInternal)this).TypeKind, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(IedmNavigationPropertyBindingTypeConverter))]
    public partial interface IIedmNavigationPropertyBinding

    {

    }
}