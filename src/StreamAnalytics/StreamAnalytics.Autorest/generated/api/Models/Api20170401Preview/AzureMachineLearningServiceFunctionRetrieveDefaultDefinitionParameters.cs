namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning web service function.
    /// </summary>
    public partial class AzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParameters,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters __functionRetrieveDefaultDefinitionParameters = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.FunctionRetrieveDefaultDefinitionParameters();

        /// <summary>Backing field for <see cref="BindingRetrievalProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalProperties _bindingRetrievalProperty;

        /// <summary>
        /// The binding retrieval properties associated with an Azure Machine learning web service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalProperties BindingRetrievalProperty { get => (this._bindingRetrievalProperty = this._bindingRetrievalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningServiceFunctionBindingRetrievalProperties()); set => this._bindingRetrievalProperty = value; }

        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string BindingRetrievalPropertyEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).Endpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).Endpoint = value ?? null; }

        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).UdfType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalPropertiesInternal)BindingRetrievalProperty).UdfType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType)""); }

        /// <summary>Indicates the function binding type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string BindingType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)__functionRetrieveDefaultDefinitionParameters).BindingType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)__functionRetrieveDefaultDefinitionParameters).BindingType = value ; }

        /// <summary>Internal Acessors for BindingRetrievalProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParametersInternal.BindingRetrievalProperty { get => (this._bindingRetrievalProperty = this._bindingRetrievalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningServiceFunctionBindingRetrievalProperties()); set { {_bindingRetrievalProperty = value;} } }

        /// <summary>
        /// Creates an new <see cref="AzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParameters" /> instance.
        /// </summary>
        public AzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParameters()
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
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning web service function.
    public partial interface IAzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParameters :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParameters
    {
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Request-Response execute endpoint of the Azure Machine Learning web service.",
        SerializedName = @"endpoint",
        PossibleTypes = new [] { typeof(string) })]
        string BindingRetrievalPropertyEndpoint { get; set; }
        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The function type.",
        SerializedName = @"udfType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get; set; }

    }
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning web service function.
    internal partial interface IAzureMachineLearningServiceFunctionRetrieveDefaultDefinitionParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal
    {
        /// <summary>
        /// The binding retrieval properties associated with an Azure Machine learning web service.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalProperties BindingRetrievalProperty { get; set; }
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        string BindingRetrievalPropertyEndpoint { get; set; }
        /// <summary>The function type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? BindingRetrievalPropertyUdfType { get; set; }

    }
}