// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy log info.</summary>
    public partial class PolicyLogInfo
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name= "returnNow" />
        /// output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyLogInfo FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json ? new PolicyLogInfo(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject into a new instance of <see cref="PolicyLogInfo" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal PolicyLogInfo(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_policyDefinitionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyDefinitionId"), out var __jsonPolicyDefinitionId) ? (string)__jsonPolicyDefinitionId : (string)_policyDefinitionId;}
            {_policySetDefinitionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policySetDefinitionId"), out var __jsonPolicySetDefinitionId) ? (string)__jsonPolicySetDefinitionId : (string)_policySetDefinitionId;}
            {_policyDefinitionReferenceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyDefinitionReferenceId"), out var __jsonPolicyDefinitionReferenceId) ? (string)__jsonPolicyDefinitionReferenceId : (string)_policyDefinitionReferenceId;}
            {_policySetDefinitionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policySetDefinitionName"), out var __jsonPolicySetDefinitionName) ? (string)__jsonPolicySetDefinitionName : (string)_policySetDefinitionName;}
            {_policySetDefinitionVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policySetDefinitionVersion"), out var __jsonPolicySetDefinitionVersion) ? (string)__jsonPolicySetDefinitionVersion : (string)_policySetDefinitionVersion;}
            {_policyDefinitionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyDefinitionName"), out var __jsonPolicyDefinitionName) ? (string)__jsonPolicyDefinitionName : (string)_policyDefinitionName;}
            {_policyDefinitionVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyDefinitionVersion"), out var __jsonPolicyDefinitionVersion) ? (string)__jsonPolicyDefinitionVersion : (string)_policyDefinitionVersion;}
            {_policyDefinitionEffect = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyDefinitionEffect"), out var __jsonPolicyDefinitionEffect) ? (string)__jsonPolicyDefinitionEffect : (string)_policyDefinitionEffect;}
            {_policyAssignmentId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyAssignmentId"), out var __jsonPolicyAssignmentId) ? (string)__jsonPolicyAssignmentId : (string)_policyAssignmentId;}
            {_policyAssignmentName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyAssignmentName"), out var __jsonPolicyAssignmentName) ? (string)__jsonPolicyAssignmentName : (string)_policyAssignmentName;}
            {_policyAssignmentVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyAssignmentVersion"), out var __jsonPolicyAssignmentVersion) ? (string)__jsonPolicyAssignmentVersion : (string)_policyAssignmentVersion;}
            {_policyAssignmentScope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyAssignmentScope"), out var __jsonPolicyAssignmentScope) ? (string)__jsonPolicyAssignmentScope : (string)_policyAssignmentScope;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="PolicyLogInfo" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="PolicyLogInfo" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._policyDefinitionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyDefinitionId.ToString()) : null, "policyDefinitionId" ,container.Add );
            AddIf( null != (((object)this._policySetDefinitionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policySetDefinitionId.ToString()) : null, "policySetDefinitionId" ,container.Add );
            AddIf( null != (((object)this._policyDefinitionReferenceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyDefinitionReferenceId.ToString()) : null, "policyDefinitionReferenceId" ,container.Add );
            AddIf( null != (((object)this._policySetDefinitionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policySetDefinitionName.ToString()) : null, "policySetDefinitionName" ,container.Add );
            AddIf( null != (((object)this._policySetDefinitionVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policySetDefinitionVersion.ToString()) : null, "policySetDefinitionVersion" ,container.Add );
            AddIf( null != (((object)this._policyDefinitionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyDefinitionName.ToString()) : null, "policyDefinitionName" ,container.Add );
            AddIf( null != (((object)this._policyDefinitionVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyDefinitionVersion.ToString()) : null, "policyDefinitionVersion" ,container.Add );
            AddIf( null != (((object)this._policyDefinitionEffect)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyDefinitionEffect.ToString()) : null, "policyDefinitionEffect" ,container.Add );
            AddIf( null != (((object)this._policyAssignmentId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyAssignmentId.ToString()) : null, "policyAssignmentId" ,container.Add );
            AddIf( null != (((object)this._policyAssignmentName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyAssignmentName.ToString()) : null, "policyAssignmentName" ,container.Add );
            AddIf( null != (((object)this._policyAssignmentVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyAssignmentVersion.ToString()) : null, "policyAssignmentVersion" ,container.Add );
            AddIf( null != (((object)this._policyAssignmentScope)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyAssignmentScope.ToString()) : null, "policyAssignmentScope" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}