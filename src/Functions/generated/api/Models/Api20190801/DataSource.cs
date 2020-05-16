namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing data source used by the detectors</summary>
    public partial class DataSource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSourceInternal
    {

        /// <summary>Backing field for <see cref="Instruction" /> property.</summary>
        private string[] _instruction;

        /// <summary>Instructions if any for the data source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Instruction { get => this._instruction; set => this._instruction = value; }

        /// <summary>Backing field for <see cref="Uri" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] _uri;

        /// <summary>Datasource Uri Links</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] Uri { get => this._uri; set => this._uri = value; }

        /// <summary>Creates an new <see cref="DataSource" /> instance.</summary>
        public DataSource()
        {

        }
    }
    /// Class representing data source used by the detectors
    public partial interface IDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Instructions if any for the data source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Instructions if any for the data source",
        SerializedName = @"instructions",
        PossibleTypes = new [] { typeof(string) })]
        string[] Instruction { get; set; }
        /// <summary>Datasource Uri Links</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Datasource Uri Links",
        SerializedName = @"dataSourceUri",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] Uri { get; set; }

    }
    /// Class representing data source used by the detectors
    internal partial interface IDataSourceInternal

    {
        /// <summary>Instructions if any for the data source</summary>
        string[] Instruction { get; set; }
        /// <summary>Datasource Uri Links</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] Uri { get; set; }

    }
}