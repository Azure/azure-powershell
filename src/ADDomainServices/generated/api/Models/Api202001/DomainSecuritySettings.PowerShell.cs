namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.PowerShell;

    /// <summary>Domain Security Settings</summary>
    [System.ComponentModel.TypeConverter(typeof(DomainSecuritySettingsTypeConverter))]
    public partial class DomainSecuritySettings
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DomainSecuritySettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DomainSecuritySettings(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DomainSecuritySettings(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).NtlmV1 = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1?) content.GetValueForProperty("NtlmV1",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).NtlmV1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).TlsV1 = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1?) content.GetValueForProperty("TlsV1",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).TlsV1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncNtlmPassword = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords?) content.GetValueForProperty("SyncNtlmPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncNtlmPassword, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncKerberosPassword = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords?) content.GetValueForProperty("SyncKerberosPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncKerberosPassword, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncOnPremPassword = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords?) content.GetValueForProperty("SyncOnPremPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncOnPremPassword, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DomainSecuritySettings(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).NtlmV1 = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1?) content.GetValueForProperty("NtlmV1",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).NtlmV1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).TlsV1 = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1?) content.GetValueForProperty("TlsV1",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).TlsV1, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncNtlmPassword = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords?) content.GetValueForProperty("SyncNtlmPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncNtlmPassword, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncKerberosPassword = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords?) content.GetValueForProperty("SyncKerberosPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncKerberosPassword, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncOnPremPassword = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords?) content.GetValueForProperty("SyncOnPremPassword",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal)this).SyncOnPremPassword, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DomainSecuritySettings" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Domain Security Settings
    [System.ComponentModel.TypeConverter(typeof(DomainSecuritySettingsTypeConverter))]
    public partial interface IDomainSecuritySettings

    {

    }
}