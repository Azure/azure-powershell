namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.PowerShell;

    /// <summary>Parameters to be applied to the cluster-autoscaler when enabled</summary>
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterPropertiesAutoScalerProfileTypeConverter))]
    public partial class ManagedClusterPropertiesAutoScalerProfile
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPropertiesAutoScalerProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ManagedClusterPropertiesAutoScalerProfile(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPropertiesAutoScalerProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ManagedClusterPropertiesAutoScalerProfile(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ManagedClusterPropertiesAutoScalerProfile" />, deserializing the content from a json
        /// string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPropertiesAutoScalerProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ManagedClusterPropertiesAutoScalerProfile(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).BalanceSimilarNodeGroup = (string) content.GetValueForProperty("BalanceSimilarNodeGroup",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).BalanceSimilarNodeGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).Expander = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander?) content.GetValueForProperty("Expander",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).Expander, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxEmptyBulkDelete = (string) content.GetValueForProperty("MaxEmptyBulkDelete",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxEmptyBulkDelete, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxGracefulTerminationSec = (string) content.GetValueForProperty("MaxGracefulTerminationSec",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxGracefulTerminationSec, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxTotalUnreadyPercentage = (string) content.GetValueForProperty("MaxTotalUnreadyPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxTotalUnreadyPercentage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).NewPodScaleUpDelay = (string) content.GetValueForProperty("NewPodScaleUpDelay",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).NewPodScaleUpDelay, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).OkTotalUnreadyCount = (string) content.GetValueForProperty("OkTotalUnreadyCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).OkTotalUnreadyCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScanInterval = (string) content.GetValueForProperty("ScanInterval",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScanInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterAdd = (string) content.GetValueForProperty("ScaleDownDelayAfterAdd",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterAdd, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterDelete = (string) content.GetValueForProperty("ScaleDownDelayAfterDelete",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterDelete, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterFailure = (string) content.GetValueForProperty("ScaleDownDelayAfterFailure",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterFailure, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnneededTime = (string) content.GetValueForProperty("ScaleDownUnneededTime",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnneededTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnreadyTime = (string) content.GetValueForProperty("ScaleDownUnreadyTime",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnreadyTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUtilizationThreshold = (string) content.GetValueForProperty("ScaleDownUtilizationThreshold",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUtilizationThreshold, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithLocalStorage = (string) content.GetValueForProperty("SkipNodesWithLocalStorage",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithLocalStorage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithSystemPod = (string) content.GetValueForProperty("SkipNodesWithSystemPod",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithSystemPod, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ManagedClusterPropertiesAutoScalerProfile"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ManagedClusterPropertiesAutoScalerProfile(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).BalanceSimilarNodeGroup = (string) content.GetValueForProperty("BalanceSimilarNodeGroup",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).BalanceSimilarNodeGroup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).Expander = (Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander?) content.GetValueForProperty("Expander",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).Expander, Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxEmptyBulkDelete = (string) content.GetValueForProperty("MaxEmptyBulkDelete",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxEmptyBulkDelete, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxGracefulTerminationSec = (string) content.GetValueForProperty("MaxGracefulTerminationSec",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxGracefulTerminationSec, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxTotalUnreadyPercentage = (string) content.GetValueForProperty("MaxTotalUnreadyPercentage",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).MaxTotalUnreadyPercentage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).NewPodScaleUpDelay = (string) content.GetValueForProperty("NewPodScaleUpDelay",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).NewPodScaleUpDelay, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).OkTotalUnreadyCount = (string) content.GetValueForProperty("OkTotalUnreadyCount",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).OkTotalUnreadyCount, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScanInterval = (string) content.GetValueForProperty("ScanInterval",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScanInterval, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterAdd = (string) content.GetValueForProperty("ScaleDownDelayAfterAdd",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterAdd, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterDelete = (string) content.GetValueForProperty("ScaleDownDelayAfterDelete",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterDelete, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterFailure = (string) content.GetValueForProperty("ScaleDownDelayAfterFailure",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownDelayAfterFailure, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnneededTime = (string) content.GetValueForProperty("ScaleDownUnneededTime",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnneededTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnreadyTime = (string) content.GetValueForProperty("ScaleDownUnreadyTime",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUnreadyTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUtilizationThreshold = (string) content.GetValueForProperty("ScaleDownUtilizationThreshold",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).ScaleDownUtilizationThreshold, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithLocalStorage = (string) content.GetValueForProperty("SkipNodesWithLocalStorage",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithLocalStorage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithSystemPod = (string) content.GetValueForProperty("SkipNodesWithSystemPod",((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal)this).SkipNodesWithSystemPod, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Parameters to be applied to the cluster-autoscaler when enabled
    [System.ComponentModel.TypeConverter(typeof(ManagedClusterPropertiesAutoScalerProfileTypeConverter))]
    public partial interface IManagedClusterPropertiesAutoScalerProfile

    {

    }
}