namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>A Kubernetes add-on profile for a managed cluster.</summary>
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterAddonProfileTypeConverter))]
    public partial class ManagedClusterAddonProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAddonProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ManagedClusterAddonProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAddonProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ManagedClusterAddonProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ManagedClusterAddonProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAddonProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ManagedClusterAddonProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.UserAssignedIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Enabled = (bool) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAddonProfileConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityResourceId = (string) content.GetValueForProperty("IdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityClientId = (string) content.GetValueForProperty("IdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityObjectId = (string) content.GetValueForProperty("IdentityObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityObjectId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAddonProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ManagedClusterAddonProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IUserAssignedIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.UserAssignedIdentityTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Enabled = (bool) content.GetValueForProperty("Enabled",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Enabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Config = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileConfig) content.GetValueForProperty("Config",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).Config, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterAddonProfileConfigTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityResourceId = (string) content.GetValueForProperty("IdentityResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityClientId = (string) content.GetValueForProperty("IdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityClientId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityObjectId = (string) content.GetValueForProperty("IdentityObjectId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAddonProfileInternal)this).IdentityObjectId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// A Kubernetes add-on profile for a managed cluster.
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterAddonProfileTypeConverter))]
    public partial interface IManagedClusterAddonProfile

    {

    }
}