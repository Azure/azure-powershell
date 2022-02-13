namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// The binding retrieval properties associated with an Azure Machine learning web service.
    /// </summary>
    public partial class AzureMachineLearningServiceFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceFunctionBindingRetrievalPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private string _endpoint;

        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="UdfType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? _udfType;

        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get => this._udfType; set => this._udfType = value; }

        /// <summary>
        /// Creates an new <see cref="AzureMachineLearningServiceFunctionBindingRetrievalProperties" /> instance.
        /// </summary>
        public AzureMachineLearningServiceFunctionBindingRetrievalProperties()
        {

        }
    }
    /// The binding retrieval properties associated with an Azure Machine learning web service.
    public partial interface IAzureMachineLearningServiceFunctionBindingRetrievalProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
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
        string Endpoint { get; set; }
        /// <summary>The function type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The function type.",
        SerializedName = @"udfType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get; set; }

    }
    /// The binding retrieval properties associated with an Azure Machine learning web service.
    internal partial interface IAzureMachineLearningServiceFunctionBindingRetrievalPropertiesInternal

    {
        /// <summary>
        /// The Request-Response execute endpoint of the Azure Machine Learning web service.
        /// </summary>
        string Endpoint { get; set; }
        /// <summary>The function type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType? UdfType { get; set; }

    }
}