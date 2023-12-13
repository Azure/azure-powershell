namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.PowerShell;

    /// <summary>Properties of the deleted vault.</summary>
    [System.ComponentModel.TypeConverter(typeof(DeletedVaultPropertiesTypeConverter))]
    public partial class DeletedVaultProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DeletedVaultProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).VaultId = (string) content.GetValueForProperty("VaultId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).VaultId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).DeletionDate = (global::System.DateTime?) content.GetValueForProperty("DeletionDate",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).DeletionDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).ScheduledPurgeDate = (global::System.DateTime?) content.GetValueForProperty("ScheduledPurgeDate",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).ScheduledPurgeDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultPropertiesTagsTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DeletedVaultProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).VaultId = (string) content.GetValueForProperty("VaultId",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).VaultId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).DeletionDate = (global::System.DateTime?) content.GetValueForProperty("DeletionDate",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).DeletionDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).ScheduledPurgeDate = (global::System.DateTime?) content.GetValueForProperty("ScheduledPurgeDate",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).ScheduledPurgeDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultPropertiesInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultPropertiesTagsTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DeletedVaultProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.DeletedVaultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DeletedVaultProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DeletedVaultProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IDeletedVaultProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the deleted vault.
    [System.ComponentModel.TypeConverter(typeof(DeletedVaultPropertiesTypeConverter))]
    public partial interface IDeletedVaultProperties

    {

    }
}