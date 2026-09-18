// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.PowerShell;

    /// <summary>The policy token response properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(PolicyTokenResponseTypeConverter))]
    public partial class PolicyTokenResponse
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponse" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponse DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PolicyTokenResponse(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponse" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponse DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PolicyTokenResponse(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PolicyTokenResponse" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="PolicyTokenResponse" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponse FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PolicyTokenResponse(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RequestDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetail = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetails) content.GetValueForProperty("RequestDetail",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetail, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenEvaluatedRequestDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Result"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Result = (string) content.GetValueForProperty("Result",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Result, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("RetryAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RetryAfter = (global::System.DateTime?) content.GetValueForProperty("RetryAfter",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RetryAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("Results"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Results = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult>) content.GetValueForProperty("Results",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Results, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExternalEvaluationEndpointInvocationResultTypeConverter.ConvertFrom));
            }
            if (content.Contains("ChangeReference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).ChangeReference = (string) content.GetValueForProperty("ChangeReference",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).ChangeReference, global::System.Convert.ToString);
            }
            if (content.Contains("Token"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Token = (string) content.GetValueForProperty("Token",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Token, global::System.Convert.ToString);
            }
            if (content.Contains("TokenId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).TokenId = (string) content.GetValueForProperty("TokenId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).TokenId, global::System.Convert.ToString);
            }
            if (content.Contains("Expiration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Expiration = (global::System.DateTime?) content.GetValueForProperty("Expiration",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Expiration, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("RequestDetailUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailUri = (string) content.GetValueForProperty("RequestDetailUri",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailUri, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailResourceId = (string) content.GetValueForProperty("RequestDetailResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailApiVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailApiVersion = (string) content.GetValueForProperty("RequestDetailApiVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailApiVersion, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailAuthorizationAction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailAuthorizationAction = (string) content.GetValueForProperty("RequestDetailAuthorizationAction",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailAuthorizationAction, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailHttpMethod"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailHttpMethod = (string) content.GetValueForProperty("RequestDetailHttpMethod",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailHttpMethod, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailContentHash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailContentHash = (string) content.GetValueForProperty("RequestDetailContentHash",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailContentHash, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenResponse"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PolicyTokenResponse(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("RequestDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetail = (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenEvaluatedRequestDetails) content.GetValueForProperty("RequestDetail",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetail, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenEvaluatedRequestDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("Result"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Result = (string) content.GetValueForProperty("Result",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Result, global::System.Convert.ToString);
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Message, global::System.Convert.ToString);
            }
            if (content.Contains("RetryAfter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RetryAfter = (global::System.DateTime?) content.GetValueForProperty("RetryAfter",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RetryAfter, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("Results"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Results = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult>) content.GetValueForProperty("Results",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Results, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IExternalEvaluationEndpointInvocationResult>(__y, Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ExternalEvaluationEndpointInvocationResultTypeConverter.ConvertFrom));
            }
            if (content.Contains("ChangeReference"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).ChangeReference = (string) content.GetValueForProperty("ChangeReference",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).ChangeReference, global::System.Convert.ToString);
            }
            if (content.Contains("Token"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Token = (string) content.GetValueForProperty("Token",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Token, global::System.Convert.ToString);
            }
            if (content.Contains("TokenId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).TokenId = (string) content.GetValueForProperty("TokenId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).TokenId, global::System.Convert.ToString);
            }
            if (content.Contains("Expiration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Expiration = (global::System.DateTime?) content.GetValueForProperty("Expiration",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).Expiration, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("RequestDetailUri"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailUri = (string) content.GetValueForProperty("RequestDetailUri",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailUri, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailResourceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailResourceId = (string) content.GetValueForProperty("RequestDetailResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailResourceId, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailApiVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailApiVersion = (string) content.GetValueForProperty("RequestDetailApiVersion",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailApiVersion, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailAuthorizationAction"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailAuthorizationAction = (string) content.GetValueForProperty("RequestDetailAuthorizationAction",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailAuthorizationAction, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailHttpMethod"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailHttpMethod = (string) content.GetValueForProperty("RequestDetailHttpMethod",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailHttpMethod, global::System.Convert.ToString);
            }
            if (content.Contains("RequestDetailContentHash"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailContentHash = (string) content.GetValueForProperty("RequestDetailContentHash",((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenResponseInternal)this).RequestDetailContentHash, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The policy token response properties.
    [System.ComponentModel.TypeConverter(typeof(PolicyTokenResponseTypeConverter))]
    public partial interface IPolicyTokenResponse

    {

    }
}