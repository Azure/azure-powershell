namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Managed service identity.</summary>
    [System.ComponentModel.TypeConverter(typeof(ManagedServiceIdentityTypeConverter))]
    public partial class ManagedServiceIdentity
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ManagedServiceIdentity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ManagedServiceIdentity(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ManagedServiceIdentity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ManagedServiceIdentity(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).PrincipalId = (string) content.GetValueForProperty("PrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).PrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).UserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities) content.GetValueForProperty("UserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).UserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ManagedServiceIdentity(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).PrincipalId = (string) content.GetValueForProperty("PrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).PrincipalId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).TenantId = (string) content.GetValueForProperty("TenantId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).TenantId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).UserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities) content.GetValueForProperty("UserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)this).UserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Managed service identity.
    [System.ComponentModel.TypeConverter(typeof(ManagedServiceIdentityTypeConverter))]
    public partial interface IManagedServiceIdentity

    {

    }
}