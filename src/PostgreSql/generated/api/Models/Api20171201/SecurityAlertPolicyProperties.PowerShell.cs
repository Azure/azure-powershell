namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.PowerShell;

    /// <summary>Properties of a security alert policy.</summary>
    [System.ComponentModel.TypeConverter(typeof(SecurityAlertPolicyPropertiesTypeConverter))]
    public partial class SecurityAlertPolicyProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.SecurityAlertPolicyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SecurityAlertPolicyProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.SecurityAlertPolicyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SecurityAlertPolicyProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SecurityAlertPolicyProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.SecurityAlertPolicyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SecurityAlertPolicyProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).DisabledAlert = (string[]) content.GetValueForProperty("DisabledAlert",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).DisabledAlert, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAccountAdmin = (bool?) content.GetValueForProperty("EmailAccountAdmin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAccountAdmin, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAddress = (string[]) content.GetValueForProperty("EmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).RetentionDay = (int?) content.GetValueForProperty("RetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).RetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageAccountAccessKey = (string) content.GetValueForProperty("StorageAccountAccessKey",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageAccountAccessKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageEndpoint = (string) content.GetValueForProperty("StorageEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageEndpoint, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.SecurityAlertPolicyProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SecurityAlertPolicyProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).DisabledAlert = (string[]) content.GetValueForProperty("DisabledAlert",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).DisabledAlert, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAccountAdmin = (bool?) content.GetValueForProperty("EmailAccountAdmin",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAccountAdmin, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAddress = (string[]) content.GetValueForProperty("EmailAddress",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).EmailAddress, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).RetentionDay = (int?) content.GetValueForProperty("RetentionDay",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).RetentionDay, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).State = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).State, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Support.ServerSecurityAlertPolicyState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageAccountAccessKey = (string) content.GetValueForProperty("StorageAccountAccessKey",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageAccountAccessKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageEndpoint = (string) content.GetValueForProperty("StorageEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20171201.ISecurityAlertPolicyPropertiesInternal)this).StorageEndpoint, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of a security alert policy.
    [System.ComponentModel.TypeConverter(typeof(SecurityAlertPolicyPropertiesTypeConverter))]
    public partial interface ISecurityAlertPolicyProperties

    {

    }
}