namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Service level objectives for performance tier.</summary>
    public partial class PerformanceTierServiceLevelObjectives
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IPerformanceTierServiceLevelObjectives FromJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json ? new PerformanceTierServiceLevelObjectives(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject into a new instance of <see cref="PerformanceTierServiceLevelObjectives" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal PerformanceTierServiceLevelObjectives(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_edition = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("edition"), out var __jsonEdition) ? (string)__jsonEdition : (string)Edition;}
            {_hardwareGeneration = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("hardwareGeneration"), out var __jsonHardwareGeneration) ? (string)__jsonHardwareGeneration : (string)HardwareGeneration;}
            {_id = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString>("id"), out var __jsonId) ? (string)__jsonId : (string)Id;}
            {_maxBackupRetentionDay = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber>("maxBackupRetentionDays"), out var __jsonMaxBackupRetentionDays) ? (int?)__jsonMaxBackupRetentionDays : MaxBackupRetentionDay;}
            {_maxStorageMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber>("maxStorageMB"), out var __jsonMaxStorageMb) ? (int?)__jsonMaxStorageMb : MaxStorageMb;}
            {_minBackupRetentionDay = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber>("minBackupRetentionDays"), out var __jsonMinBackupRetentionDays) ? (int?)__jsonMinBackupRetentionDays : MinBackupRetentionDay;}
            {_minStorageMb = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber>("minStorageMB"), out var __jsonMinStorageMb) ? (int?)__jsonMinStorageMb : MinStorageMb;}
            {_vCore = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber>("vCore"), out var __jsonVCore) ? (int?)__jsonVCore : VCore;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="PerformanceTierServiceLevelObjectives" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="PerformanceTierServiceLevelObjectives" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._edition)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._edition.ToString()) : null, "edition" ,container.Add );
            AddIf( null != (((object)this._hardwareGeneration)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._hardwareGeneration.ToString()) : null, "hardwareGeneration" ,container.Add );
            AddIf( null != (((object)this._id)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonString(this._id.ToString()) : null, "id" ,container.Add );
            AddIf( null != this._maxBackupRetentionDay ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber((int)this._maxBackupRetentionDay) : null, "maxBackupRetentionDays" ,container.Add );
            AddIf( null != this._maxStorageMb ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber((int)this._maxStorageMb) : null, "maxStorageMB" ,container.Add );
            AddIf( null != this._minBackupRetentionDay ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber((int)this._minBackupRetentionDay) : null, "minBackupRetentionDays" ,container.Add );
            AddIf( null != this._minStorageMb ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber((int)this._minStorageMb) : null, "minStorageMB" ,container.Add );
            AddIf( null != this._vCore ? (Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNode)new Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Json.JsonNumber((int)this._vCore) : null, "vCore" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}