namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding properties associated with an Azure Machine learning web service.</summary>
    public partial class AzureMachineLearningServiceFunctionBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApiKey" /> property.</summary>
        private string _apiKey;

        /// <summary>The API key used to authenticate with Request-Response endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ApiKey { get => this._apiKey; set => this._apiKey = value; }

        /// <summary>Backing field for <see cref="BatchSize" /> property.</summary>
        private int? _batchSize;

        /// <summary>
        /// Number between 1 and 10000 describing maximum number of rows for every Azure ML RRS execute request. Default is 1000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? BatchSize { get => this._batchSize; set => this._batchSize = value; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private string _endpoint;

        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="Input" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] _input;

        /// <summary>The inputs for the Azure Machine Learning web service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] Input { get => this._input; set => this._input = value; }

        /// <summary>Backing field for <see cref="NumberOfParallelRequest" /> property.</summary>
        private int? _numberOfParallelRequest;

        /// <summary>
        /// The number of parallel requests that will be sent per partition of your job to the machine learning service. Default is
        /// 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? NumberOfParallelRequest { get => this._numberOfParallelRequest; set => this._numberOfParallelRequest = value; }

        /// <summary>Backing field for <see cref="Output" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceOutputColumn[] _output;

        /// <summary>
        /// A list of outputs from the Azure Machine Learning web service endpoint execution.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceOutputColumn[] Output { get => this._output; set => this._output = value; }

        /// <summary>
        /// Creates an new <see cref="AzureMachineLearningServiceFunctionBindingProperties" /> instance.
        /// </summary>
        public AzureMachineLearningServiceFunctionBindingProperties()
        {

        }
    }
    /// The binding properties associated with an Azure Machine learning web service.
    public partial interface IAzureMachineLearningServiceFunctionBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The API key used to authenticate with Request-Response endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The API key used to authenticate with Request-Response endpoint.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string ApiKey { get; set; }
        /// <summary>
        /// Number between 1 and 10000 describing maximum number of rows for every Azure ML RRS execute request. Default is 1000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number between 1 and 10000 describing maximum number of rows for every Azure ML RRS execute request. Default is 1000.",
        SerializedName = @"batchSize",
        PossibleTypes = new [] { typeof(int) })]
        int? BatchSize { get; set; }
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Request-Response execute endpoint of the Azure Machine Learning web service.",
        SerializedName = @"endpoint",
        PossibleTypes = new [] { typeof(string) })]
        string Endpoint { get; set; }
        /// <summary>The inputs for the Azure Machine Learning web service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The inputs for the Azure Machine Learning web service endpoint.",
        SerializedName = @"inputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] Input { get; set; }
        /// <summary>
        /// The number of parallel requests that will be sent per partition of your job to the machine learning service. Default is
        /// 1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The number of parallel requests that will be sent per partition of your job to the machine learning service. Default is 1.",
        SerializedName = @"numberOfParallelRequests",
        PossibleTypes = new [] { typeof(int) })]
        int? NumberOfParallelRequest { get; set; }
        /// <summary>
        /// A list of outputs from the Azure Machine Learning web service endpoint execution.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of outputs from the Azure Machine Learning web service endpoint execution.",
        SerializedName = @"outputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceOutputColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceOutputColumn[] Output { get; set; }

    }
    /// The binding properties associated with an Azure Machine learning web service.
    internal partial interface IAzureMachineLearningServiceFunctionBindingPropertiesInternal

    {
        /// <summary>The API key used to authenticate with Request-Response endpoint.</summary>
        string ApiKey { get; set; }
        /// <summary>
        /// Number between 1 and 10000 describing maximum number of rows for every Azure ML RRS execute request. Default is 1000.
        /// </summary>
        int? BatchSize { get; set; }
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        string Endpoint { get; set; }
        /// <summary>The inputs for the Azure Machine Learning web service endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] Input { get; set; }
        /// <summary>
        /// The number of parallel requests that will be sent per partition of your job to the machine learning service. Default is
        /// 1.
        /// </summary>
        int? NumberOfParallelRequest { get; set; }
        /// <summary>
        /// A list of outputs from the Azure Machine Learning web service endpoint execution.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceOutputColumn[] Output { get; set; }

    }
}