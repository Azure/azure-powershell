namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell;

    /// <summary>
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(AzureFileVolumeTypeConverter))]
    public partial class AzureFileVolume
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.AzureFileVolume"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureFileVolume(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ShareName = (string) content.GetValueForProperty("ShareName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ShareName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ReadOnly = (bool?) content.GetValueForProperty("ReadOnly",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ReadOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountName = (string) content.GetValueForProperty("StorageAccountName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountKey = (string) content.GetValueForProperty("StorageAccountKey",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountKey, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.AzureFileVolume"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureFileVolume(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ShareName = (string) content.GetValueForProperty("ShareName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ShareName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ReadOnly = (bool?) content.GetValueForProperty("ReadOnly",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).ReadOnly, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountName = (string) content.GetValueForProperty("StorageAccountName",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountKey = (string) content.GetValueForProperty("StorageAccountKey",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolumeInternal)this).StorageAccountKey, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.AzureFileVolume"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureFileVolume(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.AzureFileVolume"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureFileVolume(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureFileVolume" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IAzureFileVolume FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The properties of the Azure File volume. Azure File shares are mounted as volumes.
    [System.ComponentModel.TypeConverter(typeof(AzureFileVolumeTypeConverter))]
    public partial interface IAzureFileVolume

    {

    }
}