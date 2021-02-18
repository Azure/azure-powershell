namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Replication protected item custom data details.</summary>
    [System.ComponentModel.TypeConverter(typeof(ReplicationProtectedItemPropertiesTypeConverter))]
    public partial class ReplicationProtectedItemProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProtectedItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ReplicationProtectedItemProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProtectedItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ReplicationProtectedItemProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ReplicationProtectedItemProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProtectedItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ReplicationProtectedItemProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenario = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails) content.GetValueForProperty("CurrentScenario",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenario, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentScenarioDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectedItemType = (string) content.GetValueForProperty("ProtectedItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectedItemType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectableItemId = (string) content.GetValueForProperty("ProtectableItemId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectableItemId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryServicesProviderId = (string) content.GetValueForProperty("RecoveryServicesProviderId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryServicesProviderId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricFriendlyName = (string) content.GetValueForProperty("PrimaryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricProvider = (string) content.GetValueForProperty("PrimaryFabricProvider",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricFriendlyName = (string) content.GetValueForProperty("RecoveryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricId = (string) content.GetValueForProperty("RecoveryFabricId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryProtectionContainerFriendlyName = (string) content.GetValueForProperty("PrimaryProtectionContainerFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryProtectionContainerFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryProtectionContainerFriendlyName = (string) content.GetValueForProperty("RecoveryProtectionContainerFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryProtectionContainerFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionState = (string) content.GetValueForProperty("ProtectionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionStateDescription = (string) content.GetValueForProperty("ProtectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ActiveLocation = (string) content.GetValueForProperty("ActiveLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ActiveLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverState = (string) content.GetValueForProperty("TestFailoverState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverStateDescription = (string) content.GetValueForProperty("TestFailoverStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).AllowedOperation = (string[]) content.GetValueForProperty("AllowedOperation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).AllowedOperation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ReplicationHealth = (string) content.GetValueForProperty("ReplicationHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ReplicationHealth, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverHealth = (string) content.GetValueForProperty("FailoverHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverHealth, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyFriendlyName = (string) content.GetValueForProperty("PolicyFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulFailoverTime = (global::System.DateTime?) content.GetValueForProperty("LastSuccessfulFailoverTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulFailoverTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulTestFailoverTime = (global::System.DateTime?) content.GetValueForProperty("LastSuccessfulTestFailoverTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulTestFailoverTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverRecoveryPointId = (string) content.GetValueForProperty("FailoverRecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverRecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryContainerId = (string) content.GetValueForProperty("RecoveryContainerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryContainerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioName = (string) content.GetValueForProperty("CurrentScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioJobId = (string) content.GetValueForProperty("CurrentScenarioJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentScenarioStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProtectedItemProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ReplicationProtectedItemProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenario = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ICurrentScenarioDetails) content.GetValueForProperty("CurrentScenario",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenario, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.CurrentScenarioDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProviderSpecificSettings) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ReplicationProviderSpecificSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectedItemType = (string) content.GetValueForProperty("ProtectedItemType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectedItemType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectableItemId = (string) content.GetValueForProperty("ProtectableItemId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectableItemId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryServicesProviderId = (string) content.GetValueForProperty("RecoveryServicesProviderId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryServicesProviderId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricFriendlyName = (string) content.GetValueForProperty("PrimaryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricProvider = (string) content.GetValueForProperty("PrimaryFabricProvider",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryFabricProvider, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricFriendlyName = (string) content.GetValueForProperty("RecoveryFabricFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricId = (string) content.GetValueForProperty("RecoveryFabricId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryFabricId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryProtectionContainerFriendlyName = (string) content.GetValueForProperty("PrimaryProtectionContainerFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PrimaryProtectionContainerFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryProtectionContainerFriendlyName = (string) content.GetValueForProperty("RecoveryProtectionContainerFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryProtectionContainerFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionState = (string) content.GetValueForProperty("ProtectionState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionStateDescription = (string) content.GetValueForProperty("ProtectionStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProtectionStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ActiveLocation = (string) content.GetValueForProperty("ActiveLocation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ActiveLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverState = (string) content.GetValueForProperty("TestFailoverState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverStateDescription = (string) content.GetValueForProperty("TestFailoverStateDescription",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).TestFailoverStateDescription, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).AllowedOperation = (string[]) content.GetValueForProperty("AllowedOperation",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).AllowedOperation, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ReplicationHealth = (string) content.GetValueForProperty("ReplicationHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ReplicationHealth, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverHealth = (string) content.GetValueForProperty("FailoverHealth",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverHealth, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).HealthError = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthError",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).HealthError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyId = (string) content.GetValueForProperty("PolicyId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyFriendlyName = (string) content.GetValueForProperty("PolicyFriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).PolicyFriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulFailoverTime = (global::System.DateTime?) content.GetValueForProperty("LastSuccessfulFailoverTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulFailoverTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulTestFailoverTime = (global::System.DateTime?) content.GetValueForProperty("LastSuccessfulTestFailoverTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).LastSuccessfulTestFailoverTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverRecoveryPointId = (string) content.GetValueForProperty("FailoverRecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).FailoverRecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryContainerId = (string) content.GetValueForProperty("RecoveryContainerId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).RecoveryContainerId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioName = (string) content.GetValueForProperty("CurrentScenarioName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioJobId = (string) content.GetValueForProperty("CurrentScenarioJobId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioJobId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentScenarioStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).CurrentScenarioStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IReplicationProtectedItemPropertiesInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Replication protected item custom data details.
    [System.ComponentModel.TypeConverter(typeof(ReplicationProtectedItemPropertiesTypeConverter))]
    public partial interface IReplicationProtectedItemProperties

    {

    }
}