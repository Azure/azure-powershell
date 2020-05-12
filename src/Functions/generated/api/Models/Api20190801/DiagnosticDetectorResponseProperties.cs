namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>DiagnosticDetectorResponse resource specific properties</summary>
    public partial class DiagnosticDetectorResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AbnormalTimePeriod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] _abnormalTimePeriod;

        /// <summary>List of Correlated events found by the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] AbnormalTimePeriod { get => this._abnormalTimePeriod; set => this._abnormalTimePeriod = value; }

        /// <summary>Backing field for <see cref="Data" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] _data;

        /// <summary>Additional Data that detector wants to send.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get => this._data; set => this._data = value; }

        /// <summary>Instructions if any for the data source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] DataSourceInstruction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)ResponseMetaData).DataSourceInstruction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)ResponseMetaData).DataSourceInstruction = value; }

        /// <summary>Datasource Uri Links</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)ResponseMetaData).DataSourceUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)ResponseMetaData).DataSourceUri = value; }

        /// <summary>Description of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Description; }

        /// <summary>Backing field for <see cref="DetectorDefinition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition _detectorDefinition;

        /// <summary>Detector's definition</summary>
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

        /// <summary>Display name of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).DisplayName; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Flag representing whether detector is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).IsEnabled; }

        /// <summary>Backing field for <see cref="IssueDetected" /> property.</summary>
        private bool? _issueDetected;

        /// <summary>Flag representing Issue was detected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IssueDetected { get => this._issueDetected; set => this._issueDetected = value; }

        /// <summary>Backing field for <see cref="Metric" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] _metric;

        /// <summary>Metrics provided by the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] Metric { get => this._metric; set => this._metric = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Description = value; }

        /// <summary>Internal Acessors for DetectorDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.DetectorDefinition { get => (this._detectorDefinition = this._detectorDefinition ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DetectorDefinition()); set { {_detectorDefinition = value;} } }

        /// <summary>Internal Acessors for DetectorDefinitionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.DetectorDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Id = value; }

        /// <summary>Internal Acessors for DetectorDefinitionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.DetectorDefinitionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Name = value; }

        /// <summary>Internal Acessors for DetectorDefinitionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.DetectorDefinitionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Property = value; }

        /// <summary>Internal Acessors for DetectorDefinitionType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.DetectorDefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)DetectorDefinition).Type = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).DisplayName = value; }

        /// <summary>Internal Acessors for IsEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).IsEnabled = value; }

        /// <summary>Internal Acessors for Rank</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.Rank { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Rank; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Rank = value; }

        /// <summary>Internal Acessors for ResponseMetaData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.ResponseMetaData { get => (this._responseMetaData = this._responseMetaData ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResponseMetaData()); set { {_responseMetaData = value;} } }

        /// <summary>Internal Acessors for ResponseMetaDataSource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal.ResponseMetaDataSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)ResponseMetaData).DataSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaDataInternal)ResponseMetaData).DataSource = value; }

        /// <summary>Detector Rank</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? Rank { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionInternal)DetectorDefinition).Rank; }

        /// <summary>Backing field for <see cref="ResponseMetaData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData _responseMetaData;

        /// <summary>Meta Data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData ResponseMetaData { get => (this._responseMetaData = this._responseMetaData ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResponseMetaData()); set => this._responseMetaData = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Creates an new <see cref="DiagnosticDetectorResponseProperties" /> instance.</summary>
        public DiagnosticDetectorResponseProperties()
        {

        }
    }
    /// DiagnosticDetectorResponse resource specific properties
    public partial interface IDiagnosticDetectorResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of Correlated events found by the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Correlated events found by the detector",
        SerializedName = @"abnormalTimePeriods",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] AbnormalTimePeriod { get; set; }
        /// <summary>Additional Data that detector wants to send.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional Data that detector wants to send.",
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
        /// <summary>End time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time of the period",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Flag representing whether detector is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Flag representing whether detector is enabled or not.",
        SerializedName = @"isEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsEnabled { get;  }
        /// <summary>Flag representing Issue was detected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag representing Issue was detected.",
        SerializedName = @"issueDetected",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IssueDetected { get; set; }
        /// <summary>Metrics provided by the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metrics provided by the detector",
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
        /// <summary>Start time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time of the period",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }

    }
    /// DiagnosticDetectorResponse resource specific properties
    internal partial interface IDiagnosticDetectorResponsePropertiesInternal

    {
        /// <summary>List of Correlated events found by the detector</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] AbnormalTimePeriod { get; set; }
        /// <summary>Additional Data that detector wants to send.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get; set; }
        /// <summary>Instructions if any for the data source</summary>
        string[] DataSourceInstruction { get; set; }
        /// <summary>Datasource Uri Links</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get; set; }
        /// <summary>Description of the detector</summary>
        string Description { get; set; }
        /// <summary>Detector's definition</summary>
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
        /// <summary>Display name of the detector</summary>
        string DisplayName { get; set; }
        /// <summary>End time of the period</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Flag representing whether detector is enabled or not.</summary>
        bool? IsEnabled { get; set; }
        /// <summary>Flag representing Issue was detected.</summary>
        bool? IssueDetected { get; set; }
        /// <summary>Metrics provided by the detector</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] Metric { get; set; }
        /// <summary>Detector Rank</summary>
        double? Rank { get; set; }
        /// <summary>Meta Data</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData ResponseMetaData { get; set; }
        /// <summary>Source of the Data</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource ResponseMetaDataSource { get; set; }
        /// <summary>Start time of the period</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}