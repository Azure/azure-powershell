// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The properties of the data policy manifest.</summary>
    public partial class DataPolicyManifestProperties
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
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject into a new instance of <see cref="DataPolicyManifestProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal DataPolicyManifestProperties(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_resourceFunction = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject>("resourceFunctions"), out var __jsonResourceFunctions) ? Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestResourceFunctionsDefinition.FromJson(__jsonResourceFunctions) : _resourceFunction;}
            {_namespace = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray>("namespaces"), out var __jsonNamespaces) ? If( __jsonNamespaces as Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _namespace;}
            {_policyMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString>("policyMode"), out var __jsonPolicyMode) ? (string)__jsonPolicyMode : (string)_policyMode;}
            {_isBuiltInOnly = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonBoolean>("isBuiltInOnly"), out var __jsonIsBuiltInOnly) ? (bool?)__jsonIsBuiltInOnly : _isBuiltInOnly;}
            {_resourceTypeAlias = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray>("resourceTypeAliases"), out var __jsonResourceTypeAliases) ? If( __jsonResourceTypeAliases as Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__q, (__p)=>(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases) (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.ResourceTypeAliases.FromJson(__p) )) ))() : null : _resourceTypeAlias;}
            {_effect = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray>("effects"), out var __jsonEffects) ? If( __jsonEffects as Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__l, (__k)=>(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect) (Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataEffect.FromJson(__k) )) ))() : null : _effect;}
            {_fieldValue = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray>("fieldValues"), out var __jsonFieldValues) ? If( __jsonFieldValues as Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonArray, out var __g) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__g, (__f)=>(string) (__f is Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString __e ? (string)(__e.ToString()) : null)) ))() : null : _fieldValue;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject json ? new DataPolicyManifestProperties(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="DataPolicyManifestProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="DataPolicyManifestProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode" />.
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
            AddIf( null != this._resourceFunction ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) this._resourceFunction.ToJson(null,serializationMode) : null, "resourceFunctions" ,container.Add );
            if (null != this._namespace)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.XNodeArray();
                foreach( var __x in this._namespace )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("namespaces",__w);
            }
            AddIf( null != (((object)this._policyMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(this._policyMode.ToString()) : null, "policyMode" ,container.Add );
            AddIf( null != this._isBuiltInOnly ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonBoolean((bool)this._isBuiltInOnly) : null, "isBuiltInOnly" ,container.Add );
            if (null != this._resourceTypeAlias)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.XNodeArray();
                foreach( var __s in this._resourceTypeAlias )
                {
                    AddIf(__s?.ToJson(null, serializationMode) ,__r.Add);
                }
                container.Add("resourceTypeAliases",__r);
            }
            if (null != this._effect)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.XNodeArray();
                foreach( var __n in this._effect )
                {
                    AddIf(__n?.ToJson(null, serializationMode) ,__m.Add);
                }
                container.Add("effects",__m);
            }
            if (null != this._fieldValue)
            {
                var __h = new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.XNodeArray();
                foreach( var __i in this._fieldValue )
                {
                    AddIf(null != (((object)__i)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Json.JsonString(__i.ToString()) : null ,__h.Add);
                }
                container.Add("fieldValues",__h);
            }
            AfterToJson(ref container);
            return container;
        }
    }
}