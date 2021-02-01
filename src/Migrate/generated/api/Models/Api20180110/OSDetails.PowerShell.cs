namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Disk Details.</summary>
    [System.ComponentModel.TypeConverter(typeof(OSDetailsTypeConverter))]
    public partial class OSDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new OSDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new OSDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="OSDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal OSDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).ProductType = (string) content.GetValueForProperty("ProductType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).ProductType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSEdition = (string) content.GetValueForProperty("OSEdition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSEdition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMajorVersion = (string) content.GetValueForProperty("OSMajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMajorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMinorVersion = (string) content.GetValueForProperty("OSMinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMinorVersion, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.OSDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal OSDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSType = (string) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).ProductType = (string) content.GetValueForProperty("ProductType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).ProductType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSEdition = (string) content.GetValueForProperty("OSEdition",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSEdition, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMajorVersion = (string) content.GetValueForProperty("OSMajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMajorVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMinorVersion = (string) content.GetValueForProperty("OSMinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IOSDetailsInternal)this).OSMinorVersion, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Disk Details.
    [System.ComponentModel.TypeConverter(typeof(OSDetailsTypeConverter))]
    public partial interface IOSDetails

    {

    }
}