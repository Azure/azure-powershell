namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.PowerShell;

    /// <summary>A class representing database principal property.</summary>
    [System.ComponentModel.TypeConverter(typeof(DatabasePrincipalPropertiesTypeConverter))]
    public partial class DatabasePrincipalProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DatabasePrincipalProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatabasePrincipalProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalId = (string) content.GetValueForProperty("PrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalName = (string) content.GetValueForProperty("PrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType) content.GetValueForProperty("PrincipalType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).Role = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole) content.GetValueForProperty("Role",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).Role, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantName = (string) content.GetValueForProperty("TenantName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DatabasePrincipalProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatabasePrincipalProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalId = (string) content.GetValueForProperty("PrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalName = (string) content.GetValueForProperty("PrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalType = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType) content.GetValueForProperty("PrincipalType",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).PrincipalType, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).Role = (Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole) content.GetValueForProperty("Role",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).Role, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantName = (string) content.GetValueForProperty("TenantName",((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalPropertiesInternal)this).TenantName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DatabasePrincipalProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatabasePrincipalProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.DatabasePrincipalProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatabasePrincipalProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatabasePrincipalProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A class representing database principal property.
    [System.ComponentModel.TypeConverter(typeof(DatabasePrincipalPropertiesTypeConverter))]
    public partial interface IDatabasePrincipalProperties

    {

    }
}