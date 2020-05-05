namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(Components15Yg3X7SchemasOperationPropertiesAdditionalpropertiesTypeConverter))]
    public partial class Components15Yg3X7SchemasOperationPropertiesAdditionalproperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.Components15Yg3X7SchemasOperationPropertiesAdditionalproperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Components15Yg3X7SchemasOperationPropertiesAdditionalproperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.Components15Yg3X7SchemasOperationPropertiesAdditionalproperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Components15Yg3X7SchemasOperationPropertiesAdditionalproperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.Components15Yg3X7SchemasOperationPropertiesAdditionalproperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IComponents15Yg3X7SchemasOperationPropertiesAdditionalproperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IComponents15Yg3X7SchemasOperationPropertiesAdditionalproperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Components15Yg3X7SchemasOperationPropertiesAdditionalproperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.Components15Yg3X7SchemasOperationPropertiesAdditionalproperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IComponents15Yg3X7SchemasOperationPropertiesAdditionalproperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IComponents15Yg3X7SchemasOperationPropertiesAdditionalproperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Components15Yg3X7SchemasOperationPropertiesAdditionalproperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Components15Yg3X7SchemasOperationPropertiesAdditionalproperties" />, deserializing
        /// the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IComponents15Yg3X7SchemasOperationPropertiesAdditionalproperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(Components15Yg3X7SchemasOperationPropertiesAdditionalpropertiesTypeConverter))]
    public partial interface IComponents15Yg3X7SchemasOperationPropertiesAdditionalproperties

    {

    }
}