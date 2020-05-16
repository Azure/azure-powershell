namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Worker pool of an App Service Environment.</summary>
    public partial class WorkerPool :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPool,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal
    {

        /// <summary>Backing field for <see cref="ComputeMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? _computeMode;

        /// <summary>Shared or dedicated app hosting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get => this._computeMode; set => this._computeMode = value; }

        /// <summary>Backing field for <see cref="InstanceName" /> property.</summary>
        private string[] _instanceName;

        /// <summary>Names of all instances in the worker pool (read only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] InstanceName { get => this._instanceName; }

        /// <summary>Internal Acessors for InstanceName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWorkerPoolInternal.InstanceName { get => this._instanceName; set { {_instanceName = value;} } }

        /// <summary>Backing field for <see cref="WorkerCount" /> property.</summary>
        private int? _workerCount;

        /// <summary>Number of instances in the worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? WorkerCount { get => this._workerCount; set => this._workerCount = value; }

        /// <summary>Backing field for <see cref="WorkerSize" /> property.</summary>
        private string _workerSize;

        /// <summary>VM size of the worker pool instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string WorkerSize { get => this._workerSize; set => this._workerSize = value; }

        /// <summary>Backing field for <see cref="WorkerSizeId" /> property.</summary>
        private int? _workerSizeId;

        /// <summary>Worker size ID for referencing this worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? WorkerSizeId { get => this._workerSizeId; set => this._workerSizeId = value; }

        /// <summary>Creates an new <see cref="WorkerPool" /> instance.</summary>
        public WorkerPool()
        {

        }
    }
    /// Worker pool of an App Service Environment.
    public partial interface IWorkerPool :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Shared or dedicated app hosting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Shared or dedicated app hosting.",
        SerializedName = @"computeMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>Names of all instances in the worker pool (read only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Names of all instances in the worker pool (read only).",
        SerializedName = @"instanceNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] InstanceName { get;  }
        /// <summary>Number of instances in the worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of instances in the worker pool.",
        SerializedName = @"workerCount",
        PossibleTypes = new [] { typeof(int) })]
        int? WorkerCount { get; set; }
        /// <summary>VM size of the worker pool instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VM size of the worker pool instances.",
        SerializedName = @"workerSize",
        PossibleTypes = new [] { typeof(string) })]
        string WorkerSize { get; set; }
        /// <summary>Worker size ID for referencing this worker pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Worker size ID for referencing this worker pool.",
        SerializedName = @"workerSizeId",
        PossibleTypes = new [] { typeof(int) })]
        int? WorkerSizeId { get; set; }

    }
    /// Worker pool of an App Service Environment.
    internal partial interface IWorkerPoolInternal

    {
        /// <summary>Shared or dedicated app hosting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ComputeModeOptions? ComputeMode { get; set; }
        /// <summary>Names of all instances in the worker pool (read only).</summary>
        string[] InstanceName { get; set; }
        /// <summary>Number of instances in the worker pool.</summary>
        int? WorkerCount { get; set; }
        /// <summary>VM size of the worker pool instances.</summary>
        string WorkerSize { get; set; }
        /// <summary>Worker size ID for referencing this worker pool.</summary>
        int? WorkerSizeId { get; set; }

    }
}