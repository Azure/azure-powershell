namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning Studio function.
    /// </summary>
    public partial class AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters __functionRetrieveDefaultDefinitionParameters = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.FunctionRetrieveDefaultDefinitionParameters();

        /// <summary>Backing field for <see cref="BindingRetrievalProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalProperties _bindingRetrievalProperty;

        /// <summary>
        /// The binding retrieval properties associated with an Azure Machine learning Studio.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalProperties BindingRetrievalProperty { get => (this._bindingRetrievalProperty = this._bindingRetrievalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionBindingRetrievalProperties()); set => this._bindingRetrievalProperty = value; }

        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string BindingRetrievalPropertyExecuteEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).ExecuteEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).ExecuteEndpoint = value ?? null; }

        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).UdfType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).UdfType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType)""); }

        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string BindingType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)__functionRetrieveDefaultDefinitionParameters).BindingType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)__functionRetrieveDefaultDefinitionParameters).BindingType = value ; }

        /// <summary>Internal Acessors for BindingRetrievalProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal.BindingRetrievalProperty { get => (this._bindingRetrievalProperty = this._bindingRetrievalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionBindingRetrievalProperties()); set { {_bindingRetrievalProperty = value;} } }

        /// <summary>
        /// Creates an new <see cref="AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters" /> instance.
        /// </summary>
        public AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters()
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
            await eventListener.AssertNotNull(nameof(__functionRetrieveDefaultDefinitionParameters), __functionRetrieveDefaultDefinitionParameters);
            await eventListener.AssertObjectIsValid(nameof(__functionRetrieveDefaultDefinitionParameters), __functionRetrieveDefaultDefinitionParameters);
        }
    }
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning Studio function.
    public partial interface IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters
    {
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs",
        SerializedName = @"executeEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string BindingRetrievalPropertyExecuteEndpoint { get; set; }
        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The function type.",
        SerializedName = @"udfType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get; set; }

    }
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning Studio function.
    internal partial interface IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal
    {
        /// <summary>
        /// The binding retrieval properties associated with an Azure Machine learning Studio.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalProperties BindingRetrievalProperty { get; set; }
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        string BindingRetrievalPropertyExecuteEndpoint { get; set; }
        /// <summary>The function type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get; set; }

    }
}