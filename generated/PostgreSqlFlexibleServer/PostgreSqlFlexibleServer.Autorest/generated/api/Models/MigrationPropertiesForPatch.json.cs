// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration properties.</summary>
    public partial class MigrationPropertiesForPatch
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json serialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container);

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

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json, ref bool returnNow);

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

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationPropertiesForPatch FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json ? new MigrationPropertiesForPatch(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject into a new instance of <see cref="MigrationPropertiesForPatch" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MigrationPropertiesForPatch(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_secretParameter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject>("secretParameters"), out var __jsonSecretParameters) ? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParametersForPatch.FromJson(__jsonSecretParameters) : _secretParameter;}
            {_sourceDbServerResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("sourceDbServerResourceId"), out var __jsonSourceDbServerResourceId) ? (string)__jsonSourceDbServerResourceId : (string)_sourceDbServerResourceId;}
            {_sourceDbServerFullyQualifiedDomainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("sourceDbServerFullyQualifiedDomainName"), out var __jsonSourceDbServerFullyQualifiedDomainName) ? (string)__jsonSourceDbServerFullyQualifiedDomainName : (string)_sourceDbServerFullyQualifiedDomainName;}
            {_targetDbServerFullyQualifiedDomainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("targetDbServerFullyQualifiedDomainName"), out var __jsonTargetDbServerFullyQualifiedDomainName) ? (string)__jsonTargetDbServerFullyQualifiedDomainName : (string)_targetDbServerFullyQualifiedDomainName;}
            {_dbsToMigrate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("dbsToMigrate"), out var __jsonDbsToMigrate) ? If( __jsonDbsToMigrate as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _dbsToMigrate;}
            {_setupLogicalReplicationOnSourceDbIfNeeded = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("setupLogicalReplicationOnSourceDbIfNeeded"), out var __jsonSetupLogicalReplicationOnSourceDbIfNeeded) ? (string)__jsonSetupLogicalReplicationOnSourceDbIfNeeded : (string)_setupLogicalReplicationOnSourceDbIfNeeded;}
            {_overwriteDbsInTarget = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("overwriteDbsInTarget"), out var __jsonOverwriteDbsInTarget) ? (string)__jsonOverwriteDbsInTarget : (string)_overwriteDbsInTarget;}
            {_migrationWindowStartTimeInUtc = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationWindowStartTimeInUtc"), out var __jsonMigrationWindowStartTimeInUtc) ? global::System.DateTime.TryParse((string)__jsonMigrationWindowStartTimeInUtc, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonMigrationWindowStartTimeInUtcValue) ? __jsonMigrationWindowStartTimeInUtcValue : _migrationWindowStartTimeInUtc : _migrationWindowStartTimeInUtc;}
            {_migrateRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrateRoles"), out var __jsonMigrateRoles) ? (string)__jsonMigrateRoles : (string)_migrateRole;}
            {_startDataMigration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("startDataMigration"), out var __jsonStartDataMigration) ? (string)__jsonStartDataMigration : (string)_startDataMigration;}
            {_triggerCutover = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("triggerCutover"), out var __jsonTriggerCutover) ? (string)__jsonTriggerCutover : (string)_triggerCutover;}
            {_dbsToTriggerCutoverOn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("dbsToTriggerCutoverOn"), out var __jsonDbsToTriggerCutoverOn) ? If( __jsonDbsToTriggerCutoverOn as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : _dbsToTriggerCutoverOn;}
            {_cancel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("cancel"), out var __jsonCancel) ? (string)__jsonCancel : (string)_cancel;}
            {_dbsToCancelMigrationOn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("dbsToCancelMigrationOn"), out var __jsonDbsToCancelMigrationOn) ? If( __jsonDbsToCancelMigrationOn as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : _dbsToCancelMigrationOn;}
            {_migrationMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationMode"), out var __jsonMigrationMode) ? (string)__jsonMigrationMode : (string)_migrationMode;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MigrationPropertiesForPatch" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MigrationPropertiesForPatch" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != this._secretParameter ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) this._secretParameter.ToJson(null,serializationMode) : null, "secretParameters" ,container.Add );
            AddIf( null != (((object)this._sourceDbServerResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._sourceDbServerResourceId.ToString()) : null, "sourceDbServerResourceId" ,container.Add );
            AddIf( null != (((object)this._sourceDbServerFullyQualifiedDomainName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._sourceDbServerFullyQualifiedDomainName.ToString()) : null, "sourceDbServerFullyQualifiedDomainName" ,container.Add );
            AddIf( null != (((object)this._targetDbServerFullyQualifiedDomainName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._targetDbServerFullyQualifiedDomainName.ToString()) : null, "targetDbServerFullyQualifiedDomainName" ,container.Add );
            if (null != this._dbsToMigrate)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.XNodeArray();
                foreach( var __x in this._dbsToMigrate )
                {
                    AddIf(null != (((object)__x)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(__x.ToString()) : null ,__w.Add);
                }
                container.Add("dbsToMigrate",__w);
            }
            AddIf( null != (((object)this._setupLogicalReplicationOnSourceDbIfNeeded)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._setupLogicalReplicationOnSourceDbIfNeeded.ToString()) : null, "setupLogicalReplicationOnSourceDbIfNeeded" ,container.Add );
            AddIf( null != (((object)this._overwriteDbsInTarget)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._overwriteDbsInTarget.ToString()) : null, "overwriteDbsInTarget" ,container.Add );
            AddIf( null != this._migrationWindowStartTimeInUtc ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationWindowStartTimeInUtc?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "migrationWindowStartTimeInUtc" ,container.Add );
            AddIf( null != (((object)this._migrateRole)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrateRole.ToString()) : null, "migrateRoles" ,container.Add );
            AddIf( null != (((object)this._startDataMigration)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._startDataMigration.ToString()) : null, "startDataMigration" ,container.Add );
            AddIf( null != (((object)this._triggerCutover)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._triggerCutover.ToString()) : null, "triggerCutover" ,container.Add );
            if (null != this._dbsToTriggerCutoverOn)
            {
                var __r = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.XNodeArray();
                foreach( var __s in this._dbsToTriggerCutoverOn )
                {
                    AddIf(null != (((object)__s)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(__s.ToString()) : null ,__r.Add);
                }
                container.Add("dbsToTriggerCutoverOn",__r);
            }
            AddIf( null != (((object)this._cancel)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._cancel.ToString()) : null, "cancel" ,container.Add );
            if (null != this._dbsToCancelMigrationOn)
            {
                var __m = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.XNodeArray();
                foreach( var __n in this._dbsToCancelMigrationOn )
                {
                    AddIf(null != (((object)__n)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(__n.ToString()) : null ,__m.Add);
                }
                container.Add("dbsToCancelMigrationOn",__m);
            }
            AddIf( null != (((object)this._migrationMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationMode.ToString()) : null, "migrationMode" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}