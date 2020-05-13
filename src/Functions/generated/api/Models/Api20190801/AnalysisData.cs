namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class Representing Detector Evidence used for analysis</summary>
    public partial class AnalysisData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisData,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal
    {

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] _data;

        /// <summary>Additional Source Data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get => this._data; set => this._data = value; }

        /// <summary>Instructions if any for the data source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] DataSourceInstruction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)DetectorMetaData).DataSourceInstruction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)DetectorMetaData).DataSourceInstruction = value; }

        /// <summary>Datasource Uri Links</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)DetectorMetaData).DataSourceUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)DetectorMetaData).DataSourceUri = value; }

        /// <summary>Description of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Description; }

        /// <summary>Backing field for <see cref="DetectorDefinition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition _detectorDefinition;

        /// <summary>Detector Definition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition DetectorDefinition { get => (this._detectorDefinition = this._detectorDefinition ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinition()); set => this._detectorDefinition = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Kind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Name; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Type; }

        /// <summary>Backing field for <see cref="DetectorMetaData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData _detectorMetaData;

        /// <summary>Detector Meta Data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData DetectorMetaData { get => (this._detectorMetaData = this._detectorMetaData ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResponseMetaData()); set => this._detectorMetaData = value; }

        /// <summary>Display name of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).DisplayName; }

        /// <summary>Flag representing whether detector is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).IsEnabled; }

        /// <summary>Backing field for <see cref="Metric" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] _metric;

        /// <summary>Source Metrics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] Metric { get => this._metric; set => this._metric = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Description = value; }

        /// <summary>Internal Acessors for DetectorDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DetectorDefinition { get => (this._detectorDefinition = this._detectorDefinition ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinition()); set { {_detectorDefinition = value;} } }

        /// <summary>Internal Acessors for DetectorDefinitionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DetectorDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Id = value; }

        /// <summary>Internal Acessors for DetectorDefinitionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DetectorDefinitionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Name = value; }

        /// <summary>Internal Acessors for DetectorDefinitionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DetectorDefinitionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Property = value; }

        /// <summary>Internal Acessors for DetectorDefinitionType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DetectorDefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Type = value; }

        /// <summary>Internal Acessors for DetectorMetaData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DetectorMetaData { get => (this._detectorMetaData = this._detectorMetaData ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResponseMetaData()); set { {_detectorMetaData = value;} } }

        /// <summary>Internal Acessors for DetectorMetaDataSource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DetectorMetaDataSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)DetectorMetaData).DataSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)DetectorMetaData).DataSource = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).DisplayName = value; }

        /// <summary>Internal Acessors for IsEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).IsEnabled = value; }

        /// <summary>Internal Acessors for Rank</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAnalysisDataInternal.Rank { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Rank; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Rank = value; }

        /// <summary>Detector Rank</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? Rank { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Rank; }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Name of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Creates an new <see cref="AnalysisData" /> instance.</summary>
        public AnalysisData()
        {

        }
    }
    /// Class Representing Detector Evidence used for analysis
    public partial interface IAnalysisData :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Additional Source Data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional Source Data",
        SerializedName = @"data",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get; set; }
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
        /// <summary>Description of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the detector",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DetectorDefinitionId { get;  }
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string DetectorDefinitionKind { get; set; }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string DetectorDefinitionName { get;  }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string DetectorDefinitionType { get;  }
        /// <summary>Display name of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display name of the detector",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Flag representing whether detector is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Flag representing whether detector is enabled or not.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get;  }
        /// <summary>Source Metrics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source Metrics",
        SerializedName = @"metrics",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] Metric { get; set; }
        /// <summary>Detector Rank</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Detector Rank",
        SerializedName = @"rank",
        PossibleTypes = new [] { typeof(double) })]
        double? Rank { get;  }
        /// <summary>Name of the Detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the Detector",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }

    }
    /// Class Representing Detector Evidence used for analysis
    internal partial interface IAnalysisDataInternal

    {
        /// <summary>Additional Source Data</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get; set; }
        /// <summary>Instructions if any for the data source</summary>
        string[] DataSourceInstruction { get; set; }
        /// <summary>Datasource Uri Links</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get; set; }
        /// <summary>Description of the detector</summary>
        string Description { get; set; }
        /// <summary>Detector Definition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition DetectorDefinition { get; set; }
        /// <summary>Resource Id.</summary>
        string DetectorDefinitionId { get; set; }
        /// <summary>Kind of resource.</summary>
        string DetectorDefinitionKind { get; set; }
        /// <summary>Resource Name.</summary>
        string DetectorDefinitionName { get; set; }
        /// <summary>DetectorDefinition resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionProperties DetectorDefinitionProperty { get; set; }
        /// <summary>Resource type.</summary>
        string DetectorDefinitionType { get; set; }
        /// <summary>Detector Meta Data</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData DetectorMetaData { get; set; }
        /// <summary>Source of the Data</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource DetectorMetaDataSource { get; set; }
        /// <summary>Display name of the detector</summary>
        string DisplayName { get; set; }
        /// <summary>Flag representing whether detector is enabled or not.</summary>
        bool? IsEnabled { get; set; }
        /// <summary>Source Metrics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] Metric { get; set; }
        /// <summary>Detector Rank</summary>
        double? Rank { get; set; }
        /// <summary>Name of the Detector</summary>
        string Source { get; set; }

    }
}