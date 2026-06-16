// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// [eSAN graft] Hand-added model for Azure Elastic SAN (eSAN) backup support.
// The eSAN "GenericBackupDatasourceParameters" discriminator exists only in the
// 2024-02-01-preview DataProtection API and is NOT present in the stable 2026-03-01
// spec this module is generated from. This file mirrors the AutoRest-generated
// BlobBackupDatasourceParameters pattern so the typed PowerShell cmdlets can build
// and serialize an eSAN backup configuration. Remove/replace with generated code
// when eSAN is promoted into the stable spec the module is generated from.

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Generic parameters to be used during configuration of backup</summary>
    public partial class GenericBackupDatasourceParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericBackupDatasourceParameters,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericBackupDatasourceParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupDatasourceParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupDatasourceParameters __backupDatasourceParameters = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BackupDatasourceParameters();

        /// <summary>Backing field for <see cref="ResourceSelector" /> property.</summary>
        private System.Collections.Generic.List<string> _resourceSelector;

        /// <summary>List of resource selectors to be backed up during configuration of backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> ResourceSelector { get => this._resourceSelector; set => this._resourceSelector = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => "GenericBackupDatasourceParameters"; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupDatasourceParametersInternal)__backupDatasourceParameters).ObjectType = "GenericBackupDatasourceParameters"; }

        /// <summary>Creates an new <see cref="GenericBackupDatasourceParameters" /> instance.</summary>
        public GenericBackupDatasourceParameters()
        {
            this.__backupDatasourceParameters.ObjectType = "GenericBackupDatasourceParameters";
        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__backupDatasourceParameters), __backupDatasourceParameters);
            await eventListener.AssertObjectIsValid(nameof(__backupDatasourceParameters), __backupDatasourceParameters);
        }

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="GenericBackupDatasourceParameters" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal GenericBackupDatasourceParameters(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __backupDatasourceParameters = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BackupDatasourceParameters(json);
            {_resourceSelector = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("resourceSelectors"), out var __jsonResourceSelectors) ? If( __jsonResourceSelectors as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _resourceSelector;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericBackupDatasourceParameters.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericBackupDatasourceParameters.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericBackupDatasourceParameters FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new GenericBackupDatasourceParameters(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="GenericBackupDatasourceParameters" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="GenericBackupDatasourceParameters" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
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
            __backupDatasourceParameters?.ToJson(container, serializationMode);
            if (null != this._resourceSelector)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __x in this._resourceSelector )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("resourceSelectors",__w);
            }
            AfterToJson(ref container);
            return container;
        }
    }
    /// Generic parameters to be used during configuration of backup
    public partial interface IGenericBackupDatasourceParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupDatasourceParameters
    {
        /// <summary>List of resource selectors to be backed up during configuration of backup</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of resource selectors to be backed up during configuration of backup",
        SerializedName = @"resourceSelectors",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ResourceSelector { get; set; }

    }
    /// Generic parameters to be used during configuration of backup
    internal partial interface IGenericBackupDatasourceParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupDatasourceParametersInternal
    {
        /// <summary>List of resource selectors to be backed up during configuration of backup</summary>
        System.Collections.Generic.List<string> ResourceSelector { get; set; }

    }
}
