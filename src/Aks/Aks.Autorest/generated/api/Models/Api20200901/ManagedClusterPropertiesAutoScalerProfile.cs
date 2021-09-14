namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Parameters to be applied to the cluster-autoscaler when enabled</summary>
    public partial class ManagedClusterPropertiesAutoScalerProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterPropertiesAutoScalerProfileInternal
    {

        /// <summary>Backing field for <see cref="BalanceSimilarNodeGroup" /> property.</summary>
        private string _balanceSimilarNodeGroup;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string BalanceSimilarNodeGroup { get => this._balanceSimilarNodeGroup; set => this._balanceSimilarNodeGroup = value; }

        /// <summary>Backing field for <see cref="Expander" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? _expander;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? Expander { get => this._expander; set => this._expander = value; }

        /// <summary>Backing field for <see cref="MaxEmptyBulkDelete" /> property.</summary>
        private string _maxEmptyBulkDelete;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string MaxEmptyBulkDelete { get => this._maxEmptyBulkDelete; set => this._maxEmptyBulkDelete = value; }

        /// <summary>Backing field for <see cref="MaxGracefulTerminationSec" /> property.</summary>
        private string _maxGracefulTerminationSec;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string MaxGracefulTerminationSec { get => this._maxGracefulTerminationSec; set => this._maxGracefulTerminationSec = value; }

        /// <summary>Backing field for <see cref="MaxTotalUnreadyPercentage" /> property.</summary>
        private string _maxTotalUnreadyPercentage;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string MaxTotalUnreadyPercentage { get => this._maxTotalUnreadyPercentage; set => this._maxTotalUnreadyPercentage = value; }

        /// <summary>Backing field for <see cref="NewPodScaleUpDelay" /> property.</summary>
        private string _newPodScaleUpDelay;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string NewPodScaleUpDelay { get => this._newPodScaleUpDelay; set => this._newPodScaleUpDelay = value; }

        /// <summary>Backing field for <see cref="OkTotalUnreadyCount" /> property.</summary>
        private string _okTotalUnreadyCount;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string OkTotalUnreadyCount { get => this._okTotalUnreadyCount; set => this._okTotalUnreadyCount = value; }

        /// <summary>Backing field for <see cref="ScaleDownDelayAfterAdd" /> property.</summary>
        private string _scaleDownDelayAfterAdd;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ScaleDownDelayAfterAdd { get => this._scaleDownDelayAfterAdd; set => this._scaleDownDelayAfterAdd = value; }

        /// <summary>Backing field for <see cref="ScaleDownDelayAfterDelete" /> property.</summary>
        private string _scaleDownDelayAfterDelete;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ScaleDownDelayAfterDelete { get => this._scaleDownDelayAfterDelete; set => this._scaleDownDelayAfterDelete = value; }

        /// <summary>Backing field for <see cref="ScaleDownDelayAfterFailure" /> property.</summary>
        private string _scaleDownDelayAfterFailure;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ScaleDownDelayAfterFailure { get => this._scaleDownDelayAfterFailure; set => this._scaleDownDelayAfterFailure = value; }

        /// <summary>Backing field for <see cref="ScaleDownUnneededTime" /> property.</summary>
        private string _scaleDownUnneededTime;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ScaleDownUnneededTime { get => this._scaleDownUnneededTime; set => this._scaleDownUnneededTime = value; }

        /// <summary>Backing field for <see cref="ScaleDownUnreadyTime" /> property.</summary>
        private string _scaleDownUnreadyTime;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ScaleDownUnreadyTime { get => this._scaleDownUnreadyTime; set => this._scaleDownUnreadyTime = value; }

        /// <summary>Backing field for <see cref="ScaleDownUtilizationThreshold" /> property.</summary>
        private string _scaleDownUtilizationThreshold;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ScaleDownUtilizationThreshold { get => this._scaleDownUtilizationThreshold; set => this._scaleDownUtilizationThreshold = value; }

        /// <summary>Backing field for <see cref="ScanInterval" /> property.</summary>
        private string _scanInterval;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string ScanInterval { get => this._scanInterval; set => this._scanInterval = value; }

        /// <summary>Backing field for <see cref="SkipNodesWithLocalStorage" /> property.</summary>
        private string _skipNodesWithLocalStorage;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string SkipNodesWithLocalStorage { get => this._skipNodesWithLocalStorage; set => this._skipNodesWithLocalStorage = value; }

        /// <summary>Backing field for <see cref="SkipNodesWithSystemPod" /> property.</summary>
        private string _skipNodesWithSystemPod;

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string SkipNodesWithSystemPod { get => this._skipNodesWithSystemPod; set => this._skipNodesWithSystemPod = value; }

        /// <summary>
        /// Creates an new <see cref="ManagedClusterPropertiesAutoScalerProfile" /> instance.
        /// </summary>
        public ManagedClusterPropertiesAutoScalerProfile()
        {

        }
    }
    /// Parameters to be applied to the cluster-autoscaler when enabled
    public partial interface IManagedClusterPropertiesAutoScalerProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"balance-similar-node-groups",
        PossibleTypes = new [] { typeof(string) })]
        string BalanceSimilarNodeGroup { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"expander",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? Expander { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"max-empty-bulk-delete",
        PossibleTypes = new [] { typeof(string) })]
        string MaxEmptyBulkDelete { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"max-graceful-termination-sec",
        PossibleTypes = new [] { typeof(string) })]
        string MaxGracefulTerminationSec { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"max-total-unready-percentage",
        PossibleTypes = new [] { typeof(string) })]
        string MaxTotalUnreadyPercentage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"new-pod-scale-up-delay",
        PossibleTypes = new [] { typeof(string) })]
        string NewPodScaleUpDelay { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ok-total-unready-count",
        PossibleTypes = new [] { typeof(string) })]
        string OkTotalUnreadyCount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-delay-after-add",
        PossibleTypes = new [] { typeof(string) })]
        string ScaleDownDelayAfterAdd { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-delay-after-delete",
        PossibleTypes = new [] { typeof(string) })]
        string ScaleDownDelayAfterDelete { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-delay-after-failure",
        PossibleTypes = new [] { typeof(string) })]
        string ScaleDownDelayAfterFailure { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-unneeded-time",
        PossibleTypes = new [] { typeof(string) })]
        string ScaleDownUnneededTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-unready-time",
        PossibleTypes = new [] { typeof(string) })]
        string ScaleDownUnreadyTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scale-down-utilization-threshold",
        PossibleTypes = new [] { typeof(string) })]
        string ScaleDownUtilizationThreshold { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"scan-interval",
        PossibleTypes = new [] { typeof(string) })]
        string ScanInterval { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skip-nodes-with-local-storage",
        PossibleTypes = new [] { typeof(string) })]
        string SkipNodesWithLocalStorage { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skip-nodes-with-system-pods",
        PossibleTypes = new [] { typeof(string) })]
        string SkipNodesWithSystemPod { get; set; }

    }
    /// Parameters to be applied to the cluster-autoscaler when enabled
    internal partial interface IManagedClusterPropertiesAutoScalerProfileInternal

    {
        string BalanceSimilarNodeGroup { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Aks.Support.Expander? Expander { get; set; }

        string MaxEmptyBulkDelete { get; set; }

        string MaxGracefulTerminationSec { get; set; }

        string MaxTotalUnreadyPercentage { get; set; }

        string NewPodScaleUpDelay { get; set; }

        string OkTotalUnreadyCount { get; set; }

        string ScaleDownDelayAfterAdd { get; set; }

        string ScaleDownDelayAfterDelete { get; set; }

        string ScaleDownDelayAfterFailure { get; set; }

        string ScaleDownUnneededTime { get; set; }

        string ScaleDownUnreadyTime { get; set; }

        string ScaleDownUtilizationThreshold { get; set; }

        string ScanInterval { get; set; }

        string SkipNodesWithLocalStorage { get; set; }

        string SkipNodesWithSystemPod { get; set; }

    }
}