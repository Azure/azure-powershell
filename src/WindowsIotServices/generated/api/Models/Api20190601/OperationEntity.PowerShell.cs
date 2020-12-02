namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.PowerShell;

    /// <summary>The operation supported by Azure Data Catalog Service.</summary>
    [System.ComponentModel.TypeConverter(typeof(OperationEntityTypeConverter))]
    public partial class OperationEntity
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationEntity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OperationEntity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationEntity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OperationEntity(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OperationEntity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationEntity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OperationEntity(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfo) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationDisplayInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayResource, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationEntity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OperationEntity(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationDisplayInfo) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.OperationDisplayInfoTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IOperationEntityInternal)this).DisplayResource, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The operation supported by Azure Data Catalog Service.
    [System.ComponentModel.TypeConverter(typeof(OperationEntityTypeConverter))]
    public partial interface IOperationEntity

    {

    }
}