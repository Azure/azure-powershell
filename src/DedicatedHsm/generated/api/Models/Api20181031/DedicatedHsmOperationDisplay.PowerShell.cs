namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(DedicatedHsmOperationDisplayTypeConverter))]
    public partial class DedicatedHsmOperationDisplay
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.DedicatedHsmOperationDisplay"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DedicatedHsmOperationDisplay(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Provider = (string) content.GetValueForProperty("Provider",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Provider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Resource = (string) content.GetValueForProperty("Resource",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Resource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Operation = (string) content.GetValueForProperty("Operation",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Operation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Description, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.DedicatedHsmOperationDisplay"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DedicatedHsmOperationDisplay(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Provider = (string) content.GetValueForProperty("Provider",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Provider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Resource = (string) content.GetValueForProperty("Resource",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Resource, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Operation = (string) content.GetValueForProperty("Operation",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Operation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplayInternal)this).Description, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.DedicatedHsmOperationDisplay"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplay"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplay DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DedicatedHsmOperationDisplay(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.DedicatedHsmOperationDisplay"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplay"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplay DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DedicatedHsmOperationDisplay(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DedicatedHsmOperationDisplay" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IDedicatedHsmOperationDisplay FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(DedicatedHsmOperationDisplayTypeConverter))]
    public partial interface IDedicatedHsmOperationDisplay

    {

    }
}