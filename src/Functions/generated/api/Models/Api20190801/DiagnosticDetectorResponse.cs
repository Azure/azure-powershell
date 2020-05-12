namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Class representing Response from Diagnostic Detectors</summary>
    public partial class DiagnosticDetectorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>List of Correlated events found by the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorAbnormalTimePeriod[] AbnormalTimePeriod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).AbnormalTimePeriod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).AbnormalTimePeriod = value; }

        /// <summary>Additional Data that detector wants to send.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[][] Data { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Data; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Data = value; }

        /// <summary>Instructions if any for the data source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] DataSourceInstruction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DataSourceInstruction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DataSourceInstruction = value; }

        /// <summary>Datasource Uri Links</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] DataSourceUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DataSourceUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DataSourceUri = value; }

        /// <summary>Description of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Description; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionId; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionKind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionName; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DetectorDefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionType; }

        /// <summary>Display name of the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DisplayName; }

        /// <summary>End time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? EndTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).EndTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).EndTime = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Flag representing whether detector is enabled or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).IsEnabled; }

        /// <summary>Flag representing Issue was detected.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IssueDetected { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).IssueDetected; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).IssueDetected = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Metrics provided by the detector</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticMetricSet[] Metric { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Metric; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Metric = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for DetectorDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinition Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.DetectorDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinition = value; }

        /// <summary>Internal Acessors for DetectorDefinitionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.DetectorDefinitionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionId = value; }

        /// <summary>Internal Acessors for DetectorDefinitionName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.DetectorDefinitionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionName = value; }

        /// <summary>Internal Acessors for DetectorDefinitionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDetectorDefinitionProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.DetectorDefinitionProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionProperty = value; }

        /// <summary>Internal Acessors for DetectorDefinitionType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.DetectorDefinitionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DetectorDefinitionType = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for IsEnabled</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.IsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).IsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).IsEnabled = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticDetectorResponseProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Rank</summary>
        double? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.Rank { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Rank; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Rank = value; }

        /// <summary>Internal Acessors for ResponseMetaData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResponseMetaData Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.ResponseMetaData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).ResponseMetaData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).ResponseMetaData = value; }

        /// <summary>Internal Acessors for ResponseMetaDataSource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDataSource Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseInternal.ResponseMetaDataSource { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).ResponseMetaDataSource; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).ResponseMetaDataSource = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties _property;

        /// <summary>DiagnosticDetectorResponse resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.DiagnosticDetectorResponseProperties()); set => this._property = value; }

        /// <summary>Detector Rank</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? Rank { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).Rank; }

        /// <summary>Start time of the period</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? StartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).StartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponsePropertiesInternal)Property).StartTime = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Creates an new <see cref="DiagnosticDetectorResponse" /> instance.</summary>
        public DiagnosticDetectorResponse()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Class representing Response from Diagnostic Detectors
    public partial interface IDiagnosticDetectorResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Class representing Response from Diagnostic Detectors
    internal partial interface IDiagnosticDetectorResponseInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>DiagnosticDetectorResponse resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDiagnosticDetectorResponseProperties Property { get; set; }
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