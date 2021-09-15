namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>Profile for Linux VMs in the container service cluster.</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerServiceLinuxProfileTypeConverter))]
    public partial class ContainerServiceLinuxProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceLinuxProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerServiceLinuxProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).Ssh = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshConfiguration) content.GetValueForProperty("Ssh",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).Ssh, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceSshConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).AdminUsername = (string) content.GetValueForProperty("AdminUsername",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).AdminUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).SshPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[]) content.GetValueForProperty("SshPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).SshPublicKey, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceSshPublicKeyTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceLinuxProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerServiceLinuxProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).Ssh = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshConfiguration) content.GetValueForProperty("Ssh",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).Ssh, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceSshConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).AdminUsername = (string) content.GetValueForProperty("AdminUsername",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).AdminUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).SshPublicKey = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey[]) content.GetValueForProperty("SshPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfileInternal)this).SshPublicKey, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceSshPublicKey>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceSshPublicKeyTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceLinuxProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerServiceLinuxProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceLinuxProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerServiceLinuxProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerServiceLinuxProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceLinuxProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Profile for Linux VMs in the container service cluster.
    [System.ComponentModel.TypeConverter(typeof(ContainerServiceLinuxProfileTypeConverter))]
    public partial interface IContainerServiceLinuxProfile

    {

    }
}