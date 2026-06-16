// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// [eSAN graft] Hand-added model for Azure Elastic SAN (eSAN) restore support.
// The eSAN "GenericRestoreDatasourceCriteria" discriminator exists only in the
// 2024-02-01-preview DataProtection API and is NOT present in the stable 2026-03-01
// spec this module is generated from. This file mirrors the AutoRest-generated
// ItemPathBasedRestoreCriteria pattern (an ItemLevelRestoreCriteria subtype) so the
// typed PowerShell cmdlets can build and serialize an eSAN restore criteria.
// Remove/replace with generated code when eSAN is promoted into the stable spec.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Generic criteria to be used during restore</summary>
    public partial class GenericRestoreDatasourceCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteria,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteriaInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IItemLevelRestoreCriteria"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IItemLevelRestoreCriteria __itemLevelRestoreCriteria = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ItemLevelRestoreCriteria();

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => "GenericRestoreDatasourceCriteria"; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IItemLevelRestoreCriteriaInternal)__itemLevelRestoreCriteria).ObjectType = "GenericRestoreDatasourceCriteria"; }

        /// <summary>Backing field for <see cref="ResourceSelector" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria _resourceSelector;

        /// <summary>List of resource identifiers that need to be restored</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria ResourceSelector { get => this._resourceSelector; set => this._resourceSelector = value; }

        /// <summary>Creates an new <see cref="GenericRestoreDatasourceCriteria" /> instance.</summary>
        public GenericRestoreDatasourceCriteria()
        {
            this.__itemLevelRestoreCriteria.ObjectType = "GenericRestoreDatasourceCriteria";
        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__itemLevelRestoreCriteria), __itemLevelRestoreCriteria);
            await eventListener.AssertObjectIsValid(nameof(__itemLevelRestoreCriteria), __itemLevelRestoreCriteria);
        }

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteria.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteria.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteria FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new GenericRestoreDatasourceCriteria(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="GenericRestoreDatasourceCriteria" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal GenericRestoreDatasourceCriteria(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __itemLevelRestoreCriteria = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ItemLevelRestoreCriteria(json);
            {_resourceSelector = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject>("resourceSelectors"), out var __jsonResourceSelectors) ? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ResourceListSelectionCriteria.FromJson(__jsonResourceSelectors) : _resourceSelector;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="GenericRestoreDatasourceCriteria" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="GenericRestoreDatasourceCriteria" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
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
            __itemLevelRestoreCriteria?.ToJson(container, serializationMode);
            AddIf( null != this._resourceSelector ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) this._resourceSelector.ToJson(null,serializationMode) : null, "resourceSelectors" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
    /// Generic criteria to be used during restore
    public partial interface IGenericRestoreDatasourceCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IItemLevelRestoreCriteria
    {
        /// <summary>List of resource identifiers that need to be restored</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of resource identifiers that need to be restored",
        SerializedName = @"resourceSelectors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria ResourceSelector { get; set; }

    }
    /// Generic criteria to be used during restore
    internal partial interface IGenericRestoreDatasourceCriteriaInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IItemLevelRestoreCriteriaInternal
    {
        /// <summary>List of resource identifiers that need to be restored</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria ResourceSelector { get; set; }

    }
}
