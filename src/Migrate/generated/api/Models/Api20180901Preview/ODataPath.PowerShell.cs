namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ODataPathTypeConverter))]
    public partial class ODataPath
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPath"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPath" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPath DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ODataPath(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPath"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPath" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPath DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ODataPath(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ODataPath" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPath FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPath"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ODataPath(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("EdmType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSource = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSource) content.GetValueForProperty("NavigationSource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSource, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Segment = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment[]) content.GetValueForProperty("Segment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Segment, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPathSegmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathTemplate = (string) content.GetValueForProperty("PathTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Path = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment[]) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Path, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPathSegmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmTypeKind = (string) content.GetValueForProperty("EdmTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourcePath = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression) content.GetValueForProperty("NavigationSourcePath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourcePath, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpressionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("NavigationSourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceNavigationPropertyBinding = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[]) content.GetValueForProperty("NavigationSourceNavigationPropertyBinding",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceNavigationPropertyBinding, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBindingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceName = (string) content.GetValueForProperty("NavigationSourceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).IedmPathExpressionPath = (string) content.GetValueForProperty("IedmPathExpressionPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).IedmPathExpressionPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathSegment = (string[]) content.GetValueForProperty("PathSegment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathSegment, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathExpressionKind = (string) content.GetValueForProperty("PathExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).TypeKind = (string) content.GetValueForProperty("TypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).TypeKind, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPath"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ODataPath(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("EdmType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSource = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSource) content.GetValueForProperty("NavigationSource",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSource, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationSourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Segment = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment[]) content.GetValueForProperty("Segment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Segment, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPathSegmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathTemplate = (string) content.GetValueForProperty("PathTemplate",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathTemplate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Path = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment[]) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).Path, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathSegment>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataPathSegmentTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmTypeKind = (string) content.GetValueForProperty("EdmTypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).EdmTypeKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourcePath = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression) content.GetValueForProperty("NavigationSourcePath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourcePath, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpressionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType) content.GetValueForProperty("NavigationSourceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceNavigationPropertyBinding = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[]) content.GetValueForProperty("NavigationSourceNavigationPropertyBinding",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceNavigationPropertyBinding, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmNavigationPropertyBindingTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceName = (string) content.GetValueForProperty("NavigationSourceName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).NavigationSourceName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).IedmPathExpressionPath = (string) content.GetValueForProperty("IedmPathExpressionPath",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).IedmPathExpressionPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathSegment = (string[]) content.GetValueForProperty("PathSegment",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathSegment, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathExpressionKind = (string) content.GetValueForProperty("PathExpressionKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).PathExpressionKind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).TypeKind = (string) content.GetValueForProperty("TypeKind",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataPathInternal)this).TypeKind, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ODataPathTypeConverter))]
    public partial interface IODataPath

    {

    }
}