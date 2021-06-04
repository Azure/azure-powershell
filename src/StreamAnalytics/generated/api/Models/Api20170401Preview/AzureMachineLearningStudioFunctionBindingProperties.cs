namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding properties associated with an Azure Machine learning Studio.</summary>
    public partial class AzureMachineLearningStudioFunctionBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal
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
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="Input" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputs _input;

        /// <summary>The inputs for the Azure Machine Learning Studio endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputs Input { get => (this._input = this._input ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioInputs()); set => this._input = value; }

        /// <summary>A list of input columns for the Azure Machine Learning Studio endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputColumn[] InputColumnName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputsInternal)Input).ColumnName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputsInternal)Input).ColumnName = value ?? null /* arrayOf */; }

        /// <summary>The name of the input. This is the name provided while authoring the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string InputName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputsInternal)Input).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputsInternal)Input).Name = value ?? null; }

        /// <summary>Internal Acessors for Input</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputs Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal.Input { get => (this._input = this._input ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioInputs()); set { {_input = value;} } }

        /// <summary>Backing field for <see cref="Output" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioOutputColumn[] _output;

        /// <summary>A list of outputs from the Azure Machine Learning Studio endpoint execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioOutputColumn[] Output { get => this._output; set => this._output = value; }

        /// <summary>
        /// Creates an new <see cref="AzureMachineLearningStudioFunctionBindingProperties" /> instance.
        /// </summary>
        public AzureMachineLearningStudioFunctionBindingProperties()
        {

        }
    }
    /// The binding properties associated with an Azure Machine learning Studio.
    public partial interface IAzureMachineLearningStudioFunctionBindingProperties :
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
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs",
        SerializedName = @"endpoint",
        PossibleTypes = new [] { typeof(string) })]
        string Endpoint { get; set; }
        /// <summary>A list of input columns for the Azure Machine Learning Studio endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of input columns for the Azure Machine Learning Studio endpoint.",
        SerializedName = @"columnNames",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputColumn[] InputColumnName { get; set; }
        /// <summary>The name of the input. This is the name provided while authoring the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the input. This is the name provided while authoring the endpoint.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string InputName { get; set; }
        /// <summary>A list of outputs from the Azure Machine Learning Studio endpoint execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of outputs from the Azure Machine Learning Studio endpoint execution.",
        SerializedName = @"outputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioOutputColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioOutputColumn[] Output { get; set; }

    }
    /// The binding properties associated with an Azure Machine learning Studio.
    internal partial interface IAzureMachineLearningStudioFunctionBindingPropertiesInternal

    {
        /// <summary>The API key used to authenticate with Request-Response endpoint.</summary>
        string ApiKey { get; set; }
        /// <summary>
        /// Number between 1 and 10000 describing maximum number of rows for every Azure ML RRS execute request. Default is 1000.
        /// </summary>
        int? BatchSize { get; set; }
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        string Endpoint { get; set; }
        /// <summary>The inputs for the Azure Machine Learning Studio endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputs Input { get; set; }
        /// <summary>A list of input columns for the Azure Machine Learning Studio endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputColumn[] InputColumnName { get; set; }
        /// <summary>The name of the input. This is the name provided while authoring the endpoint.</summary>
        string InputName { get; set; }
        /// <summary>A list of outputs from the Azure Machine Learning Studio endpoint execution.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioOutputColumn[] Output { get; set; }

    }
}