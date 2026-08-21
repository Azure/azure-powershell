// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    /// <summary>Workspace tracked resource</summary>
    [System.ComponentModel.TypeConverter(typeof(WorkspaceTypeConverter))]
    public partial class Workspace
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Workspace"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspace" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspace DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Workspace(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Workspace"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspace" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspace DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Workspace(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Workspace" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="Workspace" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspace FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Workspace"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Workspace(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspacePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("KeyVaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.KeyVaultPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SupercomputerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SupercomputerId = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupercomputerId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SupercomputerId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ApiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ApiUri = (string) content.GetValueForProperty("ApiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ApiUri, global::System.Convert.ToString);
            }
            if (content.Contains("UiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).UiUri = (string) content.GetValueForProperty("UiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).UiUri, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("AgentSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).AgentSubnetId = (string) content.GetValueForProperty("AgentSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).AgentSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointSubnetId = (string) content.GetValueForProperty("PrivateEndpointSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityId = (string) content.GetValueForProperty("IdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityClientId = (string) content.GetValueForProperty("IdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVaultUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Workspace"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Workspace(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WorkspacePropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Tag"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.TrackedResourceTagsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ITrackedResourceInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("KeyVaultProperty"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultProperty = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IKeyVaultProperties) content.GetValueForProperty("KeyVaultProperty",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultProperty, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.KeyVaultPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ManagedOnBehalfOfConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources) content.GetValueForProperty("ManagedOnBehalfOfConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.WithMoboBrokerResourcesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SupercomputerId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SupercomputerId = (System.Collections.Generic.List<string>) content.GetValueForProperty("SupercomputerId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SupercomputerId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ApiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ApiUri = (string) content.GetValueForProperty("ApiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ApiUri, global::System.Convert.ToString);
            }
            if (content.Contains("UiUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).UiUri = (string) content.GetValueForProperty("UiUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).UiUri, global::System.Convert.ToString);
            }
            if (content.Contains("CustomerManagedKey"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).CustomerManagedKey = (string) content.GetValueForProperty("CustomerManagedKey",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).CustomerManagedKey, global::System.Convert.ToString);
            }
            if (content.Contains("LogAnalyticsClusterId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).LogAnalyticsClusterId = (string) content.GetValueForProperty("LogAnalyticsClusterId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).LogAnalyticsClusterId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnection"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointConnection = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>) content.GetValueForProperty("PrivateEndpointConnection",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointConnection, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IPrivateEndpointConnection>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.PrivateEndpointConnectionTypeConverter.ConvertFrom));
            }
            if (content.Contains("PublicNetworkAccess"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PublicNetworkAccess = (string) content.GetValueForProperty("PublicNetworkAccess",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PublicNetworkAccess, global::System.Convert.ToString);
            }
            if (content.Contains("AgentSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).AgentSubnetId = (string) content.GetValueForProperty("AgentSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).AgentSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointSubnetId = (string) content.GetValueForProperty("PrivateEndpointSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).PrivateEndpointSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("SubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SubnetId = (string) content.GetValueForProperty("SubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).SubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedResourceGroup"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedResourceGroup = (string) content.GetValueForProperty("ManagedResourceGroup",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedResourceGroup, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityId = (string) content.GetValueForProperty("IdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityClientId = (string) content.GetValueForProperty("IdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).IdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVaultUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVaultUri = (string) content.GetValueForProperty("KeyVaultPropertyKeyVaultUri",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVaultUri, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyName = (string) content.GetValueForProperty("KeyVaultPropertyKeyName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyName, global::System.Convert.ToString);
            }
            if (content.Contains("KeyVaultPropertyKeyVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVersion = (string) content.GetValueForProperty("KeyVaultPropertyKeyVersion",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).KeyVaultPropertyKeyVersion, global::System.Convert.ToString);
            }
            if (content.Contains("ManagedOnBehalfOfConfigurationMoboBrokerResource"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>) content.GetValueForProperty("ManagedOnBehalfOfConfigurationMoboBrokerResource",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWorkspaceInternal)this).ManagedOnBehalfOfConfigurationMoboBrokerResource, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource>(__y, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.MoboBrokerResourceTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }
    }
    /// Workspace tracked resource
    [System.ComponentModel.TypeConverter(typeof(WorkspaceTypeConverter))]
    public partial interface IWorkspace

    {

    }
}