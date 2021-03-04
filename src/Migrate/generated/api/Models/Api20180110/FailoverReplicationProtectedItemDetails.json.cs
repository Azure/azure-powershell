namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Failover details for a replication protected item.</summary>
    public partial class FailoverReplicationProtectedItemDetails
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject into a new instance of <see cref="FailoverReplicationProtectedItemDetails" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal FailoverReplicationProtectedItemDetails(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_name = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("name"), out var __jsonName) ? (string)__jsonName : (string)Name;}
            {_friendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("friendlyName"), out var __jsonFriendlyName) ? (string)__jsonFriendlyName : (string)FriendlyName;}
            {_testVMName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("testVmName"), out var __jsonTestVMName) ? (string)__jsonTestVMName : (string)TestVMName;}
            {_testVMFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("testVmFriendlyName"), out var __jsonTestVMFriendlyName) ? (string)__jsonTestVMFriendlyName : (string)TestVMFriendlyName;}
            {_networkConnectionStatus = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("networkConnectionStatus"), out var __jsonNetworkConnectionStatus) ? (string)__jsonNetworkConnectionStatus : (string)NetworkConnectionStatus;}
            {_networkFriendlyName = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("networkFriendlyName"), out var __jsonNetworkFriendlyName) ? (string)__jsonNetworkFriendlyName : (string)NetworkFriendlyName;}
            {_subnet = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("subnet"), out var __jsonSubnet) ? (string)__jsonSubnet : (string)Subnet;}
            {_recoveryPointId = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryPointId"), out var __jsonRecoveryPointId) ? (string)__jsonRecoveryPointId : (string)RecoveryPointId;}
            {_recoveryPointTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString>("recoveryPointTime"), out var __jsonRecoveryPointTime) ? global::System.DateTime.TryParse((string)__jsonRecoveryPointTime, global::System.Globalization.CultureInfo.InvariantCulture, global::System.Globalization.DateTimeStyles.AdjustToUniversal, out var __jsonRecoveryPointTimeValue) ? __jsonRecoveryPointTimeValue : RecoveryPointTime : RecoveryPointTime;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject json ? new FailoverReplicationProtectedItemDetails(json) : null;
        }

        /// <summary>
        /// Serializes this instance of <see cref="FailoverReplicationProtectedItemDetails" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="FailoverReplicationProtectedItemDetails" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode"
        /// />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._name)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._name.ToString()) : null, "name" ,container.Add );
            AddIf( null != (((object)this._friendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._friendlyName.ToString()) : null, "friendlyName" ,container.Add );
            AddIf( null != (((object)this._testVMName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._testVMName.ToString()) : null, "testVmName" ,container.Add );
            AddIf( null != (((object)this._testVMFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._testVMFriendlyName.ToString()) : null, "testVmFriendlyName" ,container.Add );
            AddIf( null != (((object)this._networkConnectionStatus)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._networkConnectionStatus.ToString()) : null, "networkConnectionStatus" ,container.Add );
            AddIf( null != (((object)this._networkFriendlyName)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._networkFriendlyName.ToString()) : null, "networkFriendlyName" ,container.Add );
            AddIf( null != (((object)this._subnet)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._subnet.ToString()) : null, "subnet" ,container.Add );
            AddIf( null != (((object)this._recoveryPointId)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryPointId.ToString()) : null, "recoveryPointId" ,container.Add );
            AddIf( null != this._recoveryPointTime ? (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonString(this._recoveryPointTime?.ToString(@"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",global::System.Globalization.CultureInfo.InvariantCulture)) : null, "recoveryPointTime" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}