// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Cmdlets;
    using System;

    /// <summary>
    /// Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.
    /// </summary>
    /// <remarks>
    /// [OpenAPI] RecommendVmSku=>POST:"/subscriptions/{subscriptionId}/providers/Microsoft.AIInfraOptimization/locations/{location}/recommendVmSku"
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.Get, @"AzAIInfraOptimizationVMSkuRecommendation_RecommendExpanded")]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Description(@"Recommends Azure virtual machine sizes for an AI workload in the specified subscription and azure location.")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.HttpPath(Path = "/subscriptions/{subscriptionId}/providers/Microsoft.AIInfraOptimization/locations/{location}/recommendVmSku", ApiVersion = "2026-06-01-preview")]
    public partial class GetAzAIInfraOptimizationVMSkuRecommendation_RecommendExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener,
        Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IContext
    {
        /// <summary>A unique id generatd for the this cmdlet when it is instantiated.</summary>
        private string __correlationId = System.Guid.NewGuid().ToString();

        /// <summary>A copy of the Invocation Info (necessary to allow asJob to clone this cmdlet)</summary>
        private global::System.Management.Automation.InvocationInfo __invocationInfo;

        /// <summary>A unique id generatd for the this cmdlet when ProcessRecord() is called.</summary>
        private string __processRecordId;

        /// <summary>
        /// The parameters used to request an Azure virtual machine size recommendation for an AI workload.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuRequest _body = new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.RecommendVMSkuRequest();

        /// <summary>
        /// The <see cref="global::System.Threading.CancellationTokenSource" /> for this operation.
        /// </summary>
        private global::System.Threading.CancellationTokenSource _cancellationTokenSource = new global::System.Threading.CancellationTokenSource();

        /// <summary>A dictionary to carry over additional data for pipeline.</summary>
        private global::System.Collections.Generic.Dictionary<global::System.String,global::System.Object> _extensibleParameters = new System.Collections.Generic.Dictionary<string, object>();

        /// <summary>A buffer to record first returned object in response.</summary>
        private object _firstResponse = null;

        /// <summary>
        /// A flag to tell whether it is the first returned object in a call. Zero means no response yet. One means 1 returned object.
        /// Two means multiple returned objects in response.
        /// </summary>
        private int _responseSize = 0;

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Accessor for cancellationTokenSource.</summary>
        public global::System.Threading.CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource ; set { _cancellationTokenSource = value; } }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.AiInfraOptimization Client => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Module.Instance.ClientAPI;

        /// <summary>
        /// The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet
        /// against a different subscription
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>Accessor for extensibleParameters.</summary>
        public global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> ExtensibleParameters { get => _extensibleParameters ; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>
        /// The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Hugging Face model identifier, for example `meta-llama/Llama-3.1-70B-Instruct`.",
        SerializedName = @"huggingFaceModelId",
        PossibleTypes = new [] { typeof(string) })]
        public string HuggingFaceModelId { get => _body.ModelHuggingFaceModelId ?? null; set => _body.ModelHuggingFaceModelId = value; }

        /// <summary>
        /// Whether to query placement scores for candidate virtual machine sizes with available quota.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether to query placement scores for candidate virtual machine sizes with available quota.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to query placement scores for candidate virtual machine sizes with available quota.",
        SerializedName = @"includePlacement",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter IncludePlacement { get => _body.SubscriptionOptionIncludePlacement ?? default(global::System.Management.Automation.SwitchParameter); set => _body.SubscriptionOptionIncludePlacement = value; }

        /// <summary>Whether to fetch subscription-scoped virtual machine pricing.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether to fetch subscription-scoped virtual machine pricing.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to fetch subscription-scoped virtual machine pricing.",
        SerializedName = @"includePricing",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter IncludePricing { get => _body.SubscriptionOptionIncludePricing ?? default(global::System.Management.Automation.SwitchParameter); set => _body.SubscriptionOptionIncludePricing = value; }

        /// <summary>Whether to evaluate subscription quota for candidate virtual machine sizes.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Whether to evaluate subscription quota for candidate virtual machine sizes.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Whether to evaluate subscription quota for candidate virtual machine sizes.",
        SerializedName = @"includeQuota",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter IncludeQuota { get => _body.SubscriptionOptionIncludeQuota ?? default(global::System.Management.Automation.SwitchParameter); set => _body.SubscriptionOptionIncludeQuota = value; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The name of the Azure region.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the Azure region.")]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the Azure region.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Path)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>
        /// The maximum number of simultaneous inference requests handled by each deployment replica.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The maximum number of simultaneous inference requests handled by each deployment replica.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum number of simultaneous inference requests handled by each deployment replica.",
        SerializedName = @"maxConcurrentRequestsPerReplica",
        PossibleTypes = new [] { typeof(int) })]
        public int MaxConcurrentRequestsPerReplica { get => _body.WorkloadMaxConcurrentRequestsPerReplica ?? default(int); set => _body.WorkloadMaxConcurrentRequestsPerReplica = value; }

        /// <summary>
        /// The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum cost per hour for the whole deployment. Must be greater than zero when supplied.",
        SerializedName = @"amount",
        PossibleTypes = new [] { typeof(double) })]
        public double MaxDeploymentCostPerHourAmount { get => _body.MaxDeploymentCostPerHourAmount ?? default(double); set => _body.MaxDeploymentCostPerHourAmount = value; }

        /// <summary>
        /// The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ISO 4217 currency code the amount is expressed in. The recommendation service currently supports `USD`.",
        SerializedName = @"currencyCode",
        PossibleTypes = new [] { typeof(string) })]
        public string MaxDeploymentCostPerHourCurrencyCode { get => _body.MaxDeploymentCostPerHourCurrencyCode ?? null; set => _body.MaxDeploymentCostPerHourCurrencyCode = value; }

        /// <summary>
        /// The maximum number of generated output tokens per inference request. Must be supplied together with PromptTokenCount,
        /// and the two must total from 1 through 131072.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The maximum number of generated output tokens per inference request. Must be supplied together with PromptTokenCount, and the two must total from 1 through 131072.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum number of generated output tokens per inference request. Must be supplied together with PromptTokenCount, and the two must total from 1 through 131072.",
        SerializedName = @"maxOutputTokens",
        PossibleTypes = new [] { typeof(int) })]
        public int MaxOutputTokenCount { get => _body.TokenBudgetMaxOutputToken ?? default(int); set => _body.TokenBudgetMaxOutputToken = value; }

        /// <summary>
        /// <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>
        /// The attention head dimension, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount
        /// and ModelHeadDimension together with ModelParameterCount.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The attention head dimension, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The attention head dimension, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.",
        SerializedName = @"headDim",
        PossibleTypes = new [] { typeof(int) })]
        public int ModelHeadDimension { get => _body.ModelHeadDim ?? default(int); set => _body.ModelHeadDim = value; }

        /// <summary>
        /// The model key-value head count, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount
        /// and ModelHeadDimension together with ModelParameterCount.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The model key-value head count, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The model key-value head count, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.",
        SerializedName = @"numKeyValueHeads",
        PossibleTypes = new [] { typeof(int) })]
        public int ModelKeyValueHeadCount { get => _body.ModelNumKeyValueHead ?? default(int); set => _body.ModelNumKeyValueHead = value; }

        /// <summary>
        /// The model layer count, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount
        /// and ModelHeadDimension together with ModelParameterCount.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The model layer count, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The model layer count, used for architecture-aware key-value cache sizing. Supply ModelLayerCount, ModelKeyValueHeadCount and ModelHeadDimension together with ModelParameterCount.",
        SerializedName = @"numLayers",
        PossibleTypes = new [] { typeof(int) })]
        public int ModelLayerCount { get => _body.ModelNumLayer ?? default(int); set => _body.ModelNumLayer = value; }

        /// <summary>
        /// The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when
        /// Hugging Face metadata provides no usable maximum.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when Hugging Face metadata provides no usable maximum.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum context length the model supports, in tokens. Used only as an upper bound for the sizing context length when Hugging Face metadata provides no usable maximum.",
        SerializedName = @"maxContextLength",
        PossibleTypes = new [] { typeof(int) })]
        public int ModelMaxContextLength { get => _body.ModelMaxContextLength ?? default(int); set => _body.ModelMaxContextLength = value; }

        /// <summary>
        /// The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model
        /// identifier.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model identifier.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The logical total model parameter count, including all mixture-of-experts experts. May be supplied with or without a model identifier.",
        SerializedName = @"parameterCount",
        PossibleTypes = new [] { typeof(long) })]
        public long ModelParameterCount { get => _body.ModelParameterCount ?? default(long); set => _body.ModelParameterCount = value; }

        /// <summary>The precision the model weights are served at. Matched case-insensitively.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The precision the model weights are served at. Matched case-insensitively.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The precision the model weights are served at. Matched case-insensitively.",
        SerializedName = @"weightPrecision",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("FP32", "FP16", "BF16", "FP8", "INT8", "INT4", "FP4")]
        public string ModelWeightPrecision { get => _body.ModelWeightPrecision ?? null; set => _body.ModelWeightPrecision = value; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>The Azure virtual machine procurement option.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The Azure virtual machine procurement option.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure virtual machine procurement option.",
        SerializedName = @"procurementOption",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("OnDemand", "Spot")]
        public string ProcurementOption { get => _body.DeploymentProcurementOption ?? null; set => _body.DeploymentProcurementOption = value; }

        /// <summary>
        /// The number of prompt, or input, tokens per inference request. Must be supplied together with MaxOutputTokenCount, and
        /// the two must total from 1 through 131072.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The number of prompt, or input, tokens per inference request. Must be supplied together with MaxOutputTokenCount, and the two must total from 1 through 131072.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of prompt, or input, tokens per inference request. Must be supplied together with MaxOutputTokenCount, and the two must total from 1 through 131072.",
        SerializedName = @"promptTokens",
        PossibleTypes = new [] { typeof(int) })]
        public int PromptTokenCount { get => _body.TokenBudgetPromptToken ?? default(int); set => _body.TokenBudgetPromptToken = value; }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>The preference used to rank the recommended options.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The preference used to rank the recommended options.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The preference used to rank the recommended options.",
        SerializedName = @"rankingPreference",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.PSArgumentCompleterAttribute("Cost", "Latency")]
        public string RankingPreference { get => _body.OptimizationRankingPreference ?? null; set => _body.OptimizationRankingPreference = value; }

        /// <summary>
        /// The number of deployment replicas used for cost, quota, and placement calculations.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The number of deployment replicas used for cost, quota, and placement calculations.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of deployment replicas used for cost, quota, and placement calculations.",
        SerializedName = @"replicaCount",
        PossibleTypes = new [] { typeof(int) })]
        public int ReplicaCount { get => _body.DeploymentReplicaCount ?? default(int); set => _body.DeploymentReplicaCount = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string[] _subscriptionId;

        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The ID of the target subscription. The value must be an UUID.")]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the target subscription. The value must be an UUID.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.DefaultInfo(
        Name = @"",
        Description =@"",
        Script = @"(Get-AzContext).Subscription.Id",
        SetCondition = @"")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Path)]
        public string[] SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>
        /// The Azure virtual machine candidate set. When supplied, only these virtual machine sizes are ranked. Entries must be non-blank
        /// and unique, compared case-insensitively.
        /// </summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The Azure virtual machine candidate set. When supplied, only these virtual machine sizes are ranked. Entries must be non-blank and unique, compared case-insensitively.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Category(global::Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure virtual machine candidate set. When supplied, only these virtual machine sizes are ranked. Entries must be non-blank and unique, compared case-insensitively.",
        SerializedName = @"targetVmSizes",
        PossibleTypes = new [] { typeof(string) })]
        public string[] TargetVMSize { get => _body.TargetVMSize?.ToArray() ?? null /* fixedArrayOf */; set => _body.TargetVMSize = (value != null ? new System.Collections.Generic.List<string>(value) : null); }

        /// <summary>
        /// <c>overrideOnDefault</c> will be called before the regular onDefault has been processed, allowing customization of what
        /// happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onDefault method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>

        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse">Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            var telemetryId = Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Module.Instance.GetTelemetryId.Invoke();
            if (telemetryId != "" && telemetryId != "internal")
            {
                __correlationId = telemetryId;
            }
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            if (1 ==_responseSize)
            {
                // Flush buffer
                WriteObject(_firstResponse);
            }
            var telemetryInfo = Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Module.Instance.GetTelemetryInfo?.Invoke(__correlationId);
            if (telemetryInfo != null)
            {
                telemetryInfo.TryGetValue("ShowSecretsWarning", out var showSecretsWarning);
                telemetryInfo.TryGetValue("SanitizedProperties", out var sanitizedProperties);
                telemetryInfo.TryGetValue("InvocationName", out var invocationName);
                if (showSecretsWarning == "true")
                {
                    if (string.IsNullOrEmpty(sanitizedProperties))
                    {
                        WriteWarning($"The output of cmdlet {invocationName} may compromise security by showing secrets. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844");
                    }
                    else
                    {
                        WriteWarning($"The output of cmdlet {invocationName} may compromise security by showing the following secrets: {sanitizedProperties}. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844");
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzAIInfraOptimizationVMSkuRecommendation_RecommendExpanded" /> cmdlet
        /// class.
        /// </summary>
        public GetAzAIInfraOptimizationVMSkuRecommendation_RecommendExpanded()
        {

        }

        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Information:
                    {
                        var data = messageData();
                        WriteInformation(data.Message, new string[]{});
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.Progress:
                    {
                        var data = messageData();
                        int progress = (int)data.Value;
                        string activityMessage, statusDescription;
                        global::System.Management.Automation.ProgressRecordType recordType;
                        if (progress < 100)
                        {
                            activityMessage = "In progress";
                            statusDescription = "Checking operation status";
                            recordType = System.Management.Automation.ProgressRecordType.Processing;
                        }
                        else
                        {
                            activityMessage = "Completed";
                            statusDescription = "Completed";
                            recordType = System.Management.Automation.ProgressRecordType.Completed;
                        }
                        WriteProgress(new global::System.Management.Automation.ProgressRecord(1, activityMessage, statusDescription)
                        {
                            PercentComplete = progress,
                        RecordType = recordType
                        });
                        return ;
                    }
                }
                await Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Module.Instance.Signal(id, token, messageData, (i, t, m) => ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(i, t, () => Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.EventDataConverter.ConvertFrom(m()) as Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.EventData), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token) )
                {
                    asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token);
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletProcessRecordEnd).Wait();
            }
        }

        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async global::System.Threading.Tasks.Task ProcessRecordAsync()
        {
            using( NoSynchronizationContext )
            {
                await ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName, this.ExtensibleParameters);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    foreach( var SubscriptionId in this.SubscriptionId )
                    {
                        await ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                        await this.Client.RecommendationsRecommendVMSku(SubscriptionId, Location, _body, onOk, onDefault, this, Pipeline);
                        await ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new { SubscriptionId=SubscriptionId,Location=Location})
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <param name="sendToPipeline"></param>
        new protected void WriteObject(object sendToPipeline)
        {
            Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline);
        }

        /// <param name="sendToPipeline"></param>
        /// <param name="enumerateCollection"></param>
        new protected void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnDefault(responseMessage, response, ref _returnNow);
                // if overrideOnDefault has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // Error Response : default
                var code = (await response)?.Code;
                var message = (await response)?.Message;
                if ((null == code || null == message))
                {
                    // Unrecognized Response. Create an error record based on what we have.
                    var ex = new Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IErrorResponse>(responseMessage, await response);
                    WriteError( new global::System.Management.Automation.ErrorRecord(ex, ex.Code, global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(ex.Message) { RecommendedAction = ex.Action }
                    });
                }
                else
                {
                    WriteError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception($"[{code}] : {message}"), code?.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(message) { RecommendedAction = global::System.String.Empty }
                    });
                }
            }
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse">Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnOk(responseMessage, response, ref _returnNow);
                // if overrideOnOk has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // onOk - response for 200 / application/json
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.AIInfraOptimization.Models.IRecommendVMSkuResponse
                var result = (await response);
                if (null != result)
                {
                    if (0 == _responseSize)
                    {
                        _firstResponse = result;
                        _responseSize = 1;
                    }
                    else
                    {
                        if (1 ==_responseSize)
                        {
                            // Flush buffer
                            WriteObject(_firstResponse.AddMultipleTypeNameIntoPSObject());
                        }
                        WriteObject(result.AddMultipleTypeNameIntoPSObject());
                        _responseSize = 2;
                    }
                }
            }
        }
    }
}