// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Migration.</summary>
    public partial class MigrationProperties
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json ? new MigrationProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject into a new instance of <see cref="MigrationProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MigrationProperties(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_currentStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject>("currentStatus"), out var __jsonCurrentStatus) ? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationStatus.FromJson(__jsonCurrentStatus) : _currentStatus;}
            {_sourceDbServerMetadata = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject>("sourceDbServerMetadata"), out var __jsonSourceDbServerMetadata) ? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadata.FromJson(__jsonSourceDbServerMetadata) : _sourceDbServerMetadata;}
            {_targetDbServerMetadata = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject>("targetDbServerMetadata"), out var __jsonTargetDbServerMetadata) ? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DbServerMetadata.FromJson(__jsonTargetDbServerMetadata) : _targetDbServerMetadata;}
            {_secretParameter = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject>("secretParameters"), out var __jsonSecretParameters) ? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.MigrationSecretParameters.FromJson(__jsonSecretParameters) : _secretParameter;}
            {_migrationId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationId"), out var __jsonMigrationId) ? (string)__jsonMigrationId : (string)_migrationId;}
            {_migrationInstanceResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationInstanceResourceId"), out var __jsonMigrationInstanceResourceId) ? (string)__jsonMigrationInstanceResourceId : (string)_migrationInstanceResourceId;}
            {_migrationMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationMode"), out var __jsonMigrationMode) ? (string)__jsonMigrationMode : (string)_migrationMode;}
            {_migrationOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationOption"), out var __jsonMigrationOption) ? (string)__jsonMigrationOption : (string)_migrationOption;}
            {_sourceType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("sourceType"), out var __jsonSourceType) ? (string)__jsonSourceType : (string)_sourceType;}
            {_sslMode = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("sslMode"), out var __jsonSslMode) ? (string)__jsonSslMode : (string)_sslMode;}
            {_sourceDbServerResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("sourceDbServerResourceId"), out var __jsonSourceDbServerResourceId) ? (string)__jsonSourceDbServerResourceId : (string)_sourceDbServerResourceId;}
            {_sourceDbServerFullyQualifiedDomainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("sourceDbServerFullyQualifiedDomainName"), out var __jsonSourceDbServerFullyQualifiedDomainName) ? (string)__jsonSourceDbServerFullyQualifiedDomainName : (string)_sourceDbServerFullyQualifiedDomainName;}
            {_targetDbServerResourceId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("targetDbServerResourceId"), out var __jsonTargetDbServerResourceId) ? (string)__jsonTargetDbServerResourceId : (string)_targetDbServerResourceId;}
            {_targetDbServerFullyQualifiedDomainName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("targetDbServerFullyQualifiedDomainName"), out var __jsonTargetDbServerFullyQualifiedDomainName) ? (string)__jsonTargetDbServerFullyQualifiedDomainName : (string)_targetDbServerFullyQualifiedDomainName;}
            {_dbsToMigrate = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("dbsToMigrate"), out var __jsonDbsToMigrate) ? If( __jsonDbsToMigrate as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__v, (__u)=>(string) (__u is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString __t ? (string)(__t.ToString()) : null)) ))() : null : _dbsToMigrate;}
            {_setupLogicalReplicationOnSourceDbIfNeeded = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("setupLogicalReplicationOnSourceDbIfNeeded"), out var __jsonSetupLogicalReplicationOnSourceDbIfNeeded) ? (string)__jsonSetupLogicalReplicationOnSourceDbIfNeeded : (string)_setupLogicalReplicationOnSourceDbIfNeeded;}
            {_overwriteDbsInTarget = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("overwriteDbsInTarget"), out var __jsonOverwriteDbsInTarget) ? (string)__jsonOverwriteDbsInTarget : (string)_overwriteDbsInTarget;}
            {_migrationWindowStartTimeInUtc = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationWindowStartTimeInUtc"), out var __jsonMigrationWindowStartTimeInUtc) ? global::System.DateTime.TryParse((string)__jsonMigrationWindowStartTimeInUtc, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonMigrationWindowStartTimeInUtcValue) ? __jsonMigrationWindowStartTimeInUtcValue : _migrationWindowStartTimeInUtc : _migrationWindowStartTimeInUtc;}
            {_migrationWindowEndTimeInUtc = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationWindowEndTimeInUtc"), out var __jsonMigrationWindowEndTimeInUtc) ? global::System.DateTime.TryParse((string)__jsonMigrationWindowEndTimeInUtc, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonMigrationWindowEndTimeInUtcValue) ? __jsonMigrationWindowEndTimeInUtcValue : _migrationWindowEndTimeInUtc : _migrationWindowEndTimeInUtc;}
            {_migrateRole = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrateRoles"), out var __jsonMigrateRoles) ? (string)__jsonMigrateRoles : (string)_migrateRole;}
            {_startDataMigration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("startDataMigration"), out var __jsonStartDataMigration) ? (string)__jsonStartDataMigration : (string)_startDataMigration;}
            {_triggerCutover = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("triggerCutover"), out var __jsonTriggerCutover) ? (string)__jsonTriggerCutover : (string)_triggerCutover;}
            {_dbsToTriggerCutoverOn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("dbsToTriggerCutoverOn"), out var __jsonDbsToTriggerCutoverOn) ? If( __jsonDbsToTriggerCutoverOn as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __q) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__q, (__p)=>(string) (__p is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString __o ? (string)(__o.ToString()) : null)) ))() : null : _dbsToTriggerCutoverOn;}
            {_cancel = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("cancel"), out var __jsonCancel) ? (string)__jsonCancel : (string)_cancel;}
            {_dbsToCancelMigrationOn = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray>("dbsToCancelMigrationOn"), out var __jsonDbsToCancelMigrationOn) ? If( __jsonDbsToCancelMigrationOn as Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonArray, out var __l) ? new global::System.Func<System.Collections.Generic.List<string>>(()=> global::System.Linq.Enumerable.ToList(global::System.Linq.Enumerable.Select(__l, (__k)=>(string) (__k is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString __j ? (string)(__j.ToString()) : null)) ))() : null : _dbsToCancelMigrationOn;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MigrationProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MigrationProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
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
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._currentStatus ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) this._currentStatus.ToJson(null,serializationMode) : null, "currentStatus" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._sourceDbServerMetadata ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) this._sourceDbServerMetadata.ToJson(null,serializationMode) : null, "sourceDbServerMetadata" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != this._targetDbServerMetadata ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) this._targetDbServerMetadata.ToJson(null,serializationMode) : null, "targetDbServerMetadata" ,container.Add );
            }
            AddIf( null != this._secretParameter ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) this._secretParameter.ToJson(null,serializationMode) : null, "secretParameters" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._migrationId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationId.ToString()) : null, "migrationId" ,container.Add );
            }
            AddIf( null != (((object)this._migrationInstanceResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationInstanceResourceId.ToString()) : null, "migrationInstanceResourceId" ,container.Add );
            AddIf( null != (((object)this._migrationMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationMode.ToString()) : null, "migrationMode" ,container.Add );
            AddIf( null != (((object)this._migrationOption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationOption.ToString()) : null, "migrationOption" ,container.Add );
            AddIf( null != (((object)this._sourceType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._sourceType.ToString()) : null, "sourceType" ,container.Add );
            AddIf( null != (((object)this._sslMode)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._sslMode.ToString()) : null, "sslMode" ,container.Add );
            AddIf( null != (((object)this._sourceDbServerResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._sourceDbServerResourceId.ToString()) : null, "sourceDbServerResourceId" ,container.Add );
            AddIf( null != (((object)this._sourceDbServerFullyQualifiedDomainName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._sourceDbServerFullyQualifiedDomainName.ToString()) : null, "sourceDbServerFullyQualifiedDomainName" ,container.Add );
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeRead))
            {
                AddIf( null != (((object)this._targetDbServerResourceId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._targetDbServerResourceId.ToString()) : null, "targetDbServerResourceId" ,container.Add );
            }
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
            AddIf( null != this._migrationWindowEndTimeInUtc ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationWindowEndTimeInUtc?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "migrationWindowEndTimeInUtc" ,container.Add );
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
            AfterToJson(ref container);
            return container;
        }
    }
}