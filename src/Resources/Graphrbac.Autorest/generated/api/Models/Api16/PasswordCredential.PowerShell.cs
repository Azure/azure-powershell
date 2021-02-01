namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>Active Directory Password Credential information.</summary>
    [System.ComponentModel.TypeConverter(typeof(PasswordCredentialTypeConverter))]
    public partial class PasswordCredential
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredential"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PasswordCredential(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredential"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PasswordCredential(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PasswordCredential" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredential"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PasswordCredential(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).CustomKeyIdentifier = (byte[]) content.GetValueForProperty("CustomKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).CustomKeyIdentifier, i => i);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).EndDate = (global::System.DateTime?) content.GetValueForProperty("EndDate",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).EndDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).KeyId = (string) content.GetValueForProperty("KeyId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).KeyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).StartDate = (global::System.DateTime?) content.GetValueForProperty("StartDate",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).StartDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).Value, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.PasswordCredential"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PasswordCredential(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).CustomKeyIdentifier = (byte[]) content.GetValueForProperty("CustomKeyIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).CustomKeyIdentifier, i => i);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).EndDate = (global::System.DateTime?) content.GetValueForProperty("EndDate",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).EndDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).KeyId = (string) content.GetValueForProperty("KeyId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).KeyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).StartDate = (global::System.DateTime?) content.GetValueForProperty("StartDate",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).StartDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).Value = (string) content.GetValueForProperty("Value",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredentialInternal)this).Value, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Active Directory Password Credential information.
    [System.ComponentModel.TypeConverter(typeof(PasswordCredentialTypeConverter))]
    public partial interface IPasswordCredential

    {

    }
}