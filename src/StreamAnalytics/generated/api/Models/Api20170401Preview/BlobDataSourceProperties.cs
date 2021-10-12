namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a blob data source.</summary>
    public partial class BlobDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Container" /> property.</summary>
        private string _container;

        /// <summary>
        /// The name of a container within the associated Storage account. This container contains either the blob(s) to be read from
        /// or written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Container { get => this._container; set => this._container = value; }

        /// <summary>Backing field for <see cref="DateFormat" /> property.</summary>
        private string _dateFormat;

        /// <summary>
        /// The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DateFormat { get => this._dateFormat; set => this._dateFormat = value; }

        /// <summary>Backing field for <see cref="PathPattern" /> property.</summary>
        private string _pathPattern;

        /// <summary>
        /// The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine
        /// whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and
        /// example.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string PathPattern { get => this._pathPattern; set => this._pathPattern = value; }

        /// <summary>Backing field for <see cref="StorageAccount" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] _storageAccount;

        /// <summary>
        /// A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] StorageAccount { get => this._storageAccount; set => this._storageAccount = value; }

        /// <summary>Backing field for <see cref="TimeFormat" /> property.</summary>
        private string _timeFormat;

        /// <summary>
        /// The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string TimeFormat { get => this._timeFormat; set => this._timeFormat = value; }

        /// <summary>Creates an new <see cref="BlobDataSourceProperties" /> instance.</summary>
        public BlobDataSourceProperties()
        {

        }
    }
    /// The properties that are associated with a blob data source.
    public partial interface IBlobDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of a container within the associated Storage account. This container contains either the blob(s) to be read from
        /// or written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of a container within the associated Storage account. This container contains either the blob(s) to be read from or written to. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string Container { get; set; }
        /// <summary>
        /// The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.",
        SerializedName = @"dateFormat",
        PossibleTypes = new [] { typeof(string) })]
        string DateFormat { get; set; }
        /// <summary>
        /// The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine
        /// whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and
        /// example.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and example.",
        SerializedName = @"pathPattern",
        PossibleTypes = new [] { typeof(string) })]
        string PathPattern { get; set; }
        /// <summary>
        /// A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"storageAccounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] StorageAccount { get; set; }
        /// <summary>
        /// The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.",
        SerializedName = @"timeFormat",
        PossibleTypes = new [] { typeof(string) })]
        string TimeFormat { get; set; }

    }
    /// The properties that are associated with a blob data source.
    internal partial interface IBlobDataSourcePropertiesInternal

    {
        /// <summary>
        /// The name of a container within the associated Storage account. This container contains either the blob(s) to be read from
        /// or written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Container { get; set; }
        /// <summary>
        /// The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.
        /// </summary>
        string DateFormat { get; set; }
        /// <summary>
        /// The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine
        /// whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and
        /// example.
        /// </summary>
        string PathPattern { get; set; }
        /// <summary>
        /// A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] StorageAccount { get; set; }
        /// <summary>
        /// The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.
        /// </summary>
        string TimeFormat { get; set; }

    }
}