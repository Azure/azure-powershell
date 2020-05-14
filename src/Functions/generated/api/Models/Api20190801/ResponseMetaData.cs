namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class ResponseMetaData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal
    {

        /// <summary>Backing field for <see cref="DataSource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource _dataSource;

        /// <summary>Source of the Data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource DataSource { get => (this._dataSource = this._dataSource ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataSource()); set => this._dataSource = value; }

        /// <summary>Instructions if any for the data source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] DataSourceInstruction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSourceInternal)DataSource).Instruction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSourceInternal)DataSource).Instruction = value; }

        /// <summary>Datasource Uri Links</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSourceInternal)DataSource).Uri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSourceInternal)DataSource).Uri = value; }

        /// <summary>Internal Acessors for DataSource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal.DataSource { get => (this._dataSource = this._dataSource ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DataSource()); set { {_dataSource = value;} } }

        /// <summary>Creates an new <see cref="ResponseMetaData" /> instance.</summary>
        public ResponseMetaData()
        {

        }
    }
    public partial interface IResponseMetaData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Instructions if any for the data source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Instructions if any for the data source",
        SerializedName = @"instructions",
        PossibleTypes = new [] { typeof(string) })]
        string[] DataSourceInstruction { get; set; }
        /// <summary>Datasource Uri Links</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Datasource Uri Links",
        SerializedName = @"dataSourceUri",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get; set; }

    }
    internal partial interface IResponseMetaDataInternal

    {
        /// <summary>Source of the Data</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource DataSource { get; set; }
        /// <summary>Instructions if any for the data source</summary>
        string[] DataSourceInstruction { get; set; }
        /// <summary>Datasource Uri Links</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get; set; }

    }
}