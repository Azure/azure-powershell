namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.PowerShell;

    /// <summary>Administrative credentials for accessing vCenter and NSX-T</summary>
    [System.ComponentModel.TypeConverter(typeof(AdminCredentialsTypeConverter))]
    public partial class AdminCredentials
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.AdminCredentials"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AdminCredentials(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtUsername = (string) content.GetValueForProperty("NsxtUsername",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtPassword = (string) content.GetValueForProperty("NsxtPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterUsername = (string) content.GetValueForProperty("VcenterUsername",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterPassword = (string) content.GetValueForProperty("VcenterPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterPassword, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.AdminCredentials"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AdminCredentials(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtUsername = (string) content.GetValueForProperty("NsxtUsername",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtPassword = (string) content.GetValueForProperty("NsxtPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).NsxtPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterUsername = (string) content.GetValueForProperty("VcenterUsername",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterPassword = (string) content.GetValueForProperty("VcenterPassword",((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentialsInternal)this).VcenterPassword, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.AdminCredentials"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentials" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentials DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AdminCredentials(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.AdminCredentials"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentials" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentials DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AdminCredentials(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AdminCredentials" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IAdminCredentials FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Administrative credentials for accessing vCenter and NSX-T
    [System.ComponentModel.TypeConverter(typeof(AdminCredentialsTypeConverter))]
    public partial interface IAdminCredentials

    {

    }
}