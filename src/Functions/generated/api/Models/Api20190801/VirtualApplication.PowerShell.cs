namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Virtual application in an app.</summary>
    [System.ComponentModel.TypeConverter(typeof(VirtualApplicationTypeConverter))]
    public partial class VirtualApplication
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualApplication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VirtualApplication(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualApplication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VirtualApplication(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VirtualApplication" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualApplication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VirtualApplication(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualPath = (string) content.GetValueForProperty("VirtualPath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PhysicalPath = (string) content.GetValueForProperty("PhysicalPath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PhysicalPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PreloadEnabled = (bool?) content.GetValueForProperty("PreloadEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PreloadEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualDirectory = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory[]) content.GetValueForProperty("VirtualDirectory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualDirectory, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualDirectoryTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualApplication"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VirtualApplication(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualPath = (string) content.GetValueForProperty("VirtualPath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PhysicalPath = (string) content.GetValueForProperty("PhysicalPath",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PhysicalPath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PreloadEnabled = (bool?) content.GetValueForProperty("PreloadEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).PreloadEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualDirectory = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory[]) content.GetValueForProperty("VirtualDirectory",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplicationInternal)this).VirtualDirectory, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualDirectory>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.VirtualDirectoryTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }
    }
    /// Virtual application in an app.
    [System.ComponentModel.TypeConverter(typeof(VirtualApplicationTypeConverter))]
    public partial interface IVirtualApplication

    {

    }
}