namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>
    /// Network Mapping model. Ideally it should have been possible to inherit this class from prev version in InheritedModels
    /// as long as there is no difference in structure or method signature. Since there were no base Models for certain fields
    /// and methods viz NetworkMappingProperties and Load with required return type, the class has been introduced in its entirety
    /// with references to base models to facilitate extensions in subsequent versions.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkMappingTypeConverter))]
    public partial class NetworkMapping
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMapping"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkMapping(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMapping"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkMapping(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkMapping" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMapping FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMapping"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkMapping(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSetting = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings) content.GetValueForProperty("FabricSpecificSetting",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSetting, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingFabricSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkFriendlyName = (string) content.GetValueForProperty("PrimaryNetworkFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkId = (string) content.GetValueForProperty("PrimaryNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryFabricFriendlyName = (string) content.GetValueForProperty("PrimaryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkFriendlyName = (string) content.GetValueForProperty("RecoveryNetworkFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkId = (string) content.GetValueForProperty("RecoveryNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricArmId = (string) content.GetValueForProperty("RecoveryFabricArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricFriendlyName = (string) content.GetValueForProperty("RecoveryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSettingInstanceType = (string) content.GetValueForProperty("FabricSpecificSettingInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSettingInstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMapping"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkMapping(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSetting = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingFabricSpecificSettings) content.GetValueForProperty("FabricSpecificSetting",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSetting, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.NetworkMappingFabricSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).State = (string) content.GetValueForProperty("State",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).State, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkFriendlyName = (string) content.GetValueForProperty("PrimaryNetworkFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkId = (string) content.GetValueForProperty("PrimaryNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryFabricFriendlyName = (string) content.GetValueForProperty("PrimaryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).PrimaryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkFriendlyName = (string) content.GetValueForProperty("RecoveryNetworkFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkId = (string) content.GetValueForProperty("RecoveryNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricArmId = (string) content.GetValueForProperty("RecoveryFabricArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricFriendlyName = (string) content.GetValueForProperty("RecoveryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).RecoveryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSettingInstanceType = (string) content.GetValueForProperty("FabricSpecificSettingInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.INetworkMappingInternal)this).FabricSpecificSettingInstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Network Mapping model. Ideally it should have been possible to inherit this class from prev version in InheritedModels
    /// as long as there is no difference in structure or method signature. Since there were no base Models for certain fields
    /// and methods viz NetworkMappingProperties and Load with required return type, the class has been introduced in its entirety
    /// with references to base models to facilitate extensions in subsequent versions.
    [System.ComponentModel.TypeConverter(typeof(NetworkMappingTypeConverter))]
    public partial interface INetworkMapping

    {

    }
}