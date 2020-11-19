namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>ProcessModuleInfo resource specific properties</summary>
    [System.ComponentModel.TypeConverter(typeof(ProcessModuleInfoPropertiesTypeConverter))]
    public partial class ProcessModuleInfoProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ProcessModuleInfoProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ProcessModuleInfoProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ProcessModuleInfoProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ProcessModuleInfoProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).BaseAddress = (string) content.GetValueForProperty("BaseAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).BaseAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileName = (string) content.GetValueForProperty("FileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FilePath = (string) content.GetValueForProperty("FilePath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FilePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ModuleMemorySize = (int?) content.GetValueForProperty("ModuleMemorySize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ModuleMemorySize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileVersion = (string) content.GetValueForProperty("FileVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileDescription = (string) content.GetValueForProperty("FileDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Product = (string) content.GetValueForProperty("Product",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Product, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ProductVersion = (string) content.GetValueForProperty("ProductVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ProductVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).IsDebug = (bool?) content.GetValueForProperty("IsDebug",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).IsDebug, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Language = (string) content.GetValueForProperty("Language",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Language, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProcessModuleInfoProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ProcessModuleInfoProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).BaseAddress = (string) content.GetValueForProperty("BaseAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).BaseAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileName = (string) content.GetValueForProperty("FileName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Href = (string) content.GetValueForProperty("Href",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Href, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FilePath = (string) content.GetValueForProperty("FilePath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FilePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ModuleMemorySize = (int?) content.GetValueForProperty("ModuleMemorySize",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ModuleMemorySize, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileVersion = (string) content.GetValueForProperty("FileVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileDescription = (string) content.GetValueForProperty("FileDescription",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).FileDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Product = (string) content.GetValueForProperty("Product",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Product, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ProductVersion = (string) content.GetValueForProperty("ProductVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).ProductVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).IsDebug = (bool?) content.GetValueForProperty("IsDebug",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).IsDebug, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Language = (string) content.GetValueForProperty("Language",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProcessModuleInfoPropertiesInternal)this).Language, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// ProcessModuleInfo resource specific properties
    [System.ComponentModel.TypeConverter(typeof(ProcessModuleInfoPropertiesTypeConverter))]
    public partial interface IProcessModuleInfoProperties

    {

    }
}