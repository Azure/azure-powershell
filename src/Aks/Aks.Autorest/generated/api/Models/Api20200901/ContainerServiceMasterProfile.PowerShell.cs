namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>Profile for the container service master.</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerServiceMasterProfileTypeConverter))]
    public partial class ContainerServiceMasterProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceMasterProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerServiceMasterProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Count = (int?) content.GetValueForProperty("Count",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Count, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).DnsPrefix = (string) content.GetValueForProperty("DnsPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).DnsPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VMSize = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VMSize, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).OSDiskSizeGb = (int?) content.GetValueForProperty("OSDiskSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).OSDiskSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VnetSubnetId = (string) content.GetValueForProperty("VnetSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VnetSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).FirstConsecutiveStaticIP = (string) content.GetValueForProperty("FirstConsecutiveStaticIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).FirstConsecutiveStaticIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes?) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Fqdn, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceMasterProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerServiceMasterProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Count = (int?) content.GetValueForProperty("Count",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Count, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).DnsPrefix = (string) content.GetValueForProperty("DnsPrefix",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).DnsPrefix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VMSize = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes) content.GetValueForProperty("VMSize",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VMSize, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceVMSizeTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).OSDiskSizeGb = (int?) content.GetValueForProperty("OSDiskSizeGb",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).OSDiskSizeGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VnetSubnetId = (string) content.GetValueForProperty("VnetSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).VnetSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).FirstConsecutiveStaticIP = (string) content.GetValueForProperty("FirstConsecutiveStaticIP",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).FirstConsecutiveStaticIP, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).StorageProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes?) content.GetValueForProperty("StorageProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).StorageProfile, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.ContainerServiceStorageProfileTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Fqdn = (string) content.GetValueForProperty("Fqdn",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfileInternal)this).Fqdn, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceMasterProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerServiceMasterProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ContainerServiceMasterProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerServiceMasterProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerServiceMasterProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IContainerServiceMasterProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Profile for the container service master.
    [System.ComponentModel.TypeConverter(typeof(ContainerServiceMasterProfileTypeConverter))]
    public partial interface IContainerServiceMasterProfile

    {

    }
}