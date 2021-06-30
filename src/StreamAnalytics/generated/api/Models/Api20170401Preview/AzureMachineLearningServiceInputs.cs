namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The inputs for the Azure Machine Learning web service endpoint.</summary>
    public partial class AzureMachineLearningServiceInputs :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputs,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputsInternal
    {

        /// <summary>Backing field for <see cref="ColumnName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] _columnName;

        /// <summary>A list of input columns for the Azure Machine Learning web service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] ColumnName { get => this._columnName; set => this._columnName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the input. This is the name provided while authoring the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="AzureMachineLearningServiceInputs" /> instance.</summary>
        public AzureMachineLearningServiceInputs()
        {

        }
    }
    /// The inputs for the Azure Machine Learning web service endpoint.
    public partial interface IAzureMachineLearningServiceInputs :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>A list of input columns for the Azure Machine Learning web service endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of input columns for the Azure Machine Learning web service endpoint.",
        SerializedName = @"columnNames",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] ColumnName { get; set; }
        /// <summary>The name of the input. This is the name provided while authoring the endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the input. This is the name provided while authoring the endpoint.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The inputs for the Azure Machine Learning web service endpoint.
    internal partial interface IAzureMachineLearningServiceInputsInternal

    {
        /// <summary>A list of input columns for the Azure Machine Learning web service endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceInputColumn[] ColumnName { get; set; }
        /// <summary>The name of the input. This is the name provided while authoring the endpoint.</summary>
        string Name { get; set; }

    }
}