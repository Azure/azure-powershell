namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Migration Properties</summary>
    public partial class MigrationProperties
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json ? new MigrationProperties(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject into a new instance of <see cref="MigrationProperties" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal MigrationProperties(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_migrationProgress = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject>("migrationProgress"), out var __jsonMigrationProgress) ? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProgress.FromJson(__jsonMigrationProgress) : MigrationProgress;}
            {_oldSubnetId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("oldSubnetId"), out var __jsonOldSubnetId) ? (string)__jsonOldSubnetId : (string)OldSubnetId;}
            {_oldVnetSiteId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString>("oldVnetSiteId"), out var __jsonOldVnetSiteId) ? (string)__jsonOldVnetSiteId : (string)OldVnetSiteId;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="MigrationProperties" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="MigrationProperties" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode" />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != this._migrationProgress ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) this._migrationProgress.ToJson(null,serializationMode) : null, "migrationProgress" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._oldSubnetId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._oldSubnetId.ToString()) : null, "oldSubnetId" ,container.Add );
            }
            if (serializationMode.HasFlag(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeReadOnly))
            {
                AddIf( null != (((object)this._oldVnetSiteId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonString(this._oldVnetSiteId.ToString()) : null, "oldVnetSiteId" ,container.Add );
            }
            AfterToJson(ref container);
            return container;
        }
    }
}