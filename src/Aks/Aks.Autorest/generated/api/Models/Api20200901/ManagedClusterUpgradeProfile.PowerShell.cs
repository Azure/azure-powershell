namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>The list of available upgrades for compute pools.</summary>
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterUpgradeProfileTypeConverter))]
    public partial class ManagedClusterUpgradeProfile
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ManagedClusterUpgradeProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfile" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ManagedClusterUpgradeProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ManagedClusterUpgradeProfile" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ManagedClusterUpgradeProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfilePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile) content.GetValueForProperty("ControlPlaneProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfile, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).AgentPoolProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile[]) content.GetValueForProperty("AgentPoolProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).AgentPoolProfile, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfileTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileOSType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType) content.GetValueForProperty("ControlPlaneProfileOSType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileOSType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileKubernetesVersion = (string) content.GetValueForProperty("ControlPlaneProfileKubernetesVersion",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileKubernetesVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileName = (string) content.GetValueForProperty("ControlPlaneProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileUpgrade = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[]) content.GetValueForProperty("ControlPlaneProfileUpgrade",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileUpgrade, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfileUpgradesItemTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ManagedClusterUpgradeProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterUpgradeProfilePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile) content.GetValueForProperty("ControlPlaneProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfile, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).AgentPoolProfile = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile[]) content.GetValueForProperty("AgentPoolProfile",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).AgentPoolProfile, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfile>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfileTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileOSType = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType) content.GetValueForProperty("ControlPlaneProfileOSType",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileOSType, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.OSType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileKubernetesVersion = (string) content.GetValueForProperty("ControlPlaneProfileKubernetesVersion",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileKubernetesVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileName = (string) content.GetValueForProperty("ControlPlaneProfileName",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileUpgrade = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem[]) content.GetValueForProperty("ControlPlaneProfileUpgrade",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterUpgradeProfileInternal)this).ControlPlaneProfileUpgrade, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPoolUpgradeProfileUpgradesItem>(__y, Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPoolUpgradeProfileUpgradesItemTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The list of available upgrades for compute pools.
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterUpgradeProfileTypeConverter))]
    public partial interface IManagedClusterUpgradeProfile

    {

    }
}