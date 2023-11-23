namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes an output column for the Azure Machine Learning web service endpoint.</summary>
    public partial class AzureMachineLearningServiceOutputColumn :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceOutputColumn,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningServiceOutputColumnInternal
    {

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private string _dataType;

        /// <summary>The (Azure Machine Learning supported) data type of the output column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DataType { get => this._dataType; set => this._dataType = value; }

        /// <summary>Backing field for <see cref="MapTo" /> property.</summary>
        private int? _mapTo;

        /// <summary>The zero based index of the function parameter this input maps to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? MapTo { get => this._mapTo; set => this._mapTo = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the output column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="AzureMachineLearningServiceOutputColumn" /> instance.</summary>
        public AzureMachineLearningServiceOutputColumn()
        {

        }
    }
    /// Describes an output column for the Azure Machine Learning web service endpoint.
    public partial interface IAzureMachineLearningServiceOutputColumn :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The (Azure Machine Learning supported) data type of the output column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The (Azure Machine Learning supported) data type of the output column.",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        string DataType { get; set; }
        /// <summary>The zero based index of the function parameter this input maps to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The zero based index of the function parameter this input maps to.",
        SerializedName = @"mapTo",
        PossibleTypes = new [] { typeof(int) })]
        int? MapTo { get; set; }
        /// <summary>The name of the output column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the output column.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Describes an output column for the Azure Machine Learning web service endpoint.
    internal partial interface IAzureMachineLearningServiceOutputColumnInternal

    {
        /// <summary>The (Azure Machine Learning supported) data type of the output column.</summary>
        string DataType { get; set; }
        /// <summary>The zero based index of the function parameter this input maps to.</summary>
        int? MapTo { get; set; }
        /// <summary>The name of the output column.</summary>
        string Name { get; set; }

    }
}