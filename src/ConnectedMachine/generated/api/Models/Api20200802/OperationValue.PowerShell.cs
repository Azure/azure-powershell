namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>Describes the properties of a Compute Operation value.</summary>
    [System.ComponentModel.TypeConverter(typeof(OperationValueTypeConverter))]
    public partial class OperationValue
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OperationValue(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OperationValue(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OperationValue" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OperationValue(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValueDisplayTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Origin = (string) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Origin, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayResource, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OperationValue(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Display = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Display, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValueDisplayTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Origin = (string) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).Origin, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayDescription = (string) content.GetValueForProperty("DisplayDescription",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayOperation = (string) content.GetValueForProperty("DisplayOperation",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayOperation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayProvider = (string) content.GetValueForProperty("DisplayProvider",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayResource = (string) content.GetValueForProperty("DisplayResource",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal)this).DisplayResource, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the properties of a Compute Operation value.
    [System.ComponentModel.TypeConverter(typeof(OperationValueTypeConverter))]
    public partial interface IOperationValue

    {

    }
}