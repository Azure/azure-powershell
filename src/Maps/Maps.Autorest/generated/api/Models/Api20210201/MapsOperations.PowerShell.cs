namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.PowerShell;

    /// <summary>The set of operations available for Maps.</summary>
    [System.ComponentModel.TypeConverter(typeof(MapsOperationsTypeConverter))]
    public partial class MapsOperations
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsOperations"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperations" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperations DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MapsOperations(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsOperations"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperations" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperations DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MapsOperations(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MapsOperations" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperations FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsOperations"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MapsOperations(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.OperationDetailTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).NextLink, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsOperations"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MapsOperations(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).Value = (Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail[]) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).Value, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IOperationDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.OperationDetailTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).NextLink = (string) content.GetValueForProperty("NextLink",((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsOperationsInternal)this).NextLink, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The set of operations available for Maps.
    [System.ComponentModel.TypeConverter(typeof(MapsOperationsTypeConverter))]
    public partial interface IMapsOperations

    {

    }
}