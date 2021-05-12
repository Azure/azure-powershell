namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes one input parameter of a function.</summary>
    public partial class FunctionInput :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionInput,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionInputInternal
    {

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private string _dataType;

        /// <summary>
        /// The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics
        /// data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DataType { get => this._dataType; set => this._dataType = value; }

        /// <summary>Backing field for <see cref="IsConfigurationParameter" /> property.</summary>
        private bool? _isConfigurationParameter;

        /// <summary>
        /// A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant.
        /// Default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public bool? IsConfigurationParameter { get => this._isConfigurationParameter; set => this._isConfigurationParameter = value; }

        /// <summary>Creates an new <see cref="FunctionInput" /> instance.</summary>
        public FunctionInput()
        {

        }
    }
    /// Describes one input parameter of a function.
    public partial interface IFunctionInput :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics
        /// data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        string DataType { get; set; }
        /// <summary>
        /// A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant.
        /// Default is false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant. Default is false.",
        SerializedName = @"isConfigurationParameter",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsConfigurationParameter { get; set; }

    }
    /// Describes one input parameter of a function.
    internal partial interface IFunctionInputInternal

    {
        /// <summary>
        /// The (Azure Stream Analytics supported) data type of the function input parameter. A list of valid Azure Stream Analytics
        /// data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
        /// </summary>
        string DataType { get; set; }
        /// <summary>
        /// A flag indicating if the parameter is a configuration parameter. True if this input parameter is expected to be a constant.
        /// Default is false.
        /// </summary>
        bool? IsConfigurationParameter { get; set; }

    }
}