namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Azure backup discrete RecoveryPoint</summary>
    public partial class AzureBackupDiscreteRecoveryPoint
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject into a new instance of <see cref="AzureBackupDiscreteRecoveryPoint" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal AzureBackupDiscreteRecoveryPoint(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            __azureBackupRecoveryPoint = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.AzureBackupRecoveryPoint(json);
            {_friendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("friendlyName"), out var __jsonFriendlyName) ? (string)__jsonFriendlyName : (string)FriendlyName;}
            {_recoveryPointDataStoresDetail = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray>("recoveryPointDataStoresDetails"), out var __jsonRecoveryPointDataStoresDetails) ? If( __jsonRecoveryPointDataStoresDetails as Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonArray, out var __v) ? new global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails[]>(()=> global::System.Linq.Enumerable.ToArray(global::System.Linq.Enumerable.Select(__v, (__u)=>(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRecoveryPointDataStoreDetails) (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.RecoveryPointDataStoreDetails.FromJson(__u) )) ))() : null : RecoveryPointDataStoresDetail;}
            {_recoveryPointTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("recoveryPointTime"), out var __jsonRecoveryPointTime) ? global::System.DateTime.TryParse((string)__jsonRecoveryPointTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRecoveryPointTimeValue) ? __jsonRecoveryPointTimeValue : RecoveryPointTime : RecoveryPointTime;}
            {_policyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("policyName"), out var __jsonPolicyName) ? (string)__jsonPolicyName : (string)PolicyName;}
            {_policyVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("policyVersion"), out var __jsonPolicyVersion) ? (string)__jsonPolicyVersion : (string)PolicyVersion;}
            {_recoveryPointId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("recoveryPointId"), out var __jsonRecoveryPointId) ? (string)__jsonRecoveryPointId : (string)RecoveryPointId;}
            {_recoveryPointType = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("recoveryPointType"), out var __jsonRecoveryPointType) ? (string)__jsonRecoveryPointType : (string)RecoveryPointType;}
            {_retentionTagName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("retentionTagName"), out var __jsonRetentionTagName) ? (string)__jsonRetentionTagName : (string)RetentionTagName;}
            {_retentionTagVersion = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString>("retentionTagVersion"), out var __jsonRetentionTagVersion) ? (string)__jsonRetentionTagVersion : (string)RetentionTagVersion;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupDiscreteRecoveryPoint.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupDiscreteRecoveryPoint.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAzureBackupDiscreteRecoveryPoint FromJson(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject json ? new AzureBackupDiscreteRecoveryPoint(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="AzureBackupDiscreteRecoveryPoint" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="AzureBackupDiscreteRecoveryPoint" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode" />.
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
            __azureBackupRecoveryPoint?.ToJson(container, serializationMode);
            AddIf( null != (((object)this._friendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._friendlyName.ToString()) : null, "friendlyName" ,container.Add );
            if (null != this._recoveryPointDataStoresDetail)
            {
                var __w = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.XNodeArray();
                foreach( var __x in this._recoveryPointDataStoresDetail )
                {
                    AddIf(__x?.ToJson(null, serializationMode) ,__w.Add);
                }
                container.Add("recoveryPointDataStoresDetails",__w);
            }
            AddIf( (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._recoveryPointTime.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)), "recoveryPointTime" ,container.Add );
            AddIf( null != (((object)this._policyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._policyName.ToString()) : null, "policyName" ,container.Add );
            AddIf( null != (((object)this._policyVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._policyVersion.ToString()) : null, "policyVersion" ,container.Add );
            AddIf( null != (((object)this._recoveryPointId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._recoveryPointId.ToString()) : null, "recoveryPointId" ,container.Add );
            AddIf( null != (((object)this._recoveryPointType)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._recoveryPointType.ToString()) : null, "recoveryPointType" ,container.Add );
            AddIf( null != (((object)this._retentionTagName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._retentionTagName.ToString()) : null, "retentionTagName" ,container.Add );
            AddIf( null != (((object)this._retentionTagVersion)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Json.JsonString(this._retentionTagVersion.ToString()) : null, "retentionTagVersion" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}