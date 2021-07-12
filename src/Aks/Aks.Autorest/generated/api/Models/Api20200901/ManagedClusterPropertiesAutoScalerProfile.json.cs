namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Parameters to be applied to the cluster-autoscaler when enabled</summary>
    public partial class ManagedClusterPropertiesAutoScalerProfile
    {

        /// <summary>
        /// <c>AfterFromJson</c> will be called after the json deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>

        partial void AfterFromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json);

        /// <summary>
        /// <c>AfterToJson</c> will be called after the json erialization has finished, allowing customization of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject"
        /// /> before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>

        partial void AfterToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject container);

        /// <summary>
        /// <c>BeforeFromJson</c> will be called before the json deserialization has commenced, allowing complete customization of
        /// the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="json">The JsonNode that should be deserialized into this object.</param>
        /// <param name="returnNow">Determines if the rest of the deserialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeFromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json, ref bool returnNow);

        /// <summary>
        /// <c>BeforeToJson</c> will be called before the json serialization has commenced, allowing complete customization of the
        /// object before it is serialized.
        /// If you wish to disable the default serialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="container">The JSON container that the serialization result will be placed in.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeToJson(ref Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject container, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode"/> into an instance of Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile.
        /// </summary>
        /// <param name="node">a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>
        /// an instance of Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode node)
        {
            return node is Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json ? new ManagedClusterPropertiesAutoScalerProfile(json) : null;
        }

        /// <summary>
        /// Deserializes a Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject into a new instance of <see cref="ManagedClusterPropertiesAutoScalerProfile" />.
        /// </summary>
        /// <param name="json">A Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject instance to deserialize from.</param>
        internal ManagedClusterPropertiesAutoScalerProfile(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject json)
        {
            bool returnNow = false;
            BeforeFromJson(json, ref returnNow);
            if (returnNow)
            {
                return;
            }
            {_balanceSimilarNodeGroup = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("balance-similar-node-groups"), out var __jsonBalanceSimilarNodeGroups) ? (string)__jsonBalanceSimilarNodeGroups : (string)BalanceSimilarNodeGroup;}
            {_expander = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("expander"), out var __jsonExpander) ? (string)__jsonExpander : (string)Expander;}
            {_maxEmptyBulkDelete = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("max-empty-bulk-delete"), out var __jsonMaxEmptyBulkDelete) ? (string)__jsonMaxEmptyBulkDelete : (string)MaxEmptyBulkDelete;}
            {_maxGracefulTerminationSec = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("max-graceful-termination-sec"), out var __jsonMaxGracefulTerminationSec) ? (string)__jsonMaxGracefulTerminationSec : (string)MaxGracefulTerminationSec;}
            {_maxTotalUnreadyPercentage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("max-total-unready-percentage"), out var __jsonMaxTotalUnreadyPercentage) ? (string)__jsonMaxTotalUnreadyPercentage : (string)MaxTotalUnreadyPercentage;}
            {_newPodScaleUpDelay = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("new-pod-scale-up-delay"), out var __jsonNewPodScaleUpDelay) ? (string)__jsonNewPodScaleUpDelay : (string)NewPodScaleUpDelay;}
            {_okTotalUnreadyCount = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("ok-total-unready-count"), out var __jsonOkTotalUnreadyCount) ? (string)__jsonOkTotalUnreadyCount : (string)OkTotalUnreadyCount;}
            {_scanInterval = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("scan-interval"), out var __jsonScanInterval) ? (string)__jsonScanInterval : (string)ScanInterval;}
            {_scaleDownDelayAfterAdd = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("scale-down-delay-after-add"), out var __jsonScaleDownDelayAfterAdd) ? (string)__jsonScaleDownDelayAfterAdd : (string)ScaleDownDelayAfterAdd;}
            {_scaleDownDelayAfterDelete = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("scale-down-delay-after-delete"), out var __jsonScaleDownDelayAfterDelete) ? (string)__jsonScaleDownDelayAfterDelete : (string)ScaleDownDelayAfterDelete;}
            {_scaleDownDelayAfterFailure = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("scale-down-delay-after-failure"), out var __jsonScaleDownDelayAfterFailure) ? (string)__jsonScaleDownDelayAfterFailure : (string)ScaleDownDelayAfterFailure;}
            {_scaleDownUnneededTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("scale-down-unneeded-time"), out var __jsonScaleDownUnneededTime) ? (string)__jsonScaleDownUnneededTime : (string)ScaleDownUnneededTime;}
            {_scaleDownUnreadyTime = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("scale-down-unready-time"), out var __jsonScaleDownUnreadyTime) ? (string)__jsonScaleDownUnreadyTime : (string)ScaleDownUnreadyTime;}
            {_scaleDownUtilizationThreshold = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("scale-down-utilization-threshold"), out var __jsonScaleDownUtilizationThreshold) ? (string)__jsonScaleDownUtilizationThreshold : (string)ScaleDownUtilizationThreshold;}
            {_skipNodesWithLocalStorage = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("skip-nodes-with-local-storage"), out var __jsonSkipNodesWithLocalStorage) ? (string)__jsonSkipNodesWithLocalStorage : (string)SkipNodesWithLocalStorage;}
            {_skipNodesWithSystemPod = If( json?.PropertyT<Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString>("skip-nodes-with-system-pods"), out var __jsonSkipNodesWithSystemPods) ? (string)__jsonSkipNodesWithSystemPods : (string)SkipNodesWithSystemPod;}
            AfterFromJson(json);
        }

        /// <summary>
        /// Serializes this instance of <see cref="ManagedClusterPropertiesAutoScalerProfile" /> into a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode"
        /// />.
        /// </summary>
        /// <param name="container">The <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="ManagedClusterPropertiesAutoScalerProfile" /> as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode"
        /// />.
        /// </returns>
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode serializationMode)
        {
            container = container ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonObject();

            bool returnNow = false;
            BeforeToJson(ref container, ref returnNow);
            if (returnNow)
            {
                return container;
            }
            AddIf( null != (((object)this._balanceSimilarNodeGroup)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._balanceSimilarNodeGroup.ToString()) : null, "balance-similar-node-groups" ,container.Add );
            AddIf( null != (((object)this._expander)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._expander.ToString()) : null, "expander" ,container.Add );
            AddIf( null != (((object)this._maxEmptyBulkDelete)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._maxEmptyBulkDelete.ToString()) : null, "max-empty-bulk-delete" ,container.Add );
            AddIf( null != (((object)this._maxGracefulTerminationSec)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._maxGracefulTerminationSec.ToString()) : null, "max-graceful-termination-sec" ,container.Add );
            AddIf( null != (((object)this._maxTotalUnreadyPercentage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._maxTotalUnreadyPercentage.ToString()) : null, "max-total-unready-percentage" ,container.Add );
            AddIf( null != (((object)this._newPodScaleUpDelay)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._newPodScaleUpDelay.ToString()) : null, "new-pod-scale-up-delay" ,container.Add );
            AddIf( null != (((object)this._okTotalUnreadyCount)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._okTotalUnreadyCount.ToString()) : null, "ok-total-unready-count" ,container.Add );
            AddIf( null != (((object)this._scanInterval)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._scanInterval.ToString()) : null, "scan-interval" ,container.Add );
            AddIf( null != (((object)this._scaleDownDelayAfterAdd)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._scaleDownDelayAfterAdd.ToString()) : null, "scale-down-delay-after-add" ,container.Add );
            AddIf( null != (((object)this._scaleDownDelayAfterDelete)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._scaleDownDelayAfterDelete.ToString()) : null, "scale-down-delay-after-delete" ,container.Add );
            AddIf( null != (((object)this._scaleDownDelayAfterFailure)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._scaleDownDelayAfterFailure.ToString()) : null, "scale-down-delay-after-failure" ,container.Add );
            AddIf( null != (((object)this._scaleDownUnneededTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._scaleDownUnneededTime.ToString()) : null, "scale-down-unneeded-time" ,container.Add );
            AddIf( null != (((object)this._scaleDownUnreadyTime)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._scaleDownUnreadyTime.ToString()) : null, "scale-down-unready-time" ,container.Add );
            AddIf( null != (((object)this._scaleDownUtilizationThreshold)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._scaleDownUtilizationThreshold.ToString()) : null, "scale-down-utilization-threshold" ,container.Add );
            AddIf( null != (((object)this._skipNodesWithLocalStorage)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._skipNodesWithLocalStorage.ToString()) : null, "skip-nodes-with-local-storage" ,container.Add );
            AddIf( null != (((object)this._skipNodesWithSystemPod)?.ToString()) ? (Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode) new Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonString(this._skipNodesWithSystemPod.ToString()) : null, "skip-nodes-with-system-pods" ,container.Add );
            AfterToJson(ref container);
            return container;
        }
    }
}