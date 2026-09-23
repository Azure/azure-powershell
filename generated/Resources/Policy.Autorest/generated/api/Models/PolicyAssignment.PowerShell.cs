// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The policy assignment.</summary>
    [System.ComponentModel.TypeConverter(typeof(PolicyAssignmentTypeConverter))]
    public partial class PolicyAssignment
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PolicyAssignment(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PolicyAssignment(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PolicyAssignment" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="PolicyAssignment" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignment FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PolicyAssignment(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignmentPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("EnforcementMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EnforcementMode = (string) content.GetValueForProperty("EnforcementMode",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EnforcementMode, global::System.Convert.ToString);
            }
            if (content.Contains("AssignmentType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).AssignmentType = (string) content.GetValueForProperty("AssignmentType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).AssignmentType, global::System.Convert.ToString);
            }
            if (content.Contains("SelfServeExemptionSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSetting = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettings) content.GetValueForProperty("SelfServeExemptionSetting",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSetting, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.SelfServeExemptionSettingsTypeConverter.ConvertFrom);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).PolicyDefinitionId = (string) content.GetValueForProperty("PolicyDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).PolicyDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DefinitionVersion = (string) content.GetValueForProperty("DefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("LatestDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).LatestDefinitionVersion = (string) content.GetValueForProperty("LatestDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).LatestDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("EffectiveDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EffectiveDefinitionVersion = (string) content.GetValueForProperty("EffectiveDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EffectiveDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("Scope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Scope = (string) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Scope, global::System.Convert.ToString);
            }
            if (content.Contains("NotScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NotScope = (System.Collections.Generic.List<string>) content.GetValueForProperty("NotScope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NotScope, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ParameterRaw"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ParameterRaw = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesParameters) content.GetValueForProperty("ParameterRaw",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ParameterRaw, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignmentPropertiesParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("MetadataRaw"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).MetadataRaw = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("MetadataRaw",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).MetadataRaw, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("NonComplianceMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NonComplianceMessage = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.INonComplianceMessage>) content.GetValueForProperty("NonComplianceMessage",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NonComplianceMessage, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.INonComplianceMessage>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.NonComplianceMessageTypeConverter.ConvertFrom));
            }
            if (content.Contains("ResourceSelector"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ResourceSelector = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>) content.GetValueForProperty("ResourceSelector",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ResourceSelector, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ResourceSelectorTypeConverter.ConvertFrom));
            }
            if (content.Contains("Override"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Override = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride>) content.GetValueForProperty("Override",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Override, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.OverrideTypeConverter.ConvertFrom));
            }
            if (content.Contains("InstanceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).InstanceId = (string) content.GetValueForProperty("InstanceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).InstanceId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SelfServeExemptionSettingEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingEnabled = (bool?) content.GetValueForProperty("SelfServeExemptionSettingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SelfServeExemptionSettingPolicyDefinitionReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingPolicyDefinitionReferenceId = (System.Collections.Generic.List<string>) content.GetValueForProperty("SelfServeExemptionSettingPolicyDefinitionReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingPolicyDefinitionReferenceId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignment"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PolicyAssignment(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignmentPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("Identity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Identity = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IIdentity) content.GetValueForProperty("Identity",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Identity, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("EnforcementMode"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EnforcementMode = (string) content.GetValueForProperty("EnforcementMode",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EnforcementMode, global::System.Convert.ToString);
            }
            if (content.Contains("AssignmentType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).AssignmentType = (string) content.GetValueForProperty("AssignmentType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).AssignmentType, global::System.Convert.ToString);
            }
            if (content.Contains("SelfServeExemptionSetting"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSetting = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ISelfServeExemptionSettings) content.GetValueForProperty("SelfServeExemptionSetting",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSetting, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.SelfServeExemptionSettingsTypeConverter.ConvertFrom);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).PolicyDefinitionId = (string) content.GetValueForProperty("PolicyDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).PolicyDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("DefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DefinitionVersion = (string) content.GetValueForProperty("DefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).DefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("LatestDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).LatestDefinitionVersion = (string) content.GetValueForProperty("LatestDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).LatestDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("EffectiveDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EffectiveDefinitionVersion = (string) content.GetValueForProperty("EffectiveDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).EffectiveDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("Scope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Scope = (string) content.GetValueForProperty("Scope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Scope, global::System.Convert.ToString);
            }
            if (content.Contains("NotScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NotScope = (System.Collections.Generic.List<string>) content.GetValueForProperty("NotScope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NotScope, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("ParameterRaw"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ParameterRaw = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentPropertiesParameters) content.GetValueForProperty("ParameterRaw",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ParameterRaw, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyAssignmentPropertiesParametersTypeConverter.ConvertFrom);
            }
            if (content.Contains("Description"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Description, global::System.Convert.ToString);
            }
            if (content.Contains("MetadataRaw"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).MetadataRaw = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("MetadataRaw",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).MetadataRaw, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("NonComplianceMessage"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NonComplianceMessage = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.INonComplianceMessage>) content.GetValueForProperty("NonComplianceMessage",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).NonComplianceMessage, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.INonComplianceMessage>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.NonComplianceMessageTypeConverter.ConvertFrom));
            }
            if (content.Contains("ResourceSelector"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ResourceSelector = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>) content.GetValueForProperty("ResourceSelector",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).ResourceSelector, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ResourceSelectorTypeConverter.ConvertFrom));
            }
            if (content.Contains("Override"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Override = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride>) content.GetValueForProperty("Override",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).Override, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IOverride>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.OverrideTypeConverter.ConvertFrom));
            }
            if (content.Contains("InstanceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).InstanceId = (string) content.GetValueForProperty("InstanceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).InstanceId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityPrincipalId = (string) content.GetValueForProperty("IdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityTenantId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityTenantId = (string) content.GetValueForProperty("IdentityTenantId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityTenantId, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityType = (string) content.GetValueForProperty("IdentityType",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityType, global::System.Convert.ToString);
            }
            if (content.Contains("IdentityUserAssignedIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityUserAssignedIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IIdentityUserAssignedIdentities) content.GetValueForProperty("IdentityUserAssignedIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).IdentityUserAssignedIdentity, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IdentityUserAssignedIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SelfServeExemptionSettingEnabled"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingEnabled = (bool?) content.GetValueForProperty("SelfServeExemptionSettingEnabled",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("SelfServeExemptionSettingPolicyDefinitionReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingPolicyDefinitionReferenceId = (System.Collections.Generic.List<string>) content.GetValueForProperty("SelfServeExemptionSettingPolicyDefinitionReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyAssignmentInternal)this).SelfServeExemptionSettingPolicyDefinitionReferenceId, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The policy assignment.
    [System.ComponentModel.TypeConverter(typeof(PolicyAssignmentTypeConverter))]
    public partial interface IPolicyAssignment

    {

    }
}