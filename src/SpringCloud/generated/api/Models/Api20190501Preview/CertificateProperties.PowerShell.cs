namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.PowerShell;

    /// <summary>Certificate resource payload.</summary>
    [System.ComponentModel.TypeConverter(typeof(CertificatePropertiesTypeConverter))]
    public partial class CertificateProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.CertificateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal CertificateProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ActivateDate = (string) content.GetValueForProperty("ActivateDate",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ActivateDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).CertVersion = (string) content.GetValueForProperty("CertVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).CertVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).DnsName = (string[]) content.GetValueForProperty("DnsName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).DnsName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ExpirationDate = (string) content.GetValueForProperty("ExpirationDate",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ExpirationDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).IssuedDate = (string) content.GetValueForProperty("IssuedDate",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).IssuedDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).KeyVaultCertName = (string) content.GetValueForProperty("KeyVaultCertName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).KeyVaultCertName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).SubjectName = (string) content.GetValueForProperty("SubjectName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).SubjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).VaultUri = (string) content.GetValueForProperty("VaultUri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).VaultUri, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.CertificateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal CertificateProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ActivateDate = (string) content.GetValueForProperty("ActivateDate",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ActivateDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).CertVersion = (string) content.GetValueForProperty("CertVersion",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).CertVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).DnsName = (string[]) content.GetValueForProperty("DnsName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).DnsName, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ExpirationDate = (string) content.GetValueForProperty("ExpirationDate",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).ExpirationDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).IssuedDate = (string) content.GetValueForProperty("IssuedDate",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).IssuedDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Issuer = (string) content.GetValueForProperty("Issuer",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Issuer, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).KeyVaultCertName = (string) content.GetValueForProperty("KeyVaultCertName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).KeyVaultCertName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).SubjectName = (string) content.GetValueForProperty("SubjectName",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).SubjectName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Thumbprint = (string) content.GetValueForProperty("Thumbprint",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).Thumbprint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).VaultUri = (string) content.GetValueForProperty("VaultUri",((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificatePropertiesInternal)this).VaultUri, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.CertificateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new CertificateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.CertificateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new CertificateProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="CertificateProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ICertificateProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Certificate resource payload.
    [System.ComponentModel.TypeConverter(typeof(CertificatePropertiesTypeConverter))]
    public partial interface ICertificateProperties

    {

    }
}