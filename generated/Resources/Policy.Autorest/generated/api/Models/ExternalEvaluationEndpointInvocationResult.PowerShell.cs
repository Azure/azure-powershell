// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The external evaluation endpoint invocation results.</summary>
    [System.ComponentModel.TypeConverter(typeof(ExternalEvaluationEndpointInvocationResultTypeConverter))]
    public partial class ExternalEvaluationEndpointInvocationResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExternalEvaluationEndpointInvocationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ExternalEvaluationEndpointInvocationResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExternalEvaluationEndpointInvocationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ExternalEvaluationEndpointInvocationResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExternalEvaluationEndpointInvocationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ExternalEvaluationEndpointInvocationResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PolicyInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo) content.GetValueForProperty("PolicyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfo, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfoTypeConverter.ConvertFrom);
            }
            if (content.Contains("Result"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Result = (string) content.GetValueForProperty("Result",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Result, global::System.Convert.ToString);
            }
            if (content.Contains("EndpointKind"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).EndpointKind = (string) content.GetValueForProperty("EndpointKind",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).EndpointKind, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("RetryAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).RetryAfter = (global::System.DateTime?) content.GetValueForProperty("RetryAfter",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).RetryAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("Claim"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Claim = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("Claim",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Claim, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("PolicyAction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyAction = (string) content.GetValueForProperty("PolicyAction",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyAction, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyEvaluationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyEvaluationDetail = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("PolicyEvaluationDetail",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyEvaluationDetail, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdditionalInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).AdditionalInfo = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).AdditionalInfo, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("Expiration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Expiration = (global::System.DateTime?) content.GetValueForProperty("Expiration",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Expiration, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("PolicyInfoPolicyDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionId = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicySetDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionId = (string) content.GetValueForProperty("PolicyInfoPolicySetDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionReferenceId = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicySetDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionName = (string) content.GetValueForProperty("PolicyInfoPolicySetDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicySetDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionVersion = (string) content.GetValueForProperty("PolicyInfoPolicySetDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionName = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionVersion = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionEffect"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionEffect = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionEffect",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionEffect, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentId = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentName = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentVersion = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentScope = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentScope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentScope, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExternalEvaluationEndpointInvocationResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ExternalEvaluationEndpointInvocationResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("PolicyInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfo = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo) content.GetValueForProperty("PolicyInfo",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfo, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyLogInfoTypeConverter.ConvertFrom);
            }
            if (content.Contains("Result"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Result = (string) content.GetValueForProperty("Result",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Result, global::System.Convert.ToString);
            }
            if (content.Contains("EndpointKind"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).EndpointKind = (string) content.GetValueForProperty("EndpointKind",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).EndpointKind, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("RetryAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).RetryAfter = (global::System.DateTime?) content.GetValueForProperty("RetryAfter",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).RetryAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("Claim"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Claim = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("Claim",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Claim, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("PolicyAction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyAction = (string) content.GetValueForProperty("PolicyAction",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyAction, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyEvaluationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyEvaluationDetail = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("PolicyEvaluationDetail",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyEvaluationDetail, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("AdditionalInfo"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).AdditionalInfo = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) content.GetValueForProperty("AdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).AdditionalInfo, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AnyTypeConverter.ConvertFrom);
            }
            if (content.Contains("Expiration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Expiration = (global::System.DateTime?) content.GetValueForProperty("Expiration",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).Expiration, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("PolicyInfoPolicyDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionId = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicySetDefinitionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionId = (string) content.GetValueForProperty("PolicyInfoPolicySetDefinitionId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionReferenceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionReferenceId = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionReferenceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionReferenceId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicySetDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionName = (string) content.GetValueForProperty("PolicyInfoPolicySetDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicySetDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionVersion = (string) content.GetValueForProperty("PolicyInfoPolicySetDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicySetDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionName = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionVersion = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyDefinitionEffect"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionEffect = (string) content.GetValueForProperty("PolicyInfoPolicyDefinitionEffect",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyDefinitionEffect, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentId = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentId, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentName = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentName",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentName, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentVersion = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentVersion, global::System.Convert.ToString);
            }
            if (content.Contains("PolicyInfoPolicyAssignmentScope"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentScope = (string) content.GetValueForProperty("PolicyInfoPolicyAssignmentScope",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResultInternal)this).PolicyInfoPolicyAssignmentScope, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ExternalEvaluationEndpointInvocationResult" />, deserializing the content from a
        /// json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="ExternalEvaluationEndpointInvocationResult" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The external evaluation endpoint invocation results.
    [System.ComponentModel.TypeConverter(typeof(ExternalEvaluationEndpointInvocationResultTypeConverter))]
    public partial interface IExternalEvaluationEndpointInvocationResult

    {

    }
}