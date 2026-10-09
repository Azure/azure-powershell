// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.PowerShell;

    /// <summary>ServiceGroupMember relationship properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(ServiceGroupMemberRelationshipPropertiesV2TypeConverter))]
    public partial class ServiceGroupMemberRelationshipPropertiesV2
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ServiceGroupMemberRelationshipPropertiesV2"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2 DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ServiceGroupMemberRelationshipPropertiesV2(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ServiceGroupMemberRelationshipPropertiesV2"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2 DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ServiceGroupMemberRelationshipPropertiesV2(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServiceGroupMemberRelationshipPropertiesV2" />, deserializing the content from a
        /// json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="ServiceGroupMemberRelationshipPropertiesV2" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2 FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ServiceGroupMemberRelationshipPropertiesV2"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ServiceGroupMemberRelationshipPropertiesV2(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("OriginInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformation = (Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation) content.GetValueForProperty("OriginInformation",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformation, Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipOriginInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("Metadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceId = (string) content.GetValueForProperty("SourceId",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceId, global::System.Convert.ToString);
            }
            if (content.Contains("TargetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).TargetId = (string) content.GetValueForProperty("TargetId",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).TargetId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceTenant"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceTenant = (string) content.GetValueForProperty("SourceTenant",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceTenant, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("OriginInformationRelationshipOriginType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationRelationshipOriginType = (string) content.GetValueForProperty("OriginInformationRelationshipOriginType",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationRelationshipOriginType, global::System.Convert.ToString);
            }
            if (content.Contains("OriginInformationDiscoveryEngine"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationDiscoveryEngine = (string) content.GetValueForProperty("OriginInformationDiscoveryEngine",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationDiscoveryEngine, global::System.Convert.ToString);
            }
            if (content.Contains("MetadataSourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataSourceType = (string) content.GetValueForProperty("MetadataSourceType",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataSourceType, global::System.Convert.ToString);
            }
            if (content.Contains("MetadataTargetType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataTargetType = (string) content.GetValueForProperty("MetadataTargetType",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataTargetType, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.ServiceGroupMemberRelationshipPropertiesV2"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ServiceGroupMemberRelationshipPropertiesV2(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("OriginInformation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformation = (Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipOriginInformation) content.GetValueForProperty("OriginInformation",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformation, Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipOriginInformationTypeConverter.ConvertFrom);
            }
            if (content.Contains("Metadata"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).Metadata = (Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IRelationshipMetadata) content.GetValueForProperty("Metadata",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).Metadata, Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.RelationshipMetadataTypeConverter.ConvertFrom);
            }
            if (content.Contains("SourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceId = (string) content.GetValueForProperty("SourceId",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceId, global::System.Convert.ToString);
            }
            if (content.Contains("TargetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).TargetId = (string) content.GetValueForProperty("TargetId",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).TargetId, global::System.Convert.ToString);
            }
            if (content.Contains("SourceTenant"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceTenant = (string) content.GetValueForProperty("SourceTenant",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).SourceTenant, global::System.Convert.ToString);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("OriginInformationRelationshipOriginType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationRelationshipOriginType = (string) content.GetValueForProperty("OriginInformationRelationshipOriginType",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationRelationshipOriginType, global::System.Convert.ToString);
            }
            if (content.Contains("OriginInformationDiscoveryEngine"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationDiscoveryEngine = (string) content.GetValueForProperty("OriginInformationDiscoveryEngine",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).OriginInformationDiscoveryEngine, global::System.Convert.ToString);
            }
            if (content.Contains("MetadataSourceType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataSourceType = (string) content.GetValueForProperty("MetadataSourceType",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataSourceType, global::System.Convert.ToString);
            }
            if (content.Contains("MetadataTargetType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataTargetType = (string) content.GetValueForProperty("MetadataTargetType",((Microsoft.Azure.PowerShell.Cmdlets.Relationships.Models.IServiceGroupMemberRelationshipPropertiesV2Internal)this).MetadataTargetType, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Relationships.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    }
    /// ServiceGroupMember relationship properties.
    [System.ComponentModel.TypeConverter(typeof(ServiceGroupMemberRelationshipPropertiesV2TypeConverter))]
    public partial interface IServiceGroupMemberRelationshipPropertiesV2

    {

    }
}