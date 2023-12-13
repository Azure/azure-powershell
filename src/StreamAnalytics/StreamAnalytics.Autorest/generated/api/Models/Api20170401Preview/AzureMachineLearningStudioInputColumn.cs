namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes an input column for the Azure Machine Learning Studio endpoint.</summary>
    public partial class AzureMachineLearningStudioInputColumn :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputColumn,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioInputColumnInternal
    {

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private string _dataType;

        /// <summary>
        /// The (Azure Machine Learning supported) data type of the input column. A list of valid Azure Machine Learning data types
        /// are described at https://msdn.microsoft.com/en-us/library/azure/dn905923.aspx .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DataType { get => this._dataType; set => this._dataType = value; }

        /// <summary>Backing field for <see cref="MapTo" /> property.</summary>
        private int? _mapTo;

        /// <summary>The zero based index of the function parameter this input maps to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? MapTo { get => this._mapTo; set => this._mapTo = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the input column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="AzureMachineLearningStudioInputColumn" /> instance.</summary>
        public AzureMachineLearningStudioInputColumn()
        {

        }
    }
    /// Describes an input column for the Azure Machine Learning Studio endpoint.
    public partial interface IAzureMachineLearningStudioInputColumn :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The (Azure Machine Learning supported) data type of the input column. A list of valid Azure Machine Learning data types
        /// are described at https://msdn.microsoft.com/en-us/library/azure/dn905923.aspx .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The (Azure Machine Learning supported) data type of the input column. A list of valid  Azure Machine Learning data types are described at https://msdn.microsoft.com/en-us/library/azure/dn905923.aspx .",
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
        /// <summary>The name of the input column.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the input column.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Describes an input column for the Azure Machine Learning Studio endpoint.
    internal partial interface IAzureMachineLearningStudioInputColumnInternal

    {
        /// <summary>
        /// The (Azure Machine Learning supported) data type of the input column. A list of valid Azure Machine Learning data types
        /// are described at https://msdn.microsoft.com/en-us/library/azure/dn905923.aspx .
        /// </summary>
        string DataType { get; set; }
        /// <summary>The zero based index of the function parameter this input maps to.</summary>
        int? MapTo { get; set; }
        /// <summary>The name of the input column.</summary>
        string Name { get; set; }

    }
}