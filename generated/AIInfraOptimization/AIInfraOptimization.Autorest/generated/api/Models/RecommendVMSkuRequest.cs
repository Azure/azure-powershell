// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;

    /// <summary>
    /// The parameters used to request an Azure virtual machine size recommendation for an AI workload.
    /// </summary>
    public partial class RecommendVMSkuRequest :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal
    {

        /// <summary>Backing field for <see cref="Deployment" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeployment _deployment;

        /// <summary>Deployment scale and Azure virtual machine procurement option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeployment Deployment { get => (this._deployment = this._deployment ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuDeployment()); set => this._deployment = value; }

        /// <summary>The Azure virtual machine procurement option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string DeploymentProcurementOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeploymentInternal)Deployment).ProcurementOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeploymentInternal)Deployment).ProcurementOption = value ?? null; }

        /// <summary>
        /// The number of deployment replicas used for cost, quota, and placement calculations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? DeploymentReplicaCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeploymentInternal)Deployment).ReplicaCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeploymentInternal)Deployment).ReplicaCount = value ?? default(int); }

        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public double? MaxDeploymentCostPerHourAmount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).MaxDeploymentCostPerHourAmount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).MaxDeploymentCostPerHourAmount = value ?? default(double); }

        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string MaxDeploymentCostPerHourCurrencyCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).MaxDeploymentCostPerHourCurrencyCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).MaxDeploymentCostPerHourCurrencyCode = value ?? null; }

        /// <summary>Internal Acessors for Deployment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeployment Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal.Deployment { get => (this._deployment = this._deployment ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuDeployment()); set { {_deployment = value;} } }

        /// <summary>Internal Acessors for Model</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal.Model { get => (this._model = this._model ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuModel()); set { {_model = value;} } }

        /// <summary>Internal Acessors for Optimization</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimization Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal.Optimization { get => (this._optimization = this._optimization ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOptimization()); set { {_optimization = value;} } }

        /// <summary>Internal Acessors for OptimizationMaxDeploymentCostPerHour</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal.OptimizationMaxDeploymentCostPerHour { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).MaxDeploymentCostPerHour; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).MaxDeploymentCostPerHour = value ?? null /* model class */; }

        /// <summary>Internal Acessors for SubscriptionOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptions Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal.SubscriptionOption { get => (this._subscriptionOption = this._subscriptionOption ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSubscriptionOptions()); set { {_subscriptionOption = value;} } }

        /// <summary>Internal Acessors for Workload</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkload Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal.Workload { get => (this._workload = this._workload ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuWorkload()); set { {_workload = value;} } }

        /// <summary>Internal Acessors for WorkloadTokenBudget</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequestInternal.WorkloadTokenBudget { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).TokenBudget; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).TokenBudget = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="Model" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel _model;

        /// <summary>Model identity, sizing inputs, and optional maximum model context length.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel Model { get => (this._model = this._model ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuModel()); set => this._model = value; }

        /// <summary>
        /// The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? ModelHeadDim { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).HeadDim; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).HeadDim = value ?? default(int); }

        /// <summary>
        /// The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ModelHuggingFaceModelId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).HuggingFaceModelId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).HuggingFaceModelId = value ?? null; }

        /// <summary>
        /// The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when
        /// Hugging Face metadata provides no usable maximum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? ModelMaxContextLength { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).MaxContextLength; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).MaxContextLength = value ?? default(int); }

        /// <summary>
        /// The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? ModelNumKeyValueHead { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).NumKeyValueHead; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).NumKeyValueHead = value ?? default(int); }

        /// <summary>
        /// The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with
        /// a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? ModelNumLayer { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).NumLayer; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).NumLayer = value ?? default(int); }

        /// <summary>
        /// The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model
        /// identifier.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public long? ModelParameterCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).ParameterCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).ParameterCount = value ?? default(long); }

        /// <summary>The precision the model weights are served at. Matched case-insensitively.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string ModelWeightPrecision { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).WeightPrecision; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModelInternal)Model).WeightPrecision = value ?? null; }

        /// <summary>Backing field for <see cref="Optimization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimization _optimization;

        /// <summary>Ranking preference and optional deployment-wide hourly cost limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimization Optimization { get => (this._optimization = this._optimization ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuOptimization()); set => this._optimization = value; }

        /// <summary>The preference used to rank the recommended options.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public string OptimizationRankingPreference { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).RankingPreference; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimizationInternal)Optimization).RankingPreference = value ?? null; }

        /// <summary>Backing field for <see cref="SubscriptionOption" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptions _subscriptionOption;

        /// <summary>The subscription-scoped lookups to include in the recommendation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptions SubscriptionOption { get => (this._subscriptionOption = this._subscriptionOption ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuSubscriptionOptions()); set => this._subscriptionOption = value; }

        /// <summary>
        /// Whether to query placement scores for candidate virtual machine sizes with available quota.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public bool? SubscriptionOptionIncludePlacement { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptionsInternal)SubscriptionOption).IncludePlacement; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptionsInternal)SubscriptionOption).IncludePlacement = value ?? default(bool); }

        /// <summary>Whether to fetch subscription-scoped virtual machine pricing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public bool? SubscriptionOptionIncludePricing { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptionsInternal)SubscriptionOption).IncludePricing; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptionsInternal)SubscriptionOption).IncludePricing = value ?? default(bool); }

        /// <summary>Whether to evaluate subscription quota for candidate virtual machine sizes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public bool? SubscriptionOptionIncludeQuota { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptionsInternal)SubscriptionOption).IncludeQuota; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptionsInternal)SubscriptionOption).IncludeQuota = value ?? default(bool); }

        /// <summary>Backing field for <see cref="TargetVMSize" /> property.</summary>
        private System.Collections.Generic.List<string> _targetVMSize;

        /// <summary>
        /// The Azure virtual machine candidate set. When supplied, only these virtual machine sizes are ranked. Entries must be non-blank
        /// and unique, compared case-insensitively.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> TargetVMSize { get => this._targetVMSize; set => this._targetVMSize = value; }

        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 2147483647 without exceeding the model's maximum context length.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? TokenBudgetMaxOutputToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).TokenBudgetMaxOutputToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).TokenBudgetMaxOutputToken = value ?? default(int); }

        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 2147483647 without exceeding the model's maximum context length.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? TokenBudgetPromptToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).TokenBudgetPromptToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).TokenBudgetPromptToken = value ?? default(int); }

        /// <summary>Backing field for <see cref="Workload" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkload _workload;

        /// <summary>Inference request concurrency and token shape assumptions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkload Workload { get => (this._workload = this._workload ?? new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuWorkload()); set => this._workload = value; }

        /// <summary>
        /// The maximum number of simultaneous inference requests handled by each deployment replica.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Origin(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PropertyOrigin.Inlined)]
        public int? WorkloadMaxConcurrentRequestsPerReplica { get => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).MaxConcurrentRequestsPerReplica; set => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkloadInternal)Workload).MaxConcurrentRequestsPerReplica = value ?? default(int); }

        /// <summary>Creates an new <see cref="RecommendVMSkuRequest" /> instance.</summary>
        public RecommendVMSkuRequest()
        {

        }
    }
    /// The parameters used to request an Azure virtual machine size recommendation for an AI workload.
    public partial interface IRecommendVMSkuRequest :
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IJsonSerializable
    {
        /// <summary>The Azure virtual machine procurement option.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Azure virtual machine procurement option.",
        SerializedName = @"procurementOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("OnDemand", "Spot")]
        string DeploymentProcurementOption { get; set; }
        /// <summary>
        /// The number of deployment replicas used for cost, quota, and placement calculations.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of deployment replicas used for cost, quota, and placement calculations.",
        SerializedName = @"replicaCount",
        PossibleTypes = new [] { typeof(int) })]
        int? DeploymentReplicaCount { get; set; }
        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.",
        SerializedName = @"amount",
        PossibleTypes = new [] { typeof(double) })]
        double? MaxDeploymentCostPerHourAmount { get; set; }
        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.",
        SerializedName = @"currencyCode",
        PossibleTypes = new [] { typeof(string) })]
        string MaxDeploymentCostPerHourCurrencyCode { get; set; }
        /// <summary>
        /// The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together with a parameter count.",
        SerializedName = @"headDim",
        PossibleTypes = new [] { typeof(int) })]
        int? ModelHeadDim { get; set; }
        /// <summary>
        /// The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.",
        SerializedName = @"huggingFaceModelId",
        PossibleTypes = new [] { typeof(string) })]
        string ModelHuggingFaceModelId { get; set; }
        /// <summary>
        /// The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when
        /// Hugging Face metadata provides no usable maximum.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when Hugging Face metadata provides no usable maximum.",
        SerializedName = @"maxContextLength",
        PossibleTypes = new [] { typeof(int) })]
        int? ModelMaxContextLength { get; set; }
        /// <summary>
        /// The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with a parameter count.",
        SerializedName = @"numKeyValueHeads",
        PossibleTypes = new [] { typeof(int) })]
        int? ModelNumKeyValueHead { get; set; }
        /// <summary>
        /// The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with
        /// a parameter count.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with a parameter count.",
        SerializedName = @"numLayers",
        PossibleTypes = new [] { typeof(int) })]
        int? ModelNumLayer { get; set; }
        /// <summary>
        /// The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model
        /// identifier.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model identifier.",
        SerializedName = @"parameterCount",
        PossibleTypes = new [] { typeof(long) })]
        long? ModelParameterCount { get; set; }
        /// <summary>The precision the model weights are served at. Matched case-insensitively.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The precision the model weights are served at. Matched case-insensitively.",
        SerializedName = @"weightPrecision",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string ModelWeightPrecision { get; set; }
        /// <summary>The preference used to rank the recommended options.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The preference used to rank the recommended options.",
        SerializedName = @"rankingPreference",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Cost", "Latency")]
        string OptimizationRankingPreference { get; set; }
        /// <summary>
        /// Whether to query placement scores for candidate virtual machine sizes with available quota.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether to query placement scores for candidate virtual machine sizes with available quota.",
        SerializedName = @"includePlacement",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SubscriptionOptionIncludePlacement { get; set; }
        /// <summary>Whether to fetch subscription-scoped virtual machine pricing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether to fetch subscription-scoped virtual machine pricing.",
        SerializedName = @"includePricing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SubscriptionOptionIncludePricing { get; set; }
        /// <summary>Whether to evaluate subscription quota for candidate virtual machine sizes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether to evaluate subscription quota for candidate virtual machine sizes.",
        SerializedName = @"includeQuota",
        PossibleTypes = new [] { typeof(bool) })]
        bool? SubscriptionOptionIncludeQuota { get; set; }
        /// <summary>
        /// The Azure virtual machine candidate set. When supplied, only these virtual machine sizes are ranked. Entries must be non-blank
        /// and unique, compared case-insensitively.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The Azure virtual machine candidate set. When supplied, only these virtual machine sizes are ranked. Entries must be non-blank and unique, compared case-insensitively.",
        SerializedName = @"targetVmSizes",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> TargetVMSize { get; set; }
        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 2147483647 without exceeding the model's maximum context length.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and the two must total from 1 through 2147483647 without exceeding the model's maximum context length.",
        SerializedName = @"maxOutputTokens",
        PossibleTypes = new [] { typeof(int) })]
        int? TokenBudgetMaxOutputToken { get; set; }
        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 2147483647 without exceeding the model's maximum context length.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the two must total from 1 through 2147483647 without exceeding the model's maximum context length.",
        SerializedName = @"promptTokens",
        PossibleTypes = new [] { typeof(int) })]
        int? TokenBudgetPromptToken { get; set; }
        /// <summary>
        /// The maximum number of simultaneous inference requests handled by each deployment replica.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The maximum number of simultaneous inference requests handled by each deployment replica.",
        SerializedName = @"maxConcurrentRequestsPerReplica",
        PossibleTypes = new [] { typeof(int) })]
        int? WorkloadMaxConcurrentRequestsPerReplica { get; set; }

    }
    /// The parameters used to request an Azure virtual machine size recommendation for an AI workload.
    internal partial interface IRecommendVMSkuRequestInternal

    {
        /// <summary>Deployment scale and Azure virtual machine procurement option.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuDeployment Deployment { get; set; }
        /// <summary>The Azure virtual machine procurement option.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("OnDemand", "Spot")]
        string DeploymentProcurementOption { get; set; }
        /// <summary>
        /// The number of deployment replicas used for cost, quota, and placement calculations.
        /// </summary>
        int? DeploymentReplicaCount { get; set; }
        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        double? MaxDeploymentCostPerHourAmount { get; set; }
        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        string MaxDeploymentCostPerHourCurrencyCode { get; set; }
        /// <summary>Model identity, sizing inputs, and optional maximum model context length.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuModel Model { get; set; }
        /// <summary>
        /// The attention head dimension, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        int? ModelHeadDim { get; set; }
        /// <summary>
        /// The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.
        /// </summary>
        string ModelHuggingFaceModelId { get; set; }
        /// <summary>
        /// The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when
        /// Hugging Face metadata provides no usable maximum.
        /// </summary>
        int? ModelMaxContextLength { get; set; }
        /// <summary>
        /// The model key-value head count, used for architecture-aware key-value cache sizing. Supply all architecture fields together
        /// with a parameter count.
        /// </summary>
        int? ModelNumKeyValueHead { get; set; }
        /// <summary>
        /// The model layer count, used for architecture-aware key-value cache sizing. Supply all architecture fields together with
        /// a parameter count.
        /// </summary>
        int? ModelNumLayer { get; set; }
        /// <summary>
        /// The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model
        /// identifier.
        /// </summary>
        long? ModelParameterCount { get; set; }
        /// <summary>The precision the model weights are served at. Matched case-insensitively.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        string ModelWeightPrecision { get; set; }
        /// <summary>Ranking preference and optional deployment-wide hourly cost limit.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuOptimization Optimization { get; set; }
        /// <summary>The deployment-wide hourly cost ceiling.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuHourlyCost OptimizationMaxDeploymentCostPerHour { get; set; }
        /// <summary>The preference used to rank the recommended options.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Cost", "Latency")]
        string OptimizationRankingPreference { get; set; }
        /// <summary>The subscription-scoped lookups to include in the recommendation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuSubscriptionOptions SubscriptionOption { get; set; }
        /// <summary>
        /// Whether to query placement scores for candidate virtual machine sizes with available quota.
        /// </summary>
        bool? SubscriptionOptionIncludePlacement { get; set; }
        /// <summary>Whether to fetch subscription-scoped virtual machine pricing.</summary>
        bool? SubscriptionOptionIncludePricing { get; set; }
        /// <summary>Whether to evaluate subscription quota for candidate virtual machine sizes.</summary>
        bool? SubscriptionOptionIncludeQuota { get; set; }
        /// <summary>
        /// The Azure virtual machine candidate set. When supplied, only these virtual machine sizes are ranked. Entries must be non-blank
        /// and unique, compared case-insensitively.
        /// </summary>
        System.Collections.Generic.List<string> TargetVMSize { get; set; }
        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with `promptTokens`, and
        /// the two must total from 1 through 2147483647 without exceeding the model's maximum context length.
        /// </summary>
        int? TokenBudgetMaxOutputToken { get; set; }
        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with `maxOutputTokens`, and the
        /// two must total from 1 through 2147483647 without exceeding the model's maximum context length.
        /// </summary>
        int? TokenBudgetPromptToken { get; set; }
        /// <summary>Inference request concurrency and token shape assumptions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuWorkload Workload { get; set; }
        /// <summary>
        /// The maximum number of simultaneous inference requests handled by each deployment replica.
        /// </summary>
        int? WorkloadMaxConcurrentRequestsPerReplica { get; set; }
        /// <summary>The prompt and output token budget used for key-value cache sizing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuTokenBudget WorkloadTokenBudget { get; set; }

    }
}