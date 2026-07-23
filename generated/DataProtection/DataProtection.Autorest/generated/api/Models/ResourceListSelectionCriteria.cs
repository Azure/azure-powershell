// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// [eSAN graft] Hand-added model for Azure Elastic SAN (eSAN) restore support.
// "ResourceListSelectionCriteria" exists only in the 2024-02-01-preview DataProtection
// API and is NOT present in the stable 2026-03-01 spec this module is generated from.
// It is the value carried by GenericRestoreDatasourceCriteria.ResourceSelector.
// Remove/replace with generated code when eSAN is promoted into the stable spec.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Specifies the list of resources to be restored</summary>
    public partial class ResourceListSelectionCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteriaInternal
    {
        /// <summary>Backing field for <see cref="ObjectType" /> property.</summary>
        private string _objectType;

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string ObjectType { get => this._objectType; set => this._objectType = value; }

        /// <summary>Backing field for <see cref="ResourceIdentifier" /> property.</summary>
        private System.Collections.Generic.List<string> _resourceIdentifier;

        /// <summary>List of resource identifiers to restore from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> ResourceIdentifier { get => this._resourceIdentifier; set => this._resourceIdentifier = value; }

        /// <summary>Backing field for <see cref="ResourceNameOverride" /> property.</summary>
        private System.Collections.Generic.Dictionary<string,string> _resourceNameOverride;

        /// <summary>
        /// This is a map of source resource names to target resources names to restore into. Any source name not included in the
        /// map will be restored with a default naming format
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public System.Collections.Generic.Dictionary<string,string> ResourceNameOverride { get => this._resourceNameOverride; set => this._resourceNameOverride = value; }

        /// <summary>Creates an new <see cref="ResourceListSelectionCriteria" /> instance.</summary>
        public ResourceListSelectionCriteria()
        {

        }

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new ResourceListSelectionCriteria(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="ResourceListSelectionCriteria" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ResourceListSelectionCriteria(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_objectType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("objectType"), out var __jsonObjectType) ? (string)__jsonObjectType : (string)_objectType;}
            {_resourceIdentifier = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("resourceIdentifiers"), out var __jsonResourceIdentifiers) ? If( __jsonResourceIdentifiers as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _resourceIdentifier;}
            // [eSAN graft] resourceNameOverrides (string->string map) is write-only for the cmdlet
            // use case; round-trip read-back is intentionally not deserialized here.
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ResourceListSelectionCriteria" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ResourceListSelectionCriteria" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._objectType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._objectType.ToString()) : null, "objectType" ,container.Add );
            if (null != this._resourceIdentifier)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __x in this._resourceIdentifier )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("resourceIdentifiers",__w);
            }
            if (null != this._resourceNameOverride)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject();
                foreach( var __key in this._resourceNameOverride.Keys )
                {
                    var __value = this._resourceNameOverride[__key];
                    __r.Add(__key, null != __value ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(__value) : null);
                }
                container.Add("resourceNameOverrides",__r);
            }
            AfterToJson(ref container);
            return container;
        }
    }
    /// Specifies the list of resources to be restored
    public partial interface IResourceListSelectionCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of the specific object - used for deserializing",
        SerializedName = @"objectType",
        PossibleTypes = new [] { typeof(string) })]
        string ObjectType { get; set; }
        /// <summary>List of resource identifiers to restore from</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of resource identifiers to restore from",
        SerializedName = @"resourceIdentifiers",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ResourceIdentifier { get; set; }
        /// <summary>
        /// This is a map of source resource names to target resources names to restore into. Any source name not included in the
        /// map will be restored with a default naming format
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"This is a map of source resource names to target resources names to restore into. Any source name not included in the map will be restored with a default naming format",
        SerializedName = @"resourceNameOverrides",
        PossibleTypes = new [] { typeof(System.Collections.Generic.Dictionary<string,string>) })]
        System.Collections.Generic.Dictionary<string,string> ResourceNameOverride { get; set; }

    }
    /// Specifies the list of resources to be restored
    internal partial interface IResourceListSelectionCriteriaInternal

    {
        /// <summary>Type of the specific object - used for deserializing</summary>
        string ObjectType { get; set; }
        /// <summary>List of resource identifiers to restore from</summary>
        System.Collections.Generic.List<string> ResourceIdentifier { get; set; }
        /// <summary>
        /// This is a map of source resource names to target resources names to restore into. Any source name not included in the
        /// map will be restored with a default naming format
        /// </summary>
        System.Collections.Generic.Dictionary<string,string> ResourceNameOverride { get; set; }

    }
}
