namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes the output of a function.</summary>
    public partial class FunctionOutput :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionOutput,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionOutputInternal
    {

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private string _dataType;

        /// <summary>
        /// The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types
        /// are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DataType { get => this._dataType; set => this._dataType = value; }

        /// <summary>Creates an new <see cref="FunctionOutput" /> instance.</summary>
        public FunctionOutput()
        {

        }
    }
    /// Describes the output of a function.
    public partial interface IFunctionOutput :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types
        /// are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        string DataType { get; set; }

    }
    /// Describes the output of a function.
    internal partial interface IFunctionOutputInternal

    {
        /// <summary>
        /// The (Azure Stream Analytics supported) data type of the function output. A list of valid Azure Stream Analytics data types
        /// are described at https://msdn.microsoft.com/en-us/library/azure/dn835065.aspx
        /// </summary>
        string DataType { get; set; }

    }
}