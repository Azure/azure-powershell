namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding to an Azure Machine Learning Studio.</summary>
    public partial class AzureMachineLearningStudioFunctionBinding :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBinding,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBinding"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBinding __functionBinding = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.FunctionBinding();

        /// <summary>The API key used to authenticate with Request-Response endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ApiKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).ApiKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).ApiKey = value ?? null; }

        /// <summary>
        /// Number between 1 and 10000 describing maximum number of rows for every Azure ML RRS execute request. Default is 1000.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? BatchSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).BatchSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).BatchSize = value ?? default(int); }

        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Endpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).Endpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).Endpoint = value ?? null; }

        /// <summary>A list of input columns for the Azure Machine Learning Studio endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputColumn[] InputColumnName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).InputColumnName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).InputColumnName = value ?? null /* arrayOf */; }

        /// <summary>The name of the input. This is the name provided while authoring the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string InputName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).InputName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).InputName = value ?? null; }

        /// <summary>Internal Acessors for Input</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputs Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingInternal.Input { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).Input; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).Input = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionBindingProperties()); set { {_property = value;} } }

        /// <summary>A list of outputs from the Azure Machine Learning Studio endpoint execution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioOutputColumn[] Output { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).Output; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingPropertiesInternal)Property).Output = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingProperties _property;

        /// <summary>The binding properties associated with an Azure Machine learning Studio.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionBindingProperties()); set => this._property = value; }

        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBindingInternal)__functionBinding).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBindingInternal)__functionBinding).Type = value ; }

        /// <summary>
        /// Creates an new <see cref="AzureMachineLearningStudioFunctionBinding" /> instance.
        /// </summary>
        public AzureMachineLearningStudioFunctionBinding()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__functionBinding), __functionBinding);
            await eventListener.AssertObjectIsValid(nameof(__functionBinding), __functionBinding);
        }
    }
    /// The binding to an Azure Machine Learning Studio.
    public partial interface IAzureMachineLearningStudioFunctionBinding :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBinding
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
    /// The binding to an Azure Machine Learning Studio.
    internal partial interface IAzureMachineLearningStudioFunctionBindingInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionBindingInternal
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
        /// <summary>The binding properties associated with an Azure Machine learning Studio.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingProperties Property { get; set; }

    }
}