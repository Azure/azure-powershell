// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Extensions;

    public partial class SelfHelpIdentity
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity FromJson(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject json ? new SelfHelpIdentity(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject into a new instance of <see cref="SelfHelpIdentity" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal SelfHelpIdentity(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_scope = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("scope"), out var __jsonScope) ? (string)__jsonScope : (string)_scope;}
            {_diagnosticsResourceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("diagnosticsResourceName"), out var __jsonDiagnosticsResourceName) ? (string)__jsonDiagnosticsResourceName : (string)_diagnosticsResourceName;}
            {_solutionResourceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("solutionResourceName"), out var __jsonSolutionResourceName) ? (string)__jsonSolutionResourceName : (string)_solutionResourceName;}
            {_simplifiedSolutionsResourceName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("simplifiedSolutionsResourceName"), out var __jsonSimplifiedSolutionsResourceName) ? (string)__jsonSimplifiedSolutionsResourceName : (string)_simplifiedSolutionsResourceName;}
            {_troubleshooterName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("troubleshooterName"), out var __jsonTroubleshooterName) ? (string)__jsonTroubleshooterName : (string)_troubleshooterName;}
            {_solutionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("solutionId"), out var __jsonSolutionId) ? (string)__jsonSolutionId : (string)_solutionId;}
            {_subscriptionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("subscriptionId"), out var __jsonSubscriptionId) ? (string)__jsonSubscriptionId : (string)_subscriptionId;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)_id;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="SelfHelpIdentity" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="SelfHelpIdentity" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._scope)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._scope.ToString()) : null, "scope" ,container.Add );
            AddIf( null != (((object)this._diagnosticsResourceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._diagnosticsResourceName.ToString()) : null, "diagnosticsResourceName" ,container.Add );
            AddIf( null != (((object)this._solutionResourceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._solutionResourceName.ToString()) : null, "solutionResourceName" ,container.Add );
            AddIf( null != (((object)this._simplifiedSolutionsResourceName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._simplifiedSolutionsResourceName.ToString()) : null, "simplifiedSolutionsResourceName" ,container.Add );
            AddIf( null != (((object)this._troubleshooterName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._troubleshooterName.ToString()) : null, "troubleshooterName" ,container.Add );
            AddIf( null != (((object)this._solutionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._solutionId.ToString()) : null, "solutionId" ,container.Add );
            AddIf( null != (((object)this._subscriptionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._subscriptionId.ToString()) : null, "subscriptionId" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}