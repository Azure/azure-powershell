// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    public partial class PostgreSqlFlexibleServerIdentity
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
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json ? new PostgreSqlFlexibleServerIdentity(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject into a new instance of <see cref="PostgreSqlFlexibleServerIdentity" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal PostgreSqlFlexibleServerIdentity(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_subscriptionId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("subscriptionId"), out var __jsonSubscriptionId) ? (string)__jsonSubscriptionId : (string)_subscriptionId;}
            {_resourceGroupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("resourceGroupName"), out var __jsonResourceGroupName) ? (string)__jsonResourceGroupName : (string)_resourceGroupName;}
            {_serverName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("serverName"), out var __jsonServerName) ? (string)__jsonServerName : (string)_serverName;}
            {_objectId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("objectId"), out var __jsonObjectId) ? (string)__jsonObjectId : (string)_objectId;}
            {_migrationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("migrationName"), out var __jsonMigrationName) ? (string)__jsonMigrationName : (string)_migrationName;}
            {_backupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("backupName"), out var __jsonBackupName) ? (string)__jsonBackupName : (string)_backupName;}
            {_threatProtectionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("threatProtectionName"), out var __jsonThreatProtectionName) ? (string)__jsonThreatProtectionName : (string)_threatProtectionName;}
            {_configurationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("configurationName"), out var __jsonConfigurationName) ? (string)__jsonConfigurationName : (string)_configurationName;}
            {_databaseName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("databaseName"), out var __jsonDatabaseName) ? (string)__jsonDatabaseName : (string)_databaseName;}
            {_firewallRuleName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("firewallRuleName"), out var __jsonFirewallRuleName) ? (string)__jsonFirewallRuleName : (string)_firewallRuleName;}
            {_privateEndpointConnectionName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("privateEndpointConnectionName"), out var __jsonPrivateEndpointConnectionName) ? (string)__jsonPrivateEndpointConnectionName : (string)_privateEndpointConnectionName;}
            {_groupName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("groupName"), out var __jsonGroupName) ? (string)__jsonGroupName : (string)_groupName;}
            {_tuningOption = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("tuningOption"), out var __jsonTuningOption) ? (string)__jsonTuningOption : (string)_tuningOption;}
            {_virtualEndpointName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("virtualEndpointName"), out var __jsonVirtualEndpointName) ? (string)__jsonVirtualEndpointName : (string)_virtualEndpointName;}
            {_locationName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("locationName"), out var __jsonLocationName) ? (string)__jsonLocationName : (string)_locationName;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)_id;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="PostgreSqlFlexibleServerIdentity" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="PostgreSqlFlexibleServerIdentity" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode" />.
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
            AddIf( null != (((object)this._subscriptionId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._subscriptionId.ToString()) : null, "subscriptionId" ,container.Add );
            AddIf( null != (((object)this._resourceGroupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._resourceGroupName.ToString()) : null, "resourceGroupName" ,container.Add );
            AddIf( null != (((object)this._serverName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._serverName.ToString()) : null, "serverName" ,container.Add );
            AddIf( null != (((object)this._objectId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._objectId.ToString()) : null, "objectId" ,container.Add );
            AddIf( null != (((object)this._migrationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._migrationName.ToString()) : null, "migrationName" ,container.Add );
            AddIf( null != (((object)this._backupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._backupName.ToString()) : null, "backupName" ,container.Add );
            AddIf( null != (((object)this._threatProtectionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._threatProtectionName.ToString()) : null, "threatProtectionName" ,container.Add );
            AddIf( null != (((object)this._configurationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._configurationName.ToString()) : null, "configurationName" ,container.Add );
            AddIf( null != (((object)this._databaseName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._databaseName.ToString()) : null, "databaseName" ,container.Add );
            AddIf( null != (((object)this._firewallRuleName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._firewallRuleName.ToString()) : null, "firewallRuleName" ,container.Add );
            AddIf( null != (((object)this._privateEndpointConnectionName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._privateEndpointConnectionName.ToString()) : null, "privateEndpointConnectionName" ,container.Add );
            AddIf( null != (((object)this._groupName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._groupName.ToString()) : null, "groupName" ,container.Add );
            AddIf( null != (((object)this._tuningOption)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._tuningOption.ToString()) : null, "tuningOption" ,container.Add );
            AddIf( null != (((object)this._virtualEndpointName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._virtualEndpointName.ToString()) : null, "virtualEndpointName" ,container.Add );
            AddIf( null != (((object)this._locationName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._locationName.ToString()) : null, "locationName" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}