// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    /// <summary>Workspace properties</summary>
    [System.ComponentModel.TypeConverter(typeof(WorkspacePropertiesTypeConverter))]
    public partial class WorkspaceProperties
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new WorkspaceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new WorkspaceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="WorkspaceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="WorkspaceProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal WorkspaceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("WorkspaceIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("WorkspaceIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("KeyVaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.KeyVaultPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SupercomputerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).SupercomputerId = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupercomputerId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).SupercomputerId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("WorkspaceApiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceApiUri = (string) content.GetValueForProperty("WorkspaceApiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceApiUri, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceUiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceUiUri = (string) content.GetValueForProperty("WorkspaceUiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceUiUri, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("AgentSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).AgentSubnetId = (string) content.GetValueForProperty("AgentSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).AgentSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointSubnetId = (string) content.GetValueForProperty("PrivateEndpointSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceSubnetId = (string) content.GetValueForProperty("WorkspaceSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityId = (string) content.GetValueForProperty("WorkspaceIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityPrincipalId = (string) content.GetValueForProperty("WorkspaceIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityClientId = (string) content.GetValueForProperty("WorkspaceIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVaultUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspaceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal WorkspaceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("WorkspaceIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("WorkspaceIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("KeyVaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.KeyVaultPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("SupercomputerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).SupercomputerId = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupercomputerId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).SupercomputerId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("WorkspaceApiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceApiUri = (string) content.GetValueForProperty("WorkspaceApiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceApiUri, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceUiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceUiUri = (string) content.GetValueForProperty("WorkspaceUiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceUiUri, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("AgentSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).AgentSubnetId = (string) content.GetValueForProperty("AgentSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).AgentSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointSubnetId = (string) content.GetValueForProperty("PrivateEndpointSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).PrivateEndpointSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceSubnetId = (string) content.GetValueForProperty("WorkspaceSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityId = (string) content.GetValueForProperty("WorkspaceIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityPrincipalId = (string) content.GetValueForProperty("WorkspaceIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityClientId = (string) content.GetValueForProperty("WorkspaceIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).WorkspaceIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVaultUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspacePropertiesInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }
    }
    /// Workspace properties
    [System.ComponentModel.TypeConverter(typeof(WorkspacePropertiesTypeConverter))]
    public partial interface IWorkspaceProperties

    {

    }
}