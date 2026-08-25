// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The policy enrollment properties for Patch request.</summary>
    [System.ComponentModel.TypeConverter(typeof(PolicyEnrollmentUpdatePropertiesTypeConverter))]
    public partial class PolicyEnrollmentUpdateProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PolicyEnrollmentUpdateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PolicyEnrollmentUpdateProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PolicyEnrollmentUpdateProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="PolicyEnrollmentUpdateProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdateProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PolicyEnrollmentUpdateProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("AssignmentScopeValidation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).AssignmentScopeValidation = (string) content.GetValueForProperty("AssignmentScopeValidation",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).AssignmentScopeValidation, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceSelector"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).ResourceSelector = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>) content.GetValueForProperty("ResourceSelector",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).ResourceSelector, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ResourceSelectorTypeConverter.ConvertFrom));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyEnrollmentUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PolicyEnrollmentUpdateProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("AssignmentScopeValidation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).AssignmentScopeValidation = (string) content.GetValueForProperty("AssignmentScopeValidation",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).AssignmentScopeValidation, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceSelector"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).ResourceSelector = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>) content.GetValueForProperty("ResourceSelector",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollmentUpdatePropertiesInternal)this).ResourceSelector, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ResourceSelectorTypeConverter.ConvertFrom));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The policy enrollment properties for Patch request.
    [System.ComponentModel.TypeConverter(typeof(PolicyEnrollmentUpdatePropertiesTypeConverter))]
    public partial interface IPolicyEnrollmentUpdateProperties

    {

    }
}