namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The binding retrieval properties associated with an Azure Machine learning Studio.
    /// </summary>
    public partial class AzureMachineLearningStudioFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ExecuteEndpoint" /> property.</summary>
        private string _executeEndpoint;

        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ExecuteEndpoint { get => this._executeEndpoint; set => this._executeEndpoint = value; }

        /// <summary>Backing field for <see cref="UdfType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? _udfType;

        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get => this._udfType; set => this._udfType = value; }

        /// <summary>
        /// Creates an new <see cref="AzureMachineLearningStudioFunctionBindingRetrievalProperties" /> instance.
        /// </summary>
        public AzureMachineLearningStudioFunctionBindingRetrievalProperties()
        {

        }
    }
    /// The binding retrieval properties associated with an Azure Machine learning Studio.
    public partial interface IAzureMachineLearningStudioFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
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
        string ExecuteEndpoint { get; set; }
        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The function type.",
        SerializedName = @"udfType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get; set; }

    }
    /// The binding retrieval properties associated with an Azure Machine learning Studio.
    internal partial interface IAzureMachineLearningStudioFunctionBindingRetrievalPropertiesInternal

    {
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning Studio. Find out more here: https://docs.microsoft.com/en-us/azure/machine-learning/machine-learning-consume-web-services#request-response-service-rrs
        /// </summary>
        string ExecuteEndpoint { get; set; }
        /// <summary>The function type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get; set; }

    }
}