namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Application stack major version.</summary>
    [System.ComponentModel.TypeConverter(typeof(StackMajorVersionTypeConverter))]
    public partial class StackMajorVersion
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMajorVersion"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new StackMajorVersion(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMajorVersion"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new StackMajorVersion(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="StackMajorVersion" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMajorVersion"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal StackMajorVersion(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).ApplicationInsight = (bool?) content.GetValueForProperty("ApplicationInsight",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).ApplicationInsight, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).DisplayVersion = (string) content.GetValueForProperty("DisplayVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).DisplayVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDefault = (bool?) content.GetValueForProperty("IsDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDefault, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDeprecated = (bool?) content.GetValueForProperty("IsDeprecated",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDeprecated, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsHidden = (bool?) content.GetValueForProperty("IsHidden",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsHidden, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsPreview = (bool?) content.GetValueForProperty("IsPreview",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsPreview, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).MinorVersion = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion[]) content.GetValueForProperty("MinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).MinorVersion, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMinorVersionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).RuntimeVersion = (string) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).RuntimeVersion, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMajorVersion"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal StackMajorVersion(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).ApplicationInsight = (bool?) content.GetValueForProperty("ApplicationInsight",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).ApplicationInsight, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).DisplayVersion = (string) content.GetValueForProperty("DisplayVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).DisplayVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDefault = (bool?) content.GetValueForProperty("IsDefault",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDefault, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDeprecated = (bool?) content.GetValueForProperty("IsDeprecated",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsDeprecated, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsHidden = (bool?) content.GetValueForProperty("IsHidden",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsHidden, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsPreview = (bool?) content.GetValueForProperty("IsPreview",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).IsPreview, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).MinorVersion = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion[]) content.GetValueForProperty("MinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).MinorVersion, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMinorVersion>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMinorVersionTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).RuntimeVersion = (string) content.GetValueForProperty("RuntimeVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersionInternal)this).RuntimeVersion, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Application stack major version.
    [System.ComponentModel.TypeConverter(typeof(StackMajorVersionTypeConverter))]
    public partial interface IStackMajorVersion

    {

    }
}