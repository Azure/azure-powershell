// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The policy log info.</summary>
    [System.ComponentModel.TypeConverter(typeof(PolicyLogInfoTypeConverter))]
    public partial class PolicyLogInfo
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PolicyLogInfo(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PolicyLogInfo(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PolicyLogInfo" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="PolicyLogInfo" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PolicyLogInfo(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PolicyDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionId = (string) content.GetValueForProperty("PolicyDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicySetDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionId = (string) content.GetValueForProperty("PolicySetDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionReferenceId = (string) content.GetValueForProperty("PolicyDefinitionReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicySetDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionName = (string) content.GetValueForProperty("PolicySetDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicySetDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionVersion = (string) content.GetValueForProperty("PolicySetDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionName = (string) content.GetValueForProperty("PolicyDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionVersion = (string) content.GetValueForProperty("PolicyDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionEffect"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionEffect = (string) content.GetValueForProperty("PolicyDefinitionEffect",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionEffect, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentId = (string) content.GetValueForProperty("PolicyAssignmentId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentName = (string) content.GetValueForProperty("PolicyAssignmentName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentVersion = (string) content.GetValueForProperty("PolicyAssignmentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentScope = (string) content.GetValueForProperty("PolicyAssignmentScope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentScope, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfo"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PolicyLogInfo(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PolicyDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionId = (string) content.GetValueForProperty("PolicyDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicySetDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionId = (string) content.GetValueForProperty("PolicySetDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionReferenceId = (string) content.GetValueForProperty("PolicyDefinitionReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicySetDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionName = (string) content.GetValueForProperty("PolicySetDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicySetDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionVersion = (string) content.GetValueForProperty("PolicySetDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicySetDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionName = (string) content.GetValueForProperty("PolicyDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionVersion = (string) content.GetValueForProperty("PolicyDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyDefinitionEffect"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionEffect = (string) content.GetValueForProperty("PolicyDefinitionEffect",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyDefinitionEffect, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentId = (string) content.GetValueForProperty("PolicyAssignmentId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentName = (string) content.GetValueForProperty("PolicyAssignmentName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentVersion = (string) content.GetValueForProperty("PolicyAssignmentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyAssignmentScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentScope = (string) content.GetValueForProperty("PolicyAssignmentScope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfoInternal)this).PolicyAssignmentScope, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The policy log info.
    [System.ComponentModel.TypeConverter(typeof(PolicyLogInfoTypeConverter))]
    public partial interface IPolicyLogInfo

    {

    }
}